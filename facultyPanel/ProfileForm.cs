using LMS.Rounded_Region;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace LMS.facultyPanel
{
    public partial class ProfileForm : Form
    {
        private string Username;

        public ProfileForm(string username)
        {
            InitializeComponent();
            Username = username;
            this.Load += facultyProfile_Load;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void facultyProfile_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = DbConnection.GetConnection())
        {
            string query1 = "SELECT * FROM LMS_Teachers WHERE TE_USERNAME = @username";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@username", Username);

        try
        {
            con.Open();

            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.Read())
                {
                    string teacherId = reader["TE_ID"].ToString();

                    labelid.Text = teacherId;
                    labelname.Text = reader["TE_NAME"].ToString();
                    labelusrname.Text = reader["TE_USERNAME"].ToString();
                    labelEmail.Text = reader["TE_EMAIL"].ToString();
                    labelpass.Text = reader["TE_PASSWORD"].ToString();
                    date.Text = Convert.ToDateTime(reader["Joining_Date"]).ToString("dd-MM-yyyy");

                            reader.Close(); 

                    string query2 = "SELECT TE_PNUMBER FROM LMS_TeacherPhone WHERE TE_ID = @id";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@id", teacherId);

                    using (SqlDataReader phoneReader = cmd2.ExecuteReader())
                    {
                        int count = 0;
                        while (phoneReader.Read())
                        {
                            string phone = phoneReader["TE_PNUMBER"].ToString();

                            if (count == 0)
                                num1.Text = "+88"+phone +", ";
                            else if (count == 1)
                                num2.Text = "+88"+phone;

                            count++;
                        //only two number can see in the profile
                         if (count >= 2) break;
                         }

                        // if number only one than it called
                        if (count == 0)
                        {
                            num1.Text = "N/A";
                            num2.Text = "";
                        }
                        else if (count == 1)
                        {
                            num2.Text = "";
                        }
                    }
                }
                else
                {
                    labelid.Text = "N/A";
                    labelname.Text = "N/A";
                    labelusrname.Text = "N/A";
                    labelpass.Text = "N/A";
                    date.Text = "N/A";
                    num1.Text = "N/A";
                    num2.Text = "N/A";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error fetching faculty profile: " + ex.Message);
            labelid.Text = "Error";
            labelname.Text = "Error";
            labelusrname.Text = "Error";
            labelpass.Text = "Error";
            date.Text = "Error";
            num1.Text = "Error";
            num2.Text = "Error";
        }
    }
}
        //bool sidebarExpand = true;
        //private void sidebarTransition_Tick(object sender, EventArgs e)
        //{
        //    if (sidebarExpand)
        //    {
        //        sidebar.Width -= 10;
        //        if (sidebar.Width <= 62)
        //        {
        //            sidebarExpand = false;
        //            sidebarTransition.Stop();
        //            pnDashboard.Width = sidebar.Width;
        //            pnAccount.Width = sidebar.Width;
        //            pnCourses.Width = sidebar.Width;
        //            pnQuizes.Width = sidebar.Width;
        //            pnAssignments.Width = sidebar.Width;
        //            pnLogout.Width = sidebar.Width;
        //        }
        //    }
        //    else
        //    {
        //        sidebar.Width += 10;
        //        if (sidebar.Width >= 220)
        //        {
        //            sidebarExpand = true;
        //            sidebarTransition.Stop();

        //            pnDashboard.Width = sidebar.Width;
        //            pnAccount.Width = sidebar.Width;
        //            pnCourses.Width = sidebar.Width;
        //            pnQuizes.Width = sidebar.Width;
        //            pnAssignments.Width = sidebar.Width;
        //            pnLogout.Width = sidebar.Width;
        //        }
        //    }
        //}

        //private void Menu(object sender, EventArgs e)
        //{
        //    //sidebarTransition.Start();
        //}

        private void ProfileForm_Load(object sender, EventArgs e)
        {

        }
        private void facultyDashboard(object sender, EventArgs e)
        {
            FacultyDashboard d1 = new FacultyDashboard(Username);
            d1.Show();
            this.Hide();
        }

        private void Course(object sender, EventArgs e)
        {
            CourseForm c1 = new CourseForm(Username);
            c1.Show();
            this.Hide();
        }

        private void quizes(object sender, EventArgs e)
        {
            facultyQuiz q1 = new facultyQuiz(Username);
            q1.Show();
            this.Hide();
        }

        private void assignments(object sender, EventArgs e)
        {
            TAssignment a1 = new TAssignment(Username);
            a1.Show();
            this.Hide();
        }

        private void LogOut(object sender, EventArgs e)
        {
            LoginForm l1 = new LoginForm();
            l1.Show();
            this.Hide();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
