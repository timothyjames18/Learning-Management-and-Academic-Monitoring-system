using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class PostCard : UserControl
    {
        private static readonly Color ColourAnnouncement = Color.FromArgb(66, 133, 244); // blue
        private static readonly Color ColourActivity = Color.FromArgb(52, 168, 83); // green
        private static readonly Color ColourLink = Color.FromArgb(234, 67, 53); // red

        private string _url = "";

        public PostCard()
        {
            InitializeComponent();
        }

        // ── Public API ───────────────────────────────────────────────────────

        public void LoadPost(CoursePostInfo post)
        {
            if (post == null) return;

            Color accent = AccentFor(post.PostType);

            pnlAccent.BackColor = accent;
            lblBadge.BackColor = accent;
            lblBadge.Text = post.PostType.ToUpperInvariant();

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

            // Due-date row (Activities)
            if (post.IsActivity && post.DueDate.HasValue)
            {
                lblDue.Text = "Due: " + post.DueDateDisplay;
                pnlDueRow.Top = NextY(lblContent);
                pnlDueRow.Visible = true;
            }
            else
            {
                pnlDueRow.Visible = false;
            }

            // Link row
            if (post.IsLink && !string.IsNullOrWhiteSpace(post.LinkURL))
            {
                _url = post.LinkURL;
                lnkURL.Text = post.LinkURL.Length > 80
                                     ? post.LinkURL.Substring(0, 77) + "…"
                                     : post.LinkURL;
                pnlLinkRow.Top = NextY(lblContent);
                pnlLinkRow.Visible = true;
            }
            else
            {
                pnlLinkRow.Visible = false;
            }

            // Auto-size card height
            int bottom = 0;
            if (pnlDueRow.Visible) bottom = Math.Max(bottom, pnlDueRow.Bottom);
            if (pnlLinkRow.Visible) bottom = Math.Max(bottom, pnlLinkRow.Bottom);
            if (bottom == 0) bottom = lblContent.Visible ? lblContent.Bottom : lblMeta.Bottom;
            this.Height = bottom + 22;
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

        private static int NextY(Control c) => c.Visible ? c.Bottom + 8 : c.Top;

        private void lnkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_url)) return;
            try
            {
                Process.Start(new ProcessStartInfo(_url) { UseShellExecute = true });
            }
            catch
            {
                MessageBox.Show("Could not open:\n" + _url, "Link Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
