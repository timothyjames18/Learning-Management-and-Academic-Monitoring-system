using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class Attendance : Form
    {
        private readonly string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private readonly int studentId;
        private List<DateTime> scheduleDates = new List<DateTime>();

        public Attendance(int userId)
        {
            studentId = userId;
            InitializeComponent();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            LoadScheduleDates();
            MarkScheduleDates();
            scheduleCalendar.DateSelected += ScheduleCalendar_DateSelected;
        }

        private void LoadScheduleDates()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    // Get all dates where student has attendance record (scheduled classes)
                    string query = @"
                SELECT DISTINCT DATE(Date) as schedule_date 
                FROM attendance 
                WHERE StudentID = @studentId 
                ORDER BY DATE(Date)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scheduleDates.Add((DateTime)reader["schedule_date"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Fallback sample data
                scheduleDates.AddRange(new DateTime[] {
            DateTime.Now.AddDays(3),
            DateTime.Now.AddDays(7),
            DateTime.Now.AddDays(12),
            DateTime.Now.AddDays(18)
        });
                MessageBox.Show($"Using sample data: {ex.Message}");
            }
        }

        private void MarkScheduleDates()
        {
            scheduleCalendar.BoldedDates = scheduleDates.ToArray();
            scheduleCalendar.UpdateBoldedDates();
        }

        private void ScheduleCalendar_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start.Date;

            if (scheduleDates.Any(d => d.Date == selectedDate))
            {
                MessageBox.Show($"📚 CLASSES SCHEDULED ON {selectedDate:dddd, MMMM dd, yyyy}\n\n" +
                              "Click here to view full schedule details!",
                              "Scheduled Classes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}