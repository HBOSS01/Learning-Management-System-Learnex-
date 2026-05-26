using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LMS.studentPanel
{
    public partial class studentDashboard : Form
    {
        private string studentUsername;

        DateTime currentMonth;
        List<Reminder> reminders = new List<Reminder>();
        DateTime selectedDate;

        private string reminderPlaceholder = "Enter reminder title";

        public studentDashboard(string username)
        {
            InitializeComponent();
            studentUsername = username;
            currentMonth = DateTime.Now;
            this.Load += studentDashboard_Load;
        }

        private void studentDashboard_Load_1(object sender, EventArgs e)
        {
            DrawCalendar(currentMonth);

            reminderTimer.Interval = 60000; // 1 minute
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();

            txtReminder.Text = reminderPlaceholder;
            txtReminder.ForeColor = Color.Gray;

            txtReminder.GotFocus += (s, ev) =>
            {
                if (txtReminder.Text == reminderPlaceholder)
                {
                    txtReminder.Text = "";
                    txtReminder.ForeColor = Color.Black;
                }
            };

            txtReminder.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtReminder.Text))
                {
                    txtReminder.Text = reminderPlaceholder;
                    txtReminder.ForeColor = Color.Gray;
                }
            };

            LoadStudentDashboardData();
        }

        private void LoadStudentDashboardData()
        {
            using (var con = LMS.DbConnection.GetConnection())
            {
                con.Open();

                // Get student name and ID
                string studentName = "";
                int studentId = 0;
                using (var cmd = new SqlCommand("SELECT ST_ID, ST_NAME FROM LMS_Students WHERE ST_USERNAME = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", studentUsername);
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

                // Get courses count
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Student_Course_EnrolledIn WHERE ST_ID = @sid", con))
                {
                    cmd.Parameters.AddWithValue("@sid", studentId);
                    coursenmbr.Text = cmd.ExecuteScalar().ToString();
                }

                // Get quizzes count
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Student_Quiz WHERE ST_ID = @sid", con))
                {
                    cmd.Parameters.AddWithValue("@sid", studentId);
                    quiznmbr.Text = cmd.ExecuteScalar().ToString();
                }

                // Get assignments count
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM AssignmentStudentTeacherView WHERE ST_Username = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", studentUsername);
                    assnmbr.Text = cmd.ExecuteScalar().ToString();
                }
                con.Close();
            }
        }

        private void DrawCalendar(DateTime month)
        {
            calendarPanel.Controls.Clear();
            lblMonthYear.Text = month.ToString("MMMM yyyy");

            DateTime firstDay = new DateTime(month.Year, month.Month, 1);
            int startDay = (int)firstDay.DayOfWeek;
            int days = DateTime.DaysInMonth(month.Year, month.Month);

            for (int i = 0; i < days; i++)
            {
                DateTime thisDate = new DateTime(month.Year, month.Month, i + 1);
                var todaysReminders = reminders.Where(r => r.DateTime.Date == thisDate).ToList();

                Button dayBtn = new Button
                {
                    Width = 80,
                    Height = 60,
                    Tag = thisDate,
                    BackColor = todaysReminders.Any() ? Color.LightYellow : Color.White,
                    Font = new Font("Segoe UI", 8),
                };

                string btnText = (i + 1).ToString();
                if (todaysReminders.Count == 1)
                {
                    btnText += "\n" + Truncate(todaysReminders[0].Title, 10);
                }
                else if (todaysReminders.Count > 1)
                {
                    btnText += $"\n{Truncate(todaysReminders[0].Title, 10)}\n+{todaysReminders.Count - 1} more";
                }

                dayBtn.Text = btnText;
                dayBtn.TextAlign = ContentAlignment.TopLeft;
                dayBtn.Click += DayBtn_Click;

                int row = (i + startDay) / 7;
                int col = (i + startDay) % 7;
                dayBtn.Location = new Point(col * 82, row * 62);

                calendarPanel.Controls.Add(dayBtn);
            }
        }

        private void DayBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is DateTime date)
            {
                selectedDate = date;
                var todaysReminders = reminders.Where(r => r.DateTime.Date == date).OrderBy(r => r.DateTime).ToList();
                if (todaysReminders.Any())
                {
                    string message = "📅 " + date.ToLongDateString() + ":\n\n";
                    foreach (var r in todaysReminders)
                    {
                        message += $"⏰ {r.DateTime.ToShortTimeString()} - {r.Title}\n";
                    }
                    MessageBox.Show(message, "Reminders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No reminders for " + date.ToShortDateString(), "No Reminders");
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            DrawCalendar(currentMonth);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            DrawCalendar(currentMonth);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtReminder.Text == reminderPlaceholder || string.IsNullOrWhiteSpace(txtReminder.Text))
            {
                MessageBox.Show("Please enter reminder text.");
                return;
            }

            DateTime fullDateTime = selectedDate.Date.AddHours(timePicker.Value.Hour).AddMinutes(timePicker.Value.Minute);

            reminders.Add(new Reminder { Title = txtReminder.Text, DateTime = fullDateTime });
            lstReminders.Items.Add($"{fullDateTime:G} - {txtReminder.Text}");

            txtReminder.Text = reminderPlaceholder;
            txtReminder.ForeColor = Color.Gray;

            DrawCalendar(currentMonth);
        }

        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            var due = reminders.Where(r => r.DateTime.Date == now.Date && r.DateTime.Hour == now.Hour && r.DateTime.Minute == now.Minute).ToList();

            foreach (var r in due)
            {
                MessageBox.Show("⏰ Reminder: " + r.Title, "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reminders.Remove(r);
            }
        }

        public class Reminder
        {
            public string Title { get; set; }
            public DateTime DateTime { get; set; }
        }

        private string Truncate(string input, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(input)) return "";
            return input.Length <= maxLength ? input : input.Substring(0, maxLength) + "...";
        }

        private void studentDashboard_Load(object sender, EventArgs e)
        {
            // This is now handled in LoadStudentDashboardData
        }

        private void EXIT(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PROFILE(object sender, EventArgs e)
        {
            studentProfile f1 = new studentProfile(studentUsername);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void LOGOUT(object sender, EventArgs e)
        {
            LoginForm f1 = new LoginForm();
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void matbtn_Click(object sender, EventArgs e)
        {
            studentAssignment f1 = new studentAssignment(studentUsername);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void qzbtn_Click(object sender, EventArgs e)
        {
            Quiz f1 = new Quiz(studentUsername);
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void btnUpdateReminder_Click(object sender, EventArgs e)
        {
            if (lstReminders.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reminder to update.");
                return;
            }

            string selectedItem = lstReminders.SelectedItem.ToString();
            var reminder = reminders.FirstOrDefault(r => $"{r.DateTime:G} - {r.Title}" == selectedItem);
            if (reminder != null)
            {
                string newText = ShowInputDialog("Update reminder text:", "Update", reminder.Title);
                if (!string.IsNullOrWhiteSpace(newText))
                {
                    reminder.Title = newText;
                    lstReminders.Items[lstReminders.SelectedIndex] = $"{reminder.DateTime:G} - {reminder.Title}";
                    DrawCalendar(currentMonth);
                }
            }
        }

        private string ShowInputDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 350 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350, Text = defaultValue };
            Button confirmation = new Button() { Text = "Ok", Left = 280, Width = 90, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        private void btnDeleteReminder_Click(object sender, EventArgs e)
        {
            if (lstReminders.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reminder to delete.");
                return;
            }

            string selectedItem = lstReminders.SelectedItem.ToString();
            var reminder = reminders.FirstOrDefault(r => $"{r.DateTime:G} - {r.Title}" == selectedItem);
            if (reminder != null)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this reminder?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    reminders.Remove(reminder);
                    lstReminders.Items.RemoveAt(lstReminders.SelectedIndex);
                    DrawCalendar(currentMonth);
                }
            }
        }
        private void MINIMISE(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gradeBtn_Click(object sender, EventArgs e)
        {
            gradeReport g1 = new gradeReport(studentUsername);
            g1.FormClosed += (s, args) => Application.Exit();
            g1.Show();
            this.Hide();
        }
    }
}
