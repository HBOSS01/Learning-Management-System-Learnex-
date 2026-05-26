using LMS.Rounded_Region;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LMS.adminPanel
{
    public partial class courseAdd : Form
    {
        private string _adminUsername;
        private int selectedCourseId = -1;

        public courseAdd(string adminUsername)
        {
            InitializeComponent();
            _adminUsername = adminUsername;
            namelbl.Text = _adminUsername;
            LoadCourses();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        

        private void LoadCourses()
        {
            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string query = "SELECT C_ID, C_Name FROM LMS_Courses";
                    SqlDataAdapter da = new SqlDataAdapter(query, sql);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    if (dataGridView1.Columns.Contains("C_ID"))
                        dataGridView1.Columns["C_ID"].Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard(_adminUsername);
            ad.FormClosed += (s, args) => Application.Exit();
            ad.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string courseName = namebox.Text.Trim();

            if (string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please fill in the course name.");
                return;
            }

            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string insertQuery = @"INSERT INTO LMS_Courses (C_Name) VALUES (@name)";
                    SqlCommand cmd = new SqlCommand(insertQuery, sql);
                    cmd.Parameters.AddWithValue("@name", courseName);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Course added successfully.");
                    ClearFields();
                    LoadCourses();
                    selectedCourseId = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting course: " + ex.Message);
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to edit.");
                return;
            }

            string courseName = namebox.Text.Trim();

            if (string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please fill in the course name.");
                return;
            }

            try
            {
                using (SqlConnection sql = new SqlConnection(@"server=LMS\SQLEXPRESS;database=LMS;integrated Security=SSPI;"))
                {
                    sql.Open();
                    string updateQuery = @"UPDATE LMS_Courses SET C_Name = @name WHERE C_ID = @id";
                    SqlCommand cmd = new SqlCommand(updateQuery, sql);
                    cmd.Parameters.AddWithValue("@name", courseName);
                    cmd.Parameters.AddWithValue("@id", selectedCourseId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Course updated successfully.");
                    ClearFields();
                    LoadCourses();
                    selectedCourseId = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating course: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                if (row.Cells["C_ID"].Value != DBNull.Value)
                {
                    selectedCourseId = Convert.ToInt32(row.Cells["C_ID"].Value);
                    namebox.Text = row.Cells["C_Name"].Value?.ToString() ?? "";
                }
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            ClearFields();
            selectedCourseId = -1;
        }

        private void ClearFields()
        {
            namebox.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this course?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection sql = new SqlConnection(@"server=LMS\SQLEXPRESS;database=LMS;integrated Security=SSPI;"))
                {
                    sql.Open();
                    string deleteQuery = "DELETE FROM LMS_Courses WHERE C_ID = @id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, sql);
                    cmd.Parameters.AddWithValue("@id", selectedCourseId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Course deleted successfully.");
                    ClearFields();
                    LoadCourses();
                    selectedCourseId = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting course: " + ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
