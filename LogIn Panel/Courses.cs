using System;
using LMS.Rounded_Region;
using System.Windows.Forms;

namespace LMS.LogIn_Panel
{
    public partial class Courses: Form
    {
        public Courses()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(roundedRegion.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        roundedRegion region = new roundedRegion();
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragForm.ReleaseCapture();
            dragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage f1 = new Homepage();
            f1.FormClosed += (s, args) => Application.Exit();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.FormClosed += (s, args) => Application.Exit();
            about.Show();
            this.Hide();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Contact_Us contact_Us = new Contact_Us();
            contact_Us.FormClosed += (s, args) => Application.Exit();
            contact_Us.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            region.SetRoundedRegion(panel1, 20);
            region.SetRoundedRegion(panel2, 20);
            region.SetRoundedRegion(panel3, 20);
            region.SetRoundedRegion(panel4, 20);
            region.SetRoundedRegion(panel5, 20);
            region.SetRoundedRegion(panel6, 20);
            region.SetRoundedRegion(panel7, 20);
            region.SetRoundedRegion(panel8, 20);
            region.SetRoundedRegion(panel9, 20);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
}
