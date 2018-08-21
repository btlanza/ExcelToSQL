using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToSQL
{
    public partial class MainForm : Form
    {

        // Private fields
        private List<Column> columns;                   // Stores all column/attribute SQL type definitions
        private List<List<int>> primaryKeys;            // Stores lists of column indexes representing primary keys

        // Global working variables
        private SQLTypeDef currentEditDef;

        // Private constants
        private static long FILE_SIZE_WARNING_CUTOFF = 80;   // Excel file size warning cutoff in KB

        // Constructor
        public MainForm()
        {
            InitializeComponent();
        }

        // Run when the form loads
        private void MainForm_Load(object sender, EventArgs e)
        {
            setInitialUIState();
            cboxAttributeType.SelectedIndexChanged += new EventHandler(cboxAttributeType_SelectedIndexChanged);
            this.primaryKeys = new List<List<int>>();
            // TestClass.run();
        }

        // Set the initial enabled/disabled states for UI elements
        private void setInitialUIState()
        {

            // Excel file input group elements
            grpExcelInput.Enabled = true;
            txtExcelPath.Enabled = false;
            btnBrowseExcel.Enabled = true;
            lblWorksheetNumber.Enabled = true;
            numWorksheetNumber.Enabled = true;
            btnLoadData.Enabled = false;

            // Table options group elements
            grpTableOptions.Enabled = false;
            lblTableName.Enabled = true;
            txtTableName.Enabled = true;
            lblCurrentAttribute.Enabled = true;
            cboxCurrentAttribute.Enabled = true;
            btnEditAttribute.Enabled = true;

            // Attribute options group elements
            grpAttributeOptions.Enabled = false;
            lblAttributeName.Enabled = true;
            txtAttributeName.Enabled = true;
            lblAttributeType.Enabled = true;
            cboxAttributeType.Enabled = true;
            btnAdvancedAttribute.Enabled = false;
            btnSaveAttribute.Enabled = true;

            // SQL file output group elements
            grpSQLOutput.Enabled = false;
            txtSQLPath.Enabled = false;
            btnBrowseSQL.Enabled = true;
            btnGenerateSQL.Enabled = false;
            btnAddPrimaryKey.Enabled = true;

        }

        // Run when the Excel file browse button is pressed
        private void btnBrowseExcel_Click(object sender, EventArgs e)
        {

            // Clears previous file path
            txtExcelPath.Text = "";

            // Get Excel file path from user
            OpenFileDialog excelFileDialog = new OpenFileDialog();
            excelFileDialog.InitialDirectory = @"c:\\";
            excelFileDialog.Filter = "Microsoft Excel Files (*.xlsx)|*.xlsx";
            excelFileDialog.Multiselect = false;
            if(excelFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnLoadData.Enabled = true;
                txtExcelPath.Text = excelFileDialog.FileName;
            }
            else
            {
                btnLoadData.Enabled = false;
                txtExcelPath.Text = "Excel File Path";
                MessageBox.Show("Please select a valid Excel file.", "Selected file invalid");
            }

        }

        // Run when the load Excel file button is pressed
        private void btnLoadData_Click(object sender, EventArgs e)
        {

            // Warning for big files
            long excelFileSizeKB = (new System.IO.FileInfo(txtExcelPath.Text).Length) / 1000;
            if(excelFileSizeKB > FILE_SIZE_WARNING_CUTOFF)
            {
                DialogResult sizeResult = MessageBox.Show("The given Excel file is pretty big, so this could take a while! Do you wish to continue?",
                    "Size Warning", MessageBoxButtons.YesNo);
                if(sizeResult == DialogResult.No) return;
            }

            ExcelReader reader;
            
            // Try to read Excel file
            try
            {
                reader = new ExcelReader(txtExcelPath.Text);
            }
            catch(System.IO.FileNotFoundException ex)
            {
                btnLoadData.Enabled = false;
                txtExcelPath.Text = "Excel File Path";
                MessageBox.Show(ex.Message, "Exception");
                return;
            }

            // Get column data and parse it for the program (takes a while)
            this.columns = ColumnFactory.getColumnsFromCells(reader.getCellText());
            
            if(columns.Count <= 0)
            {
                MessageBox.Show("Excel file is empty or there was a formatting issue!", "Failed");
                setInitialUIState();
                return;
            }

            txtTableName.Text = "MyNewTable";
            foreach(Column column in columns)
            {
                // if(column.getName() != null)
                cboxCurrentAttribute.Items.Add(column.getName());
            }

            cboxCurrentAttribute.SelectedIndex = 0;

            // Enable controls
            grpTableOptions.Enabled = true;
            grpSQLOutput.Enabled = true;
            grpExcelInput.Enabled = false;

            // Tell user it's ready
            MessageBox.Show("Completed loading and analysis of the Excel file!", "Success");

        }

        // Run when the edit current attribute button is pressed
        private void btnEditAttribute_Click(object sender, EventArgs e)
        {

            grpSQLOutput.Enabled = false;
            cboxCurrentAttribute.Enabled = false;
            btnEditAttribute.Enabled = false;
            grpAttributeOptions.Enabled = true;

            int columnIndex = cboxCurrentAttribute.SelectedIndex;

            txtAttributeName.Text = columns[columnIndex].getName();
            cboxAttributeType.Items.Clear();
            foreach(SQLTypeDef.SQLTypeID typeID in (SQLTypeDef.SQLTypeID[])Enum.GetValues(typeof(SQLTypeDef.SQLTypeID))){
                cboxAttributeType.Items.Add(SQLTypeDef.getSQLTypeName(typeID));
            }

            cboxAttributeType.SelectedIndex = (int)columns[columnIndex].getTypeID();
            if(columns[columnIndex].getTypeDef().getParams().Length == 0) btnAdvancedAttribute.Enabled = false;
            else btnAdvancedAttribute.Enabled = true;

            currentEditDef = columns[columnIndex].getTypeDef();

        }

        // Run when the advanced button is pressed
        private void btnAdvancedAttribute_Click(object sender, EventArgs e)
        {

            int columnIndex = cboxCurrentAttribute.SelectedIndex;
            SQLTypeDef def = SQLTypeDefFactory.getCopy(currentEditDef);

            AdvancedAttributeForm popupForm = new AdvancedAttributeForm(def);
            if(popupForm.ShowDialog(this) == DialogResult.OK)
            {
                currentEditDef = def;
                MessageBox.Show("Successfully saved attribute parameter changes!", "Success");
            }
            else
            {
                MessageBox.Show("Attribute parameter changes have been cancelled!", "Cancelled");
            }

        }

        // Run when the save current attribute button is pressed
        private void btnSaveAttribute_Click(object sender, EventArgs e)
        {

            grpAttributeOptions.Enabled = false;
            grpSQLOutput.Enabled = true;
            cboxCurrentAttribute.Enabled = true;
            btnEditAttribute.Enabled = true;

            int columnIndex = cboxCurrentAttribute.SelectedIndex;
            columns[columnIndex].setTypeDef(currentEditDef);

        }

        // Run when the attribute type is changed
        private void cboxAttributeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int columnIndex = cboxCurrentAttribute.SelectedIndex;

            currentEditDef = SQLTypeDefFactory.getNew((SQLTypeDef.SQLTypeID)cboxAttributeType.SelectedIndex);

            if (currentEditDef.getParams().Length == 0) btnAdvancedAttribute.Enabled = false;
            else btnAdvancedAttribute.Enabled = true;
        }

        // Run when the SQL output file browse button is pressed
        private void btnBrowseSQL_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sqlFileDialog = new SaveFileDialog();
            sqlFileDialog.Filter = "SQL files (*.sql)|*.sql";
            sqlFileDialog.RestoreDirectory = true;
            sqlFileDialog.OverwritePrompt = true;
            if(sqlFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnGenerateSQL.Enabled = true;
                txtSQLPath.Text = sqlFileDialog.FileName;
            }
            else
            {
                btnGenerateSQL.Enabled = false;
                txtSQLPath.Text = "SQL File Path";
            }

        }

        // Run when the generate SQL button is pressed
        private void btnGenerateSQL_Click(object sender, EventArgs e)
        {
            List<string> lines = SQLFactory.getSQLLines(txtTableName.Text, this.columns, this.primaryKeys);
            SQLFactory.writeLinesToFile(txtSQLPath.Text, lines);
            DialogResult dialogCont = MessageBox.Show("Finished generating the SQL file! Would you like to start over?", "Success", MessageBoxButtons.YesNo);
            if(dialogCont == DialogResult.No || dialogCont == DialogResult.Cancel) Application.Exit();
            else
            {
                setInitialUIState();
                this.columns = new List<Column>();
                this.primaryKeys = new List<List<int>>();
                txtExcelPath.Text = "Excel File Path";
                txtSQLPath.Text = "SQL File Path";
            }
        }

        // Run when the add primary key button is clicked
        private void btnAddPrimaryKey_Click(object sender, EventArgs e)
        {

            // List<string> lines = SQLFactory.getSQLLines("Lol", this.columns);
            // MessageBox.Show("Feature coming soon!", "Add Primary Key");

            List<int> newKey = new List<int>();

            PrimaryKeyForm popupForm = new PrimaryKeyForm(this.columns, out newKey);
            if(popupForm.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show("Successfully added primary key!", "Success");
                this.primaryKeys.Add(new List<int>(newKey));
                btnAddPrimaryKey.Enabled = false;
            }
            else
            {
                MessageBox.Show("Primary key addition has been cancelled!", "Cancelled");
            }

        }

        // Run when the cancel attribute edits button is clicked
        private void btnCancelAttribute_Click(object sender, EventArgs e)
        {
            grpAttributeOptions.Enabled = false;
            grpSQLOutput.Enabled = true;
            cboxCurrentAttribute.Enabled = true;
            btnEditAttribute.Enabled = true;
        }

    }
}
