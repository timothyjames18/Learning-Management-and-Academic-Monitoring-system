namespace Learning_Management_and_Academic_Monitoring_system.Admin_Dashboard
{
    partial class EnrollStudent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCourses = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.btnEnrollStudent = new Guna.UI2.WinForms.Guna2Button();
            this.cmbStudents = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbCourses = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvEnrollments = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCourses
            // 
            this.lblCourses.AutoSize = true;
            this.lblCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourses.Location = new System.Drawing.Point(141, 234);
            this.lblCourses.Name = "lblCourses";
            this.lblCourses.Size = new System.Drawing.Size(80, 24);
            this.lblCourses.TabIndex = 0;
            this.lblCourses.Text = "Courses";
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.Location = new System.Drawing.Point(141, 184);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(74, 24);
            this.lblStudent.TabIndex = 1;
            this.lblStudent.Text = "Student";
            // 
            // btnEnrollStudent
            // 
            this.btnEnrollStudent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEnrollStudent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEnrollStudent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEnrollStudent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEnrollStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEnrollStudent.ForeColor = System.Drawing.Color.White;
            this.btnEnrollStudent.Location = new System.Drawing.Point(244, 349);
            this.btnEnrollStudent.Name = "btnEnrollStudent";
            this.btnEnrollStudent.Size = new System.Drawing.Size(180, 45);
            this.btnEnrollStudent.TabIndex = 2;
            this.btnEnrollStudent.Text = "Enroll";
            this.btnEnrollStudent.Click += new System.EventHandler(this.btnEnrollStudent_Click_1);
            // 
            // cmbStudents
            // 
            this.cmbStudents.BackColor = System.Drawing.Color.Transparent;
            this.cmbStudents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudents.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStudents.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStudents.ItemHeight = 30;
            this.cmbStudents.Location = new System.Drawing.Point(244, 172);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(180, 36);
            this.cmbStudents.TabIndex = 3;
            // 
            // cmbCourses
            // 
            this.cmbCourses.BackColor = System.Drawing.Color.Transparent;
            this.cmbCourses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourses.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCourses.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCourses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCourses.ItemHeight = 30;
            this.cmbCourses.Location = new System.Drawing.Point(244, 222);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(180, 36);
            this.cmbCourses.TabIndex = 4;
            // 
            // dgvEnrollments
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvEnrollments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEnrollments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEnrollments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEnrollments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEnrollments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEnrollments.Location = new System.Drawing.Point(595, 172);
            this.dgvEnrollments.Name = "dgvEnrollments";
            this.dgvEnrollments.RowHeadersVisible = false;
            this.dgvEnrollments.Size = new System.Drawing.Size(240, 150);
            this.dgvEnrollments.TabIndex = 5;
            this.dgvEnrollments.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEnrollments.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvEnrollments.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvEnrollments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvEnrollments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvEnrollments.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEnrollments.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEnrollments.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvEnrollments.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEnrollments.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEnrollments.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEnrollments.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrollments.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvEnrollments.ThemeStyle.ReadOnly = false;
            this.dgvEnrollments.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEnrollments.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEnrollments.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEnrollments.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEnrollments.ThemeStyle.RowsStyle.Height = 22;
            this.dgvEnrollments.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEnrollments.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // EnrollStudent
            // 
            this.ClientSize = new System.Drawing.Size(987, 646);
            this.Controls.Add(this.dgvEnrollments);
            this.Controls.Add(this.cmbCourses);
            this.Controls.Add(this.cmbStudents);
            this.Controls.Add(this.btnEnrollStudent);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnrollStudent";
            this.Load += new System.EventHandler(this.EnrollStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalSubj;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSubjects;
        private System.Windows.Forms.Label lblCourses;
        private System.Windows.Forms.Label lblStudent;
        private Guna.UI2.WinForms.Guna2Button btnEnrollStudent;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStudents;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCourses;
        private Guna.UI2.WinForms.Guna2DataGridView dgvEnrollments;
    }
}