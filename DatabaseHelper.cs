using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system
{

    internal class DatabaseHelper
    {
        private static string connectionString =
        "Server=localhost;Database=lms_db;Uid=root;Pwd=;";

        public static List<StudentSubjectInfo> GetAvailableCourses()
        {
            string query = "SELECT CourseID, CourseCode, CourseName, Credits FROM courses ORDER BY CourseCode";

            var courses = new List<StudentSubjectInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                courses.Add(new StudentSubjectInfo
                                {
                                    CourseID = reader.GetInt32("CourseID"),
                                    CourseCode = reader.GetString("CourseCode"),
                                    CourseName = reader.GetString("CourseName"),
                                    Credits = reader.GetInt32("Credits"),
                                    Schedule = "TBA",
                                    Room = "TBA",
                                    Semester = "Fall 2024",
                                    ActivityCount = 0
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Courses error: " + ex.Message);
                }
            }
            return courses;  // NEVER NULL!
        }
        // === ADMIN ENROLLMENT METHODS ===

        // 1. Students dropdown
        public static List<UserInfo> GetStudentsForEnrollment()
        {
            string query = @"
        SELECT UserID, 
               CONCAT(FirstName, ' ', Surname) as FullName, 
               Email 
        FROM users 
        WHERE Role = 'Student'
        ORDER BY Surname, FirstName";  

        var students = new List<UserInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                students.Add(new UserInfo
                                {
                                    UserID = reader.GetInt32("UserID"),
                                    FullName = reader.GetString("FullName"),
                                    Email = reader.GetString("Email")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);  // Debug
                }
            }
            return students;
        }

        // 2. All courses dropdown


        // 3. Recent enrollments grid
        public static System.Data.DataTable GetRecentEnrollments()
        {
            string query = @"
        SELECT 
            u.FirstName, u.Surname, u.Program, u.Section,
            c.CourseCode, c.CourseName, c.Credits
        FROM enrollments e
        JOIN users u ON e.studentId = u.UserID
        JOIN courses c ON e.course_id = c.CourseID
        ORDER BY u.Surname
        LIMIT 50";

            System.Data.DataTable dt = new System.Data.DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // 4. Enroll student
        public static bool EnrollStudent(int studentId, int courseId)
        {
            string query = @"
        INSERT IGNORE INTO enrollments (studentId, course_id, enroll_date) 
        VALUES (@studentId, @courseId, NOW())";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", studentId);
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        // For Student Dashboard Cards
        public static List<StudentSubjectInfo> GetEnrolledSubjects(int studentId)
        {
            string query = @"
        SELECT 
            c.CourseID,
            c.CourseCode,
            c.CourseName,
            c.Credits,
            COALESCE(c.Schedule, 'TBA') AS Schedule,
            COALESCE(c.Room, 'TBA') AS Room,
            COALESCE(c.Semester, 'Fall 2024') AS Semester,
            0 AS ActivityCount  -- Add activities table later
        FROM enrollments e
        JOIN courses c ON e.course_id = c.CourseID
        WHERE e.studentId = @studentId
        ORDER BY c.CourseCode";

            var courses = new List<StudentSubjectInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", studentId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                courses.Add(new StudentSubjectInfo
                                {
                                    CourseID = reader.GetInt32("CourseID"),
                                    CourseCode = reader.GetString("CourseCode"),
                                    CourseName = reader.GetString("CourseName"),
                                    Credits = reader.GetInt32("Credits"),
                                    Schedule = reader.GetString("Schedule"),
                                    Room = reader.GetString("Room"),
                                    Semester = reader.GetString("Semester"),
                                    ActivityCount = reader.GetInt32("ActivityCount")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("GetEnrolledSubjects error: " + ex.Message);
                }
            }
            return courses;
        }
    }
}