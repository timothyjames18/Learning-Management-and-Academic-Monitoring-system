namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    partial class PostCard
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblBadge = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMeta = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.pnlDueRow = new System.Windows.Forms.Panel();
            this.lblDueIcon = new System.Windows.Forms.Label();
            this.lblDue = new System.Windows.Forms.Label();
            this.pnlLinkRow = new System.Windows.Forms.Panel();
            this.lblLinkIcon = new System.Windows.Forms.Label();
            this.lnkURL = new System.Windows.Forms.LinkLabel();
            this.pnlActionRow = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnTaskComplete = new System.Windows.Forms.Button();

            this.pnlCard.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlDueRow.SuspendLayout();
            this.pnlLinkRow.SuspendLayout();
            this.pnlActionRow.SuspendLayout();
            this.SuspendLayout();

            // ── pnlCard ────────────────────────────────────────────────────
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Controls.Add(this.pnlAccent);
            this.pnlCard.Controls.Add(this.pnlBody);

            // ── pnlAccent (left colour stripe) ─────────────────────────────
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccent.Width = 7;
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(66, 133, 244);

            // ── pnlBody ────────────────────────────────────────────────────
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.lblBadge);
            this.pnlBody.Controls.Add(this.lblTitle);
            this.pnlBody.Controls.Add(this.lblMeta);
            this.pnlBody.Controls.Add(this.lblContent);
            this.pnlBody.Controls.Add(this.pnlDueRow);
            this.pnlBody.Controls.Add(this.pnlLinkRow);
            this.pnlBody.Controls.Add(this.pnlActionRow);

            // lblBadge
            this.lblBadge.AutoSize = true;
            this.lblBadge.Location = new System.Drawing.Point(14, 10);
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblBadge.ForeColor = System.Drawing.Color.White;
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(66, 133, 244);
            this.lblBadge.Text = "ANNOUNCEMENT";
            this.lblBadge.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(14, 34);
            this.lblTitle.Size = new System.Drawing.Size(680, 26);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.lblTitle.Text = "Title";

            // lblMeta
            this.lblMeta.AutoSize = false;
            this.lblMeta.Location = new System.Drawing.Point(14, 62);
            this.lblMeta.Size = new System.Drawing.Size(680, 16);
            this.lblMeta.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblMeta.ForeColor = System.Drawing.Color.Gray;
            this.lblMeta.Text = "Posted by Instructor  •  Date";

            // lblContent
            this.lblContent.AutoSize = false;
            this.lblContent.Location = new System.Drawing.Point(14, 82);
            this.lblContent.Size = new System.Drawing.Size(680, 56);
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContent.ForeColor = System.Drawing.Color.FromArgb(55, 55, 55);
            this.lblContent.Text = "";

            // pnlDueRow
            this.pnlDueRow.AutoSize = true;
            this.pnlDueRow.Location = new System.Drawing.Point(14, 142);
            this.pnlDueRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlDueRow.Visible = false;
            this.pnlDueRow.Controls.Add(this.lblDueIcon);
            this.pnlDueRow.Controls.Add(this.lblDue);

            this.lblDueIcon.AutoSize = true;
            this.lblDueIcon.Location = new System.Drawing.Point(0, 1);
            this.lblDueIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDueIcon.Text = "📅";

            this.lblDue.AutoSize = true;
            this.lblDue.Location = new System.Drawing.Point(24, 1);
            this.lblDue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDue.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDue.Text = "Due: ...";

            // pnlLinkRow
            this.pnlLinkRow.AutoSize = true;
            this.pnlLinkRow.Location = new System.Drawing.Point(14, 162);
            this.pnlLinkRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlLinkRow.Visible = false;
            this.pnlLinkRow.Controls.Add(this.lblLinkIcon);
            this.pnlLinkRow.Controls.Add(this.lnkURL);

            this.lblLinkIcon.AutoSize = true;
            this.lblLinkIcon.Location = new System.Drawing.Point(0, 1);
            this.lblLinkIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLinkIcon.Text = "🔗";

            this.lnkURL.AutoSize = true;
            this.lnkURL.Location = new System.Drawing.Point(24, 1);
            this.lnkURL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkURL.Text = "Open link";
            this.lnkURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkURL_LinkClicked);

            // ── pnlActionRow (Upload + Task Complete) ──────────────────────
            this.pnlActionRow.AutoSize = true;
            this.pnlActionRow.Location = new System.Drawing.Point(14, 186);
            this.pnlActionRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlActionRow.Visible = false;
            this.pnlActionRow.Controls.Add(this.btnUpload);
            this.pnlActionRow.Controls.Add(this.btnTaskComplete);

            // btnUpload
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(66, 133, 244);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnUpload.Text = "📁  Upload File";
            this.btnUpload.Location = new System.Drawing.Point(0, 0);
            this.btnUpload.Size = new System.Drawing.Size(130, 30);
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            // btnTaskComplete
            this.btnTaskComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskComplete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnTaskComplete.FlatAppearance.BorderSize = 1;
            this.btnTaskComplete.BackColor = System.Drawing.Color.White;
            this.btnTaskComplete.ForeColor = System.Drawing.Color.FromArgb(52, 168, 83);
            this.btnTaskComplete.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnTaskComplete.Text = "☐  Mark as Complete";
            this.btnTaskComplete.Location = new System.Drawing.Point(140, 0);
            this.btnTaskComplete.Size = new System.Drawing.Size(160, 30);
            this.btnTaskComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskComplete.Click += new System.EventHandler(this.btnTaskComplete_Click);

            // ── PostCard UserControl ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Controls.Add(this.pnlCard);
            this.Name = "PostCard";
            this.Size = new System.Drawing.Size(720, 210);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);

            this.pnlCard.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlDueRow.ResumeLayout(false);
            this.pnlDueRow.PerformLayout();
            this.pnlLinkRow.ResumeLayout(false);
            this.pnlLinkRow.PerformLayout();
            this.pnlActionRow.ResumeLayout(false);
            this.pnlActionRow.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblBadge;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Panel pnlDueRow;
        private System.Windows.Forms.Label lblDueIcon;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Panel pnlLinkRow;
        private System.Windows.Forms.Label lblLinkIcon;
        private System.Windows.Forms.LinkLabel lnkURL;
        private System.Windows.Forms.Panel pnlActionRow;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnTaskComplete;
    }
}