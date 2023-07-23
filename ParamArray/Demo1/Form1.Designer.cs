namespace Demo1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnShow = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            txtDepartmentNo = new TextBox();
            txtDepartmentName = new TextBox();
            txtDepartmentAdd = new TextBox();
            lblDeptNo = new Label();
            lblDeptName = new Label();
            lblDeptAdd = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnShow
            // 
            btnShow.Location = new Point(718, 355);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 0;
            btnShow.Text = "Show All\r\n";
            btnShow.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(614, 355);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 23);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(508, 355);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(401, 355);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(347, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(480, 290);
            dataGridView1.TabIndex = 4;
            // 
            // txtDepartmentNo
            // 
            txtDepartmentNo.Location = new Point(200, 76);
            txtDepartmentNo.Name = "txtDepartmentNo";
            txtDepartmentNo.Size = new Size(100, 23);
            txtDepartmentNo.TabIndex = 5;
            txtDepartmentNo.TextChanged += textBox1_TextChanged;
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Location = new Point(200, 160);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(100, 23);
            txtDepartmentName.TabIndex = 6;
            txtDepartmentName.TextChanged += txtDepartmentName_TextChanged;
            // 
            // txtDepartmentAdd
            // 
            txtDepartmentAdd.Location = new Point(200, 250);
            txtDepartmentAdd.Name = "txtDepartmentAdd";
            txtDepartmentAdd.Size = new Size(100, 23);
            txtDepartmentAdd.TabIndex = 7;
            // 
            // lblDeptNo
            // 
            lblDeptNo.AutoSize = true;
            lblDeptNo.Location = new Point(47, 79);
            lblDeptNo.Name = "lblDeptNo";
            lblDeptNo.Size = new Size(147, 15);
            lblDeptNo.TabIndex = 8;
            lblDeptNo.Text = "Enter Department Number";
            lblDeptNo.Click += label1_Click;
            // 
            // lblDeptName
            // 
            lblDeptName.AutoSize = true;
            lblDeptName.Location = new Point(47, 163);
            lblDeptName.Name = "lblDeptName";
            lblDeptName.Size = new Size(135, 15);
            lblDeptName.TabIndex = 9;
            lblDeptName.Text = "Enter Department Name";
            lblDeptName.Click += label2_Click;
            // 
            // lblDeptAdd
            // 
            lblDeptAdd.AutoSize = true;
            lblDeptAdd.Location = new Point(47, 253);
            lblDeptAdd.Name = "lblDeptAdd";
            lblDeptAdd.Size = new Size(149, 15);
            lblDeptAdd.TabIndex = 10;
            lblDeptAdd.Text = "Enter Department Location";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 464);
            Controls.Add(lblDeptAdd);
            Controls.Add(lblDeptName);
            Controls.Add(lblDeptNo);
            Controls.Add(txtDepartmentAdd);
            Controls.Add(txtDepartmentName);
            Controls.Add(txtDepartmentNo);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(btnShow);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnShow;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private TextBox txtDepartmentNo;
        private TextBox txtDepartmentName;
        private TextBox txtDepartmentAdd;
        private Label lblDeptNo;
        private Label lblDeptName;
        private Label lblDeptAdd;
    }
}