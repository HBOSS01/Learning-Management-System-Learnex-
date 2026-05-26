using LMS.Rounded_Region;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LMS.facultyPanel
{
    public partial class CourseForm : Form
    {
        private string Username;

        public CourseForm(string username)
        {
            InitializeComponent();
            sidebar.Width = 62;
            sidebarExpand = false;

            pnDashboard.Width = sidebar.Width;
            pnAccount.Width = sidebar.Width;
            pnCourses.Width = sidebar.Width;
            pnQuizes.Width = sidebar.Width;
            pnAssignments.Width = sidebar.Width;
            pnLogout.Width = sidebar.Width;
            Username = username;

            this.Load += CourseForm_Load; this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
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

        private void Menu(object sender, EventArgs e)
        {
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCourseStudentList();
        }

        private void LoadCourseStudentList()
        {
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();

                // Get the teacher's ID based on the logged-in username
                int teacherId = 0;
                using (var cmd = new SqlCommand("SELECT TE_ID FROM LMS_Teachers WHERE TE_Username = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", Username);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        teacherId = Convert.ToInt32(result);
                }

                // Now get the course and student names for this teacher
                using (var cmd = new SqlCommand(
                    "SELECT C_Name, ST_Name FROM CourseAssignList WHERE TE_ID = @tid", con))
                {
                    cmd.Parameters.AddWithValue("@tid", teacherId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void dashboard(object sender, EventArgs e)
        {
            FacultyDashboard dashboard = new FacultyDashboard(Username);
            dashboard.FormClosed += (s, args) => Application.Exit();
            this.Hide();
            dashboard.Show();
        }

        private void myaccount(object sender, EventArgs e)
        {
            ProfileForm m1 = new ProfileForm(Username);
            m1.FormClosed += (s, args) => Application.Exit();
            this.Hide();
            m1.Show();
        }

        private void quizes(object sender, EventArgs e)
        {
            facultyQuiz q1 = new facultyQuiz(Username);
            q1.FormClosed += (s, args) => Application.Exit();
            q1.Show();
            this.Hide();
        }

        private void assignments(object sender, EventArgs e)
        {
            TAssignment a1 = new TAssignment(Username);
            a1.FormClosed += (s, args) => Application.Exit();
            a1.Show();
            this.Hide();
        }

        private void LogOut(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
