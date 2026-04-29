using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system
{
    public partial class SubjectCard : UserControl
    {
        public StudentSubjectInfo Course { get; private set; }
        public SubjectCard()
        {
            InitializeComponent();
        }


        public void LoadCourse(StudentSubjectInfo course)  // ← YOUR CLASS!
        {
            Course = course;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            // YOUR PROPERTIES!
            lblTitle.Text = $"{Course.CourseCode} - {Course.CourseName}";
            lblSchedule.Text = $"📚 {Course.Schedule}";
            lblRoom.Text = $"🏫 {Course.Room}";
            lblDetails.Text = $"{Course.Credits} Credits • {Course.Semester} • {Course.ActivityCount} Activities";

            // Default to 100% when no activities have been uploaded yet
            int percentage = 100;
            progressCompletion.Value = percentage;
            lblProgressBar.Text = $"{percentage}%";
        }

        private void SubjectCard_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }
    }
}