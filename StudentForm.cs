using Learning_Management_and_Academic_Monitoring_system.Student_Dashboard;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Learning_Management_and_Academic_Monitoring_system
{
    public partial class StudentForm : Form
    {
        private string connectionString = "Server=localhost;Database=lms_db;Uid=root;Pwd=;";
        private int studentId;
        private Random random = new Random();
        private int tempIndex = 0;
        private Button currentButton;
        private Form activeForm;

        public StudentForm(int userId)
        {
            studentId = userId;
            InitializeComponent();
            SetupNavigationHoverEffects();
            if (studentId > 0)
                LoadStudentWelcome();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            btnCloseChildForm.Visible = false;

        }
        private void SetupNavigationHoverEffects()
        {
            // Use correct panel name (tblpnlNavigation OR pnlNavigation?)
            Panel navPanel = tblpnlNavigation ?? (Panel)pnlNavigation;  // Adjust name!

            foreach (Button btn in navPanel.Controls.OfType<Button>())
            {
                btn.MouseEnter += NavButton_MouseEnter;
                btn.MouseLeave += NavButton_MouseLeave;
            }
        }
        private void NavButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentButton)
                btn.BackColor = Color.FromArgb(70, 70, 90);
        }

        private void NavButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentButton)
                btn.BackColor = Color.FromArgb(51, 51, 76);
        }
        private void LoadStudentWelcome()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT FullName, Role FROM Users WHERE UserID=@id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                wlcm.Text = "Welcome " + reader["FullName"] + " (" + reader["Role"] + ")!";
                                lblName.Text = "Hello " + reader["FullName"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Welcome Error: " + ex.Message);
            }
        }
        private void ActivateButton(object btnsender)
        {
            if (btnsender != null)
            {
                if (currentButton != (Button)btnsender)
                {
                    DisableButton();
                    currentButton = (Button)btnsender;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            // Works for BOTH Panel AND TableLayoutPanel
            foreach (Control previousBtn in tblpnlNavigation.Controls)  // Use your actual name
            {
                if (previousBtn is Button btn)
                {
                    btn.ForeColor = Color.Gainsboro;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                }
            }
        }

        public void OpenChildForm(Form childForm, object btnsender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnsender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            if (childForm is Profile profileForm)
                profileForm.SetParentForm(this);

            // Suspend layout so no intermediate repaint fires while we
            // add, bring-to-front, and show the child — prevents the
            // one-frame flicker/wipe seen when postcards load.
            this.pnlDashboard.SuspendLayout();
            this.pnlDashboard.Controls.Add(childForm);
            this.pnlDashboard.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.pnlDashboard.ResumeLayout(true);

            lblTitle.Text = childForm.Text;
        }

        public void SwitchToForm(Form newForm)
        {
            OpenChildForm(newForm, null);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Student_Dashboard.Profile(studentId), sender);
        }
        private void btnCourses_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Student_Dashboard.Courses(studentId), sender);
        }
        private void btnActivities_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Student_Dashboard.Activities(studentId), sender);
        }
        private void btnGrades_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Student_Dashboard.Grade(studentId), sender);
        }
        private void btnAssessment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Student_Dashboard.Assessment(studentId), sender);
        }
        private void btnAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Student_Dashboard.Attendance(studentId), sender);
        }
        private void btnMessages_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Student_Dashboard.Messages(studentId), sender);
        }
        private void pnlProfile_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            //pnlHeader.BackColor = Color.FromArgb(0, 150, 136);
            //logoPanel.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool isMaximized = false;
        private GraphicsPath storedPath;
        private Rectangle storedRect;
        private int cornerRadius = 20;
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}