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
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Courses error: " + ex.Message);
                }
            }
            return courses;
        }

        // === ADMIN ENROLLMENT METHODS ===

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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return students;
        }

        public static System.Data.DataTable GetRecentEnrollments()
        {
            string query = @"
                SELECT
                    u.FirstName, u.Surname, u.Program, u.Section,
                    c.CourseCode, c.CourseName, c.Credits
                FROM enrollments e
                JOIN users   u ON e.StudentID = u.UserID
                JOIN courses c ON e.CourseID  = c.CourseID
                ORDER BY u.Surname
                LIMIT 50";

            System.Data.DataTable dt = new System.Data.DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public static bool EnrollStudent(int studentId, int courseId)
        {
            string query = @"
                INSERT IGNORE INTO enrollments (StudentID, CourseID, EnrollmentDate)
                VALUES (@studentId, @courseId, NOW())";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static List<StudentSubjectInfo> GetEnrolledSubjects(int studentId)
        {
            string query = @"
                SELECT
                    c.CourseID,
                    c.CourseCode,
                    c.CourseName,
                    c.Credits,
                    COALESCE(c.Schedule, 'TBA')        AS Schedule,
                    COALESCE(c.Room,     'TBA')        AS Room,
                    COALESCE(c.Semester, 'Fall 2024')  AS Semester,
                    0 AS ActivityCount
                FROM enrollments e
                JOIN courses c ON e.CourseID = c.CourseID
                WHERE e.StudentID = @studentId
                ORDER BY c.CourseCode";

            var courses = new List<StudentSubjectInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
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

        // === GRADE METHODS ===

        public static decimal ConvertToGPA(decimal percentage)
        {
            if (percentage >= 97) return 1.00m;
            if (percentage >= 94) return 1.25m;
            if (percentage >= 90) return 1.50m;
            if (percentage >= 87) return 1.75m;
            if (percentage >= 83) return 2.00m;
            if (percentage >= 80) return 2.25m;
            if (percentage >= 77) return 2.50m;
            if (percentage >= 74) return 2.75m;
            if (percentage >= 70) return 3.00m;
            return 5.00m;
        }

        public static bool SaveGrades(int studentId, int courseId,
            decimal? prelim, decimal? midterm, decimal? preFinals, decimal? finals)
        {
            decimal? finalGrade = null;
            decimal? gpa = null;
            string remarks = null;

            if (prelim.HasValue && midterm.HasValue && preFinals.HasValue && finals.HasValue)
            {
                finalGrade = Math.Round((prelim.Value + midterm.Value + preFinals.Value + finals.Value) / 4, 2);
                gpa = ConvertToGPA(finalGrade.Value);
                remarks = gpa.Value <= 3.00m ? "Passed" : "Failed";
            }

            string query = @"
                INSERT INTO grades (StudentID, CourseID, Prelim, Midterm, PreFinals, Finals, FinalGrade, GPA, Remarks)
                VALUES (@studentId, @courseId, @prelim, @midterm, @preFinals, @finals, @finalGrade, @gpa, @remarks)
                ON DUPLICATE KEY UPDATE
                    Prelim    = @prelim,
                    Midterm   = @midterm,
                    PreFinals = @preFinals,
                    Finals    = @finals,
                    FinalGrade = @finalGrade,
                    GPA       = @gpa,
                    Remarks   = @remarks";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@studentId", studentId);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.Parameters.AddWithValue("@prelim", (object)prelim ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@midterm", (object)midterm ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@preFinals", (object)preFinals ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@finals", (object)finals ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@finalGrade", (object)finalGrade ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@gpa", (object)gpa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@remarks", (object)remarks ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        //  COURSE POSTS  (new – for CourseView)
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Returns all visible posts for one course, newest first.
        /// Requires the course_posts table – run add_course_posts.sql first.
        /// </summary>
        public static List<CoursePostInfo> GetCoursePostsByCourse(int courseId)
        {
            const string query = @"
                SELECT
                    cp.PostID,
                    cp.CourseID,
                    cp.InstructorID,
                    CONCAT(u.FirstName, ' ', u.Surname) AS InstructorName,
                    cp.PostType,
                    cp.Title,
                    cp.Content,
                    cp.LinkURL,
                    cp.DueDate,
                    cp.PostedDate
                FROM course_posts cp
                JOIN users u ON cp.InstructorID = u.UserID
                WHERE cp.CourseID  = @courseId
                  AND cp.IsVisible = 1
                ORDER BY cp.PostedDate DESC";

            var posts = new List<CoursePostInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@courseId", courseId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                posts.Add(new CoursePostInfo
                                {
                                    PostID = reader.GetInt32("PostID"),
                                    CourseID = reader.GetInt32("CourseID"),
                                    InstructorID = reader.GetInt32("InstructorID"),
                                    InstructorName = reader.GetString("InstructorName"),
                                    PostType = reader.GetString("PostType"),
                                    Title = reader.GetString("Title"),
                                    Content = reader["Content"] == DBNull.Value ? null : reader.GetString("Content"),
                                    LinkURL = reader["LinkURL"] == DBNull.Value ? null : reader.GetString("LinkURL"),
                                    DueDate = reader["DueDate"] == DBNull.Value
                                                     ? (DateTime?)null
                                                     : reader.GetDateTime("DueDate"),
                                    PostedDate = reader.GetDateTime("PostedDate")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("GetCoursePostsByCourse error: " + ex.Message);
                    // Don't crash – return empty list so the UI shows "No posts yet"
                }
            }
            return posts;
        }
    }
}
