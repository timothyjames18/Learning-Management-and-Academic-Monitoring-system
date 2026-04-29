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

        // Raised when the student clicks "View" on this card.
        // The int argument is the CourseID.
        public event EventHandler<int> ViewCourseRequested;

        public SubjectCard()
        {
            InitializeComponent();
        }

        public void LoadCourse(StudentSubjectInfo course)
        {
            Course = course;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblTitle.Text = $"{Course.CourseCode} - {Course.CourseName}";
            lblSchedule.Text = $"{Course.Schedule}";
            lblRoom.Text = $"{Course.Room}";
            lblDetails.Text = $"{Course.Credits} Credits • {Course.Semester} • {Course.ActivityCount} Activities";

            int percentage = 100;
            progressCompletion.Value = percentage;
            lblProgressBar.Text = $"{percentage}%";
        }

        private void SubjectCard_Load(object sender, EventArgs e) { }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Fire the event so the parent Courses form can react
            ViewCourseRequested?.Invoke(this, Course.CourseID);
        }
    }
}
