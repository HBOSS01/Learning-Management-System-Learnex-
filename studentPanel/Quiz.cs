using LMS.Rounded_Region;
using System;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace LMS.studentPanel
{
    public partial class Quiz: Form
    {
        private string user;
        public Quiz(string User)
        {
            InitializeComponent();
            user = User;
            LoadCoursesToComboBox();
            LoadquizToComboBox();
        }
        roundedRegion region = new roundedRegion();

        private void EXIT(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void LoadCoursesToComboBox()
        {
            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string query = "SELECT C_ID, C_Name FROM LMS_Courses";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "C_Name";
                    comboBox1.ValueMember = "C_ID";
                    comboBox1.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }


        private void LoadquizToComboBox()
        {
            try
            {
                using (var con = LMS.DbConnection.GetConnection())
                {
                    con.Open();
                    string studentName = "";
                    int studentId = 0;
                    using (SqlCommand cmd = new SqlCommand("SELECT ST_ID, ST_Name FROM LMS_Students WHERE ST_Username = @username", con))
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
                    label2.Text = studentName;


                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT DISTINCT q.QU_ID, q.QU_Name 
                        FROM LMS_Quiz q, Course_Quiz cq, Student_Course_EnrolledIn s 
                        WHERE q.QU_ID = cq.QU_ID AND cq.C_ID = s.C_ID AND s.ST_ID = @stId", con))
                    {
                        cmd.Parameters.AddWithValue("@stId", studentId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        comboBox2.DataSource = dt;
                        comboBox2.DisplayMember = "QU_Name";
                        comboBox2.ValueMember = "QU_ID";
                        comboBox2.SelectedIndex = -1;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading quizzes: " + ex.Message);
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentProfile f1 = new studentProfile(user);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void matbtn_Click(object sender, EventArgs e)
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



        private void quizStartBtn_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a quiz to start.");
                return;
            }

            int selectedCourseId = Convert.ToInt32(comboBox1.SelectedValue);
            int selectedQuizId = Convert.ToInt32(comboBox2.SelectedValue);
            int attemptId = 0;

            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand(
                    "INSERT INTO QuizAttempt_Quiz (QU_ID) OUTPUT INSERTED.AT_ID VALUES (@quizId)", con))
                {
                    cmd.Parameters.AddWithValue("@quizId", selectedQuizId);
                    attemptId = (int)cmd.ExecuteScalar();
                }
            }

            QuizAttempt quizForm = new QuizAttempt(user, selectedCourseId, attemptId);
            quizForm.FormClosed += (s, args) => this.Show(); 
            quizForm.Show();
            this.Hide();
        }

        private void MINIMIZE(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(panel2, 20);
            region.SetRoundedRegion(quizStartBtn, 16);
        }

        private void notebtn_Click(object sender, EventArgs e)
        {
            gradeReport g1 = new gradeReport(user);
            g1.FormClosed += (s, args) => Application.Exit();
            g1.Show();
            this.Hide();
        }
    }
}

