using LMS.adminPanel;
using LMS.Rounded_Region;
using System;
using System.Data.SqlClient; 
using System.Drawing;
using System.Windows.Forms;

namespace LMS
{
    public partial class Admin_Dashboard : Form
    {

        private string _adminUsername;

        public Admin_Dashboard(string adminUsername)
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

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {

            using (SqlConnection con = DbConnection.GetConnection())
            {
                string query = "SELECT AD_Name FROM LMS_Admins WHERE AD_Username = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", _adminUsername);

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != null)
                {
                    label6.Text = result.ToString();
                }
                else
                {
                    label6.Text = "Unknown Admin";
                }
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        

        

        private void label6_Click(object sender, EventArgs e)
        {

        }
//Manage Transition
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

//Menu Transition

        private void menuButton_Click(object sender, EventArgs e)
        {
            slideBarTransition.Start();
        }
        bool sidebarExpand = false;
        private void sideBarTransition_Tick(object sender, EventArgs e)
        {

            if (sidebarExpand)
            {

                sideBar.Width -= 10;
                if (sideBar.Width <= 57)
                {
                    sidebarExpand = false;
                    slideBarTransition.Stop();
                    dashButton.Width = sideBar.Width;
                    reportButton.Width = sideBar.Width;
                    logOutButton.Width = sideBar.Width;

                }
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width >= 211)
                {
                    sidebarExpand = true;
                    slideBarTransition.Stop();

                    dashButton.Width = sideBar.Width;
                    reportButton.Width = sideBar.Width;
                    logOutButton.Width = sideBar.Width;
                }
            }

        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void profileButton_Click(object sender, EventArgs e)
        {
            AdProfile ap = new AdProfile(_adminUsername);
            ap.FormClosed += (s, args) => Application.Exit();
            ap.Show();
            this.Hide();
        }
        private void manageFacultyButton_Click(object sender, EventArgs e)
        {
            Manage_Faculty mf = new Manage_Faculty(_adminUsername);
            mf.FormClosed += (s, args) => Application.Exit();
            mf.Show();
            this.Hide();
        }
        private void manageStudent_Click(object sender, EventArgs e)
        {
            Manage_Student ms = new Manage_Student(_adminUsername);
            ms.FormClosed += (s, args) => Application.Exit();
            ms.Show();
            this.Hide();
        }
        private void logOutButtonClick(object sender, EventArgs e)
        {
            LoginForm f1 = new LoginForm();
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }
//shape round
        private void roundedPanel_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(roundedPanel, 20); 
        }

        private void totalUser_Click(object sender, EventArgs e)
        {

            assignCources l1 = new assignCources(_adminUsername);
            l1.FormClosed += (s, args) => Application.Exit();
            l1.Show();
            this.Hide();
            

        }

        private void BUTTON_Click(object sender, EventArgs e)
        {
            totalUser.FlatStyle = FlatStyle.Flat;
            totalUser.FlatAppearance.BorderSize = 0;
            totalUser.BackColor = Color.FromArgb(27, 42, 65);
            totalUser.Cursor = Cursors.Hand;
            totalUser.BackColor = Color.FromArgb(27, 42, 65);


            totalCourse.FlatStyle = FlatStyle.Flat;
            totalCourse.FlatAppearance.BorderSize = 0;
            totalCourse.BackColor = Color.FromArgb(27, 42, 65);
            totalCourse.Cursor = Cursors.Hand;
            totalCourse.BackColor = Color.FromArgb(27, 42, 65);

            activeTeacher.FlatStyle = FlatStyle.Flat;
            activeTeacher.FlatAppearance.BorderSize = 0;
            activeTeacher.BackColor = Color.FromArgb(27, 42, 65);
            activeTeacher.Cursor = Cursors.Hand;
            activeTeacher.BackColor = Color.FromArgb(27, 42, 65);

            addCourseB.FlatStyle = FlatStyle.Flat;
            addCourseB.FlatAppearance.BorderSize = 0;
            addCourseB.BackColor = Color.FromArgb(27, 42, 65);
            addCourseB.Cursor = Cursors.Hand;
            addCourseB.BackColor = Color.FromArgb(27, 42, 65);


            addUserB.FlatStyle = FlatStyle.Flat;
            addUserB.FlatAppearance.BorderSize = 0;
            addUserB.BackColor = Color.FromArgb(27, 42, 65);
            addUserB.Cursor = Cursors.Hand;
            addUserB.BackColor = Color.FromArgb(27, 42, 65);


            viewRe.FlatStyle = FlatStyle.Flat;
            viewRe.FlatAppearance.BorderSize = 0;
            viewRe.BackColor = Color.FromArgb(27, 42, 65);
            viewRe.Cursor = Cursors.Hand;
            viewRe.BackColor = Color.FromArgb(27, 42, 65);

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.BackColor = Color.FromArgb(27, 42, 65);
            button4.Cursor = Cursors.Hand;
            button4.BackColor = Color.FromArgb(27, 42, 65);





        }
        //round shape
        private void totalUserPanel_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(totalUserPanel, 8);
            region.SetRoundedRegion(totalCources, 8);
            region.SetRoundedRegion(active, 8);
            region.SetRoundedRegion(addCourse, 8);
            region.SetRoundedRegion(addUser, 8);
            region.SetRoundedRegion(viewFeadBack, 8);
            region.SetRoundedRegion(generateReport, 8);
        }

        private void addCourseB_Click(object sender, EventArgs e)
        {
            courseAdd courseAdd = new courseAdd(_adminUsername);
            courseAdd.FormClosed += (s, args) => Application.Exit();
            courseAdd.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
    }