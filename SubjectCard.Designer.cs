namespace Learning_Management_and_Academic_Monitoring_system
{
    partial class SubjectCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSchedule = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRoom = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.progressCompletion = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.btnView = new Guna.UI2.WinForms.Guna2Button();
            this.btnActivities = new Guna.UI2.WinForms.Guna2Button();
            this.lblDetails = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.progressCompletion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(16, 163);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(23, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // lblSchedule
            // 
            this.lblSchedule.BackColor = System.Drawing.Color.Transparent;
            this.lblSchedule.Location = new System.Drawing.Point(16, 184);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(48, 15);
            this.lblSchedule.TabIndex = 1;
            this.lblSchedule.Text = "Schedule";
            // 
            // lblRoom
            // 
            this.lblRoom.BackColor = System.Drawing.Color.Transparent;
            this.lblRoom.Location = new System.Drawing.Point(16, 205);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(31, 15);
            this.lblRoom.TabIndex = 2;
            this.lblRoom.Text = "Room";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(16, 246);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(47, 15);
            this.guna2HtmlLabel4.TabIndex = 3;
            this.guna2HtmlLabel4.Text = "Instructor";
            // 
            // progressCompletion
            // 
            this.progressCompletion.Controls.Add(this.lblProgressBar);
            this.progressCompletion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.progressCompletion.FillThickness = 15;
            this.progressCompletion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.progressCompletion.ForeColor = System.Drawing.Color.White;
            this.progressCompletion.Location = new System.Drawing.Point(43, 17);
            this.progressCompletion.Minimum = 0;
            this.progressCompletion.Name = "progressCompletion";
            this.progressCompletion.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.progressCompletion.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.progressCompletion.Size = new System.Drawing.Size(125, 125);
            this.progressCompletion.TabIndex = 4;
            this.progressCompletion.Text = "Activities Completed";
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = true;
            this.lblProgressBar.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBar.ForeColor = System.Drawing.Color.Black;
            this.lblProgressBar.Location = new System.Drawing.Point(29, 49);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(65, 29);
            this.lblProgressBar.TabIndex = 0;
            this.lblProgressBar.Text = "100%";
            // 
            // btnView
            // 
            this.btnView.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(16, 302);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(78, 30);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnActivities
            // 
            this.btnActivities.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnActivities.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnActivities.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnActivities.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnActivities.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnActivities.ForeColor = System.Drawing.Color.White;
            this.btnActivities.Location = new System.Drawing.Point(111, 302);
            this.btnActivities.Name = "btnActivities";
            this.btnActivities.Size = new System.Drawing.Size(78, 30);
            this.btnActivities.TabIndex = 7;
            this.btnActivities.Text = "Activities";
            // 
            // lblDetails
            // 
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Location = new System.Drawing.Point(16, 226);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(31, 15);
            this.lblDetails.TabIndex = 8;
            this.lblDetails.Text = "Room";
            // 
            // SubjectCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.btnActivities);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.progressCompletion);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.lblTitle);
            this.Name = "SubjectCard";
            this.Size = new System.Drawing.Size(205, 346);
            this.Load += new System.EventHandler(this.SubjectCard_Load);
            this.progressCompletion.ResumeLayout(false);
            this.progressCompletion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSchedule;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRoom;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2CircleProgressBar progressCompletion;
        private Guna.UI2.WinForms.Guna2Button btnView;
        private Guna.UI2.WinForms.Guna2Button btnActivities;
        private System.Windows.Forms.Label lblProgressBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDetails;
    }
}
