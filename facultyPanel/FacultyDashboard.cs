using LMS.Rounded_Region;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LMS.facultyPanel
{
    public partial class FacultyDashboard : Form
    {
        private string Username;

        public FacultyDashboard(string username)
        {
            InitializeComponent();
            Username = username;
            sidebar.Width = 62;
            sidebarExpand = false;

            pnDashboard.Width = sidebar.Width;
            pnAccount.Width = sidebar.Width;
            pnCourses.Width = sidebar.Width;
            pnQuizes.Width = sidebar.Width;
            pnAssignments.Width = sidebar.Width;
            pnLogout.Width = sidebar.Width;

            LoadTeacherDashboardData();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        roundedRegion region = new roundedRegion();
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 62)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    pnDashboard.Width = sidebar.Width;
                    pnAccount.Width = sidebar.Width;
                    pnCourses.Width = sidebar.Width;
                    pnQuizes.Width = sidebar.Width;
                    pnAssignments.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 220)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pnDashboard.Width = sidebar.Width;
                    pnAccount.Width = sidebar.Width;
                    pnCourses.Width = sidebar.Width;
                    pnQuizes.Width = sidebar.Width;
                    pnAssignments.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }
        }

        private void menu(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void profile(object sender, EventArgs e)
        {
            ProfileForm m1 = new ProfileForm(Username);
            m1.FormClosed += (s, args) => Application.Exit();
            m1.Show();
            this.Hide();
        }

        private void course(object sender, EventArgs e)
        {
            CourseForm c1 = new CourseForm(Username);
            c1.FormClosed += (s, args) => Application.Exit();
            c1.Show();
            this.Hide();
        }

        private void quiz(object sender, EventArgs e)
        {
            facultyQuiz q1 = new facultyQuiz(Username);
            q1.FormClosed += (s, args) => Application.Exit();
            q1.Show();
            this.Hide();
        }

        private void assignment(object sender, EventArgs e)
        {
            TAssignment a1 = new TAssignment(Username);
            a1.FormClosed += (s, args) => Application.Exit();
            a1.Show();
            this.Hide();
        }

        private void logout(object sender, EventArgs e)
        {
            LoginForm l1 = new LoginForm();
            l1.FormClosed += (s, args) => Application.Exit();
            l1.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadTeacherDashboardData()
        {
            using (var con = DbConnection.GetConnection())
            {
                con.Open();

                // Get teacher's name and ID
                string name = "";
                int teacherId = 0;
                using (var cmd = new SqlCommand("SELECT TE_ID, TE_Name FROM LMS_Teachers WHERE TE_Username = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", Username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            teacherId = reader.GetInt32(0);
                            name = reader.GetString(1);
                        }
                    }
                }
                namelbl.Text = name;

                // Get courses count
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Teacher_Teaches_Course WHERE TE_ID = @tid", con))
                {
                    cmd.Parameters.AddWithValue("@tid", teacherId);
                    coursenmbr.Text = cmd.ExecuteScalar().ToString();
                }

                // Get quizzes count
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Teacher_Quiz WHERE TE_ID = @tid", con))
                {
                    cmd.Parameters.AddWithValue("@tid", teacherId);
                    quiznmbr.Text = cmd.ExecuteScalar().ToString();
                }

                // Get assignments count
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM AssignmentStudentTeacherView WHERE TE_ID = @tid", con))
                {
                    cmd.Parameters.AddWithValue("@tid", teacherId);
                    assnmbr.Text = cmd.ExecuteScalar().ToString();
                }

                // Get students count (students enrolled in teacher's courses)
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM CourseAssignList WHERE TE_ID = @tid", con))
                {
                    cmd.Parameters.AddWithValue("@tid", teacherId);
                    studentnmbr.Text = cmd.ExecuteScalar().ToString();
                }
            }
        }

        private void roundedPanel_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(roundedPanel, 20);
            region.SetRoundedRegion(panel4, 20);
            region.SetRoundedRegion(panel5, 20);
            region.SetRoundedRegion(panel6, 20);
            region.SetRoundedRegion(panel7, 20);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
