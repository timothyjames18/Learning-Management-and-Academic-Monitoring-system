using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    /// <summary>
    /// UserControl that fills pnlDashboard (inside StudentForm) when a student
    /// clicks "View" on a SubjectCard.  Shows all instructor posts for that course.
    /// </summary>
    public partial class CourseView : UserControl
    {
        private StudentSubjectInfo _course;
        private int _studentId;
        private List<CoursePostInfo> _allPosts = new List<CoursePostInfo>();
        private string _activeFilter = "All";

        // Raised when student presses "Back" – parent Courses form listens here
        public event EventHandler BackRequested;

        public CourseView()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.CourseView_Resize);
        }

        // ── Public ───────────────────────────────────────────────────────────

        public void LoadCourse(StudentSubjectInfo course, int studentId)
        {
            _course = course;
            _studentId = studentId;

            lblCourseCode.Text = course.CourseCode;
            lblCourseName.Text = course.CourseName;
            lblCourseMeta.Text = $"{course.Schedule}   •   Room: {course.Room}";

            // Move post-count label to far right now that we know the width
            PositionPostCount();

            _allPosts = DatabaseHelper.GetCoursePostsByCourse(course.CourseID);
            RenderPosts(_allPosts);
            HighlightFilter(btnAll);
        }

        // ── Filter button click handlers ─────────────────────────────────────

        private void btnAll_Click(object sender, EventArgs e) { ApplyFilter("All"); }
        private void btnAnnouncements_Click(object sender, EventArgs e) { ApplyFilter("Announcement"); }
        private void btnActivities_Click(object sender, EventArgs e) { ApplyFilter("Activity"); }
        private void btnLinks_Click(object sender, EventArgs e) { ApplyFilter("Link"); }

        private void CourseView_Resize(object sender, EventArgs e) { AdjustPostWidths(); }

        private void ApplyFilter(string filter)
        {
            _activeFilter = filter;

            var visible = filter == "All"
                ? _allPosts
                : _allPosts.Where(p => p.PostType == filter).ToList();

            RenderPosts(visible);

            switch (filter)
            {
                case "Announcement": HighlightFilter(btnAnnouncements); break;
                case "Activity": HighlightFilter(btnActivities); break;
                case "Link": HighlightFilter(btnLinks); break;
                default: HighlightFilter(btnAll); break;
            }
        }

        // ── Rendering ────────────────────────────────────────────────────────

        private void RenderPosts(List<CoursePostInfo> posts)
        {
            flowPosts.SuspendLayout();
            flowPosts.Controls.Clear();

            bool empty = (posts == null || posts.Count == 0);
            lblNoPosts.Visible = empty;
            flowPosts.Visible = !empty;

            lblPostCount.Text = empty ? "0 posts"
                                      : $"{posts.Count} post{(posts.Count != 1 ? "s" : "")}";

            if (!empty)
            {
                int cardWidth = CardWidth();
                foreach (var post in posts)
                {
                    var card = new PostCard();
                    card.Width = cardWidth;
                    card.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    card.Margin = new Padding(0, 0, 0, 12);
                    card.LoadPost(post);
                    flowPosts.Controls.Add(card);
                }
            }

            flowPosts.ResumeLayout(true);   // true = perform layout immediately
            flowPosts.PerformLayout();       // ensure AutoSize recalculates height
            pnlScroll.PerformLayout();       // reflow scroll panel so cards appear
        }

        private void HighlightFilter(Button active)
        {
            var activeBack = Color.FromArgb(30, 86, 160);
            var inactiveBack = Color.White;

            foreach (var btn in new[] { btnAll, btnAnnouncements, btnActivities, btnLinks })
            {
                bool isActive = (btn == active);
                btn.BackColor = isActive ? activeBack : inactiveBack;
                btn.ForeColor = isActive ? Color.White : Color.FromArgb(60, 80, 110);
                btn.Font = new Font("Segoe UI", 8.5F,
                                    isActive ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        // ── Sizing helpers ────────────────────────────────────────────────────

        private int CardWidth() =>
            Math.Max(200, pnlScroll.ClientSize.Width
                         - pnlScroll.Padding.Horizontal - 4);

        private void AdjustPostWidths()
        {
            int w = CardWidth();
            foreach (Control c in flowPosts.Controls)
                c.Width = w;

            PositionPostCount();
        }

        private void PositionPostCount()
        {
            lblPostCount.Left = pnlFilterBar.ClientSize.Width - lblPostCount.Width - 12;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustPostWidths();
        }

        // ── Back button ──────────────────────────────────────────────────────

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
