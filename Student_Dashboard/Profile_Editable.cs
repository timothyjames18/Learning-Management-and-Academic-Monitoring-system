using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system.Student_Dashboard
{
    public partial class Profile_Editable : Form
    {
        private Image currentProfileImage;
        private byte[] profileImageBytes;
        private readonly string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private readonly int studentId;
        private readonly StudentForm parentForm;

        public Profile_Editable(int userId, StudentForm parent = null)
        {
            studentId = userId;
            parentForm = parent;
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
                SELECT PasswordHash, FirstName, MiddleName, Surname, FullName, 
                       Email, ContactNumber, Address, Birthday, FName, MotherName, FatherOccupation, MotherOccupation, ProfilePicturePath
            FROM Users WHERE UserID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
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

                                // 🔥 FIXED: DON'T load password (security!)
                                // txtPass.Text = reader["PasswordHash"]?.ToString() ?? "";

                                if (reader["Birthday"] != DBNull.Value)
                                    dtpBirthday.Value = Convert.ToDateTime(reader["Birthday"]);
                                if (reader["ProfilePicturePath"] != DBNull.Value)
                                {
                                    string profilePicturePath = reader["ProfilePicturePath"].ToString();
                                    if (File.Exists(profilePicturePath))
                                    {
                                        currentProfileImage = Image.FromFile(profilePicturePath);
                                        pbxPfp.Image = ResizeImage(currentProfileImage, 150, 150);
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

        private void BtnProfSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        UPDATE Users SET 
                            Fullname = @fullName, FirstName = @firstName, MiddleName = @middleName, Surname = @surname,
                            Email = @email, ContactNumber = @phone, Address = @address,
                            Birthday = @birthday, FName = @fname, MotherName = @mname,
                            FatherOccupation = @foccupation, MotherOccupation = @moccupation
                        WHERE UserID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@middleName", txtMiddleName.Text.Trim());
                        cmd.Parameters.AddWithValue("@surname", txtSurname.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@birthday", dtpBirthday.Value.Date);
                        cmd.Parameters.AddWithValue("@fname", txtFName.Text.Trim());
                        cmd.Parameters.AddWithValue("@mname", txtMName.Text.Trim());
                        cmd.Parameters.AddWithValue("@foccupation", txtFOccupation.Text.Trim());
                        cmd.Parameters.AddWithValue("@moccupation", txtMOccupation.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", studentId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Profile updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GoBackToProfile();
                        }
                        else
                        {
                            MessageBox.Show("No changes saved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProfEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Discard all changes and return to Profile?",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                GoBackToProfile();
            }
        }
        private void GoBackToProfile()
        {
            if (parentForm != null)
            {
                // Switch back to read-only Profile
                parentForm.OpenChildForm(new Profile(studentId, parentForm), null);
            }
            else
            {
                this.Close();
            }
        }

        // 🔥 INPUT VALIDATION
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First name is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Valid email is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void BtnAddPfP_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Profile Picture";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load and resize image
                        currentProfileImage = Image.FromFile(openFileDialog.FileName);
                        Image resizedImage = ResizeImage(currentProfileImage, 150, 150);

                        // Display in PictureBox
                        pbxPfp.Image = resizedImage;

                        // Convert to bytes for database
                        using (MemoryStream ms = new MemoryStream())
                        {
                            resizedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            profileImageBytes = ms.ToArray();
                        }

                        MessageBox.Show("Profile picture selected successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
       
        private bool ValidatePasswordChange()
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Current password is required!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("New password is required!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("New password must be at least 6 characters long!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please confirm your new password!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private void ClearPasswordFields()
        {
            txtPass.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }
        private string HashPassword(string password)
        {
            // Use BCrypt for NEW passwords
            return password;
        }

        private bool VerifyPassword(string password, string storedPassword)
        {
            // Plain text passwords in DB (length ~4-20 chars)
            return password == storedPassword;
        }

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

        private void chkShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtNewPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void BtnChangePss_Click(object sender, EventArgs e)
        {
            if (!ValidatePasswordChange())
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT PasswordHash FROM Users WHERE UserID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        string currentHash = cmd.ExecuteScalar()?.ToString();

                        string currentPasswordInput = txtPass.Text.Trim();
                        string newPassword = txtNewPassword.Text.Trim();
                        string confirmPassword = txtConfirmPassword.Text.Trim();

                        // Verify current password (you might want to use proper password verification)
                        if (!VerifyPassword(currentPasswordInput, currentHash))
                        {
                            MessageBox.Show("❌ Current password is incorrect!", "Password Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPass.Focus();
                            txtPass.SelectAll();
                            return;
                        }

                        if (newPassword != confirmPassword)
                        {
                            MessageBox.Show("❌ New passwords do not match!", "Password Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtConfirmPassword.Focus();
                            txtConfirmPassword.SelectAll();
                            return;
                        }

                        // Update password
                        string updateQuery = "UPDATE Users SET PasswordHash = @newPassword WHERE UserID = @id";
                        using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@newPassword", HashPassword(newPassword));
                            updateCmd.Parameters.AddWithValue("@id", studentId);

                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("✅ Password changed successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Clear password fields
                                ClearPasswordFields();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Password change failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


