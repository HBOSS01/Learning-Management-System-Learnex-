using LMS.Rounded_Region;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using sqlConnection = System.Data.SqlClient.SqlConnection;

namespace LMS.facultyPanel
{
    public partial class facultyQuiz : Form
    {
        private string Username;
        private int selectedQuestionId = -1;

        public facultyQuiz(string username)
        {
            InitializeComponent();
            LoadCoursesToComboBox();
            LoadQuestions();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            Username = username;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void LoadQuestions(int? courseId = null)
        {
            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    string query = "SELECT * FROM QuestionDetails WHERE IsCorrect = 'YES'";
                    if (courseId.HasValue)
                        query += " AND C_ID = @cid"; 
                    SqlDataAdapter da = new SqlDataAdapter(query, sql);
                    if (courseId.HasValue)
                        da.SelectCommand.Parameters.AddWithValue("@cid", courseId.Value);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    if (dataGridView1.Columns.Contains("Q_ID") && dataGridView1.Columns.Contains("C_ID") && dataGridView1.Columns.Contains("QU_ID"))
                    {
                        dataGridView1.Columns["C_ID"].Visible = false; //C_ID HIDE 
                        dataGridView1.Columns["Q_ID"].Visible = false; //Q_ID HIDE 
                        dataGridView1.Columns["QU_ID"].Visible = false; //QU_ID HIDE 

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading questions Details! " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            optn1box.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string question = qstnbox.Text.Trim();
            string opt1 = optn1box.Text.Trim();
            string opt2 = optn2box.Text.Trim();
            string opt3 = optn3box.Text.Trim();
            string opt4 = optn4box.Text.Trim();
            string answer = ansrbox.Text.Trim();
            string quizName = richTextBox1.Text.Trim();
            string totalMarksText = richTextBox2.Text.Trim();
            DateTime dueDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(question) ||
                string.IsNullOrWhiteSpace(opt1) ||
                string.IsNullOrWhiteSpace(opt2) ||
                string.IsNullOrWhiteSpace(opt3) ||
                string.IsNullOrWhiteSpace(opt4) ||
                string.IsNullOrWhiteSpace(answer) ||
                string.IsNullOrWhiteSpace(quizName) ||
                string.IsNullOrWhiteSpace(totalMarksText) ||
                comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields and select a course.");
                return;
            }

            if (!(new[] { opt1, opt2, opt3, opt4 }.Contains(answer)))
            {
                MessageBox.Show("Correct answer must match one of the options.");
                return;
            }

            if (!int.TryParse(totalMarksText, out int totalMarks))
            {
                MessageBox.Show("Total marks must be a valid number.");
                return;
            }

            var options = new[] { opt1, opt2, opt3, opt4 }.Distinct().ToList();
            int courseId = Convert.ToInt32(comboBox1.SelectedValue);

            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    SqlTransaction transaction = sql.BeginTransaction();

                    try
                    {
                        // 1. Insert new quiz
                        string insertQuizQuery = @"
                    INSERT INTO LMS_Quiz (QU_Name, QU_DueDate, QU_TotalMarks) VALUES (@qname, @duedate, @tmarks);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                        SqlCommand insertQuizCmd = new SqlCommand(insertQuizQuery, sql, transaction);
                        insertQuizCmd.Parameters.AddWithValue("@qname", quizName);
                        insertQuizCmd.Parameters.AddWithValue("@duedate", dueDate);
                        insertQuizCmd.Parameters.AddWithValue("@tmarks", totalMarks);
                        int quizId = (int)insertQuizCmd.ExecuteScalar();

                        // 2. Link quiz to course
                        string insertCourseQuizQuery = @"
                    INSERT INTO Course_Quiz (C_ID, QU_ID) VALUES (@cid, @quid)";
                        SqlCommand insertCourseQuizCmd = new SqlCommand(insertCourseQuizQuery, sql, transaction);
                        insertCourseQuizCmd.Parameters.AddWithValue("@cid", courseId);
                        insertCourseQuizCmd.Parameters.AddWithValue("@quid", quizId);
                        insertCourseQuizCmd.ExecuteNonQuery();

                        // 3. Insert question
                        string insertQuestionQuery = @"
                    INSERT INTO LMS_Questions (Q_Question, Q_CorrectAnswer)
                    VALUES (@q, @ans);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                        SqlCommand cmd = new SqlCommand(insertQuestionQuery, sql, transaction);
                        cmd.Parameters.AddWithValue("@q", question);
                        cmd.Parameters.AddWithValue("@ans", answer);
                        int newQID = (int)cmd.ExecuteScalar();

                        // 4. Insert options
                        foreach (string opt in options)
                        {
                            string insertOptionQuery = @"INSERT INTO LMS_Question_Option (Q_ID, Q_Option) VALUES (@id, @opt)";
                            SqlCommand cmdOption = new SqlCommand(insertOptionQuery, sql, transaction);
                            cmdOption.Parameters.AddWithValue("@id", newQID);
                            cmdOption.Parameters.AddWithValue("@opt", opt);
                            cmdOption.ExecuteNonQuery();
                        }

                        // 5. Link question to quiz
                        string insertQuizQuestionQuery = @"
                    INSERT INTO Quiz_Question (QU_ID, Q_ID) VALUES (@quid, @qid)";
                        SqlCommand insertQuizQuestionCmd = new SqlCommand(insertQuizQuestionQuery, sql, transaction);
                        insertQuizQuestionCmd.Parameters.AddWithValue("@quid", quizId);
                        insertQuizQuestionCmd.Parameters.AddWithValue("@qid", newQID);
                        insertQuizQuestionCmd.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show("Quiz and question added successfully.");
                        ClearFields();
                        LoadQuestions(courseId);
                        selectedQuestionId = -1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error inserting quiz/question: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
        }


        private void button6_Click_1(object sender, EventArgs e) // Update Question
        {
            if (selectedQuestionId == -1)
            {
                MessageBox.Show("Please select a question to edit.");
                return;
            }

            string question = qstnbox.Text.Trim();
            string opt1 = optn1box.Text.Trim();
            string opt2 = optn2box.Text.Trim();
            string opt3 = optn3box.Text.Trim();
            string opt4 = optn4box.Text.Trim();
            string answer = ansrbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(question) ||
                string.IsNullOrWhiteSpace(opt1) ||
                string.IsNullOrWhiteSpace(opt2) ||
                string.IsNullOrWhiteSpace(opt3) ||
                string.IsNullOrWhiteSpace(opt4) ||
                string.IsNullOrWhiteSpace(answer) ||
                comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields and select a course.");
                return;
            }

            // Validate answer against options
            var options = new[] { opt1, opt2, opt3, opt4 }.Select(o => o.Trim()).ToList();
            if (!options.Contains(answer))
            {
                MessageBox.Show("Correct answer must match one of the options.");
                return;
            }

            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    SqlTransaction transaction = sql.BeginTransaction();

                    try
                    {
                        // 1. Update question text and correct answer
                        string updateQuestionQuery = @"
                    UPDATE LMS_Questions
                    SET Q_Question = @q, Q_CorrectAnswer = @ans
                    WHERE Q_ID = @id";
                        SqlCommand cmdQuestion = new SqlCommand(updateQuestionQuery, sql, transaction);
                        cmdQuestion.Parameters.AddWithValue("@q", question);
                        cmdQuestion.Parameters.AddWithValue("@ans", answer);
                        cmdQuestion.Parameters.AddWithValue("@id", selectedQuestionId);
                        cmdQuestion.ExecuteNonQuery();

                        // 2. Remove old options
                        string deleteOptionsQuery = "DELETE FROM LMS_Question_Option WHERE Q_ID = @id";
                        SqlCommand cmdDelete = new SqlCommand(deleteOptionsQuery, sql, transaction);
                        cmdDelete.Parameters.AddWithValue("@id", selectedQuestionId);
                        cmdDelete.ExecuteNonQuery();

                        // 3. Insert new options
                        foreach (string opt in options.Distinct())
                        {
                            string insertOptionQuery = @"INSERT INTO LMS_Question_Option (Q_ID, Q_Option) VALUES (@id, @opt)";
                            SqlCommand cmdOption = new SqlCommand(insertOptionQuery, sql, transaction);
                            cmdOption.Parameters.AddWithValue("@id", selectedQuestionId);
                            cmdOption.Parameters.AddWithValue("@opt", opt);
                            cmdOption.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Question updated successfully.");
                        ClearFields();
                        LoadQuestions(Convert.ToInt32(comboBox1.SelectedValue));
                        selectedQuestionId = -1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Update failed: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                if (row.Cells["Q_ID"].Value != DBNull.Value)
                {
                    selectedQuestionId = Convert.ToInt32(row.Cells["Q_ID"].Value);
                    qstnbox.Text = row.Cells["Q_Question"].Value?.ToString() ?? "";
                    ansrbox.Text = row.Cells["Q_CorrectAnswer"].Value?.ToString() ?? "";

                    try
                    {
                        using (SqlConnection sql = DbConnection.GetConnection())
                        {
                            sql.Open();
                            string query = "SELECT Q_Option FROM LMS_Question_Option WHERE Q_ID = @qid";
                            SqlCommand cmd = new SqlCommand(query, sql);
                            cmd.Parameters.AddWithValue("@qid", selectedQuestionId);
                            SqlDataReader reader = cmd.ExecuteReader();

                            string[] options = new string[4];
                            int i = 0;
                            while (reader.Read() && i < 4)
                            {
                                options[i] = reader["Q_Option"].ToString();
                                i++;
                            }
                            reader.Close();

                            optn1box.Text = options.Length > 0 ? options[0] ?? "" : "";
                            optn2box.Text = options.Length > 1 ? options[1] ?? "" : "";
                            optn3box.Text = options.Length > 2 ? options[2] ?? "" : "";
                            optn4box.Text = options.Length > 3 ? options[3] ?? "" : "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading options: " + ex.Message);
                    }
                }
            }
        }



        private void ClearFields()
        {
            qstnbox.Clear();
            optn1box.Clear();
            optn2box.Clear();
            optn3box.Clear();
            optn4box.Clear();
            ansrbox.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ClearFields();
            selectedQuestionId = -1;
        }

        private void button10_Click(object sender, EventArgs e)  //delete function
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a quiz question from the list.");
                return;
            }

            int selectedQuizId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["QU_ID"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this entire quiz and its data?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection sql = DbConnection.GetConnection())
                {
                    sql.Open();
                    SqlTransaction transaction = sql.BeginTransaction();

                    try
                    {
                        string deleteOptions = @"
                    DELETE FROM LMS_Question_Option
                    WHERE Q_ID IN (
                        SELECT Q_ID FROM Quiz_Question WHERE QU_ID = @quid
                    )";
                        SqlCommand cmdOpt = new SqlCommand(deleteOptions, sql, transaction);
                        cmdOpt.Parameters.AddWithValue("@quid", selectedQuizId);
                        cmdOpt.ExecuteNonQuery();

                        string deleteQQ = "DELETE FROM Quiz_Question WHERE QU_ID = @quid";
                        SqlCommand cmdQQ = new SqlCommand(deleteQQ, sql, transaction);
                        cmdQQ.Parameters.AddWithValue("@quid", selectedQuizId);
                        cmdQQ.ExecuteNonQuery();

                        string deleteQuestions = @"
                    DELETE FROM LMS_Questions
                    WHERE Q_ID IN (
                        SELECT Q_ID FROM Quiz_Question WHERE QU_ID = @quid
                    )";
                        SqlCommand cmdQuestions = new SqlCommand(deleteQuestions, sql, transaction);
                        cmdQuestions.Parameters.AddWithValue("@quid", selectedQuizId);
                        cmdQuestions.ExecuteNonQuery();

                        string deleteCQ = "DELETE FROM Course_Quiz WHERE QU_ID = @quid";
                        SqlCommand cmdCQ = new SqlCommand(deleteCQ, sql, transaction);
                        cmdCQ.Parameters.AddWithValue("@quid", selectedQuizId);
                        cmdCQ.ExecuteNonQuery();

                        string deleteQuiz = "DELETE FROM LMS_Quiz WHERE QU_ID = @quid";
                        SqlCommand cmdQuiz = new SqlCommand(deleteQuiz, sql, transaction);
                        cmdQuiz.Parameters.AddWithValue("@quid", selectedQuizId);
                        cmdQuiz.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show("Quiz and all its questions/options deleted successfully.");
                        LoadQuestions(); 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error during deletion: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            LoginForm l1 = new LoginForm();
            l1.FormClosed += (s, args) => Application.Exit();

            l1.Show();
            this.Hide();
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

            m1.Show();
            this.Hide();
        }

        private void courses(object sender, EventArgs e)
        {
            CourseForm q1 = new CourseForm(Username);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int courseId))
            {
                LoadQuestions(courseId);
            }
            else
            {
                LoadQuestions();
            }
        }
        private void LoadCoursesToComboBox()
        {
            try
            {
                using (SqlConnection sql =DbConnection.GetConnection())
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
    }
