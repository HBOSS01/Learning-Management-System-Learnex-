using LMS.Rounded_Region;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LMS
{
    public partial class AdProfile : Form
    {
        private string _adminUsername;
        public AdProfile(string adminUsername)
        {
            InitializeComponent();
            _adminUsername = adminUsername;
            this.Load += AdProfile_Load; this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        roundedRegion region = new roundedRegion();
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AdProfile_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM LMS_Admins WHERE AD_USERNAME = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", _adminUsername);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelid.Text = reader["AD_ID"].ToString();
                            labelname.Text = reader["AD_NAME"].ToString();
                            labelusrname.Text = reader["AD_USERNAME"].ToString();
                            labelpass.Text = reader["AD_PASSWORD"].ToString();
                        }
                        else
                        {
                            labelid.Text = "N/A";
                            labelname.Text = "N/A";
                            labelusrname.Text = "N/A";
                            labelpass.Text = "N/A";
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching admin profile: " + ex.Message);
                    labelid.Text = "Error";
                    labelname.Text = "Error";
                    labelusrname.Text = "Error";
                    labelpass.Text = "Error";
                }
            }
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageFaculty_Click(object sender, EventArgs e)
        {
            Manage_Faculty mf = new Manage_Faculty(_adminUsername);
            mf.FormClosed += (s, args) => Application.Exit();
            mf.Show();
            this.Hide();
        }

        private void manageStudentButton_Click(object sender, EventArgs e)
        {
            Manage_Student ms = new Manage_Student(_adminUsername);
            ms.FormClosed += (s, args) => Application.Exit();
            ms.Show();
            this.Hide();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            LoginForm f1 = new LoginForm();
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }


        private void dashBoardButton_Click(object sender, EventArgs e)
        {
            Admin_Dashboard ad = new Admin_Dashboard(_adminUsername);
            ad.FormClosed += (s, args) => Application.Exit();
            ad.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(roundedPanel, 20);
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
                if (manageContainer.Height <= 61)
                {
                    manageTransition.Stop();
                    manageExpand = false;
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
