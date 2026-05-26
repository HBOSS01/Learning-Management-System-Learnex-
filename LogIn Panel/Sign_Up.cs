using LMS.Rounded_Region;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LMS.LogIn_Panel
{
    public partial class Sign_Up : Form
    {
        public Sign_Up()
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

        private void signupbtn_Click_1(object sender, EventArgs e)
        {
            string name = namebox.Text.Trim();
            string username = usrnamebox.Text.Trim();
            string password = passbox.Text.Trim();
            string email = emailbox.Text.Trim();
            string phone = numberbox.Text.Trim();
            string userType = comboBox1.SelectedItem?.ToString();
            DateTime now = DateTime.Now;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Name and Username are required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                MessageBox.Show("Email is required and must contain '@'.");
                return;
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Phone number is required.");
                return;
            }
            if (!Regex.IsMatch(phone, @"^\d{11}$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
                return;
            }
            if (string.IsNullOrWhiteSpace(userType))
            {
                MessageBox.Show("Please select user type.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                SqlTransaction transaction = null;
                try
                {
                    con.Open();
                    transaction = con.BeginTransaction();

                    if (userType == "Teacher")
                    {
                        string teacherQuery = @"
                            INSERT INTO LMS_Teachers (TE_Name, TE_Username, TE_Password, TE_Email, Joining_Date)
                            VALUES (@name, @username, @password, @email, @joinDate);
                            SELECT SCOPE_IDENTITY();";
                        int teId;
                        using (SqlCommand cmd = new SqlCommand(teacherQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@joinDate", now);
                            teId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        string phoneQuery = "INSERT INTO LMS_TeacherPhone (TE_ID, TE_PNUMBER) VALUES (@id, @phone)";
                        using (SqlCommand phoneCmd = new SqlCommand(phoneQuery, con, transaction))
                        {
                            phoneCmd.Parameters.AddWithValue("@id", teId);
                            phoneCmd.Parameters.AddWithValue("@phone", phone);
                            phoneCmd.ExecuteNonQuery();
                        }
                    }
                    else if (userType == "Student")
                    {
                        string studentQuery = @"
                            INSERT INTO LMS_Students (ST_Name, ST_Username, ST_Password, ST_Email, Registration_Date)
                            VALUES (@name, @username, @password, @email, @regDate);";
                        using (SqlCommand cmd = new SqlCommand(studentQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@regDate", now);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            namebox.Text = "";
            usrnamebox.Text = "";
            passbox.Text = "";
            emailbox.Text = "";
            numberbox.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(panel1, 20);
        }

        private void namebox_TextChanged(object sender, EventArgs e)
        {
            if (namebox.Text == "Enter Your Name")
                namebox.Text = "";
        }

        private void usrnamebox_TextChanged(object sender, EventArgs e)
        {
            if (usrnamebox.Text == "Enter Your UserName")
                usrnamebox.Text = "";

        }

        private void emailbox_TextChanged(object sender, EventArgs e)
        {
            if (emailbox.Text == "Enter Your Email Address")
                emailbox.Text = "";

        }

        private void numberbox_TextChanged(object sender, EventArgs e)
        {
            if (numberbox.Text == "Enter Your Phone Number")
                numberbox.Text = "";

        }

        private void passbox_TextChanged(object sender, EventArgs e)
        {
            if (passbox.Text == "Enter Your Password")
                passbox.Text = "";

        }
    }
}
