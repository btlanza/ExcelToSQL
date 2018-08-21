namespace ExcelToSQL
{
    partial class AdvancedAttributeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cboxParameter = new System.Windows.Forms.ComboBox();
            this.lblParameter = new System.Windows.Forms.Label();
            this.numParameterVal = new System.Windows.Forms.NumericUpDown();
            this.lblParameterVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numParameterVal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(12, 65);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(242, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cboxParameter
            // 
            this.cboxParameter.FormattingEnabled = true;
            this.cboxParameter.Location = new System.Drawing.Point(73, 12);
            this.cboxParameter.Name = "cboxParameter";
            this.cboxParameter.Size = new System.Drawing.Size(181, 21);
            this.cboxParameter.TabIndex = 1;
            // 
            // lblParameter
            // 
            this.lblParameter.AutoSize = true;
            this.lblParameter.Location = new System.Drawing.Point(9, 15);
            this.lblParameter.Name = "lblParameter";
            this.lblParameter.Size = new System.Drawing.Size(58, 13);
            this.lblParameter.TabIndex = 2;
            this.lblParameter.Text = "Parameter:";
            // 
            // numParameterVal
            // 
            this.numParameterVal.Location = new System.Drawing.Point(73, 39);
            this.numParameterVal.Name = "numParameterVal";
            this.numParameterVal.Size = new System.Drawing.Size(181, 20);
            this.numParameterVal.TabIndex = 3;
            // 
            // lblParameterVal
            // 
            this.lblParameterVal.AutoSize = true;
            this.lblParameterVal.Location = new System.Drawing.Point(9, 41);
            this.lblParameterVal.Name = "lblParameterVal";
            this.lblParameterVal.Size = new System.Drawing.Size(37, 13);
            this.lblParameterVal.TabIndex = 4;
            this.lblParameterVal.Text = "Value:";
            // 
            // AdvancedAttributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 99);
            this.Controls.Add(this.lblParameterVal);
            this.Controls.Add(this.numParameterVal);
            this.Controls.Add(this.lblParameter);
            this.Controls.Add(this.cboxParameter);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdvancedAttributeForm";
            this.ShowIcon = false;
            this.Text = "Advanced Attribute Options";
            this.Load += new System.EventHandler(this.AdvancedAttributeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numParameterVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cboxParameter;
        private System.Windows.Forms.Label lblParameter;
        private System.Windows.Forms.NumericUpDown numParameterVal;
        private System.Windows.Forms.Label lblParameterVal;
    }
}