namespace Learning_Management_and_Academic_Monitoring_system.Admin_Dashboard
{
    partial class EnrollInstructor
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
            this.lblTotalSubj = new System.Windows.Forms.Label();
            this.flowLayoutPanelSubjects = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTotalSubj
            // 
            this.lblTotalSubj.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalSubj.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalSubj.ForeColor = System.Drawing.Color.White;
            this.lblTotalSubj.Location = new System.Drawing.Point(0, 0);
            this.lblTotalSubj.Name = "lblTotalSubj";
            this.lblTotalSubj.Size = new System.Drawing.Size(1050, 32);
            this.lblTotalSubj.TabIndex = 0;
            this.lblTotalSubj.Text = "Enrolled in 0 subject";
            // 
            // flowLayoutPanelSubjects
            // 
            this.flowLayoutPanelSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSubjects.Location = new System.Drawing.Point(0, 32);
            this.flowLayoutPanelSubjects.Name = "flowLayoutPanelSubjects";
            this.flowLayoutPanelSubjects.Size = new System.Drawing.Size(1050, 641);
            this.flowLayoutPanelSubjects.TabIndex = 1;
            // 
            // Courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 673);
            this.Controls.Add(this.flowLayoutPanelSubjects);
            this.Controls.Add(this.lblTotalSubj);
            this.Name = "Courses";
            this.Text = "Schedule";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalSubj;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSubjects;
    }
}