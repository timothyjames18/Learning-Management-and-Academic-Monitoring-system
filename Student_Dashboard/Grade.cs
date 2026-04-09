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
    public partial class Grade : Form
    {
        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private int studentId;
        public Grade(int userId)
        {
            studentId = userId;
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
    }
}