using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LMS.studentPanel
{
    public partial class studentProfile : Form
    {
        private string studentUsername;

        // Constructor accepts the student's username
        public studentProfile(string studentUsername)
        {
            InitializeComponent();
            this.studentUsername = studentUsername;
            this.Load += studentProfile_Load; // Wire up the Load event
        }

        //private void SetRoundedRegion(Control control, int radius)
        //{
        //    Rectangle bounds = control.ClientRectangle;
        //    GraphicsPath path = new GraphicsPath();

        //    int diameter = radius * 2;
        //    path.StartFigure();
        //    path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        //    path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        //    path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        //    path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        //    path.CloseFigure();

        //    control.Region = new Region(path);
        //}

        private void studentProfile_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query1 = "SELECT * FROM LMS_Students WHERE ST_USERNAME = @username";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@username", studentUsername);

                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string teacherId = reader["ST_ID"].ToString();

                            labelid.Text = teacherId;
                            labelname.Text = reader["ST_NAME"].ToString();
                            labelusrname.Text = reader["ST_USERNAME"].ToString();
                            labelEmail.Text = reader["ST_EMAIL"].ToString();
                            labelpass.Text = reader["ST_PASSWORD"].ToString();
                            date.Text = Convert.ToDateTime(reader["Registration_Date"]).ToString("dd-MM-yyyy");

                            reader.Close();

                            string query2 = "SELECT ST_PNUMBER FROM LMS_StudentPhone WHERE ST_ID = @id";
                            SqlCommand cmd2 = new SqlCommand(query2, con);
                            cmd2.Parameters.AddWithValue("@id", teacherId);

                            using (SqlDataReader phoneReader = cmd2.ExecuteReader())
                            {
                                int count = 0;
                                while (phoneReader.Read())
                                {
                                    string phone = phoneReader["ST_PNUMBER"].ToString();

                                    if (count == 0)
                                        num1.Text = "+88" + phone + ", ";
                                    else if (count == 1)
                                        num2.Text = "+88" + phone;

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

        private void EXIT(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            studentDashboard s1 = new studentDashboard(studentUsername);
            s1.FormClosed += (s, args) => Application.Exit();
            s1.Show();
            this.Hide();
        }

        private void LOGOUT(object sender, EventArgs e)
        {
            LoginForm s1 = new LoginForm();
            s1.FormClosed += (s, args) => Application.Exit();
            s1.Show();
            this.Hide();
        }

        private void labelname_Click(object sender, EventArgs e)
        {

        }


        private void matbtn_Click_1(object sender, EventArgs e)
        {
            studentAssignment f1 = new studentAssignment(studentUsername);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void studentProfile_Load_1(object sender, EventArgs e)
        {

        }

        private void MINIMIZE(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void qzbtn_Click(object sender, EventArgs e)
        {
            Quiz f1 = new Quiz(studentUsername);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

            private void notebtn_Click(object sender, EventArgs e){
            gradeReport g1 = new gradeReport(studentUsername);
            g1.FormClosed += (s, args) => Application.Exit();
            g1.Show();
            this.Hide();
        }
    }
    
}
