using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class Grade : Form
    {
        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private int studentId;

        // Student info for the header
        private string studentFullName = "";
        private string studentFirstName = "";
        private string studentMiddleName = "";
        private string studentSurname = "";
        private string studentProgram = "";
        private string studentSection = "";
        private int studentYearLevel = 0;
        private string studentNumber = "";

        // DataTable to hold grades for printing
        private DataTable gradesTable = new DataTable();

        public Grade(int userId)
        {
            studentId = userId;
            InitializeComponent();
            LoadStudentInfo();
            LoadGrades();
        }

        // ─────────────────────────────────────────────
        //  Load student header info
        // ─────────────────────────────────────────────
        private void LoadStudentInfo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT FirstName, MiddleName, Surname, FullName,
                               Program, YearLevel, Section, Username
                        FROM users WHERE UserID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                studentFirstName = r["FirstName"]?.ToString() ?? "";
                                studentMiddleName = r["MiddleName"]?.ToString() ?? "";
                                studentSurname = r["Surname"]?.ToString() ?? "";
                                studentFullName = r["FullName"]?.ToString() ?? "";
                                studentProgram = r["Program"]?.ToString() ?? "";
                                studentYearLevel = r["YearLevel"] == DBNull.Value ? 0 : Convert.ToInt32(r["YearLevel"]);
                                studentSection = r["Section"]?.ToString() ?? "";
                                studentNumber = r["Username"]?.ToString() ?? "";
                            }
                        }
                    }
                }

                // Populate header labels
                lblStudentName.Text = studentFullName;
                lblProgram.Text = studentProgram;
                lblYearSection.Text = $"Year {studentYearLevel} — Section {studentSection}";
                lblStudentNo.Text = $"Student No: {studentNumber}";
                lblSchoolYear.Text = $"School Year: {DateTime.Now.Year - 1}-{DateTime.Now.Year}";
                lblSemester.Text = "Semester: 1st Sem";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student info: " + ex.Message);
            }
        }

        // ─────────────────────────────────────────────
        //  Load grades into grid
        // ─────────────────────────────────────────────
        private void LoadGrades()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            c.CourseCode                                    AS Code,
                            c.CourseName                                    AS Subject,
                            c.Credits                                       AS Units,
                            COALESCE(CAST(g.Prelim    AS DECIMAL(5,2)), NULL) AS Prelim,
                            COALESCE(CAST(g.Midterm   AS DECIMAL(5,2)), NULL) AS Midterm,
                            COALESCE(CAST(g.PreFinals AS DECIMAL(5,2)), NULL) AS PreFinals,
                            COALESCE(CAST(g.Finals    AS DECIMAL(5,2)), NULL) AS Finals,
                            COALESCE(CAST(g.GPA       AS DECIMAL(4,2)), NULL) AS Grade,
                            COALESCE(g.Remarks, 'Pending')                  AS Remarks
                        FROM enrollments e
                        JOIN courses c ON e.CourseID = c.CourseID
                        LEFT JOIN grades g
                               ON g.StudentID = e.StudentID
                              AND g.CourseID  = e.CourseID
                        WHERE e.StudentID = @sid
                        ORDER BY c.CourseCode";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", studentId);
                        gradesTable = new DataTable();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            da.Fill(gradesTable);
                    }
                }

                dgvGrades.DataSource = gradesTable;
                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading grades: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  Style the DataGridView
        // ─────────────────────────────────────────────
        private void StyleGrid()
        {
            if (dgvGrades.Columns.Count == 0) return;

            // Column widths
            int[] widths = { 80, 260, 50, 70, 70, 80, 70, 65, 90 };
            string[] names = { "Code", "Subject", "Units", "Prelim", "Midterm", "Pre-Finals", "Finals", "Grade", "Remarks" }; // display headers only

            for (int i = 0; i < names.Length && i < dgvGrades.Columns.Count; i++)
            {
                dgvGrades.Columns[i].HeaderText = names[i];
                dgvGrades.Columns[i].Width = widths[i];
                dgvGrades.Columns[i].DefaultCellStyle.Alignment =
                    (i == 1) ? DataGridViewContentAlignment.MiddleLeft
                             : DataGridViewContentAlignment.MiddleCenter;
            }

            // Show "-" for null grade cells
            dgvGrades.DefaultCellStyle.NullValue = "-";

            // Color Remarks
            foreach (DataGridViewRow row in dgvGrades.Rows)
            {
                string rem = row.Cells["Remarks"].Value?.ToString() ?? "";
                if (rem.Equals("Passed", StringComparison.OrdinalIgnoreCase))
                {
                    row.Cells["Remarks"].Style.ForeColor = Color.FromArgb(0, 128, 0);
                    row.Cells["Remarks"].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
                else if (rem.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                {
                    row.Cells["Remarks"].Style.ForeColor = Color.FromArgb(192, 0, 0);
                    row.Cells["Remarks"].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
                else
                {
                    row.Cells["Remarks"].Style.ForeColor = Color.Gray;
                }
            }
        }

        // ─────────────────────────────────────────────
        //  Print button click
        // ─────────────────────────────────────────────
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = false;
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169); // A4 in hundredths of an inch

            pd.PrintPage += PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.Width = 820;
            preview.Height = 900;
            preview.Text = "Print Preview — Grade Report";
            preview.ShowDialog();
        }

        // ─────────────────────────────────────────────
        //  PrintPage handler — renders the CDSGA-style report
        // ─────────────────────────────────────────────
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int marginLeft = 60;
            int marginRight = e.PageBounds.Width - 60;
            int pageWidth = marginRight - marginLeft;
            int y = 40;

            // ── School name / header ──────────────────
            Font fontSchool = new Font("Times New Roman", 18, FontStyle.Bold);
            Font fontAddress = new Font("Times New Roman", 10, FontStyle.Regular);
            Font fontLabel = new Font("Arial", 9, FontStyle.Regular);
            Font fontLabelB = new Font("Arial", 9, FontStyle.Bold);
            Font fontSmall = new Font("Arial", 8, FontStyle.Regular);
            Font fontTitle = new Font("Arial", 10, FontStyle.Bold | FontStyle.Underline);
            Font fontTable = new Font("Arial", 9, FontStyle.Regular);
            Font fontTableH = new Font("Arial", 9, FontStyle.Bold);

            Brush black = Brushes.Black;
            Brush blue = new SolidBrush(Color.FromArgb(0, 70, 140));
            Pen border = new Pen(Color.Black, 0.75f);

            StringFormat center = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat right = new StringFormat { Alignment = StringAlignment.Far };

            // School name (centered, leaving ~130px left for logo placeholder and ~100px right for photo)
            RectangleF nameRect = new RectangleF(marginLeft + 100, y, pageWidth - 200, 50);
            g.DrawString("Colegio de San Gabriel Arcangel", fontSchool, black, nameRect, center);
            y += 52;

            RectangleF addrRect = new RectangleF(marginLeft + 100, y, pageWidth - 200, 30);
            g.DrawString("Area E, Sapang Palay, City of San Jose del Monte, Bulacan", fontAddress, black, addrRect, center);
            y += 40;

            // Divider
            g.DrawLine(border, marginLeft, y, marginRight, y);
            y += 8;

            // Form title
            g.DrawString("SYSTEM GENERATED GRADE REPORT", fontTitle, black,
                new RectangleF(marginLeft, y, pageWidth, 20), center);
            y += 26;

            // ── Student info block ────────────────────
            // Row 1: Student No
            g.DrawString("Student No.:", fontLabelB, black, marginLeft, y);
            g.DrawString(studentNumber, fontLabel, blue, marginLeft + 80, y);
            y += 18;

            // Row 2: Name fields
            g.DrawString(studentSurname, fontLabel, blue, marginLeft, y);
            g.DrawString(studentFirstName, fontLabel, blue, marginLeft + 170, y);
            g.DrawString(studentMiddleName, fontLabel, blue, marginLeft + 340, y);

            g.DrawString("Last Name", fontSmall, black, marginLeft, y + 12);
            g.DrawString("First Name", fontSmall, black, marginLeft + 170, y + 12);
            g.DrawString("Middle Name", fontSmall, black, marginLeft + 340, y + 12);
            y += 32;

            // Row 3: School year, grade level, semester
            g.DrawString("School Year:", fontLabelB, black, marginLeft, y);
            g.DrawString($"{DateTime.Now.Year - 1}-{DateTime.Now.Year}", fontLabel, blue, marginLeft + 75, y);

            g.DrawString("Grade Level:", fontLabelB, black, marginLeft + 200, y);
            string yearStr = studentYearLevel == 1 ? "1st Year College"
                           : studentYearLevel == 2 ? "2nd Year College"
                           : studentYearLevel == 3 ? "3rd Year College"
                           : studentYearLevel == 4 ? "4th Year College"
                           : $"Year {studentYearLevel}";
            g.DrawString(yearStr, fontLabel, blue, marginLeft + 275, y);

            g.DrawString("Semester:", fontLabelB, black, marginLeft + 420, y);
            g.DrawString("1st Sem", fontLabel, blue, marginLeft + 480, y);
            y += 18;

            // Row 4: Section, program
            g.DrawString("Section:", fontLabelB, black, marginLeft, y);
            g.DrawString(studentSection, fontLabel, blue, marginLeft + 55, y);

            g.DrawString("Course:", fontLabelB, black, marginLeft + 200, y);
            g.DrawString(studentProgram, fontLabel, blue, marginLeft + 248, y);
            y += 26;

            // ── Table ─────────────────────────────────
            // Column definitions: x, width, header
            int[] colX = { marginLeft, marginLeft + 80, marginLeft + 300, marginLeft + 350, marginLeft + 400, marginLeft + 455, marginLeft + 505, marginLeft + 555, marginLeft + 610 };
            int[] colW = { 80, 220, 50, 50, 55, 50, 50, 55, 80 };
            string[] headers = { "Code", "Subject", "Units", "Prelim", "Midterm", "Pre-Finals", "Finals", "Grade", "Remarks" };

            // Header row background
            int rowH = 22;
            g.FillRectangle(new SolidBrush(Color.FromArgb(220, 230, 245)),
                marginLeft, y, pageWidth, rowH);
            g.DrawRectangle(border, marginLeft, y, pageWidth, rowH);

            // Draw header text + vertical lines
            for (int i = 0; i < headers.Length; i++)
            {
                RectangleF cell = new RectangleF(colX[i], y, colW[i], rowH);
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(headers[i], fontTableH, black, cell, sf);
                if (i > 0) g.DrawLine(border, colX[i], y, colX[i], y + rowH);
            }
            y += rowH;

            // Data rows
            bool altRow = false;
            foreach (DataRow row in gradesTable.Rows)
            {
                Brush rowBg = altRow
                    ? new SolidBrush(Color.FromArgb(240, 245, 255))
                    : Brushes.White;
                g.FillRectangle(rowBg, marginLeft, y, pageWidth, rowH);
                g.DrawRectangle(border, marginLeft, y, pageWidth, rowH);

                string[] vals = {
                    row["Code"]?.ToString()      ?? "",
                    row["Subject"]?.ToString()   ?? "",
                    row["Units"]?.ToString()     ?? "",
                    row["Prelim"]  == DBNull.Value ? "-" : row["Prelim"].ToString(),
                    row["Midterm"] == DBNull.Value ? "-" : row["Midterm"].ToString(),
                    row["PreFinals"] == DBNull.Value ? "-" : row["PreFinals"].ToString(),
                    row["Finals"]  == DBNull.Value ? "-" : row["Finals"].ToString(),
                    row["Grade"]   == DBNull.Value ? "-" : row["Grade"].ToString(),
                    row["Remarks"]?.ToString()   ?? "Pending"
                };

                for (int i = 0; i < vals.Length; i++)
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = (i == 1) ? StringAlignment.Near : StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    RectangleF cell = new RectangleF(colX[i] + 2, y, colW[i] - 2, rowH);

                    Brush textBrush = black;
                    if (i == 8) // Remarks column
                    {
                        if (vals[i].Equals("Passed", StringComparison.OrdinalIgnoreCase))
                            textBrush = new SolidBrush(Color.FromArgb(0, 128, 0));
                        else if (vals[i].Equals("Failed", StringComparison.OrdinalIgnoreCase))
                            textBrush = new SolidBrush(Color.FromArgb(180, 0, 0));
                        else
                            textBrush = Brushes.Gray;
                    }

                    g.DrawString(vals[i], fontTable, textBrush, cell, sf);
                    if (i > 0) g.DrawLine(border, colX[i], y, colX[i], y + rowH);
                }
                y += rowH;
                altRow = !altRow;
            }

            // Bottom border of table
            g.DrawLine(border, marginLeft, y, marginRight, y);
            y += 20;

            // ── Footer note ───────────────────────────
            Font fontFooter = new Font("Arial", 8, FontStyle.Italic);
            g.DrawString("This is a system-generated grade report. Grades are subject to verification by the registrar.",
                fontFooter, Brushes.Gray,
                new RectangleF(marginLeft, y, pageWidth, 20), center);
            y += 16;

            g.DrawString($"Printed: {DateTime.Now:MMMM dd, yyyy  h:mm tt}",
                fontFooter, Brushes.Gray,
                new RectangleF(marginLeft, y, pageWidth, 20), center);

            // Cleanup
            fontSchool.Dispose(); fontAddress.Dispose(); fontLabel.Dispose();
            fontLabelB.Dispose(); fontSmall.Dispose(); fontTitle.Dispose();
            fontTable.Dispose(); fontTableH.Dispose(); fontFooter.Dispose();
            border.Dispose(); blue.Dispose();
        }
    }
}   