using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    partial class Attendance
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.scheduleCalendar = new System.Windows.Forms.MonthCalendar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scheduleCalendar
            // 
            this.scheduleCalendar.Location = new System.Drawing.Point(50, 60);
            this.scheduleCalendar.Name = "scheduleCalendar";
            this.scheduleCalendar.Size = new System.Drawing.Size(850, 500); // BIG Calendar!
            this.scheduleCalendar.TabIndex = 0;
            this.scheduleCalendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.scheduleCalendar.TitleForeColor = System.Drawing.Color.White;
            this.scheduleCalendar.TrailingForeColor = System.Drawing.Color.Gray;
            this.scheduleCalendar.CalendarDimensions = new System.Drawing.Size(2, 2); // 4 months view
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Location = new System.Drawing.Point(50, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 36);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "📅 My Class Schedule";
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(950, 620);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.scheduleCalendar);
            this.Name = "Attendance";
            this.Text = "Class Schedule";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.MonthCalendar scheduleCalendar;
        private System.Windows.Forms.Label lblTitle;
    }
}