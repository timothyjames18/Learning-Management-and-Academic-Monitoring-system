using MySql.Data.MySqlClient;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class Profile : Form
    {
        private Image currentProfileImage; 
        private StudentForm parentForm;
        public void SetParentForm(StudentForm parent)
        {
            parentForm = parent;
        }

        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private int studentId;
        public Profile(int userId, StudentForm parent = null)
        {
            studentId = userId;
            parentForm = parent;
            InitializeComponent();
            LoadCurrentProfile();
        }
        private void LoadProfilePicture(MySqlDataReader reader)
        {
            try
            {
                if (reader["ProfilePicture"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])reader["ProfilePicture"];
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(ms);
                        picProfilePicture.Image = ResizeImage(image, 150, 150); // Assuming picProfilePicture PictureBox
                    }
                }

            }
            catch (Exception ex)
            {
                // Fallback to default image if there's an error
                string fallbackPath = @"C:\Users\Xander\Documents\School\Learning Management and Academic Monitoring system\profile.png";

                if (File.Exists(fallbackPath))
                {
                    using (var temp = Image.FromFile(fallbackPath))
                    {
                        picProfilePicture.Image = new Bitmap(temp);
                    }
                }
                Console.WriteLine($"Profile picture load error: {ex.Message}");
            }
        }

        // 🔥 HELPER METHOD - Resize Image (same as Editable form)
        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resized))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resized;
        }
        private void LoadCurrentProfile()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT Username, PasswordHash, FirstName, MiddleName, Surname, FullName, 
                           Email, ContactNumber, Address, Birthday, FName, MotherName, FatherOccupation, MotherOccupation, ProfilePicturePath
                    FROM Users WHERE UserID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUsrnm.Text = reader["Username"]?.ToString() ?? "";
                                txtFullName.Text = reader["FullName"]?.ToString() ?? "";
                                txtFirstName.Text = reader["FirstName"]?.ToString() ?? "";
                                txtMiddleName.Text = reader["MiddleName"]?.ToString() ?? "";
                                txtSurname.Text = reader["Surname"]?.ToString() ?? "";
                                txtEmail.Text = reader["Email"]?.ToString() ?? "";
                                txtPhone.Text = reader["ContactNumber"]?.ToString() ?? "";
                                txtAddress.Text = reader["Address"]?.ToString() ?? "";
                                txtFName.Text = reader["FName"]?.ToString() ?? "";
                                txtMName.Text = reader["MotherName"]?.ToString() ?? "";
                                txtFOccupation.Text = reader["FatherOccupation"]?.ToString() ?? "";
                                txtMOccupation.Text = reader["MotherOccupation"]?.ToString() ?? "";
                                txtPass.Text = reader["PasswordHash"]?.ToString() ?? "";

                                if (reader["Birthday"] != DBNull.Value)
                                    dtpBirthday.Value = Convert.ToDateTime(reader["Birthday"]);

                                string profilePicturePath = reader["ProfilePicturePath"]?.ToString();

                                if (!string.IsNullOrEmpty(profilePicturePath) && File.Exists(profilePicturePath))
                                {
                                    // 🔥 Load without locking file
                                    using (var temp = Image.FromFile(profilePicturePath))
                                    {
                                        currentProfileImage = new Bitmap(temp);
                                    }

                                    if (picProfilePicture.Image != null)
                                    {
                                        picProfilePicture.Image.Dispose();
                                        picProfilePicture.Image = null;
                                    }

                                    picProfilePicture.Image = ResizeImage(currentProfileImage, 150, 150);
                                }
                                else
                                {
                                    // 🔥 Load default image safely (no lock)
                                    string defaultPath = Path.Combine(Application.StartupPath, "ProfilePicture", "default.png");

                                    if (File.Exists(defaultPath))
                                    {
                                        using (var temp = Image.FromFile(defaultPath))
                                        {
                                            picProfilePicture.Image = new Bitmap(temp);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load Error: {ex.Message}");
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void BtnProfEdit_Click_1(object sender, EventArgs e)
        {
            if (parentForm != null) 
            {
                // Switch to editable version
                parentForm.OpenChildForm(new Profile_Editable(studentId, parentForm), null);
            }
        }

        private void lblphone_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


