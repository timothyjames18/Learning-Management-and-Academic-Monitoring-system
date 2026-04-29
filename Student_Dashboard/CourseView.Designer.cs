namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    partial class CourseView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblCourseCode = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.lblCourseMeta = new System.Windows.Forms.Label();
            this.pnlFilterBar = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnAnnouncements = new System.Windows.Forms.Button();
            this.btnActivities = new System.Windows.Forms.Button();
            this.btnLinks = new System.Windows.Forms.Button();
            this.lblPostCount = new System.Windows.Forms.Label();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.flowPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNoPosts = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlFilterBar.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 86, 160);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 100;
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblCourseCode);
            this.pnlHeader.Controls.Add(this.lblCourseName);
            this.pnlHeader.Controls.Add(this.lblCourseMeta);

            // btnBack
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(20, 60, 120);
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(190, 220, 255);
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.Text = "◀  Back to My Courses";
            this.btnBack.Location = new System.Drawing.Point(16, 8);
            this.btnBack.Size = new System.Drawing.Size(160, 26);
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // lblCourseCode
            this.lblCourseCode.AutoSize = false;
            this.lblCourseCode.Location = new System.Drawing.Point(16, 38);
            this.lblCourseCode.Size = new System.Drawing.Size(200, 22);
            this.lblCourseCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourseCode.ForeColor = System.Drawing.Color.FromArgb(173, 216, 255);
            this.lblCourseCode.Text = "CS101";

            // lblCourseName
            this.lblCourseName.AutoSize = false;
            this.lblCourseName.Location = new System.Drawing.Point(16, 58);
            this.lblCourseName.Size = new System.Drawing.Size(800, 26);
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblCourseName.ForeColor = System.Drawing.Color.White;
            this.lblCourseName.Text = "Course Name";

            // lblCourseMeta
            this.lblCourseMeta.AutoSize = false;
            this.lblCourseMeta.Location = new System.Drawing.Point(16, 82);
            this.lblCourseMeta.Size = new System.Drawing.Size(800, 16);
            this.lblCourseMeta.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCourseMeta.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblCourseMeta.Text = "Schedule  •  Room";

            // ── pnlFilterBar ───────────────────────────────────────────────
            this.pnlFilterBar.BackColor = System.Drawing.Color.FromArgb(235, 240, 248);
            this.pnlFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBar.Height = 46;
            this.pnlFilterBar.Controls.Add(this.btnAll);
            this.pnlFilterBar.Controls.Add(this.btnAnnouncements);
            this.pnlFilterBar.Controls.Add(this.btnActivities);
            this.pnlFilterBar.Controls.Add(this.btnLinks);
            this.pnlFilterBar.Controls.Add(this.lblPostCount);

            MakeFilterBtn(this.btnAll, "All", 16, 80);
            MakeFilterBtn(this.btnAnnouncements, "📢 Announcements", 106, 140);
            MakeFilterBtn(this.btnActivities, "📋 Activities", 256, 110);
            MakeFilterBtn(this.btnLinks, "🔗 Links/Quizzes", 376, 120);

            this.btnAll.Click += (s, e) => ApplyFilter("All");
            this.btnAnnouncements.Click += (s, e) => ApplyFilter("Announcement");
            this.btnActivities.Click += (s, e) => ApplyFilter("Activity");
            this.btnLinks.Click += (s, e) => ApplyFilter("Link");

            // lblPostCount
            this.lblPostCount.AutoSize = false;
            this.lblPostCount.Anchor = System.Windows.Forms.AnchorStyles.Right
                                         | System.Windows.Forms.AnchorStyles.Top;
            this.lblPostCount.Size = new System.Drawing.Size(120, 46);
            this.lblPostCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPostCount.ForeColor = System.Drawing.Color.Gray;
            this.lblPostCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPostCount.Text = "0 posts";
            this.lblPostCount.Left = 900; // repositioned in OnResize

            // ── pnlScroll ──────────────────────────────────────────────────
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.pnlScroll.Padding = new System.Windows.Forms.Padding(28, 16, 28, 16);
            this.pnlScroll.Controls.Add(this.flowPosts);
            this.pnlScroll.Controls.Add(this.lblNoPosts);

            // flowPosts
            this.flowPosts.AutoSize = true;
            this.flowPosts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPosts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPosts.WrapContents = false;
            this.flowPosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPosts.BackColor = System.Drawing.Color.Transparent;

            // lblNoPosts
            this.lblNoPosts.AutoSize = false;
            this.lblNoPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoPosts.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNoPosts.ForeColor = System.Drawing.Color.Gray;
            this.lblNoPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoPosts.Text = "No posts yet for this course.";
            this.lblNoPosts.Visible = false;

            // ── CourseView ─────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlFilterBar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "CourseView";
            this.Size = new System.Drawing.Size(1000, 700);

            this.pnlHeader.ResumeLayout(false);
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void MakeFilterBtn(System.Windows.Forms.Button b, string text, int x, int w)
        {
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            b.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 200, 220);
            b.BackColor = System.Drawing.Color.White;
            b.ForeColor = System.Drawing.Color.FromArgb(60, 80, 110);
            b.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            b.Text = text;
            b.Location = new System.Drawing.Point(x, 8);
            b.Size = new System.Drawing.Size(w, 30);
            b.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCourseCode;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.Label lblCourseMeta;
        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnAnnouncements;
        private System.Windows.Forms.Button btnActivities;
        private System.Windows.Forms.Button btnLinks;
        private System.Windows.Forms.Label lblPostCount;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.FlowLayoutPanel flowPosts;
        private System.Windows.Forms.Label lblNoPosts;
    }
}
