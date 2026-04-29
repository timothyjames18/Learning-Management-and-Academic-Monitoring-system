using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    /// <summary>
    /// UserControl that fills pnlDashboard (inside StudentForm) when a student
    /// clicks "View" on a SubjectCard.  Shows all instructor posts for that course,
    /// separated into Announcements and Activities sections with a progress bar.
    /// </summary>
    public partial class CourseView : UserControl
    {
        private StudentSubjectInfo _course;
        private int _studentId;
        private List<CoursePostInfo> _allPosts = new List<CoursePostInfo>();
        // Cached fonts — allocated once, reused on every filter click
        private readonly Font _filterFontBold = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        private readonly Font _filterFontRegular = new Font("Segoe UI", 8.5F, FontStyle.Regular);

        private string _activeFilter = "All";

        // Raised when student presses "Back"
        public event EventHandler BackRequested;

        public CourseView()
        {
            InitializeComponent();
            // Use double-buffering WITHOUT UserPaint.
            // UserPaint would suppress default background/child painting on the
            // first render, causing a blank panel until a repaint is triggered.
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint,
                true);
            this.SetStyle(ControlStyles.UserPaint, false);
            this.UpdateStyles();

            // Enable double-buffering on the FlowLayoutPanel via reflection
            // (WinForms doesn't expose DoubleBuffered publicly on Panel/FlowLayoutPanel)
            EnableDoubleBuffer(flowPosts);
            EnableDoubleBuffer(pnlScroll);

            this.Resize += new System.EventHandler(this.CourseView_Resize);
        }

        // Helper: turns on DoubleBuffered on any Control via the protected property
        private static void EnableDoubleBuffer(System.Windows.Forms.Control ctrl)
        {
            var prop = typeof(System.Windows.Forms.Control)
                           .GetProperty("DoubleBuffered",
                               System.Reflection.BindingFlags.Instance |
                               System.Reflection.BindingFlags.NonPublic);
            prop?.SetValue(ctrl, true, null);
        }

        // ── Public ───────────────────────────────────────────────────────────

        public void LoadCourse(StudentSubjectInfo course, int studentId)
        {
            _course = course;
            _studentId = studentId;

            lblCourseCode.Text = course.CourseCode;
            lblCourseName.Text = course.CourseName;
            lblCourseMeta.Text = $"{course.Schedule}   •   Room: {course.Room}";

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

            List<CoursePostInfo> visible;
            if (filter == "All")
                visible = _allPosts;
            else if (filter == "Activity")
                // "Activities" filter shows Activity AND Link/Quiz posts
                visible = _allPosts.Where(p => p.IsActivityOrQuiz).ToList();
            else
                visible = _allPosts.Where(p => p.PostType == filter).ToList();

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
            // Do NOT toggle flowPosts.Visible — hiding/showing causes a full repaint flash.
            // The flow panel stays visible; when empty it simply has no children.

            int totalPosts = posts?.Count ?? 0;
            lblPostCount.Text = totalPosts == 0 ? "0 posts"
                                                 : $"{totalPosts} post{(totalPosts != 1 ? "s" : "")}";

            // Update progress bar (counts Activity + Link/Quiz as activities)
            UpdateProgressBar(posts);

            if (!empty)
            {
                int cardWidth = CardWidth();

                // ── Separate into sections ────────────────────────────────
                var announcements = posts.Where(p => p.IsAnnouncement).ToList();
                var activities = posts.Where(p => p.IsActivityOrQuiz).ToList();

                bool showBothSections = announcements.Count > 0 && activities.Count > 0;

                // Announcements section
                if (announcements.Count > 0)
                {
                    if (showBothSections)
                        flowPosts.Controls.Add(MakeSectionHeader("📢  Announcements", announcements.Count));

                    foreach (var post in announcements)
                        flowPosts.Controls.Add(MakeCard(post, cardWidth));
                }

                // Activities section
                if (activities.Count > 0)
                {
                    if (showBothSections)
                        flowPosts.Controls.Add(MakeSectionHeader("📋  Activities & Quizzes", activities.Count));

                    foreach (var post in activities)
                        flowPosts.Controls.Add(MakeCard(post, cardWidth));
                }
            }

            flowPosts.ResumeLayout(true);
            flowPosts.PerformLayout();
            pnlScroll.PerformLayout();
            // Force an immediate repaint so the very first frame shows all
            // postcards fully painted — without this, cards remain invisible
            // until the next paint cycle (e.g. a button click or mouse-over).
            flowPosts.Refresh();
        }

        private PostCard MakeCard(CoursePostInfo post, int cardWidth)
        {
            var card = new PostCard();
            card.Width = cardWidth;
            card.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            card.Margin = new Padding(0, 0, 0, 12);
            card.LoadPost(post);
            card.CompletionChanged += (s, e) => RefreshProgressBar();
            return card;
        }

        private Label MakeSectionHeader(string text, int count)
        {
            var lbl = new Label
            {
                AutoSize = false,
                Width = CardWidth(),
                Height = 34,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Margin = new Padding(0, 8, 0, 4),
                Text = $"{text}  ({count})",
                Font = new Font("Segoe UI Semibold", 10F),
                ForeColor = Color.FromArgb(30, 86, 160),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0),
                BackColor = Color.FromArgb(220, 232, 248)
            };
            return lbl;
        }

        // ── Progress bar ─────────────────────────────────────────────────────

        private void UpdateProgressBar(List<CoursePostInfo> visiblePosts)
        {
            int total = _allPosts.Count(p => p.IsActivityOrQuiz);
            pnlProgressBar.Visible = (total > 0);
            if (total > 0)
                RenderProgress(total, 0);
        }

        /// <summary>Called whenever a PostCard fires CompletionChanged.</summary>
        private void RefreshProgressBar()
        {
            int total = _allPosts.Count(p => p.IsActivityOrQuiz);
            int completed = flowPosts.Controls
                                     .OfType<PostCard>()
                                     .Count(c => c.IsCompleted);

            if (total > 0)
                RenderProgress(total, completed);
        }

        private void RenderProgress(int total, int completed)
        {
            int pct = (int)((completed / (double)total) * 100);
            lblProgress.Text = $"Activities Progress:  {completed} / {total} completed  ({pct}%)";
            int trackWidth = Math.Max(0, pnlProgressTrack.Width - 2);
            progressFill.Width = (int)((pct / 100.0) * trackWidth);
        }

        // ── Highlighting filter buttons ───────────────────────────────────────

        private void HighlightFilter(Button active)
        {
            var activeBack = Color.FromArgb(30, 86, 160);
            var inactiveBack = Color.White;

            foreach (var btn in new[] { btnAll, btnAnnouncements, btnActivities, btnLinks })
            {
                bool isActive = (btn == active);
                btn.BackColor = isActive ? activeBack : inactiveBack;
                btn.ForeColor = isActive ? Color.White : Color.FromArgb(60, 80, 110);
                btn.Font = isActive ? _filterFontBold : _filterFontRegular;
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