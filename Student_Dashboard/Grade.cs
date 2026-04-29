using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class Grade : Form
    {
        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private int studentId;

        public Grade(int userId)
        {
            studentId = userId;
            InitializeComponent();
            LoadGrades();
        }

        private void LoadGrades()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            c.CourseCode,
                            c.CourseName,
                            COALESCE(g.Prelim,    '-') AS Prelim,
                            COALESCE(g.Midterm,   '-') AS Midterm,
                            COALESCE(g.PreFinals, '-') AS PreFinals,
                            COALESCE(g.Finals,    '-') AS Finals,
                            COALESCE(g.FinalGrade,'-') AS FinalGrade,
                            COALESCE(g.GPA,       '-') AS GPA,
                            COALESCE(g.Remarks,   'Pending') AS Remarks
                        FROM enrollments e
                        JOIN courses c ON e.CourseID = c.CourseID
                        LEFT JOIN grades g ON g.StudentID = e.StudentID AND g.CourseID = e.CourseID
                        WHERE e.StudentID = @studentId
                        ORDER BY c.CourseCode";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                        dgvGrades.DataSource = dt;
                    }
                }

                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading grades: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleGrid()
        {
            if (dgvGrades.Columns.Count == 0) return;

            // Column headers
            dgvGrades.Columns["CourseCode"].HeaderText = "Code";
            dgvGrades.Columns["CourseName"].HeaderText = "Subject";
            dgvGrades.Columns["Prelim"].HeaderText = "Prelim";
            dgvGrades.Columns["Midterm"].HeaderText = "Midterm";
            dgvGrades.Columns["PreFinals"].HeaderText = "Pre-Finals";
            dgvGrades.Columns["Finals"].HeaderText = "Finals";
            dgvGrades.Columns["FinalGrade"].HeaderText = "Final Grade";
            dgvGrades.Columns["GPA"].HeaderText = "GPA";
            dgvGrades.Columns["Remarks"].HeaderText = "Remarks";

            // Column widths
            dgvGrades.Columns["CourseCode"].Width = 70;
            dgvGrades.Columns["CourseName"].Width = 220;
            dgvGrades.Columns["Prelim"].Width = 70;
            dgvGrades.Columns["Midterm"].Width = 70;
            dgvGrades.Columns["PreFinals"].Width = 85;
            dgvGrades.Columns["Finals"].Width = 70;
            dgvGrades.Columns["FinalGrade"].Width = 85;
            dgvGrades.Columns["GPA"].Width = 55;
            dgvGrades.Columns["Remarks"].Width = 80;

            // Center-align grade columns
            foreach (DataGridViewColumn col in dgvGrades.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (col.Name == "CourseName")
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            // Color-code Remarks column
            foreach (DataGridViewRow row in dgvGrades.Rows)
            {
                string remarks = row.Cells["Remarks"].Value?.ToString();
                if (remarks == "Passed")
                    row.Cells["Remarks"].Style.ForeColor = Color.Green;
                else if (remarks == "Failed")
                    row.Cells["Remarks"].Style.ForeColor = Color.Red;
                else
                    row.Cells["Remarks"].Style.ForeColor = Color.Gray;
            }
        }
    }
}