using LMS.facultyPanel;
using LMS.LogIn_Panel;
using LMS.Rounded_Region;
using LMS.studentPanel;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text.Trim();
            string password = passwordBox.Text.Trim();

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                string queryAdmin = "SELECT COUNT(*) FROM LMS_Admins WHERE AD_Username = @username AND AD_Password = @password";
                using (SqlCommand cmd = new SqlCommand(queryAdmin, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Admin login successful!");
                        Form dashboard = new Admin_Dashboard(username);
                        dashboard.FormClosed += (s, args) => Application.Exit();
                        dashboard.Show();
                        this.Hide();
                        return;
                    }
                }

                string queryTeacher = "SELECT COUNT(*) FROM LMS_Teachers WHERE TE_Username = @username AND TE_Password = @password";
                using (SqlCommand cmd = new SqlCommand(queryTeacher, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Teacher login successful!");
                        Form dashboard = new FacultyDashboard(username);
                        dashboard.FormClosed += (s, args) => Application.Exit();
                        dashboard.Show();
                        this.Hide();
                        return;
                    }
                }

                string queryStudent = "SELECT COUNT(*) FROM LMS_Students WHERE ST_Username = @username AND ST_Password = @password";
                using (SqlCommand cmd = new SqlCommand(queryStudent, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Student login successful!");
                        Form dashboard = new studentDashboard(username);
                        dashboard.FormClosed += (s, args) => Application.Exit();
                        dashboard.Show();
                        this.Hide();
                        return;
                    }
                }
                MessageBox.Show("Invalid username or password.");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(passwordBox.PasswordChar == '*')
            {
                button1.BringToFront();
                passwordBox.PasswordChar = '\0';
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (passwordBox.PasswordChar == '\0')
            {
                button3.BringToFront();
                passwordBox.PasswordChar = '*';
            }
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_Up sign_Up = new Sign_Up();
            sign_Up.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgetPass forgetPassForm = new forgetPass();
            forgetPassForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}