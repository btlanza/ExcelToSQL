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
    public partial class PrimaryKeyForm : Form
    {

        private List<Column> columns;
        private List<int> newKey;

        public PrimaryKeyForm(List<Column> columns, out List<int> newKey)
        {
            InitializeComponent();
            this.columns = columns;
            newKey = new List<int>();
            this.newKey = newKey;

            btnCancel.Enabled = true;
            btnApply.Enabled = false;
        }

        private void PrimaryKeyForm_Load(object sender, EventArgs e)
        {

            foreach (Column column in this.columns)
            {
                cboxColumnName.Items.Add(column.getName());
            }
            cboxColumnName.SelectedIndex = 0;
            cboxColumnName.SelectedIndexChanged += new EventHandler(cboxColumnName_SelectedIndexChanged);

        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            newKey.Add(cboxColumnName.SelectedIndex);
            btnAddColumn.Enabled = !newKey.Contains(cboxColumnName.SelectedIndex);
            btnApply.Enabled = true;
        }

        private void cboxColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddColumn.Enabled = !newKey.Contains(cboxColumnName.SelectedIndex);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }
    }
}
