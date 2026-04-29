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
            this.pnlProgressBar = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pnlProgressTrack = new System.Windows.Forms.Panel();
            this.progressFill = new System.Windows.Forms.Panel();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.flowPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNoPosts = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFilterBar.SuspendLayout();
            this.pnlProgressBar.SuspendLayout();
            this.pnlProgressTrack.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(86)))), ((int)(((byte)(160)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblCourseCode);
            this.pnlHeader.Controls.Add(this.lblCourseName);
            this.pnlHeader.Controls.Add(this.lblCourseMeta);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 100);
            this.pnlHeader.TabIndex = 3;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnBack.Location = new System.Drawing.Point(16, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 26);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "◀  Back to My Courses";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblCourseCode
            // 
            this.lblCourseCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourseCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.lblCourseCode.Location = new System.Drawing.Point(16, 38);
            this.lblCourseCode.Name = "lblCourseCode";
            this.lblCourseCode.Size = new System.Drawing.Size(200, 22);
            this.lblCourseCode.TabIndex = 1;
            this.lblCourseCode.Text = "CS101";
            // 
            // lblCourseName
            // 
            this.lblCourseName.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblCourseName.ForeColor = System.Drawing.Color.White;
            this.lblCourseName.Location = new System.Drawing.Point(16, 58);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(800, 26);
            this.lblCourseName.TabIndex = 2;
            this.lblCourseName.Text = "Course Name";
            // 
            // lblCourseMeta
            // 
            this.lblCourseMeta.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCourseMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.lblCourseMeta.Location = new System.Drawing.Point(16, 82);
            this.lblCourseMeta.Name = "lblCourseMeta";
            this.lblCourseMeta.Size = new System.Drawing.Size(800, 16);
            this.lblCourseMeta.TabIndex = 3;
            this.lblCourseMeta.Text = "Schedule  •  Room";
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.pnlFilterBar.Controls.Add(this.btnAll);
            this.pnlFilterBar.Controls.Add(this.btnAnnouncements);
            this.pnlFilterBar.Controls.Add(this.btnActivities);
            this.pnlFilterBar.Controls.Add(this.btnLinks);
            this.pnlFilterBar.Controls.Add(this.lblPostCount);
            this.pnlFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBar.Location = new System.Drawing.Point(0, 100);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1000, 46);
            this.pnlFilterBar.TabIndex = 2;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.White;
            this.btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnAll.Location = new System.Drawing.Point(16, 8);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(80, 30);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnAnnouncements
            // 
            this.btnAnnouncements.BackColor = System.Drawing.Color.White;
            this.btnAnnouncements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnouncements.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnAnnouncements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnouncements.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnAnnouncements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnAnnouncements.Location = new System.Drawing.Point(106, 8);
            this.btnAnnouncements.Name = "btnAnnouncements";
            this.btnAnnouncements.Size = new System.Drawing.Size(140, 30);
            this.btnAnnouncements.TabIndex = 1;
            this.btnAnnouncements.Text = "📢 Announcements";
            this.btnAnnouncements.UseVisualStyleBackColor = false;
            this.btnAnnouncements.Click += new System.EventHandler(this.btnAnnouncements_Click);
            // 
            // btnActivities
            // 
            this.btnActivities.BackColor = System.Drawing.Color.White;
            this.btnActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivities.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnActivities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivities.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnActivities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnActivities.Location = new System.Drawing.Point(256, 8);
            this.btnActivities.Name = "btnActivities";
            this.btnActivities.Size = new System.Drawing.Size(160, 30);
            this.btnActivities.TabIndex = 2;
            this.btnActivities.Text = "📋 Activities & Quizzes";
            this.btnActivities.UseVisualStyleBackColor = false;
            this.btnActivities.Click += new System.EventHandler(this.btnActivities_Click);
            // 
            // btnLinks
            // 
            this.btnLinks.BackColor = System.Drawing.Color.White;
            this.btnLinks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.btnLinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinks.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnLinks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnLinks.Location = new System.Drawing.Point(426, 8);
            this.btnLinks.Name = "btnLinks";
            this.btnLinks.Size = new System.Drawing.Size(90, 30);
            this.btnLinks.TabIndex = 3;
            this.btnLinks.Text = "🔗 Links";
            this.btnLinks.UseVisualStyleBackColor = false;
            this.btnLinks.Visible = false;
            this.btnLinks.Click += new System.EventHandler(this.btnLinks_Click);
            // 
            // lblPostCount
            // 
            this.lblPostCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPostCount.ForeColor = System.Drawing.Color.Gray;
            this.lblPostCount.Location = new System.Drawing.Point(1700, 0);
            this.lblPostCount.Name = "lblPostCount";
            this.lblPostCount.Size = new System.Drawing.Size(120, 46);
            this.lblPostCount.TabIndex = 4;
            this.lblPostCount.Text = "0 posts";
            this.lblPostCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlProgressBar
            // 
            this.pnlProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.pnlProgressBar.Controls.Add(this.lblProgress);
            this.pnlProgressBar.Controls.Add(this.pnlProgressTrack);
            this.pnlProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProgressBar.Location = new System.Drawing.Point(0, 146);
            this.pnlProgressBar.Name = "pnlProgressBar";
            this.pnlProgressBar.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);
            this.pnlProgressBar.Size = new System.Drawing.Size(1000, 40);
            this.pnlProgressBar.TabIndex = 1;
            this.pnlProgressBar.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.lblProgress.Location = new System.Drawing.Point(16, 8);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(400, 16);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Activities Progress:  0 / 0 completed  (0%)";
            // 
            // pnlProgressTrack
            // 
            this.pnlProgressTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(225)))));
            this.pnlProgressTrack.Controls.Add(this.progressFill);
            this.pnlProgressTrack.Location = new System.Drawing.Point(16, 26);
            this.pnlProgressTrack.Name = "pnlProgressTrack";
            this.pnlProgressTrack.Size = new System.Drawing.Size(600, 8);
            this.pnlProgressTrack.TabIndex = 1;
            // 
            // progressFill
            // 
            this.progressFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(168)))), ((int)(((byte)(83)))));
            this.progressFill.Location = new System.Drawing.Point(1, 1);
            this.progressFill.Name = "progressFill";
            this.progressFill.Size = new System.Drawing.Size(0, 6);
            this.progressFill.TabIndex = 0;
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlScroll.Controls.Add(this.flowPosts);
            this.pnlScroll.Controls.Add(this.lblNoPosts);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 186);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Padding = new System.Windows.Forms.Padding(28, 16, 28, 16);
            this.pnlScroll.Size = new System.Drawing.Size(1000, 514);
            this.pnlScroll.TabIndex = 0;
            // 
            // flowPosts
            // 
            this.flowPosts.AutoSize = true;
            this.flowPosts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPosts.BackColor = System.Drawing.Color.Transparent;
            this.flowPosts.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPosts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPosts.Location = new System.Drawing.Point(28, 16);
            this.flowPosts.Name = "flowPosts";
            this.flowPosts.Size = new System.Drawing.Size(944, 0);
            this.flowPosts.TabIndex = 0;
            this.flowPosts.WrapContents = false;
            // 
            // lblNoPosts
            // 
            this.lblNoPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoPosts.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNoPosts.ForeColor = System.Drawing.Color.Gray;
            this.lblNoPosts.Location = new System.Drawing.Point(28, 16);
            this.lblNoPosts.Name = "lblNoPosts";
            this.lblNoPosts.Size = new System.Drawing.Size(944, 482);
            this.lblNoPosts.TabIndex = 1;
            this.lblNoPosts.Text = "No posts yet for this course.";
            this.lblNoPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoPosts.Visible = false;
            // 
            // CourseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlProgressBar);
            this.Controls.Add(this.pnlFilterBar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "CourseView";
            this.Size = new System.Drawing.Size(1000, 700);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlProgressBar.ResumeLayout(false);
            this.pnlProgressTrack.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel pnlProgressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel pnlProgressTrack;
        private System.Windows.Forms.Panel progressFill;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.FlowLayoutPanel flowPosts;
        private System.Windows.Forms.Label lblNoPosts;
    }
}