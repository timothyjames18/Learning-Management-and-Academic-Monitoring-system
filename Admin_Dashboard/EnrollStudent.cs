using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Admin_Dashboard
{
    public partial class EnrollStudent : Form
    {
        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private int adminId;
        public EnrollStudent(int userId)
        {
            adminId = userId;
            InitializeComponent();
            LoadCurrentProfile();
        }
        private void LoadCurrentProfile()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT FirstName, MiddleName, Surname, FullName, 
                           Email, ContactNumber, Address, Birthday, FName, MotherName, FatherOccupation, MotherOccupation
                    FROM Users WHERE UserID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", adminId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            //if (reader.Read())
                            //{
                            //    txtFirstName.Text = reader["FirstName"]?.ToString() ?? "";
                            //    txtMiddleName.Text = reader["MiddleName"]?.ToString() ?? "";
                            //    txtSurname.Text = reader["Surname"]?.ToString() ?? "";
                            //    txtEmail.Text = reader["Email"]?.ToString() ?? "";
                            //    txtPhone.Text = reader["ContactNumber"]?.ToString() ?? "";
                            //    txtAddress.Text = reader["Address"]?.ToString() ?? "";
                            //    txtFName.Text = reader["FName"]?.ToString() ?? "";
                            //    txtMName.Text = reader["MotherName"]?.ToString() ?? "";
                            //    txtFOccupation.Text = reader["FatherOccupation"]?.ToString() ?? "";
                            //    txtMOccupation.Text = reader["MotherOccupation"]?.ToString() ?? "";
                            //    if (reader["Birthday"] != DBNull.Value)
                            //        dtpBirthday.Value = Convert.ToDateTime(reader["Birthday"]);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load Error: {ex.Message}");
            }
        }
        private void LoadEnrolledSubjects(int userId)
        {
            flowLayoutPanelSubjects.Controls.Clear();

            // Gets YOUR StudentSubjectInfo list!
            var courses = DatabaseHelper.GetEnrolledSubjects(userId);

            foreach (var course in courses)  // StudentSubjectInfo objects
            {
                SubjectCard card = new SubjectCard();
                card.LoadCourse(course);  // Pass YOUR object!

                //card.btnView_Clicked += (s, courseId) =>
                   //MessageBox.Show($"Opening CourseID: {courseId}");

                flowLayoutPanelSubjects.Controls.Add(card);
            }
        }

        private void EnrollStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            LoadStudents();
            LoadCourses();
            RefreshEnrollments();
        }

        private void LoadStudents()
        {
            try
            {
                cmbStudents.DataSource = null;
                cmbStudents.DataSource = DatabaseHelper.GetStudentsForEnrollment();
                cmbStudents.DisplayMember = "FullName";
                cmbStudents.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Students load error: " + ex.Message);
            }
        }

        private void LoadCourses()
        {
            try
            {
                cmbCourses.DataSource = null;
                cmbCourses.DataSource = DatabaseHelper.GetAvailableCourses();
                cmbCourses.DisplayMember = "FullName";
                cmbCourses.ValueMember = "CourseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Courses load error: " + ex.Message);
            }
        }

        private void RefreshEnrollments()
        {
            try
            {
                dgvEnrollments.DataSource = DatabaseHelper.GetRecentEnrollments();
                //if (dgvEnrollments.Columns["EnrollDate"] != null)
                 //   dgvEnrollments.Columns["EnrollDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grid error: " + ex.Message);
            }
        }

        private void btnEnrollStudent_Click_1(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedValue == null || cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Select student AND course!", "Missing Selection");
                return;
            }

            int userId = (int)cmbStudents.SelectedValue;
            int courseId = (int)cmbCourses.SelectedValue;

            if (DatabaseHelper.EnrollStudent(userId, courseId))
            {
                MessageBox.Show("✅ Student enrolled successfully!", "Success");
                RefreshEnrollments();
            }
            else
            {
                MessageBox.Show("❌ Already enrolled or error!", "Info");
            }
        }
    }
}
