namespace ExcelToSQL
{
    partial class MainForm
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
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.btnBrowseExcel = new System.Windows.Forms.Button();
            this.grpExcelInput = new System.Windows.Forms.GroupBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.numWorksheetNumber = new System.Windows.Forms.NumericUpDown();
            this.lblWorksheetNumber = new System.Windows.Forms.Label();
            this.grpTableOptions = new System.Windows.Forms.GroupBox();
            this.grpAttributeOptions = new System.Windows.Forms.GroupBox();
            this.btnCancelAttribute = new System.Windows.Forms.Button();
            this.btnAdvancedAttribute = new System.Windows.Forms.Button();
            this.btnSaveAttribute = new System.Windows.Forms.Button();
            this.cboxAttributeType = new System.Windows.Forms.ComboBox();
            this.lblAttributeType = new System.Windows.Forms.Label();
            this.txtAttributeName = new System.Windows.Forms.TextBox();
            this.lblAttributeName = new System.Windows.Forms.Label();
            this.btnEditAttribute = new System.Windows.Forms.Button();
            this.cboxCurrentAttribute = new System.Windows.Forms.ComboBox();
            this.lblCurrentAttribute = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.grpSQLOutput = new System.Windows.Forms.GroupBox();
            this.btnAddPrimaryKey = new System.Windows.Forms.Button();
            this.btnGenerateSQL = new System.Windows.Forms.Button();
            this.btnBrowseSQL = new System.Windows.Forms.Button();
            this.txtSQLPath = new System.Windows.Forms.TextBox();
            this.grpExcelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWorksheetNumber)).BeginInit();
            this.grpTableOptions.SuspendLayout();
            this.grpAttributeOptions.SuspendLayout();
            this.grpSQLOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Enabled = false;
            this.txtExcelPath.Location = new System.Drawing.Point(6, 19);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(264, 20);
            this.txtExcelPath.TabIndex = 0;
            this.txtExcelPath.Text = "Excel File Path";
            // 
            // btnBrowseExcel
            // 
            this.btnBrowseExcel.Location = new System.Drawing.Point(276, 17);
            this.btnBrowseExcel.Name = "btnBrowseExcel";
            this.btnBrowseExcel.Size = new System.Drawing.Size(78, 23);
            this.btnBrowseExcel.TabIndex = 1;
            this.btnBrowseExcel.Text = "Browse";
            this.btnBrowseExcel.UseVisualStyleBackColor = true;
            this.btnBrowseExcel.Click += new System.EventHandler(this.btnBrowseExcel_Click);
            // 
            // grpExcelInput
            // 
            this.grpExcelInput.Controls.Add(this.btnLoadData);
            this.grpExcelInput.Controls.Add(this.numWorksheetNumber);
            this.grpExcelInput.Controls.Add(this.lblWorksheetNumber);
            this.grpExcelInput.Controls.Add(this.txtExcelPath);
            this.grpExcelInput.Controls.Add(this.btnBrowseExcel);
            this.grpExcelInput.Location = new System.Drawing.Point(12, 12);
            this.grpExcelInput.Name = "grpExcelInput";
            this.grpExcelInput.Size = new System.Drawing.Size(360, 83);
            this.grpExcelInput.TabIndex = 2;
            this.grpExcelInput.TabStop = false;
            this.grpExcelInput.Text = "Select an Excel File";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Enabled = false;
            this.btnLoadData.Location = new System.Drawing.Point(276, 46);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(78, 23);
            this.btnLoadData.TabIndex = 4;
            this.btnLoadData.Text = "Load";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // numWorksheetNumber
            // 
            this.numWorksheetNumber.Location = new System.Drawing.Point(114, 49);
            this.numWorksheetNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWorksheetNumber.Name = "numWorksheetNumber";
            this.numWorksheetNumber.Size = new System.Drawing.Size(156, 20);
            this.numWorksheetNumber.TabIndex = 3;
            this.numWorksheetNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWorksheetNumber
            // 
            this.lblWorksheetNumber.AutoSize = true;
            this.lblWorksheetNumber.Location = new System.Drawing.Point(6, 51);
            this.lblWorksheetNumber.Name = "lblWorksheetNumber";
            this.lblWorksheetNumber.Size = new System.Drawing.Size(102, 13);
            this.lblWorksheetNumber.TabIndex = 2;
            this.lblWorksheetNumber.Text = "Worksheet Number:";
            // 
            // grpTableOptions
            // 
            this.grpTableOptions.Controls.Add(this.grpAttributeOptions);
            this.grpTableOptions.Controls.Add(this.btnEditAttribute);
            this.grpTableOptions.Controls.Add(this.cboxCurrentAttribute);
            this.grpTableOptions.Controls.Add(this.lblCurrentAttribute);
            this.grpTableOptions.Controls.Add(this.txtTableName);
            this.grpTableOptions.Controls.Add(this.lblTableName);
            this.grpTableOptions.Enabled = false;
            this.grpTableOptions.Location = new System.Drawing.Point(12, 101);
            this.grpTableOptions.Name = "grpTableOptions";
            this.grpTableOptions.Size = new System.Drawing.Size(360, 183);
            this.grpTableOptions.TabIndex = 3;
            this.grpTableOptions.TabStop = false;
            this.grpTableOptions.Text = "Table Options";
            // 
            // grpAttributeOptions
            // 
            this.grpAttributeOptions.Controls.Add(this.btnCancelAttribute);
            this.grpAttributeOptions.Controls.Add(this.btnAdvancedAttribute);
            this.grpAttributeOptions.Controls.Add(this.btnSaveAttribute);
            this.grpAttributeOptions.Controls.Add(this.cboxAttributeType);
            this.grpAttributeOptions.Controls.Add(this.lblAttributeType);
            this.grpAttributeOptions.Controls.Add(this.txtAttributeName);
            this.grpAttributeOptions.Controls.Add(this.lblAttributeName);
            this.grpAttributeOptions.Enabled = false;
            this.grpAttributeOptions.Location = new System.Drawing.Point(6, 72);
            this.grpAttributeOptions.Name = "grpAttributeOptions";
            this.grpAttributeOptions.Size = new System.Drawing.Size(348, 105);
            this.grpAttributeOptions.TabIndex = 4;
            this.grpAttributeOptions.TabStop = false;
            this.grpAttributeOptions.Text = "Attribute Options";
            // 
            // btnCancelAttribute
            // 
            this.btnCancelAttribute.Location = new System.Drawing.Point(192, 72);
            this.btnCancelAttribute.Name = "btnCancelAttribute";
            this.btnCancelAttribute.Size = new System.Drawing.Size(72, 23);
            this.btnCancelAttribute.TabIndex = 10;
            this.btnCancelAttribute.Text = "Cancel";
            this.btnCancelAttribute.UseVisualStyleBackColor = true;
            this.btnCancelAttribute.Click += new System.EventHandler(this.btnCancelAttribute_Click);
            // 
            // btnAdvancedAttribute
            // 
            this.btnAdvancedAttribute.Location = new System.Drawing.Point(9, 72);
            this.btnAdvancedAttribute.Name = "btnAdvancedAttribute";
            this.btnAdvancedAttribute.Size = new System.Drawing.Size(177, 23);
            this.btnAdvancedAttribute.TabIndex = 9;
            this.btnAdvancedAttribute.Text = "Advanced";
            this.btnAdvancedAttribute.UseVisualStyleBackColor = true;
            this.btnAdvancedAttribute.Click += new System.EventHandler(this.btnAdvancedAttribute_Click);
            // 
            // btnSaveAttribute
            // 
            this.btnSaveAttribute.Location = new System.Drawing.Point(270, 72);
            this.btnSaveAttribute.Name = "btnSaveAttribute";
            this.btnSaveAttribute.Size = new System.Drawing.Size(72, 23);
            this.btnSaveAttribute.TabIndex = 8;
            this.btnSaveAttribute.Text = "Save";
            this.btnSaveAttribute.UseVisualStyleBackColor = true;
            this.btnSaveAttribute.Click += new System.EventHandler(this.btnSaveAttribute_Click);
            // 
            // cboxAttributeType
            // 
            this.cboxAttributeType.FormattingEnabled = true;
            this.cboxAttributeType.Location = new System.Drawing.Point(50, 45);
            this.cboxAttributeType.Name = "cboxAttributeType";
            this.cboxAttributeType.Size = new System.Drawing.Size(292, 21);
            this.cboxAttributeType.TabIndex = 8;
            // 
            // lblAttributeType
            // 
            this.lblAttributeType.AutoSize = true;
            this.lblAttributeType.Location = new System.Drawing.Point(6, 48);
            this.lblAttributeType.Name = "lblAttributeType";
            this.lblAttributeType.Size = new System.Drawing.Size(34, 13);
            this.lblAttributeType.TabIndex = 5;
            this.lblAttributeType.Text = "Type:";
            // 
            // txtAttributeName
            // 
            this.txtAttributeName.Location = new System.Drawing.Point(50, 19);
            this.txtAttributeName.Name = "txtAttributeName";
            this.txtAttributeName.Size = new System.Drawing.Size(292, 20);
            this.txtAttributeName.TabIndex = 4;
            // 
            // lblAttributeName
            // 
            this.lblAttributeName.AutoSize = true;
            this.lblAttributeName.Location = new System.Drawing.Point(6, 22);
            this.lblAttributeName.Name = "lblAttributeName";
            this.lblAttributeName.Size = new System.Drawing.Size(38, 13);
            this.lblAttributeName.TabIndex = 0;
            this.lblAttributeName.Text = "Name:";
            // 
            // btnEditAttribute
            // 
            this.btnEditAttribute.Location = new System.Drawing.Point(276, 45);
            this.btnEditAttribute.Name = "btnEditAttribute";
            this.btnEditAttribute.Size = new System.Drawing.Size(78, 23);
            this.btnEditAttribute.TabIndex = 7;
            this.btnEditAttribute.Text = "Edit";
            this.btnEditAttribute.UseVisualStyleBackColor = true;
            this.btnEditAttribute.Click += new System.EventHandler(this.btnEditAttribute_Click);
            // 
            // cboxCurrentAttribute
            // 
            this.cboxCurrentAttribute.FormattingEnabled = true;
            this.cboxCurrentAttribute.Location = new System.Drawing.Point(104, 45);
            this.cboxCurrentAttribute.Name = "cboxCurrentAttribute";
            this.cboxCurrentAttribute.Size = new System.Drawing.Size(166, 21);
            this.cboxCurrentAttribute.TabIndex = 6;
            // 
            // lblCurrentAttribute
            // 
            this.lblCurrentAttribute.AutoSize = true;
            this.lblCurrentAttribute.Location = new System.Drawing.Point(6, 48);
            this.lblCurrentAttribute.Name = "lblCurrentAttribute";
            this.lblCurrentAttribute.Size = new System.Drawing.Size(86, 13);
            this.lblCurrentAttribute.TabIndex = 4;
            this.lblCurrentAttribute.Text = "Current Attribute:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(104, 19);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(250, 20);
            this.txtTableName.TabIndex = 5;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(6, 22);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(92, 13);
            this.lblTableName.TabIndex = 4;
            this.lblTableName.Text = "SQL Table Name:";
            // 
            // grpSQLOutput
            // 
            this.grpSQLOutput.Controls.Add(this.btnAddPrimaryKey);
            this.grpSQLOutput.Controls.Add(this.btnGenerateSQL);
            this.grpSQLOutput.Controls.Add(this.btnBrowseSQL);
            this.grpSQLOutput.Controls.Add(this.txtSQLPath);
            this.grpSQLOutput.Enabled = false;
            this.grpSQLOutput.Location = new System.Drawing.Point(12, 290);
            this.grpSQLOutput.Name = "grpSQLOutput";
            this.grpSQLOutput.Size = new System.Drawing.Size(360, 76);
            this.grpSQLOutput.TabIndex = 4;
            this.grpSQLOutput.TabStop = false;
            this.grpSQLOutput.Text = "Generate a SQL File";
            // 
            // btnAddPrimaryKey
            // 
            this.btnAddPrimaryKey.Location = new System.Drawing.Point(6, 45);
            this.btnAddPrimaryKey.Name = "btnAddPrimaryKey";
            this.btnAddPrimaryKey.Size = new System.Drawing.Size(102, 23);
            this.btnAddPrimaryKey.TabIndex = 12;
            this.btnAddPrimaryKey.Text = "Add Primary Key";
            this.btnAddPrimaryKey.UseVisualStyleBackColor = true;
            this.btnAddPrimaryKey.Click += new System.EventHandler(this.btnAddPrimaryKey_Click);
            // 
            // btnGenerateSQL
            // 
            this.btnGenerateSQL.Location = new System.Drawing.Point(114, 46);
            this.btnGenerateSQL.Name = "btnGenerateSQL";
            this.btnGenerateSQL.Size = new System.Drawing.Size(240, 23);
            this.btnGenerateSQL.TabIndex = 11;
            this.btnGenerateSQL.Text = "Generate SQL";
            this.btnGenerateSQL.UseVisualStyleBackColor = true;
            this.btnGenerateSQL.Click += new System.EventHandler(this.btnGenerateSQL_Click);
            // 
            // btnBrowseSQL
            // 
            this.btnBrowseSQL.Location = new System.Drawing.Point(276, 17);
            this.btnBrowseSQL.Name = "btnBrowseSQL";
            this.btnBrowseSQL.Size = new System.Drawing.Size(78, 23);
            this.btnBrowseSQL.TabIndex = 5;
            this.btnBrowseSQL.Text = "Browse";
            this.btnBrowseSQL.UseVisualStyleBackColor = true;
            this.btnBrowseSQL.Click += new System.EventHandler(this.btnBrowseSQL_Click);
            // 
            // txtSQLPath
            // 
            this.txtSQLPath.Enabled = false;
            this.txtSQLPath.Location = new System.Drawing.Point(6, 19);
            this.txtSQLPath.Name = "txtSQLPath";
            this.txtSQLPath.Size = new System.Drawing.Size(264, 20);
            this.txtSQLPath.TabIndex = 10;
            this.txtSQLPath.Text = "SQL File Path";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 374);
            this.Controls.Add(this.grpSQLOutput);
            this.Controls.Add(this.grpTableOptions);
            this.Controls.Add(this.grpExcelInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "ExcelToSQL";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpExcelInput.ResumeLayout(false);
            this.grpExcelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWorksheetNumber)).EndInit();
            this.grpTableOptions.ResumeLayout(false);
            this.grpTableOptions.PerformLayout();
            this.grpAttributeOptions.ResumeLayout(false);
            this.grpAttributeOptions.PerformLayout();
            this.grpSQLOutput.ResumeLayout(false);
            this.grpSQLOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Button btnBrowseExcel;
        private System.Windows.Forms.GroupBox grpExcelInput;
        private System.Windows.Forms.Label lblWorksheetNumber;
        private System.Windows.Forms.NumericUpDown numWorksheetNumber;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.GroupBox grpTableOptions;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblCurrentAttribute;
        private System.Windows.Forms.ComboBox cboxCurrentAttribute;
        private System.Windows.Forms.Button btnEditAttribute;
        private System.Windows.Forms.GroupBox grpAttributeOptions;
        private System.Windows.Forms.Label lblAttributeName;
        private System.Windows.Forms.TextBox txtAttributeName;
        private System.Windows.Forms.ComboBox cboxAttributeType;
        private System.Windows.Forms.Label lblAttributeType;
        private System.Windows.Forms.Button btnSaveAttribute;
        private System.Windows.Forms.GroupBox grpSQLOutput;
        private System.Windows.Forms.TextBox txtSQLPath;
        private System.Windows.Forms.Button btnBrowseSQL;
        private System.Windows.Forms.Button btnGenerateSQL;
        private System.Windows.Forms.Button btnAdvancedAttribute;
        private System.Windows.Forms.Button btnAddPrimaryKey;
        private System.Windows.Forms.Button btnCancelAttribute;
    }
}

