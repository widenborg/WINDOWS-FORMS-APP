namespace Assignment5Forms
{
    partial class Form1
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
            this.dataGridViewDataBase = new System.Windows.Forms.DataGridView();
            this.btnGetAllConstraints = new System.Windows.Forms.Button();
            this.btnGetAllKeys = new System.Windows.Forms.Button();
            this.btnReadAllIndexes = new System.Windows.Forms.Button();
            this.btnReadEmployeeAndRelatedTables = new System.Windows.Forms.Button();
            this.btnSickEmployees2004 = new System.Windows.Forms.Button();
            this.btnMostAbsentEmployee = new System.Windows.Forms.Button();
            this.btnGetAllTables1 = new System.Windows.Forms.Button();
            this.btnGetAllTables2 = new System.Windows.Forms.Button();
            this.btnGetEmployeeAndRelatives = new System.Windows.Forms.Button();
            this.btnGetEmployeeColumns1 = new System.Windows.Forms.Button();
            this.btnGetEmployeeColumns2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDataBase
            // 
            this.dataGridViewDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataBase.Location = new System.Drawing.Point(109, 26);
            this.dataGridViewDataBase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewDataBase.Name = "dataGridViewDataBase";
            this.dataGridViewDataBase.RowHeadersWidth = 51;
            this.dataGridViewDataBase.RowTemplate.Height = 24;
            this.dataGridViewDataBase.Size = new System.Drawing.Size(696, 311);
            this.dataGridViewDataBase.TabIndex = 0;
            // 
            // btnGetAllConstraints
            // 
            this.btnGetAllConstraints.Location = new System.Drawing.Point(109, 341);
            this.btnGetAllConstraints.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetAllConstraints.Name = "btnGetAllConstraints";
            this.btnGetAllConstraints.Size = new System.Drawing.Size(100, 38);
            this.btnGetAllConstraints.TabIndex = 1;
            this.btnGetAllConstraints.Text = "Get All Constraints";
            this.btnGetAllConstraints.UseVisualStyleBackColor = true;
            this.btnGetAllConstraints.Click += new System.EventHandler(this.BtnGetAllConstraints_Click);
            // 
            // btnGetAllKeys
            // 
            this.btnGetAllKeys.Location = new System.Drawing.Point(213, 341);
            this.btnGetAllKeys.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetAllKeys.Name = "btnGetAllKeys";
            this.btnGetAllKeys.Size = new System.Drawing.Size(73, 38);
            this.btnGetAllKeys.TabIndex = 2;
            this.btnGetAllKeys.Text = "Get All Keys";
            this.btnGetAllKeys.UseVisualStyleBackColor = true;
            this.btnGetAllKeys.Click += new System.EventHandler(this.BtnGetAllKeys_Click);
            // 
            // btnReadAllIndexes
            // 
            this.btnReadAllIndexes.Location = new System.Drawing.Point(290, 341);
            this.btnReadAllIndexes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReadAllIndexes.Name = "btnReadAllIndexes";
            this.btnReadAllIndexes.Size = new System.Drawing.Size(97, 38);
            this.btnReadAllIndexes.TabIndex = 3;
            this.btnReadAllIndexes.Text = "Get All Indexes";
            this.btnReadAllIndexes.UseVisualStyleBackColor = true;
            this.btnReadAllIndexes.Click += new System.EventHandler(this.BtnReadAllIndexes_Click);
            // 
            // btnReadEmployeeAndRelatedTables
            // 
            this.btnReadEmployeeAndRelatedTables.Location = new System.Drawing.Point(391, 341);
            this.btnReadEmployeeAndRelatedTables.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReadEmployeeAndRelatedTables.Name = "btnReadEmployeeAndRelatedTables";
            this.btnReadEmployeeAndRelatedTables.Size = new System.Drawing.Size(127, 38);
            this.btnReadEmployeeAndRelatedTables.TabIndex = 4;
            this.btnReadEmployeeAndRelatedTables.Text = "Get Employee And Related Tables";
            this.btnReadEmployeeAndRelatedTables.UseVisualStyleBackColor = true;
            this.btnReadEmployeeAndRelatedTables.Click += new System.EventHandler(this.BtnReadEmployeeAndRelatedTables_Click);
            // 
            // btnSickEmployees2004
            // 
            this.btnSickEmployees2004.Location = new System.Drawing.Point(523, 341);
            this.btnSickEmployees2004.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSickEmployees2004.Name = "btnSickEmployees2004";
            this.btnSickEmployees2004.Size = new System.Drawing.Size(145, 38);
            this.btnSickEmployees2004.TabIndex = 5;
            this.btnSickEmployees2004.Text = "Get Sick Employees 2004";
            this.btnSickEmployees2004.UseVisualStyleBackColor = true;
            this.btnSickEmployees2004.Click += new System.EventHandler(this.BtnSickEmployees2004_Click);
            // 
            // btnMostAbsentEmployee
            // 
            this.btnMostAbsentEmployee.Location = new System.Drawing.Point(672, 341);
            this.btnMostAbsentEmployee.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMostAbsentEmployee.Name = "btnMostAbsentEmployee";
            this.btnMostAbsentEmployee.Size = new System.Drawing.Size(133, 38);
            this.btnMostAbsentEmployee.TabIndex = 6;
            this.btnMostAbsentEmployee.Text = "Most Absent Employee";
            this.btnMostAbsentEmployee.UseVisualStyleBackColor = true;
            this.btnMostAbsentEmployee.Click += new System.EventHandler(this.BtnMostAbsentEmployee_Click);
            // 
            // btnGetAllTables1
            // 
            this.btnGetAllTables1.Location = new System.Drawing.Point(109, 384);
            this.btnGetAllTables1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetAllTables1.Name = "btnGetAllTables1";
            this.btnGetAllTables1.Size = new System.Drawing.Size(94, 38);
            this.btnGetAllTables1.TabIndex = 7;
            this.btnGetAllTables1.Text = "Get All Tables 1";
            this.btnGetAllTables1.UseVisualStyleBackColor = true;
            this.btnGetAllTables1.Click += new System.EventHandler(this.BtnGetAllTables1_Click);
            // 
            // btnGetAllTables2
            // 
            this.btnGetAllTables2.Location = new System.Drawing.Point(207, 384);
            this.btnGetAllTables2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetAllTables2.Name = "btnGetAllTables2";
            this.btnGetAllTables2.Size = new System.Drawing.Size(92, 38);
            this.btnGetAllTables2.TabIndex = 8;
            this.btnGetAllTables2.Text = "Get All Tables 2";
            this.btnGetAllTables2.UseVisualStyleBackColor = true;
            this.btnGetAllTables2.Click += new System.EventHandler(this.BtnGetAllTables2_Click);
            // 
            // btnGetEmployeeAndRelatives
            // 
            this.btnGetEmployeeAndRelatives.Location = new System.Drawing.Point(304, 384);
            this.btnGetEmployeeAndRelatives.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetEmployeeAndRelatives.Name = "btnGetEmployeeAndRelatives";
            this.btnGetEmployeeAndRelatives.Size = new System.Drawing.Size(158, 38);
            this.btnGetEmployeeAndRelatives.TabIndex = 9;
            this.btnGetEmployeeAndRelatives.Text = "Get Employees And Relatives";
            this.btnGetEmployeeAndRelatives.UseVisualStyleBackColor = true;
            this.btnGetEmployeeAndRelatives.Click += new System.EventHandler(this.BtnGetEmployeeAndRelatives_Click);
            // 
            // btnGetEmployeeColumns1
            // 
            this.btnGetEmployeeColumns1.Location = new System.Drawing.Point(467, 384);
            this.btnGetEmployeeColumns1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetEmployeeColumns1.Name = "btnGetEmployeeColumns1";
            this.btnGetEmployeeColumns1.Size = new System.Drawing.Size(150, 38);
            this.btnGetEmployeeColumns1.TabIndex = 10;
            this.btnGetEmployeeColumns1.Text = "Get Employee Columns 1";
            this.btnGetEmployeeColumns1.UseVisualStyleBackColor = true;
            this.btnGetEmployeeColumns1.Click += new System.EventHandler(this.BtnGetEmployeeColumns1_Click);
            // 
            // btnGetEmployeeColumns2
            // 
            this.btnGetEmployeeColumns2.Location = new System.Drawing.Point(621, 384);
            this.btnGetEmployeeColumns2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetEmployeeColumns2.Name = "btnGetEmployeeColumns2";
            this.btnGetEmployeeColumns2.Size = new System.Drawing.Size(184, 38);
            this.btnGetEmployeeColumns2.TabIndex = 11;
            this.btnGetEmployeeColumns2.Text = "Get Employee Columns 2";
            this.btnGetEmployeeColumns2.UseVisualStyleBackColor = true;
            this.btnGetEmployeeColumns2.Click += new System.EventHandler(this.BtnGetEmployeeColumns2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 480);
            this.Controls.Add(this.btnGetEmployeeColumns2);
            this.Controls.Add(this.btnGetEmployeeColumns1);
            this.Controls.Add(this.btnGetEmployeeAndRelatives);
            this.Controls.Add(this.btnGetAllTables2);
            this.Controls.Add(this.btnGetAllTables1);
            this.Controls.Add(this.btnMostAbsentEmployee);
            this.Controls.Add(this.btnSickEmployees2004);
            this.Controls.Add(this.btnReadEmployeeAndRelatedTables);
            this.Controls.Add(this.btnReadAllIndexes);
            this.Controls.Add(this.btnGetAllKeys);
            this.Controls.Add(this.btnGetAllConstraints);
            this.Controls.Add(this.dataGridViewDataBase);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDataBase;
        private System.Windows.Forms.Button btnGetAllConstraints;
        private System.Windows.Forms.Button btnGetAllKeys;
        private System.Windows.Forms.Button btnReadAllIndexes;
        private System.Windows.Forms.Button btnReadEmployeeAndRelatedTables;
        private System.Windows.Forms.Button btnSickEmployees2004;
        private System.Windows.Forms.Button btnMostAbsentEmployee;
        private System.Windows.Forms.Button btnGetAllTables1;
        private System.Windows.Forms.Button btnGetAllTables2;
        private System.Windows.Forms.Button btnGetEmployeeAndRelatives;
        private System.Windows.Forms.Button btnGetEmployeeColumns1;
        private System.Windows.Forms.Button btnGetEmployeeColumns2;
    }
}

