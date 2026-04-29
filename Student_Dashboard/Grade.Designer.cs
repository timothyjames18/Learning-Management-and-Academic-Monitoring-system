namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    partial class Grade
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlSchoolInfo = new System.Windows.Forms.Panel();
            this.lblSchool = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlStudentInfo = new System.Windows.Forms.Panel();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblProgram = new System.Windows.Forms.Label();
            this.lblYearSection = new System.Windows.Forms.Label();
            this.lblStudentNo = new System.Windows.Forms.Label();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterNote = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSchoolInfo.SuspendLayout();
            this.pnlStudentInfo.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 155;
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.pnlHeader.Controls.Add(this.pnlSchoolInfo);
            this.pnlHeader.Controls.Add(this.pnlStudentInfo);

            // ── pnlSchoolInfo (top portion of header) ─────────────
            this.pnlSchoolInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSchoolInfo.Height = 80;
            this.pnlSchoolInfo.BackColor = System.Drawing.Color.FromArgb(21, 56, 110); // dark navy
            this.pnlSchoolInfo.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.pnlSchoolInfo.Controls.Add(this.lblFormTitle);
            this.pnlSchoolInfo.Controls.Add(this.lblSchool);
            this.pnlSchoolInfo.Controls.Add(this.lblAddress);

            // lblSchool
            this.lblSchool.Text = "Colegio de San Gabriel Arcangel";
            this.lblSchool.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblSchool.ForeColor = System.Drawing.Color.White;
            this.lblSchool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSchool.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSchool.Height = 34;

            // lblAddress
            this.lblAddress.Text = "Area E, Sapang Palay, City of San Jose del Monte, Bulacan";
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAddress.Height = 22;

            // lblFormTitle
            this.lblFormTitle.Text = "─── OFFICIAL GRADE REPORT ───";
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(150, 185, 230);
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFormTitle.Height = 20;

            // ── pnlStudentInfo (below school banner) ───────────────
            this.pnlStudentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStudentInfo.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.pnlStudentInfo.Padding = new System.Windows.Forms.Padding(14, 6, 14, 4);
            this.pnlStudentInfo.Controls.Add(this.lblStudentName);
            this.pnlStudentInfo.Controls.Add(this.lblNameCaption);
            this.pnlStudentInfo.Controls.Add(this.lblProgram);
            this.pnlStudentInfo.Controls.Add(this.lblYearSection);
            this.pnlStudentInfo.Controls.Add(this.lblStudentNo);
            this.pnlStudentInfo.Controls.Add(this.lblSchoolYear);
            this.pnlStudentInfo.Controls.Add(this.lblSemester);

            // lblNameCaption
            this.lblNameCaption.Text = "Student Name";
            this.lblNameCaption.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblNameCaption.ForeColor = System.Drawing.Color.Gray;
            this.lblNameCaption.Location = new System.Drawing.Point(14, 2);
            this.lblNameCaption.Size = new System.Drawing.Size(220, 16);

            // lblStudentName
            this.lblStudentName.Text = "";
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStudentName.ForeColor = System.Drawing.Color.FromArgb(21, 56, 110);
            this.lblStudentName.Location = new System.Drawing.Point(14, 16);
            this.lblStudentName.Size = new System.Drawing.Size(400, 22);

            // lblProgram
            this.lblProgram.Text = "";
            this.lblProgram.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgram.ForeColor = System.Drawing.Color.FromArgb(50, 90, 150);
            this.lblProgram.Location = new System.Drawing.Point(14, 39);
            this.lblProgram.Size = new System.Drawing.Size(400, 18);

            // lblYearSection
            this.lblYearSection.Text = "";
            this.lblYearSection.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblYearSection.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblYearSection.Location = new System.Drawing.Point(14, 58);
            this.lblYearSection.Size = new System.Drawing.Size(220, 16);

            // lblStudentNo
            this.lblStudentNo.Text = "";
            this.lblStudentNo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStudentNo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblStudentNo.Location = new System.Drawing.Point(240, 39);
            this.lblStudentNo.Size = new System.Drawing.Size(200, 18);

            // lblSchoolYear
            this.lblSchoolYear.Text = "";
            this.lblSchoolYear.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSchoolYear.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblSchoolYear.Location = new System.Drawing.Point(240, 58);
            this.lblSchoolYear.Size = new System.Drawing.Size(180, 16);

            // lblSemester
            this.lblSemester.Text = "";
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSemester.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblSemester.Location = new System.Drawing.Point(430, 58);
            this.lblSemester.Size = new System.Drawing.Size(180, 16);

            // ── pnlGrid ────────────────────────────────────────────
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(12, 6, 12, 4);
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvGrades);

            // ── dgvGrades ──────────────────────────────────────────
            this.dgvGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.ReadOnly = true;
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvGrades.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.RowHeadersVisible = false;
            this.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrades.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvGrades.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvGrades.RowTemplate.Height = 28;
            this.dgvGrades.GridColor = System.Drawing.Color.FromArgb(200, 215, 240);

            // Header style — navy blue like CDSGA
            this.dgvGrades.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(21, 56, 110);
            this.dgvGrades.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvGrades.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvGrades.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvGrades.EnableHeadersVisualStyles = false;

            // Alternating rows
            this.dgvGrades.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 242, 255);

            // Default cell style
            this.dgvGrades.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(50, 100, 180);
            this.dgvGrades.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            // ── pnlFooter ──────────────────────────────────────────
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 46;
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.pnlFooter.Controls.Add(this.lblFooterNote);
            this.pnlFooter.Controls.Add(this.btnPrint);

            // lblFooterNote
            this.lblFooterNote.Text = "Grades are updated by your instructor. This is for reference only.";
            this.lblFooterNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblFooterNote.ForeColor = System.Drawing.Color.Gray;
            this.lblFooterNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFooterNote.Dock = System.Windows.Forms.DockStyle.Fill;

            // btnPrint
            this.btnPrint.Text = "🖨  Print Grade Report";
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(21, 56, 110);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Size = new System.Drawing.Size(180, 32);
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // ── Grade Form ─────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 560);
            this.BackColor = System.Drawing.Color.White;

            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Name = "Grade";
            this.Text = "Grades";

            this.pnlHeader.ResumeLayout(false);
            this.pnlSchoolInfo.ResumeLayout(false);
            this.pnlStudentInfo.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSchoolInfo;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlStudentInfo;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.Label lblYearSection;
        private System.Windows.Forms.Label lblStudentNo;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterNote;
        private System.Windows.Forms.Button btnPrint;
    }
}