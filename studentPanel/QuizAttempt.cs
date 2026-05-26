using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LMS.studentPanel
{
    public partial class QuizAttempt : Form
    {
        private string Username;
        private int id;
        private int attemptId;

        public QuizAttempt(string username, int quizId, int attempId)
        {
            InitializeComponent();
            Username = username;
            id = quizId;
            attemptId = attempId;

            LoadQuestions();
        }

        private string[] correctAnswers = new string[10];

        private void LoadQuestions()
        {


            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                string studentName = "";

                using (var cmd = new SqlCommand("SELECT ST_Name FROM LMS_Students WHERE ST_USERNAME = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", Username);
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

                using (var cmd = new SqlCommand("SELECT Q_ID,Q_Question,Q_Option,Q_CorrectAnswer FROM QuestionDetails WHERE C_ID = @cid", con))
                {
                    cmd.Parameters.AddWithValue("@cid", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int currentQ = 0;
                        int lastQID = -1;
                        int optionCounter = 0;

                        while (reader.Read() && currentQ < 10)
                        {
                            int qid = Convert.ToInt32(reader["Q_ID"]);
                            string questionText = reader["Q_Question"].ToString();
                            string optionText = reader["Q_Option"].ToString();
                            string correct = reader["Q_CorrectAnswer"].ToString();

                            if (qid != lastQID)
                            {
                                currentQ++;
                                lastQID = qid;
                                optionCounter = 1;

                                var qLabel = this.Controls.Find($"Q{currentQ}", true).FirstOrDefault();
                                if (qLabel != null)
                                    qLabel.Text = questionText;
                                if (currentQ - 1 >= 0 && currentQ - 1 < correctAnswers.Length)

                                    correctAnswers[currentQ - 1] = correct;
                            }
                            else
                            {
                                optionCounter++;
                            }

                            if (optionCounter <= 4)
                            {
                                var opt = this.Controls.Find($"Q{currentQ}O{optionCounter}", true).FirstOrDefault() as RadioButton;
                                if (opt != null)
                                    opt.Text = optionText;
                            }
                        }
                    }
                }
            }
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            int totalQuestions = 10;
            int correctCount = 0;
            string[] userAnswers = new string[totalQuestions];
            int[] questionIds = new int[totalQuestions];

            // 1. Collect user answers and question IDs
            for (int i = 1; i <= totalQuestions; i++)
            {
                string selectedAnswer = null;
                for (int j = 1; j <= 4; j++)
                {
                    var radio = this.Controls.Find($"Q{i}O{j}", true).FirstOrDefault() as RadioButton;
                    if (radio != null && radio.Checked)
                    {
                        selectedAnswer = radio.Text;
                        break;
                    }
                }
                userAnswers[i - 1] = selectedAnswer ?? "";

                // Find the question label to get the question text (assuming label name is Q{i})
                var qLabel = this.Controls.Find($"Q{i}", true).FirstOrDefault();
                if (qLabel != null)
                {
                    // Get the question ID from the database based on question text and course ID
                    using (var con = LMS.DbConnection.GetConnection())
                    {
                        con.Open();
                        using (var cmd = new SqlCommand("SELECT Q_ID FROM QuestionDetails WHERE Q_Question = @qText AND C_ID = @cid", con))
                        {
                            cmd.Parameters.AddWithValue("@qText", qLabel.Text);
                            cmd.Parameters.AddWithValue("@cid", id);
                            var result = cmd.ExecuteScalar();
                            questionIds[i - 1] = result != null ? Convert.ToInt32(result) : 0;
                        }
                    }
                }
            }

            // 2. Verify answers with the database (isCorrect = 'Yes')
            for (int i = 0; i < totalQuestions; i++)
            {
                if (string.IsNullOrEmpty(userAnswers[i]) || questionIds[i] == 0)
                    continue;

                using (var con = LMS.DbConnection.GetConnection())
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SELECT isCorrect FROM QuestionDetails WHERE Q_ID = @qid AND Q_Option = @opt", con))
                    {
                        cmd.Parameters.AddWithValue("@qid", questionIds[i]);
                        cmd.Parameters.AddWithValue("@opt", userAnswers[i]);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result.ToString().Equals("Yes", StringComparison.OrdinalIgnoreCase))
                        {
                            correctCount++;
                        }
                    }
                }
            }

            // 3. Calculate percentage and grade
            double percentage = (correctCount / (double)totalQuestions) * 100;
            string gradeValue;
            if (percentage >= 90)
                gradeValue = "A+";
            else if (percentage >= 85)
                gradeValue = "A";
            else if (percentage >= 80)
                gradeValue = "B+";
            else if (percentage >= 75)
                gradeValue = "B";
            else if (percentage >= 70)
                gradeValue = "C+";
            else if (percentage >= 65)
                gradeValue = "C";
            else if (percentage >= 60)
                gradeValue = "D+";
            else if (percentage >= 50)
                gradeValue = "D";
            else
                gradeValue = "F";

            // 4. Get student ID
            int studentId = 0;
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT ST_ID FROM LMS_Students WHERE ST_Username = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", Username);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        studentId = Convert.ToInt32(result);
                    else
                    {
                        MessageBox.Show("Student not found.");
                        return;
                    }
                }
            }

            // 5. Get grade ID from LMS_Grade table
            int gradeId = 0;
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT G_ID FROM LMS_Grade WHERE G_Value = @gval", con))
                {
                    cmd.Parameters.AddWithValue("@gval", gradeValue);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        gradeId = Convert.ToInt32(result);
                    else
                    {
                        MessageBox.Show("No matching grade found.");
                        return;
                    }
                }
            }

            // 6. Insert into StudentGrades (ST_ID, G_ID)
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("INSERT INTO StudentGrades (ST_ID, G_ID) VALUES (@stId, @gId)", con))
                {
                    cmd.Parameters.AddWithValue("@stId", studentId);
                    cmd.Parameters.AddWithValue("@gId", gradeId);
                    cmd.ExecuteNonQuery();
                }
            }

            // 7. Insert into Student_AttemptQuiz (AT_ID, ST_ID)
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("INSERT INTO Student_AttemptQuiz (AT_ID, ST_ID) VALUES (@attemptId, @stId)", con))
                {
                    cmd.Parameters.AddWithValue("@attemptId", attemptId);
                    cmd.Parameters.AddWithValue("@stId", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
            // 8. Get TE_ID for the course (id is C_ID)
            int teacherId = 0;
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT TE_ID FROM Teacher_Teaches_Course WHERE C_ID = @cid", con))
                {
                    cmd.Parameters.AddWithValue("@cid", id);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        teacherId = Convert.ToInt32(result);
                    else
                    {
                        MessageBox.Show("No teacher assigned to this course.");
                        return;
                    }
                }
            }

            // 9. Insert into Grade_Manage (G_ID, TE_ID)
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("INSERT INTO Grade_Manage (G_ID, TE_ID) VALUES (@gId, @teId)", con))
                {
                    cmd.Parameters.AddWithValue("@gId", gradeId);
                    cmd.Parameters.AddWithValue("@teId", teacherId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"Quiz submitted! Your score: {correctCount}/{totalQuestions} ({percentage:F1}%) — Grade: {gradeValue}");
            this.Close();
        }
        private void EXIT(object sender, EventArgs e) { 
            Application.Exit(); 
        }
        private void MINIMIZE(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void BACK(object sender, EventArgs e)
        {
            Quiz f1 = new Quiz(Username);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        
    }
}
