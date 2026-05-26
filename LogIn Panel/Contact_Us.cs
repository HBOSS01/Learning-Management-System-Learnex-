using LMS.Rounded_Region;
using System;
using System.Windows.Forms;

namespace LMS.LogIn_Panel
{
    public partial class Contact_Us: Form
    {
        public Contact_Us()
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
        private void button5_Click(object sender, EventArgs e)
        {
            Homepage h1 = new Homepage();
            h1.FormClosed += (s, args) => Application.Exit();
            h1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            About a1 = new About();
            a1.FormClosed += (s, args) => Application.Exit();
            a1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Courses c1 = new Courses();
            c1.FormClosed += (s, args) => Application.Exit();
            c1.Show();
            this.Hide();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
            region.SetRoundedRegion(panel6, 20);
            region.SetRoundedRegion(panel2, 20);
            region.SetRoundedRegion(panel3, 20);
            region.SetRoundedRegion(panel4, 20);
            region.SetRoundedRegion(panel5, 20);

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
