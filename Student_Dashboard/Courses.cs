using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class Courses : Form
    {
        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private int studentId;

        // These are declared/created in InitializeComponent below
        private Label label1;
        private FlowLayoutPanel flowLayoutPanelSubjects;
        private Panel pnlContent;   // ← swap container

        public Courses(int userId)
        {
            studentId = userId;
            InitializeComponent();
            ShowCourseList();           // start on the card grid
        }

        // ════════════════════════════════════════════════════════════════════
        //  VIEW SWITCHING
        // ════════════════════════════════════════════════════════════════════
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelSubjects = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // label1 – will be docked Top when inside pnlContent
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1151, 28);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(40, 60, 100);
            this.label1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.label1.Text = "Loading...";

            // flowLayoutPanelSubjects
            this.flowLayoutPanelSubjects.Name = "flowLayoutPanelSubjects";
            this.flowLayoutPanelSubjects.AutoScroll = true;

            // pnlContent – full-canvas swap container
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name = "pnlContent";

            // Courses form
            this.ClientSize = new System.Drawing.Size(1151, 688);
            this.Controls.Add(this.pnlContent);
            this.Name = "Courses";
            this.Text = "Courses";
            this.ResumeLayout(false);
        }
        private void ShowCourseList()
        {
            pnlContent.Controls.Clear();

            label1.Dock = DockStyle.Top;
            flowLayoutPanelSubjects.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(flowLayoutPanelSubjects);
            pnlContent.Controls.Add(label1);

            LoadEnrolledSubjects();
        }

        private void ShowCourseView(StudentSubjectInfo course)
        {
            // Suspend layout on both the container and the form so no
            // intermediate repaint fires between Clear(), Add(), and LoadCourse().
            pnlContent.SuspendLayout();
            this.SuspendLayout();

            pnlContent.Controls.Clear();

            var view = new CourseView();
            view.Dock = DockStyle.Fill;
            view.BackRequested += (s, e) => ShowCourseList();

            pnlContent.Controls.Add(view);

            // Load data BEFORE resuming layout so the very first painted
            // frame already has all postcards in place — no flicker/flash.
            view.LoadCourse(course, studentId);

            pnlContent.ResumeLayout(true);
            this.ResumeLayout(true);
        }

        // ════════════════════════════════════════════════════════════════════
        //  DATA LOADING
        // ════════════════════════════════════════════════════════════════════

        private void LoadEnrolledSubjects()
        {
            flowLayoutPanelSubjects.Controls.Clear();

            var courses = DatabaseHelper.GetEnrolledSubjects(studentId);
            label1.Text = $"Enrolled in {courses.Count} Subject{(courses.Count != 1 ? "s" : "")}";

            foreach (var course in courses)
            {
                var card = new SubjectCard();
                card.LoadCourse(course);

                // Capture loop variable correctly
                var capturedCourse = course;
                card.ViewCourseRequested += (sender, courseId) =>
                {
                    ShowCourseView(capturedCourse);
                };

                flowLayoutPanelSubjects.Controls.Add(card);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        //  InitializeComponent
        // ════════════════════════════════════════════════════════════════════


    }
}