using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace LMS.studentPanel
{
    public partial class studentAssignment : Form
    {
        private string studentUsername;

        public studentAssignment(string username)
        {
            InitializeComponent();
            studentUsername = username;
            this.Load += studentAssignment_Load;
        }

        private void studentAssignment_Load(object sender, EventArgs e)
        {
            LoadUploadedAssignments();
        }

        private void LoadUploadedAssignments()
        {

            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                string studentName = "";
                int TeacherId = 0;
                using (var cmd = new SqlCommand("SELECT TE_ID FROM LMS_Teachers WHERE TE_USERNAME = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", studentUsername);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TeacherId = reader.GetInt32(0);
                        }
                    }
                }
                using (var cmd = new SqlCommand("SELECT ST_Name FROM LMS_Students WHERE ST_USERNAME = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", studentUsername);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            studentName = reader.GetString(0);
                        }
                        else
                        {
                            MessageBox.Show("Student not found.");
                            return;
                        }
                    }
                }
                label2.Text = studentName;

                using (var cmd = new SqlCommand("SELECT AS_ID, AS_FileName, AS_UploadDate, C_ID, TE_ID, ST_Username FROM AssignmentStudentTeacherView WHERE ST_Username = @ST_Username", con))
                    {
                        cmd.Parameters.AddWithValue("@ST_Username", studentUsername);
                        using (var reader = cmd.ExecuteReader())
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            dt.Load(reader);

                            dataGridView1.DataSource = dt;
                        }
                    }
                con.Close();

            }

        }
        

        private void browsebtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|Word files (*.doc;*.docx)|*.doc;*.docx";
            openFileDialog1.Title = "Select Assignment File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                richTextBox1.Text = filePath;
            }
        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {
            string filePath = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please select a valid file first using the Browse button.");
                return;
            }

            string fileName = Path.GetFileName(filePath);
            byte[] fileData = File.ReadAllBytes(filePath);

            //string studentUsername = "S"; // Assumed to be defined elsewhere

            //int cId = 0;
            //int teId = 0;

            //using (SqlConnection con = DbConnection.GetConnection())
            //{
            //    con.Open();

            //    try
            //    {
            //        // Get Course ID where this student is enrolled
            //        using (SqlCommand cmd = new SqlCommand(@"
            //    SELECT TOP 1 C_ID 
            //    FROM Student_Course_EnrolledIn 
            //    WHERE ST_ID = (SELECT ST_ID FROM LMS_Students WHERE ST_Username = @Username)", con))
            //        {
            //            cmd.Parameters.AddWithValue("@Username", studentUsername);
            //            var result = cmd.ExecuteScalar();
            //            if (result != null)
            //                cId = Convert.ToInt32(result);
            //            else
            //                throw new Exception("No course found for this student.");
            //        }

            //        // Get Teacher ID who teaches this course
            //        using (SqlCommand cmd = new SqlCommand(@"
            //    SELECT TOP 1 TE_ID 
            //    FROM Teacher_Teaches_Course 
            //    WHERE C_ID = @C_ID", con))
            //        {
            //            cmd.Parameters.AddWithValue("@C_ID", cId);
            //            var result = cmd.ExecuteScalar();
            //            if (result != null)
            //                teId = Convert.ToInt32(result);
            //            else
            //                throw new Exception("No teacher found for this course.");
            //        }

            //        // Call Save method
            //        SaveAssignmentToDatabase(fileName, fileData, cId, teId, studentUsername);

            //        MessageBox.Show("Assignment uploaded successfully!");
            //        richTextBox1.Clear();
            //        LoadUploadedAssignments(); 
            //    }
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: " + ex.Message);
                //}
            //}
        }


        private void SaveAssignmentToDatabase(string fileName, byte[] fileData, int cId, int teId, string studentUsername)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Get Student ID from Username
                    int studentId;
                    using (SqlCommand getStudentIdCmd = new SqlCommand("SELECT ST_ID FROM LMS_Students WHERE ST_Username = @Username", con, transaction))
                    {
                        getStudentIdCmd.Parameters.AddWithValue("@Username", studentUsername);
                        studentId = (int)getStudentIdCmd.ExecuteScalar();
                    }

                    // Insert into LMS_Assignment
                    int assignmentId;
                    using (SqlCommand insertAssignmentCmd = new SqlCommand(
                        @"INSERT INTO LMS_Assignment (AS_Name, AS_FilePath, AS_DueDate, AS_TotalMarks) 
                        OUTPUT INSERTED.AS_ID
      V                 VALUES (@FileName, @FilePath, @DueDate, @TotalMarks)", con, transaction))
                    {
                        insertAssignmentCmd.Parameters.AddWithValue("@FileName", fileName);
                        insertAssignmentCmd.Parameters.AddWithValue("@FilePath", fileData); // Use the file path, not file data
                        insertAssignmentCmd.Parameters.AddWithValue("@DueDate", DateTime.Now.AddDays(7)); // Example due date
                        insertAssignmentCmd.Parameters.AddWithValue("@TotalMarks", 100); // Example total marks
                        assignmentId = (int)insertAssignmentCmd.ExecuteScalar();
                    }

                    // Insert into Course_Assignment
                    using (SqlCommand courseAssignmentCmd = new SqlCommand(
                        "INSERT INTO Course_Assignment (AS_ID, C_ID) VALUES (@AS_ID, @C_ID)", con, transaction))
                    {
                        courseAssignmentCmd.Parameters.AddWithValue("@AS_ID", assignmentId);
                        courseAssignmentCmd.Parameters.AddWithValue("@C_ID", cId);
                        courseAssignmentCmd.ExecuteNonQuery();
                    }

                    // Insert into Assignment_Manage
                    using (SqlCommand manageCmd = new SqlCommand(
                        "INSERT INTO Assignment_Manage (AS_ID, TE_ID) VALUES (@AS_ID, @TE_ID)", con, transaction))
                    {
                        manageCmd.Parameters.AddWithValue("@AS_ID", assignmentId);
                        manageCmd.Parameters.AddWithValue("@TE_ID", teId);
                        manageCmd.ExecuteNonQuery();
                    }

                    // Insert into Assignment_Submits
                    using (SqlCommand submitCmd = new SqlCommand(
                        "INSERT INTO Assignment_Submits (AS_ID, ST_ID) VALUES (@AS_ID, @ST_ID)", con, transaction))
                    {
                        submitCmd.Parameters.AddWithValue("@AS_ID", assignmentId);
                        submitCmd.Parameters.AddWithValue("@ST_ID", studentId);
                        submitCmd.ExecuteNonQuery();
                    }

                    // Insert into LMS_Submission_Info
                    int submissionId;
                    using (SqlCommand submissionInfoCmd = new SqlCommand(
                        @"INSERT INTO LMS_Submission_Info (Submission_Timestamp, Submission_FilePath, Submission_Grade)
                  OUTPUT INSERTED.Submission_ID
                  VALUES (@Timestamp, @FileData, @Grade)", con, transaction))
                    {
                        submissionInfoCmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                        submissionInfoCmd.Parameters.AddWithValue("@FileData", fileData);
                        submissionInfoCmd.Parameters.AddWithValue("@Grade", DBNull.Value); // grade can be updated later
                        submissionId = (int)submissionInfoCmd.ExecuteScalar();
                    }

                    // Link Assignment and Submission
                    using (SqlCommand assignSubmissionCmd = new SqlCommand(
                        "INSERT INTO Assignment_Submission (AS_ID, Submission_ID) VALUES (@AS_ID, @Submission_ID)", con, transaction))
                    {
                        assignSubmissionCmd.Parameters.AddWithValue("@AS_ID", assignmentId);
                        assignSubmissionCmd.Parameters.AddWithValue("@Submission_ID", submissionId);
                        assignSubmissionCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        private void EXIT(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            studentDashboard h1 = new studentDashboard(studentUsername);
            h1.FormClosed += (s, args) => this.Close();
            h1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void MINIMIZE(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        

        private void BACK(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.FormClosed += (s, args) => this.Close();
            lf.Show();
            this.Hide();
        }

        private void qzbtn_Click(object sender, EventArgs e)
        {
            Quiz f1 = new Quiz(studentUsername);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void PROFILE(object sender, EventArgs e)
        {
            studentProfile f1 = new studentProfile(studentUsername);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void notebtn_Click(object sender, EventArgs e)
        {
            gradeReport g1 = new gradeReport(studentUsername);
            g1.FormClosed += (s, args) => Application.Exit();
            g1.Show();
            this.Hide();
        }
    }
}
