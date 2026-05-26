using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.facultyPanel
{
    public partial class FacultyDashboard : Form
    {
        private string Username;

        public FacultyDashboard(string username)
        {
            InitializeComponent();
            Username= username;
            label6.Text = Username;
            sidebar.Width = 62;
            sidebarExpand = false;

            pnDashboard.Width = sidebar.Width;
            pnAccount.Width = sidebar.Width;
            pnCourses.Width = sidebar.Width;
            pnQuizes.Width = sidebar.Width;
            pnAssignments.Width = sidebar.Width;
            pnLogout.Width = sidebar.Width;
            Username = username;
        }

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 62)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    pnDashboard.Width = sidebar.Width;
                    pnAccount.Width = sidebar.Width;
                    pnCourses.Width = sidebar.Width;
                    pnQuizes.Width = sidebar.Width;
                    pnAssignments.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 220)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pnDashboard.Width = sidebar.Width;
                    pnAccount.Width = sidebar.Width;
                    pnCourses.Width = sidebar.Width;
                    pnQuizes.Width = sidebar.Width;
                    pnAssignments.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }
        }

        private void menu(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void profile(object sender, EventArgs e)
        {
            ProfileForm m1 = new ProfileForm(Username);
            m1.FormClosed += (s, args) => Application.Exit();
            m1.Show();
            this.Hide();
        }


        private void course(object sender, EventArgs e)
        {
            CourseForm c1 = new CourseForm(Username);
            c1.FormClosed += (s, args) => Application.Exit();
            c1.Show();
            this.Hide();
        }


        private void quiz(object sender, EventArgs e)
        {
            facultyQuiz q1 = new facultyQuiz(Username);
            q1.FormClosed += (s, args) => Application.Exit();

            q1.Show();
            this.Hide();
        }
        private void assignment(object sender, EventArgs e)
        {
            TAssignment a1 = new TAssignment();
            a1.FormClosed += (s, args) => Application.Exit();
            a1.Show();
            this.Hide();
        }
        private void logout(object sender, EventArgs e)
        {
            LoginForm l1 = new LoginForm();
            l1.FormClosed += (s, args) => Application.Exit();
            l1.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void SetRoundedRegion(Control control, int radius)
        {
            Rectangle bounds = control.ClientRectangle;
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private void roundedPanel_Paint(object sender, PaintEventArgs e)
        {
            SetRoundedRegion(roundedPanel, 20);

        }
    }
}

