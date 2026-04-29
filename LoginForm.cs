using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Learning_Management_and_Academic_Monitoring_system
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        public LoginForm()
        {
            InitializeComponent();
            ApplyRoundedCorners(20);
        }

        private void ApplyRoundedCorners(int radius = 20)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            GraphicsPath path = AddRoundedRectangle(this.ClientRectangle, radius);
            this.Region = new Region(path);

            this.ShowInTaskbar = true;
        }
        private GraphicsPath AddRoundedRectangle(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // Top-left arc
            path.AddArc(arc, 180, 90);
            // Top-right arc
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // Bottom-right arc  
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // Bottom-left arc
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblDebug.Text = "Checking credentials...";
            lblConn.Text = "Connecting...";

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblDebug.Text = "Enter username/password!";
                return;
            }

            try
            {
                lblDebug.Text = "Opening MySQL...";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    lblConn.Text = "✅ Connected!";

                    lblDebug.Text = "Querying user...";
                    string query = "SELECT UserID, FullName, Role FROM Users WHERE Username=@username AND PasswordHash=@password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullName = reader["FullName"].ToString();
                                string role = reader["Role"].ToString();

                                lblDebug.Text = $"✅ Welcome {fullName} ({role})!";

                                // 🎭 OPEN FORM BY ROLE
                                switch (role)
                                {
                                    case "Admin":
                                        new AdminForm(reader.GetInt32("UserID")).Show();
                                        break;
                                    case "Student":
                                        new StudentForm(reader.GetInt32("UserID")).Show();  // Your existing form
                                        break;
                                    case "Instructor":
                                        MessageBox.Show("Instructor dashboard coming soon!");
                                        break;
                                    default:
                                        MessageBox.Show("Unknown role!");
                                        break;
                                }

                                this.Hide();
                                return;
                            }
                            else
                            {
                                lblDebug.Text = "❌ Wrong username/password";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblDebug.Text = "ERROR!";
                lblConn.Text = $"❌ {ex.Message}";
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Are you sure you want to exit LMS?",
        "Exit Application",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button2
    );

            if (result == DialogResult.Yes)
            {
                // Close XAMPP connection properly
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Close();
                    }
                }
                catch { }

                Application.Exit();
            }
        }
    }

}
