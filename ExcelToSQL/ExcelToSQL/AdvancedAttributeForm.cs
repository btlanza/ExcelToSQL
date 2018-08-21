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
    public partial class AdvancedAttributeForm : Form
    {

        private SQLTypeDef tdRef;       // Persistent reference to SQLTypeDef being edited
        private SQLTypeDef tdCng;       // Temporary copy of edited SQLTypeDef to validate changes

        // Constructor
        public AdvancedAttributeForm(SQLTypeDef typeDef)
        {
            InitializeComponent();
            tdRef = typeDef;
            tdCng = SQLTypeDefFactory.getCopy(typeDef);
        }

        // Run when the form loads
        private void AdvancedAttributeForm_Load(object sender, EventArgs e)
        {

            string[] attributeParams = tdCng.getParams();
            foreach(string s in attributeParams)
            {
                cboxParameter.Items.Add(s);
            }
            cboxParameter.SelectedIndex = 0;

            // Manually call the parameterChangedListener so that changes work as expected
            parameterChangedListener(null, null);

            // Activate event listeners
            cboxParameter.SelectedIndexChanged += new EventHandler(parameterChangedListener);
            numParameterVal.ValueChanged += new EventHandler(valueChangedListener);

        }

        // Run when the confirm button is pressed
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            // Checks that changes are valid
            string errStr = "";
            if (!tdCng.isValid(out errStr))
            {
                MessageBox.Show(errStr, "Error");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            // Copies valid changes to the original type definition
            string[] attributeParams = tdCng.getParams();
            foreach(string s in attributeParams)
            {
                tdRef.setParam(s, tdCng.getParam(s));
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        // Run when the attribute value is changed on the UI
        private void valueChangedListener(object sender, EventArgs e)
        {
            tdCng.setParam(cboxParameter.Text, (int)numParameterVal.Value);
        }

        // Run when the parameter choice is changed
        private void parameterChangedListener(object sender, EventArgs e)
        {

            string currentParam = cboxParameter.Text;
            int paramVal = tdCng.getParam(currentParam);
            numParameterVal.Minimum = tdCng.getMinParamVal(currentParam);
            numParameterVal.Maximum = tdCng.getMaxParamVal(currentParam);
            numParameterVal.Value = paramVal;

        }
    }
}
