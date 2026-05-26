using LMS.Rounded_Region;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LMS.facultyPanel
{
    public partial class TAssignment : Form
    {
        private string Username;
        public TAssignment(string USERNAME)
        {
            InitializeComponent();
            Username = USERNAME;
            //sidebar.Width = 62;
            //sidebarExpand = false;

            //pnDashboard.Width = sidebar.Width;
            //pnAccount.Width = sidebar.Width;
            //pnCourses.Width = sidebar.Width;
            //pnQuizes.Width = sidebar.Width;
            //pnAssignments.Width = sidebar.Width;
            //pnLogout.Width = sidebar.Width;

            LoadAssignments();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
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
        //    sidebarTransition.Start();
        //}
        private void dashboard(object sender, EventArgs e)
        {
            FacultyDashboard dashboard = new FacultyDashboard(Username);
            dashboard.Show();
            this.Hide();
        }

        private void myaccount(object sender, EventArgs e)
        {
            ProfileForm m1 = new ProfileForm(Username);
            m1.Show();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void downloadbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int assignmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AS_ID"].Value);
                    string fileName = dataGridView1.SelectedRows[0].Cells["AS_FileName"].Value.ToString();

                    byte[] fileData = null;

                    using (SqlConnection conn = DbConnection.GetConnection())
                    using (SqlCommand cmd = new SqlCommand("SELECT AS_FilePath FROM LMS_Assignment WHERE AS_ID = @AS_ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@AS_ID", assignmentId);
                        conn.Open();
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                            fileData = (byte[])result;
                    }

                    if (fileData != null)
                    {
                        using (SaveFileDialog sfd = new SaveFileDialog())
                        {
                            sfd.FileName = fileName;
                            sfd.Filter = "All files (*.*)|*.*";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                System.IO.File.WriteAllBytes(sfd.FileName, fileData);
                                MessageBox.Show("File downloaded successfully.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("File data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an assignment to download.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LoadAssignments()
        {
            DataTable dt = new DataTable();
            string query = "SELECT AS_ID, AS_FileName, AS_UploadDate, C_ID, TE_ID, ST_Username FROM AssignmentStudentTeacherView";

            using (SqlConnection conn = DbConnection.GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                adapter.Fill(dt);
            }

            dataGridView1.DataSource = dt;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
