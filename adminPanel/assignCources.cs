using LMS.Rounded_Region;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LMS.adminPanel
{
    public partial class assignCources : Form
    {
        private string _adminUsername;

        public assignCources(string adminUsername)
        {
            _adminUsername = adminUsername;
            InitializeComponent();
            namelbl.Text = _adminUsername;

            LoadCoursesToComboBox();
            LoadStudentsToComboBox();
            LoadTeachesToComboBox(); 
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        
        }
        private void LoadCourses(int? courseId = null)
        {
            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string query = "SELECT * FROM CourseAssignList";
                    if (courseId.HasValue)
                        query += " WHERE C_ID = @cid";

                    SqlDataAdapter da = new SqlDataAdapter(query, sql);
                    if (courseId.HasValue)
                    da.SelectCommand.Parameters.AddWithValue("@cid", courseId.Value);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    if (dataGridView1.Columns.Contains("C_ID") && dataGridView1.Columns.Contains("TE_ID") && dataGridView1.Columns.Contains("ST_ID"))
                    {
                        dataGridView1.Columns["C_ID"].Visible = false;
                        dataGridView1.Columns["TE_ID"].Visible = false;
                        dataGridView1.Columns["ST_ID"].Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading course details! " + ex.Message);
            }
        }
        private void LoadStudents(int? studentId = null)
        {
            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string query = "SELECT * FROM CourseAssignList";
                    if (studentId.HasValue)
                        query += " WHERE ST_ID = @stid";

                    SqlDataAdapter da = new SqlDataAdapter(query, sql);
                    if (studentId.HasValue)
                        da.SelectCommand.Parameters.AddWithValue("@stid", studentId.Value);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns.Contains("ST_ID"))
                        dataGridView1.Columns["ST_ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student details! " + ex.Message);
            }
        }
        private void LoadTeachers(int? TE_Id = null)
        {
            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string query = "SELECT * FROM CourseAssignList";
                    if (TE_Id.HasValue)
                        query += " WHERE TE_ID = @stid";

                    SqlDataAdapter da = new SqlDataAdapter(query, sql);
                    if (TE_Id.HasValue)
                        da.SelectCommand.Parameters.AddWithValue("@stid", TE_Id.Value);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // Optionally hide the primary key column
                    if (dataGridView1.Columns.Contains("TE_ID"))
                        dataGridView1.Columns["TE_ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student details! " + ex.Message);
            }
        }


        private void assignCources_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int courseId))
            {
                LoadCourses(courseId);
            }
            else
            {
                LoadCourses(); 
            }

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

        private void LoadStudentsToComboBox()
        {
            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string query = "SELECT * FROM LMS_Students";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "ST_Name";
                    comboBox2.ValueMember = "ST_ID";
                    comboBox2.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }
        private void LoadTeachesToComboBox()
        {
            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string query = "SELECT * FROM LMS_Teachers";
                    SqlCommand cmd = new SqlCommand(query, sql);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox3.DataSource = dt;
                    comboBox3.DisplayMember = "TE_Name";
                    comboBox3.ValueMember = "TE_ID";
                    comboBox3.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int ST_Id))
            {
                LoadStudents(ST_Id);
            }
            else
            {
                LoadStudents();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int TE_Id))
            {
                LoadTeachers(TE_Id);
            }
            else
            {
                LoadTeachers();
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null || comboBox3.SelectedValue == null)
            {
                MessageBox.Show("Please select a course, student, and teacher.");
                return;
            }

            int courseId = Convert.ToInt32(comboBox1.SelectedValue);
            int studentId = Convert.ToInt32(comboBox2.SelectedValue);
            int teacherId = Convert.ToInt32(comboBox3.SelectedValue);

            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();

                    string checkTeacherQuery = "SELECT COUNT(*) FROM Teacher_Teaches_Course WHERE C_ID = @cid AND TE_ID = @teid";
                    using (SqlCommand checkCmd = new SqlCommand(checkTeacherQuery, sql))
                    {
                        checkCmd.Parameters.AddWithValue("@cid", courseId);
                        checkCmd.Parameters.AddWithValue("@teid", teacherId);
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists == 0)
                        {
                            string teacherQuery = "INSERT INTO Teacher_Teaches_Course (C_ID, TE_ID) VALUES (@cid, @teid)";
                            using (SqlCommand cmd = new SqlCommand(teacherQuery, sql))
                            {
                                cmd.Parameters.AddWithValue("@cid", courseId);
                                cmd.Parameters.AddWithValue("@teid", teacherId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    string checkStudentQuery = "SELECT COUNT(*) FROM Student_Course_EnrolledIn WHERE C_ID = @cid AND ST_ID = @stid";
                    using (SqlCommand checkCmd = new SqlCommand(checkStudentQuery, sql))
                    {
                        checkCmd.Parameters.AddWithValue("@cid", courseId);
                        checkCmd.Parameters.AddWithValue("@stid", studentId);
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists == 0)
                        {
                            string studentQuery = "INSERT INTO Student_Course_EnrolledIn (C_ID, ST_ID) VALUES (@cid, @stid)";
                            using (SqlCommand cmd = new SqlCommand(studentQuery, sql))
                            {
                                cmd.Parameters.AddWithValue("@cid", courseId);
                                cmd.Parameters.AddWithValue("@stid", studentId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                MessageBox.Show("Course assigned to student and teacher successfully!");
                LoadCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error assigning course: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Admin_Dashboard admin_Dashboard = new Admin_Dashboard(_adminUsername);
            admin_Dashboard.FormClosed += (s, args) => Application.Exit();
            admin_Dashboard.Show();
            this.Hide();
        }
    }
}
