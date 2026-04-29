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

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class Courses : Form
    {
        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private Label label1;
        private FlowLayoutPanel flowLayoutPanelSubjects;
        private int studentId;
        public Courses(int userId)
        {
            studentId = userId;
            InitializeComponent();
            LoadCurrentProfile();
            LoadEnrolledSubjects(studentId);
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
                        cmd.Parameters.AddWithValue("@id", studentId);
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

            var courses = DatabaseHelper.GetEnrolledSubjects(userId);

            label1.Text = $"Enrolled in {courses.Count} Subject{(courses.Count != 1 ? "s" : "")}";

            foreach (var course in courses)  // StudentSubjectInfo objects
            {
                SubjectCard card = new SubjectCard();
                card.LoadCourse(course);  // Pass YOUR object!

                //card.btnView_Clicked += (s, courseId) =>
                //MessageBox.Show($"Opening CourseID: {courseId}");

                flowLayoutPanelSubjects.Controls.Add(card);
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelSubjects = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1151, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enroll in 0 Subjects";
            // 
            // flowLayoutPanelSubjects
            // 
            this.flowLayoutPanelSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSubjects.Location = new System.Drawing.Point(0, 23);
            this.flowLayoutPanelSubjects.Name = "flowLayoutPanelSubjects";
            this.flowLayoutPanelSubjects.Size = new System.Drawing.Size(1151, 665);
            this.flowLayoutPanelSubjects.TabIndex = 1;
            // 
            // Courses
            // 
            this.ClientSize = new System.Drawing.Size(1151, 688);
            this.Controls.Add(this.flowLayoutPanelSubjects);
            this.Controls.Add(this.label1);
            this.Name = "Courses";
            this.ResumeLayout(false);

        }
    }
}