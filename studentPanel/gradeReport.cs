using LMS.Rounded_Region;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace LMS.studentPanel
{
    public partial class gradeReport : Form
    {
        private string user;

        public gradeReport(string User)
        {
            InitializeComponent();
            user = User;
            LoadStudentData();

        }
        roundedRegion region = new roundedRegion();

        private void EXIT(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void MINIMIZE(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        private void profile(object sender, EventArgs e)
        {
            studentProfile f1 = new studentProfile(user);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void assignment(object sender, EventArgs e)
        {
            studentAssignment f1 = new studentAssignment(user);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void LOGOUT(object sender, EventArgs e)
        {
            LoginForm f1 = new LoginForm();
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }
        private void Home(object sender, EventArgs e)
        {
            studentDashboard d = new studentDashboard(user);
            d.FormClosed += (s, args) => Application.Exit();
            d.Show();
            this.Hide();
        }
        private void quiz(object sender, EventArgs e)
        {
            Quiz f1 = new Quiz(user);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }
        private void LoadStudentData()
        {
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                string studentName = "";
                int studentId = 0;
                using (var cmd = new SqlCommand("SELECT ST_ID, ST_NAME FROM LMS_Students WHERE ST_USERNAME = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", user);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            studentId = reader.GetInt32(0);
                            studentName = reader.GetString(1);
                        }
                        else
                        {
                            MessageBox.Show("Student not found.");
                            return;
                        }
                    }
                }
                namelbl.Text = studentName;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(grade, 20);
            region.SetRoundedRegion(gpa, 20);
            region.SetRoundedRegion(details, 20);

        }
    }

}
