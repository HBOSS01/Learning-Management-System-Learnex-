using LMS.Rounded_Region;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class Manage_Student: Form
    {
        private string _adminUsername;
        public Manage_Student(string adminUsername)
        {
            InitializeComponent();
            _adminUsername = adminUsername;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        roundedRegion region = new roundedRegion();
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Manage_Student_Load(object sender, EventArgs e)
        {
            dataView();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataView()
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM LMS_StudentFullDetails";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading teacher data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

//inserting datas
        private void insertData_Click(object sender, EventArgs e)
        {
            string name = richTextBox2.Text.Trim();
            string username = richTextBox3.Text.Trim();
            string password = richTextBox4.Text.Trim();
            string email = richTextBox6.Text.Trim();
            string phone = richTextBox5.Text.Trim();
            DateTime registrationDate = registrationDatePicker.Value;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Name and Username are required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password is required, it cannot be empty.");
                return;
            }

            if (string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
            {
                MessageBox.Show("Email is required and it must contain @ in it.");
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Phone number is required.");
                return;
            }

            if (!Regex.IsMatch(phone, @"^\d{11}$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                SqlTransaction transaction = null;

                try
                {
                    con.Open();
                    transaction = con.BeginTransaction();

                    string teacherQuery = @"
                    INSERT INTO LMS_Students (ST_Name, ST_Username, ST_Password, ST_Email, Registration_Date)
                    VALUES (@name, @username, @password, @email, @joinDate);
                    SELECT SCOPE_IDENTITY();";

                    int teId;
                    using (SqlCommand cmd = new SqlCommand(teacherQuery, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@joinDate", registrationDate);

                        teId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string phoneQuery = "INSERT INTO LMS_StudentPhone (ST_ID, ST_PNUMBER) VALUES (@id, @phone)";
                    using (SqlCommand phoneCmd = new SqlCommand(phoneQuery, con, transaction))
                    {
                        phoneCmd.Parameters.AddWithValue("@id", teId);
                        phoneCmd.Parameters.AddWithValue("@phone", phone);
                        phoneCmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    MessageBox.Show("Data inserted into both tables successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error inserting data: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dataView();
        }

        private void ClearFields()
        {
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            registrationDatePicker.Value = DateTime.Today;
        }

//Updateting Datas
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row from the table to update.");
                return;
            }

            int teId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ST_ID"].Value);

            string name = richTextBox2.Text.Trim();
            string username = richTextBox3.Text.Trim();
            string password = richTextBox4.Text.Trim();
            string email = richTextBox6.Text.Trim();
            string phone = richTextBox5.Text.Trim();
            DateTime registrationDate = registrationDatePicker.Value;

            if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
            {
                MessageBox.Show("Email must contain '@'.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(phone) && !Regex.IsMatch(phone, @"^\d{11}$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
                return;
            }


            using (SqlConnection con = DbConnection.GetConnection())
            {
                SqlTransaction transaction = null;

                try
                {
                    con.Open();
                    transaction = con.BeginTransaction();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.Transaction = transaction;

                    string updateQuery = "UPDATE LMS_Students SET ";
                    bool somethingToUpdate = false;

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        updateQuery += "ST_Name = @name, ";
                        cmd.Parameters.AddWithValue("@name", name);
                        somethingToUpdate = true;
                    }

                    if (!string.IsNullOrWhiteSpace(username))
                    {
                        updateQuery += "ST_Username = @username, ";
                        cmd.Parameters.AddWithValue("@username", username);
                        somethingToUpdate = true;
                    }

                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        updateQuery += "ST_Password = @password, ";
                        cmd.Parameters.AddWithValue("@password", password);
                        somethingToUpdate = true;
                    }

                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        updateQuery += "ST_Email = @email, ";
                        cmd.Parameters.AddWithValue("@email", email);
                        somethingToUpdate = true;
                    }

                    if (registrationDatePicker.Checked)
                    {
                        updateQuery += "Registration_Date = @joinDate, ";
                        cmd.Parameters.AddWithValue("@joinDate", registrationDate);
                        somethingToUpdate = true;
                    }


                    if (somethingToUpdate)
                    {
                        updateQuery = updateQuery.TrimEnd(',', ' ');
                        updateQuery += " WHERE ST_ID = @id";
                        cmd.Parameters.AddWithValue("@id", teId);
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(phone))
                    {
                        string updatePhoneQuery = "UPDATE LMS_StudentPhone SET ST_PNUMBER = @phone WHERE ST_ID = @id";
                        using (SqlCommand phoneCmd = new SqlCommand(updatePhoneQuery, con, transaction))
                        {
                            phoneCmd.Parameters.AddWithValue("@phone", phone);
                            phoneCmd.Parameters.AddWithValue("@id", teId);
                            phoneCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Selected data updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error updating data: " + ex.Message);
                }
            }

            dataView();
        }

//deleteting Data
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            string username = dataGridView1.SelectedRows[0].Cells["ST_Username"].Value.ToString();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("The selected row does not contain a valid username.");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the record for '{username}'?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "DELETE FROM LMS_Students WHERE ST_Username = @username";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    try
                    {
                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(
                            rows > 0 ? "Data deleted successfully." : "No record found with the selected username.",
                            "Delete Status",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            dataView();
        }


//Search for data
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string username = richTextBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Enter a valid Username.");
                return;
            }

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM LMS_StudentFullDetails WHERE ST_Username = @username";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No record found with the given Username.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving data: " + ex.Message);
                    }
                }
            }
        }
        private void manageFaculty_Click(object sender, EventArgs e)
        {
            Manage_Faculty mf = new Manage_Faculty(_adminUsername);
            mf.FormClosed += (s, args) => Application.Exit();
            mf.Show();
            this.Hide();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            LoginForm f1 = new LoginForm();
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            AdProfile ad = new AdProfile(_adminUsername);
            ad.FormClosed += (s, args) => Application.Exit();
            ad.Show();
            this.Hide();
        }

        private void dashBoardButton_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard(_adminUsername);
            ad.FormClosed += (s, args) => Application.Exit();
            ad.Show();
            this.Hide();
        }
        private void manageButton_Click(object sender, EventArgs e)
        {
            manageTransition.Start();
            manageButton.FlatStyle = FlatStyle.Flat;
            manageButton.FlatAppearance.BorderSize = 0;
            manageButton.BackColor = Color.FromArgb(27, 42, 65);
            manageButton.Cursor = Cursors.Hand;
            manageButton.BackColor = Color.FromArgb(27, 42, 65);
        }
        bool manageExpand = false;

        private void manageTransition_Tick(object sender, EventArgs e)
        {
            if (manageExpand == false)
            {
                manageContainer.Height += 10;
                if (manageContainer.Height >= 200)
                {
                    manageTransition.Stop();
                    manageExpand = true;
                }
            }
            else
            {
                manageContainer.Height -= 10;
                if (manageContainer.Height <= 60)
                {
                    manageTransition.Stop();
                    manageExpand = false;
                }
            }
        }
        private void roundedPanel_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(roundedPanel, 20);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
