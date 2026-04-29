using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class PostCard : UserControl
    {
        private static readonly Color ColourAnnouncement = Color.FromArgb(66, 133, 244);  // blue
        private static readonly Color ColourActivity = Color.FromArgb(52, 168, 83);   // green
        private static readonly Color ColourLink = Color.FromArgb(234, 67, 53);   // red

        private string _url = "";
        private string _driveUrl = "";   // Google Drive submission link (from LinkURL on Activity posts)
        private bool _completed = false;

        // Fired whenever the student toggles the Task Complete button
        public event EventHandler CompletionChanged;

        /// <summary>True when the student has marked this task as complete.</summary>
        public bool IsCompleted => _completed;

        public PostCard()
        {
            InitializeComponent();
            // Eliminate flicker when the card is created or repainted
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);
            this.UpdateStyles();
        }

        // ── Public API ───────────────────────────────────────────────────────

        public void LoadPost(CoursePostInfo post)
        {
            if (post == null) return;

            Color accent = AccentFor(post.PostType);

            pnlAccent.BackColor = accent;
            lblBadge.BackColor = accent;
            lblBadge.Text = BadgeText(post.PostType);

            lblTitle.Text = post.Title;
            lblMeta.Text = $"Posted by {post.InstructorName}   •   {post.PostedDateDisplay}";

            // Body text
            if (!string.IsNullOrWhiteSpace(post.Content))
            {
                lblContent.Text = post.Content;
                lblContent.Visible = true;
            }
            else
            {
                lblContent.Visible = false;
            }

            // Due-date row (Activities & quizzes)
            if (post.IsActivityOrQuiz && post.DueDate.HasValue)
            {
                lblDue.Text = "Due: " + post.DueDateDisplay;
                pnlDueRow.Top = NextY(lblContent);
                pnlDueRow.Visible = true;
            }
            else
            {
                pnlDueRow.Visible = false;
            }

            // Link row (PostType == "Link" — quizzes)
            if (post.IsLink && !string.IsNullOrWhiteSpace(post.LinkURL))
            {
                _url = post.LinkURL;
                lnkURL.Text = post.LinkURL.Length > 80
                                     ? post.LinkURL.Substring(0, 77) + "…"
                                     : post.LinkURL;
                pnlLinkRow.Top = NextY(GetReferenceControl());
                pnlLinkRow.Visible = true;
            }
            else
            {
                pnlLinkRow.Visible = false;
            }

            // Action row
            if (post.IsActivityOrQuiz)
            {
                if (post.IsActivity && !string.IsNullOrWhiteSpace(post.LinkURL))
                    _driveUrl = post.LinkURL;
                else
                    _driveUrl = "";

                btnUpload.Visible = post.IsActivity;

                pnlActionRow.Top = NextY(GetReferenceControl());  // Uses helper
                pnlActionRow.Visible = true;

                _completed = false;
                RefreshActionState();
            }
            else
            {
                pnlActionRow.Visible = false;
            }

            // Auto-size card height
            int bottom = 0;
            if (pnlActionRow.Visible) bottom = Math.Max(bottom, pnlActionRow.Bottom);
            if (pnlLinkRow.Visible) bottom = Math.Max(bottom, pnlLinkRow.Bottom);
            if (pnlDueRow.Visible) bottom = Math.Max(bottom, pnlDueRow.Bottom);
            if (bottom == 0) bottom = lblContent.Visible ? lblContent.Bottom : lblMeta.Bottom;
            this.Height = bottom + 22;
        }

        // Add this helper method
        private Control GetReferenceControl()
        {
            if (pnlLinkRow.Visible) return pnlLinkRow;
            if (pnlDueRow.Visible) return pnlDueRow;
            return lblContent;
        }
        // ── Helpers ──────────────────────────────────────────────────────────

        private static Color AccentFor(string postType)
        {
            switch (postType)
            {
                case "Activity": return ColourActivity;
                case "Link": return ColourLink;
                default: return ColourAnnouncement;
            }
        }

        private static string BadgeText(string postType)
        {
            switch (postType)
            {
                case "Link": return "QUIZ / LINK";
                default: return postType.ToUpperInvariant();
            }
        }

        private static int NextY(Control c) => c.Visible ? c.Bottom + 8 : c.Top;

        private void RefreshActionState()
        {
            if (_completed)
            {
                // Completed state
                btnTaskComplete.Text = "✔  Completed  (click to undo)";
                btnTaskComplete.BackColor = Color.FromArgb(52, 168, 83);
                btnTaskComplete.ForeColor = Color.White;
                btnUpload.Enabled = false;
                btnUpload.BackColor = Color.FromArgb(200, 200, 200);
                btnUpload.ForeColor = Color.FromArgb(140, 140, 140);
            }
            else
            {
                // Pending state
                btnTaskComplete.Text = "☐  Mark as Complete";
                btnTaskComplete.BackColor = Color.White;
                btnTaskComplete.ForeColor = Color.FromArgb(52, 168, 83);
                btnUpload.Enabled = true;
                btnUpload.BackColor = Color.FromArgb(66, 133, 244);
                btnUpload.ForeColor = Color.White;
            }
        }

        // ── Event handlers ───────────────────────────────────────────────────

        private void lnkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(_url);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_driveUrl))
            {
                MessageBox.Show(
                    "No submission link has been provided by the instructor yet.",
                    "Upload Link Unavailable",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OpenUrl(_driveUrl);
        }

        private void btnTaskComplete_Click(object sender, EventArgs e)
        {
            _completed = !_completed;
            RefreshActionState();
            CompletionChanged?.Invoke(this, EventArgs.Empty);
        }

        private static void OpenUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return;
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch
            {
                MessageBox.Show("Could not open:\n" + url, "Link Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}