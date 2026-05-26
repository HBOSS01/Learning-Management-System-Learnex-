using LMS.Rounded_Region;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LMS.LogIn_Panel
{
    public partial class forgetPass : Form
    {
        public forgetPass()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Teacher");
            comboBox1.Items.Add("Student");
            comboBox1.SelectedIndex = 0;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        roundedRegion region = new roundedRegion();
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void resetbtn_Click_1(object sender, EventArgs e)
        {
            string userType = comboBox1.SelectedItem?.ToString();
            string username = usrnamebox.Text.Trim();
            string email = emailbox.Text.Trim();
            string newPassword = passbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();
                string query = "";
                if (userType == "Teacher")
                {
                    query = "UPDATE LMS_Teachers SET TE_Password = @password WHERE TE_Username = @username AND TE_Email = @email";
                }
                else
                {
                    query = "UPDATE LMS_Students SET ST_Password = @password WHERE ST_Username = @username AND ST_Email = @email";
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Password updated successfully!");
                        LoginForm loginForm = new LoginForm();
                        loginForm.FormClosed += (s, args) => this.Close();
                        loginForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username and email do not match any record.");
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(panel1, 20);
        }

        private void passbox_TextChanged(object sender, EventArgs e)
        {
            if (passbox.Text == "Enter new password")
                passbox.Text = "";
        }

        private void emailbox_TextChanged(object sender, EventArgs e)
        {
            if (emailbox.Text == "Enter Your Email Address")
                passbox.Text = ""; 
        }
        private void namebox_TextChanged(object sender, EventArgs e)
        {
            if (usrnamebox.Text == "Enter Your UserName")
                passbox.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}

