using LMS.Rounded_Region; 
using System;
using System.Windows.Forms;

namespace LMS.LogIn_Panel
{
    public partial class Homepage: Form
    {
        roundedRegion region = new roundedRegion();
        public Homepage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm f1 = new LoginForm();
            f1.Show();
            this.Hide();
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(panel5, 16);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(panel1, 20);
            region.SetRoundedRegion(panel2, 20);
            region.SetRoundedRegion(panel3, 20);
            region.SetRoundedRegion(panel4, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.FormClosed += (s, args) => this.Show();
            about.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Courses courses = new Courses();
            courses.FormClosed += (s, args) => this.Show(); 
            courses.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Contact_Us contact_Us = new Contact_Us();
            contact_Us.FormClosed += (s, args) => Application.Exit();
            contact_Us.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }
    }
}
