namespace LMS
{
    partial class Admin_Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Dashboard));
            this.slideBarTransition = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.adminLogo = new System.Windows.Forms.PictureBox();
            this.pnDashboard = new System.Windows.Forms.Panel();
            this.dashButton = new System.Windows.Forms.Label();
            this.pnAccount = new System.Windows.Forms.Panel();
            this.profileButton = new System.Windows.Forms.Button();
            this.pnCourses = new System.Windows.Forms.Panel();
            this.manageFaculty = new System.Windows.Forms.Button();
            this.sideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.manageContainer = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.manageStudent = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.manageButton = new System.Windows.Forms.Button();
            this.pnAssignments = new System.Windows.Forms.Panel();
            this.reportButton = new System.Windows.Forms.Button();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.logOutButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roundedPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.manageTransition = new System.Windows.Forms.Timer(this.components);
            this.totalCources = new System.Windows.Forms.Panel();
            this.totalCourse = new System.Windows.Forms.Button();
            this.active = new System.Windows.Forms.Panel();
            this.activeTeacher = new System.Windows.Forms.Button();
            this.totalUserPanel = new System.Windows.Forms.Panel();
            this.totalUser = new System.Windows.Forms.Button();
            this.generateReport = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.viewFeadBack = new System.Windows.Forms.Panel();
            this.viewRe = new System.Windows.Forms.Button();
            this.addCourse = new System.Windows.Forms.Panel();
            this.addCourseB = new System.Windows.Forms.Button();
            this.addUser = new System.Windows.Forms.Panel();
            this.addUserB = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminLogo)).BeginInit();
            this.pnDashboard.SuspendLayout();
            this.pnAccount.SuspendLayout();
            this.pnCourses.SuspendLayout();
            this.sideBar.SuspendLayout();
            this.manageContainer.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnAssignments.SuspendLayout();
            this.pnLogout.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).BeginInit();
            this.roundedPanel.SuspendLayout();
            this.totalCources.SuspendLayout();
            this.active.SuspendLayout();
            this.totalUserPanel.SuspendLayout();
            this.generateReport.SuspendLayout();
            this.viewFeadBack.SuspendLayout();
            this.addCourse.SuspendLayout();
            this.addUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // slideBarTransition
            // 
            this.slideBarTransition.Interval = 10;
            this.slideBarTransition.Tick += new System.EventHandler(this.sideBarTransition_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.adminLogo);
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 170);
            this.panel2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(54, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Admin";
            // 
            // adminLogo
            // 
            this.adminLogo.Image = ((System.Drawing.Image)(resources.GetObject("adminLogo.Image")));
            this.adminLogo.Location = new System.Drawing.Point(56, 17);
            this.adminLogo.Name = "adminLogo";
            this.adminLogo.Size = new System.Drawing.Size(108, 114);
            this.adminLogo.TabIndex = 0;
            this.adminLogo.TabStop = false;
            // 
            // pnDashboard
            // 
            this.pnDashboard.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pnDashboard.Controls.Add(this.dashButton);
            this.pnDashboard.Location = new System.Drawing.Point(3, 209);
            this.pnDashboard.Name = "pnDashboard";
            this.pnDashboard.Size = new System.Drawing.Size(217, 61);
            this.pnDashboard.TabIndex = 3;
            // 
            // dashButton
            // 
            this.dashButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dashButton.Image = ((System.Drawing.Image)(resources.GetObject("dashButton.Image")));
            this.dashButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashButton.Location = new System.Drawing.Point(-2, 0);
            this.dashButton.Name = "dashButton";
            this.dashButton.Padding = new System.Windows.Forms.Padding(5, 0, 20, 0);
            this.dashButton.Size = new System.Drawing.Size(222, 61);
            this.dashButton.TabIndex = 5;
            this.dashButton.Text = "         Dashboard";
            this.dashButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnAccount
            // 
            this.pnAccount.Controls.Add(this.profileButton);
            this.pnAccount.Location = new System.Drawing.Point(3, 276);
            this.pnAccount.Name = "pnAccount";
            this.pnAccount.Size = new System.Drawing.Size(217, 61);
            this.pnAccount.TabIndex = 8;
            // 
            // profileButton
            // 
            this.profileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.profileButton.FlatAppearance.BorderSize = 0;
            this.profileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileButton.ForeColor = System.Drawing.Color.Transparent;
            this.profileButton.Image = ((System.Drawing.Image)(resources.GetObject("profileButton.Image")));
            this.profileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profileButton.Location = new System.Drawing.Point(-9, -2);
            this.profileButton.Name = "profileButton";
            this.profileButton.Padding = new System.Windows.Forms.Padding(2, 0, 20, 0);
            this.profileButton.Size = new System.Drawing.Size(222, 61);
            this.profileButton.TabIndex = 2;
            this.profileButton.Text = "             Profile";
            this.profileButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profileButton.UseVisualStyleBackColor = false;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // pnCourses
            // 
            this.pnCourses.Controls.Add(this.manageFaculty);
            this.pnCourses.Location = new System.Drawing.Point(3, 68);
            this.pnCourses.Name = "pnCourses";
            this.pnCourses.Size = new System.Drawing.Size(217, 60);
            this.pnCourses.TabIndex = 4;
            // 
            // manageFaculty
            // 
            this.manageFaculty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.manageFaculty.FlatAppearance.BorderSize = 0;
            this.manageFaculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageFaculty.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageFaculty.ForeColor = System.Drawing.Color.White;
            this.manageFaculty.Image = ((System.Drawing.Image)(resources.GetObject("manageFaculty.Image")));
            this.manageFaculty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageFaculty.Location = new System.Drawing.Point(-24, 0);
            this.manageFaculty.Name = "manageFaculty";
            this.manageFaculty.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.manageFaculty.Size = new System.Drawing.Size(235, 61);
            this.manageFaculty.TabIndex = 5;
            this.manageFaculty.Text = "  Manage Faculty";
            this.manageFaculty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.manageFaculty.UseVisualStyleBackColor = false;
            this.manageFaculty.Click += new System.EventHandler(this.manageFacultyButton_Click);
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.sideBar.Controls.Add(this.panel2);
            this.sideBar.Controls.Add(this.pnDashboard);
            this.sideBar.Controls.Add(this.pnAccount);
            this.sideBar.Controls.Add(this.manageContainer);
            this.sideBar.Controls.Add(this.pnAssignments);
            this.sideBar.Controls.Add(this.pnLogout);
            this.sideBar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sideBar.Location = new System.Drawing.Point(0, -1);
            this.sideBar.Name = "sideBar";
            this.sideBar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.sideBar.Size = new System.Drawing.Size(50, 800);
            this.sideBar.TabIndex = 3;
            this.sideBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // manageContainer
            // 
            this.manageContainer.Controls.Add(this.panel5);
            this.manageContainer.Controls.Add(this.panel4);
            this.manageContainer.Controls.Add(this.pnCourses);
            this.manageContainer.Location = new System.Drawing.Point(3, 343);
            this.manageContainer.Name = "manageContainer";
            this.manageContainer.Size = new System.Drawing.Size(217, 60);
            this.manageContainer.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.manageStudent);
            this.panel5.Location = new System.Drawing.Point(3, 134);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 60);
            this.panel5.TabIndex = 5;
            // 
            // manageStudent
            // 
            this.manageStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.manageStudent.FlatAppearance.BorderSize = 0;
            this.manageStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageStudent.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageStudent.ForeColor = System.Drawing.Color.White;
            this.manageStudent.Image = ((System.Drawing.Image)(resources.GetObject("manageStudent.Image")));
            this.manageStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageStudent.Location = new System.Drawing.Point(-24, 0);
            this.manageStudent.Name = "manageStudent";
            this.manageStudent.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.manageStudent.Size = new System.Drawing.Size(241, 61);
            this.manageStudent.TabIndex = 4;
            this.manageStudent.Text = "    Manage Student";
            this.manageStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.manageStudent.UseVisualStyleBackColor = false;
            this.manageStudent.Click += new System.EventHandler(this.manageStudent_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.manageButton);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(216, 59);
            this.panel4.TabIndex = 5;
            // 
            // manageButton
            // 
            this.manageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.manageButton.FlatAppearance.BorderSize = 0;
            this.manageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageButton.ForeColor = System.Drawing.Color.White;
            this.manageButton.Image = global::LMS.Properties.Resources.icons8_manage_321;
            this.manageButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageButton.Location = new System.Drawing.Point(-6, 1);
            this.manageButton.Name = "manageButton";
            this.manageButton.Padding = new System.Windows.Forms.Padding(5, 0, 20, 0);
            this.manageButton.Size = new System.Drawing.Size(222, 61);
            this.manageButton.TabIndex = 2;
            this.manageButton.Text = "       Manage";
            this.manageButton.UseVisualStyleBackColor = false;
            this.manageButton.Click += new System.EventHandler(this.manageButton_Click);
            // 
            // pnAssignments
            // 
            this.pnAssignments.Controls.Add(this.reportButton);
            this.pnAssignments.Location = new System.Drawing.Point(3, 409);
            this.pnAssignments.Name = "pnAssignments";
            this.pnAssignments.Size = new System.Drawing.Size(214, 61);
            this.pnAssignments.TabIndex = 5;
            // 
            // reportButton
            // 
            this.reportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.reportButton.FlatAppearance.BorderSize = 0;
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportButton.ForeColor = System.Drawing.Color.White;
            this.reportButton.Image = ((System.Drawing.Image)(resources.GetObject("reportButton.Image")));
            this.reportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportButton.Location = new System.Drawing.Point(-3, 3);
            this.reportButton.Name = "reportButton";
            this.reportButton.Padding = new System.Windows.Forms.Padding(5, 0, 20, 0);
            this.reportButton.Size = new System.Drawing.Size(224, 61);
            this.reportButton.TabIndex = 2;
            this.reportButton.Text = "      View Report";
            this.reportButton.UseVisualStyleBackColor = false;
            // 
            // pnLogout
            // 
            this.pnLogout.Controls.Add(this.logOutButton);
            this.pnLogout.Location = new System.Drawing.Point(3, 476);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Size = new System.Drawing.Size(214, 61);
            this.pnLogout.TabIndex = 9;
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.logOutButton.FlatAppearance.BorderSize = 0;
            this.logOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOutButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.Color.White;
            this.logOutButton.Image = ((System.Drawing.Image)(resources.GetObject("logOutButton.Image")));
            this.logOutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logOutButton.Location = new System.Drawing.Point(-3, 3);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Padding = new System.Windows.Forms.Padding(2, 0, 20, 0);
            this.logOutButton.Size = new System.Drawing.Size(217, 61);
            this.logOutButton.TabIndex = 2;
            this.logOutButton.Text = "       Logout";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButtonClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.menuButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 31);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Broadway", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(50, -2);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 36);
            this.label7.TabIndex = 45;
            this.label7.Text = "LEARNEX";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(1121, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.TabIndex = 44;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.exitButton.BackgroundImage = global::LMS.Properties.Resources.icons8_cross_321;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(1159, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(32, 32);
            this.exitButton.TabIndex = 4;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.Image = ((System.Drawing.Image)(resources.GetObject("menuButton.Image")));
            this.menuButton.Location = new System.Drawing.Point(12, 2);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(31, 29);
            this.menuButton.TabIndex = 1;
            this.menuButton.TabStop = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 47);
            this.label3.TabIndex = 4;
            this.label3.Text = "Welcome ";
            // 
            // roundedPanel
            // 
            this.roundedPanel.BackColor = System.Drawing.Color.White;
            this.roundedPanel.Controls.Add(this.label6);
            this.roundedPanel.Controls.Add(this.label5);
            this.roundedPanel.Controls.Add(this.label3);
            this.roundedPanel.Location = new System.Drawing.Point(293, 91);
            this.roundedPanel.Name = "roundedPanel";
            this.roundedPanel.Size = new System.Drawing.Size(614, 77);
            this.roundedPanel.TabIndex = 6;
            this.roundedPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.roundedPanel_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(208, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 47);
            this.label6.TabIndex = 7;
            this.label6.Text = "*name*";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(324, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 47);
            this.label5.TabIndex = 6;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // manageTransition
            // 
            this.manageTransition.Interval = 10;
            this.manageTransition.Tick += new System.EventHandler(this.manageTransition_Tick);
            // 
            // totalCources
            // 
            this.totalCources.BackColor = System.Drawing.Color.White;
            this.totalCources.Controls.Add(this.totalCourse);
            this.totalCources.Location = new System.Drawing.Point(528, 200);
            this.totalCources.Name = "totalCources";
            this.totalCources.Size = new System.Drawing.Size(132, 93);
            this.totalCources.TabIndex = 10;
            // 
            // totalCourse
            // 
            this.totalCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.totalCourse.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.totalCourse.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCourse.ForeColor = System.Drawing.SystemColors.Control;
            this.totalCourse.Image = ((System.Drawing.Image)(resources.GetObject("totalCourse.Image")));
            this.totalCourse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.totalCourse.Location = new System.Drawing.Point(-30, -4);
            this.totalCourse.Name = "totalCourse";
            this.totalCourse.Padding = new System.Windows.Forms.Padding(20, 15, 20, 0);
            this.totalCourse.Size = new System.Drawing.Size(197, 113);
            this.totalCourse.TabIndex = 7;
            this.totalCourse.Text = "                         Total cources";
            this.totalCourse.UseVisualStyleBackColor = false;
            this.totalCourse.Click += new System.EventHandler(this.BUTTON_Click);
            this.totalCourse.MouseEnter += new System.EventHandler(this.BUTTON_Click);
            this.totalCourse.MouseLeave += new System.EventHandler(this.BUTTON_Click);
            // 
            // active
            // 
            this.active.BackColor = System.Drawing.Color.White;
            this.active.Controls.Add(this.activeTeacher);
            this.active.Location = new System.Drawing.Point(721, 200);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(136, 94);
            this.active.TabIndex = 11;
            // 
            // activeTeacher
            // 
            this.activeTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.activeTeacher.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.activeTeacher.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeTeacher.ForeColor = System.Drawing.SystemColors.Control;
            this.activeTeacher.Image = ((System.Drawing.Image)(resources.GetObject("activeTeacher.Image")));
            this.activeTeacher.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.activeTeacher.Location = new System.Drawing.Point(-20, -25);
            this.activeTeacher.Name = "activeTeacher";
            this.activeTeacher.Padding = new System.Windows.Forms.Padding(20, 15, 20, 0);
            this.activeTeacher.Size = new System.Drawing.Size(176, 133);
            this.activeTeacher.TabIndex = 6;
            this.activeTeacher.Text = "                                               Active Teacher";
            this.activeTeacher.UseVisualStyleBackColor = false;
            this.activeTeacher.Click += new System.EventHandler(this.BUTTON_Click);
            this.activeTeacher.MouseEnter += new System.EventHandler(this.BUTTON_Click);
            this.activeTeacher.MouseLeave += new System.EventHandler(this.BUTTON_Click);
            // 
            // totalUserPanel
            // 
            this.totalUserPanel.BackColor = System.Drawing.Color.White;
            this.totalUserPanel.Controls.Add(this.totalUser);
            this.totalUserPanel.Location = new System.Drawing.Point(344, 200);
            this.totalUserPanel.Name = "totalUserPanel";
            this.totalUserPanel.Size = new System.Drawing.Size(122, 94);
            this.totalUserPanel.TabIndex = 8;
            this.totalUserPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.totalUserPanel_Paint);
            // 
            // totalUser
            // 
            this.totalUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.totalUser.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.totalUser.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalUser.ForeColor = System.Drawing.SystemColors.Control;
            this.totalUser.Image = ((System.Drawing.Image)(resources.GetObject("totalUser.Image")));
            this.totalUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.totalUser.Location = new System.Drawing.Point(-16, -7);
            this.totalUser.Name = "totalUser";
            this.totalUser.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.totalUser.Size = new System.Drawing.Size(154, 115);
            this.totalUser.TabIndex = 5;
            this.totalUser.Text = "                               Total User";
            this.totalUser.UseVisualStyleBackColor = false;
            this.totalUser.Click += new System.EventHandler(this.BUTTON_Click);
            this.totalUser.MouseEnter += new System.EventHandler(this.BUTTON_Click);
            this.totalUser.MouseLeave += new System.EventHandler(this.BUTTON_Click);
            // 
            // generateReport
            // 
            this.generateReport.BackColor = System.Drawing.Color.White;
            this.generateReport.Controls.Add(this.button4);
            this.generateReport.Location = new System.Drawing.Point(616, 449);
            this.generateReport.Name = "generateReport";
            this.generateReport.Size = new System.Drawing.Size(241, 65);
            this.generateReport.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-6, -3);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.button4.Size = new System.Drawing.Size(274, 76);
            this.button4.TabIndex = 9;
            this.button4.Text = "Generate Reports";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.BUTTON_Click);
            this.button4.MouseEnter += new System.EventHandler(this.BUTTON_Click);
            this.button4.MouseLeave += new System.EventHandler(this.BUTTON_Click);
            // 
            // viewFeadBack
            // 
            this.viewFeadBack.BackColor = System.Drawing.Color.White;
            this.viewFeadBack.Controls.Add(this.viewRe);
            this.viewFeadBack.Location = new System.Drawing.Point(344, 449);
            this.viewFeadBack.Name = "viewFeadBack";
            this.viewFeadBack.Size = new System.Drawing.Size(241, 65);
            this.viewFeadBack.TabIndex = 12;
            // 
            // viewRe
            // 
            this.viewRe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.viewRe.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.viewRe.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewRe.ForeColor = System.Drawing.SystemColors.Control;
            this.viewRe.Image = ((System.Drawing.Image)(resources.GetObject("viewRe.Image")));
            this.viewRe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewRe.Location = new System.Drawing.Point(-3, -5);
            this.viewRe.Name = "viewRe";
            this.viewRe.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.viewRe.Size = new System.Drawing.Size(253, 78);
            this.viewRe.TabIndex = 8;
            this.viewRe.Text = "View FeedBack";
            this.viewRe.UseVisualStyleBackColor = false;
            this.viewRe.Click += new System.EventHandler(this.BUTTON_Click);
            this.viewRe.MouseEnter += new System.EventHandler(this.BUTTON_Click);
            this.viewRe.MouseLeave += new System.EventHandler(this.BUTTON_Click);
            // 
            // addCourse
            // 
            this.addCourse.BackColor = System.Drawing.Color.White;
            this.addCourse.Controls.Add(this.addCourseB);
            this.addCourse.Location = new System.Drawing.Point(344, 345);
            this.addCourse.Name = "addCourse";
            this.addCourse.Size = new System.Drawing.Size(241, 65);
            this.addCourse.TabIndex = 9;
            // 
            // addCourseB
            // 
            this.addCourseB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.addCourseB.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.addCourseB.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCourseB.ForeColor = System.Drawing.SystemColors.Control;
            this.addCourseB.Image = ((System.Drawing.Image)(resources.GetObject("addCourseB.Image")));
            this.addCourseB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addCourseB.Location = new System.Drawing.Point(-8, -6);
            this.addCourseB.Name = "addCourseB";
            this.addCourseB.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.addCourseB.Size = new System.Drawing.Size(277, 76);
            this.addCourseB.TabIndex = 6;
            this.addCourseB.Text = "Add New Course";
            this.addCourseB.UseVisualStyleBackColor = false;
            this.addCourseB.Click += new System.EventHandler(this.addCourseB_Click);
            this.addCourseB.MouseEnter += new System.EventHandler(this.BUTTON_Click);
            this.addCourseB.MouseLeave += new System.EventHandler(this.BUTTON_Click);
            // 
            // addUser
            // 
            this.addUser.BackColor = System.Drawing.Color.White;
            this.addUser.Controls.Add(this.addUserB);
            this.addUser.Location = new System.Drawing.Point(616, 342);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(241, 65);
            this.addUser.TabIndex = 7;
            // 
            // addUserB
            // 
            this.addUserB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.addUserB.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.addUserB.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUserB.ForeColor = System.Drawing.SystemColors.Control;
            this.addUserB.Image = ((System.Drawing.Image)(resources.GetObject("addUserB.Image")));
            this.addUserB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addUserB.Location = new System.Drawing.Point(-3, -5);
            this.addUserB.Name = "addUserB";
            this.addUserB.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.addUserB.Size = new System.Drawing.Size(253, 76);
            this.addUserB.TabIndex = 7;
            this.addUserB.Text = "      Assign Courses";
            this.addUserB.UseVisualStyleBackColor = false;
            this.addUserB.Click += new System.EventHandler(this.totalUser_Click);
            this.addUserB.MouseEnter += new System.EventHandler(this.BUTTON_Click);
            this.addUserB.MouseLeave += new System.EventHandler(this.BUTTON_Click);
            // 
            // Admin_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1200, 799);
            this.Controls.Add(this.totalCources);
            this.Controls.Add(this.active);
            this.Controls.Add(this.totalUserPanel);
            this.Controls.Add(this.generateReport);
            this.Controls.Add(this.viewFeadBack);
            this.Controls.Add(this.addCourse);
            this.Controls.Add(this.addUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.roundedPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_Dashboard";
            this.TransparencyKey = System.Drawing.Color.Gainsboro;
            this.Load += new System.EventHandler(this.Admin_Dashboard_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminLogo)).EndInit();
            this.pnDashboard.ResumeLayout(false);
            this.pnAccount.ResumeLayout(false);
            this.pnCourses.ResumeLayout(false);
            this.sideBar.ResumeLayout(false);
            this.manageContainer.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnAssignments.ResumeLayout(false);
            this.pnLogout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).EndInit();
            this.roundedPanel.ResumeLayout(false);
            this.roundedPanel.PerformLayout();
            this.totalCources.ResumeLayout(false);
            this.active.ResumeLayout(false);
            this.totalUserPanel.ResumeLayout(false);
            this.generateReport.ResumeLayout(false);
            this.viewFeadBack.ResumeLayout(false);
            this.addCourse.ResumeLayout(false);
            this.addUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer slideBarTransition;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox adminLogo;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Panel pnDashboard;
        private System.Windows.Forms.Label dashButton;
        private System.Windows.Forms.Panel pnAccount;
        private System.Windows.Forms.Panel pnCourses;
        private System.Windows.Forms.FlowLayoutPanel sideBar;
        private System.Windows.Forms.Panel manageContainer;
        private System.Windows.Forms.Panel pnAssignments;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.PictureBox menuButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button manageStudent;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel roundedPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer manageTransition;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button manageButton;
        private System.Windows.Forms.Button manageFaculty;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel totalCources;
        private System.Windows.Forms.Button totalCourse;
        private System.Windows.Forms.Panel active;
        private System.Windows.Forms.Button activeTeacher;
        private System.Windows.Forms.Panel totalUserPanel;
        private System.Windows.Forms.Button totalUser;
        private System.Windows.Forms.Panel generateReport;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel viewFeadBack;
        private System.Windows.Forms.Button viewRe;
        private System.Windows.Forms.Panel addCourse;
        private System.Windows.Forms.Button addCourseB;
        private System.Windows.Forms.Panel addUser;
        private System.Windows.Forms.Button addUserB;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label7;
    }
}