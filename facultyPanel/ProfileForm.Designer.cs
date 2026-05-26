namespace LMS.facultyPanel
{
    partial class ProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.adminLogo = new System.Windows.Forms.PictureBox();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnDashboard = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnAccount = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnCourses = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnQuizes = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.pnAssignments = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.roundedPanel = new System.Windows.Forms.Panel();
            this.num2 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.num1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelpass = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelid = new System.Windows.Forms.Label();
            this.labelusrname = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelname = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminLogo)).BeginInit();
            this.sidebar.SuspendLayout();
            this.pnDashboard.SuspendLayout();
            this.pnAccount.SuspendLayout();
            this.pnCourses.SuspendLayout();
            this.pnQuizes.SuspendLayout();
            this.pnAssignments.SuspendLayout();
            this.pnLogout.SuspendLayout();
            this.roundedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.btnHam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 31);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(1121, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.TabIndex = 52;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Broadway", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(50, -2);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 36);
            this.label6.TabIndex = 46;
            this.label6.Text = "LEARNEX";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button8.BackgroundImage = global::LMS.Properties.Resources.icons8_cross_321;
            this.button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(1159, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(31, 32);
            this.button8.TabIndex = 27;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // btnHam
            // 
            this.btnHam.Image = ((System.Drawing.Image)(resources.GetObject("btnHam.Image")));
            this.btnHam.Location = new System.Drawing.Point(16, 2);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(43, 36);
            this.btnHam.TabIndex = 1;
            this.btnHam.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.adminLogo);
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 194);
            this.panel2.TabIndex = 10;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(56, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Teacher";
            // 
            // adminLogo
            // 
            this.adminLogo.Image = ((System.Drawing.Image)(resources.GetObject("adminLogo.Image")));
            this.adminLogo.Location = new System.Drawing.Point(66, 40);
            this.adminLogo.Name = "adminLogo";
            this.adminLogo.Size = new System.Drawing.Size(108, 114);
            this.adminLogo.TabIndex = 0;
            this.adminLogo.TabStop = false;
            this.adminLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.pnDashboard);
            this.sidebar.Controls.Add(this.pnAccount);
            this.sidebar.Controls.Add(this.pnCourses);
            this.sidebar.Controls.Add(this.pnQuizes);
            this.sidebar.Controls.Add(this.pnAssignments);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.pnLogout);
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.sidebar.Size = new System.Drawing.Size(220, 800);
            this.sidebar.TabIndex = 5;
            this.sidebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // pnDashboard
            // 
            this.pnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.pnDashboard.Controls.Add(this.button1);
            this.pnDashboard.Location = new System.Drawing.Point(3, 233);
            this.pnDashboard.Name = "pnDashboard";
            this.pnDashboard.Size = new System.Drawing.Size(217, 79);
            this.pnDashboard.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-16, 14);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(244, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "     Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.facultyDashboard);
            // 
            // pnAccount
            // 
            this.pnAccount.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pnAccount.Controls.Add(this.label1);
            this.pnAccount.Location = new System.Drawing.Point(3, 318);
            this.pnAccount.Name = "pnAccount";
            this.pnAccount.Size = new System.Drawing.Size(217, 79);
            this.pnAccount.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(-5, 16);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(222, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Profile";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnCourses
            // 
            this.pnCourses.Controls.Add(this.button2);
            this.pnCourses.Location = new System.Drawing.Point(3, 403);
            this.pnCourses.Name = "pnCourses";
            this.pnCourses.Size = new System.Drawing.Size(217, 79);
            this.pnCourses.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(-14, 16);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(231, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Courses";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Course);
            // 
            // pnQuizes
            // 
            this.pnQuizes.Controls.Add(this.button4);
            this.pnQuizes.Location = new System.Drawing.Point(3, 488);
            this.pnQuizes.Name = "pnQuizes";
            this.pnQuizes.Size = new System.Drawing.Size(217, 79);
            this.pnQuizes.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-14, 15);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(231, 46);
            this.button4.TabIndex = 2;
            this.button4.Text = "Quizes";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.quizes);
            // 
            // pnAssignments
            // 
            this.pnAssignments.Controls.Add(this.button3);
            this.pnAssignments.Location = new System.Drawing.Point(3, 573);
            this.pnAssignments.Name = "pnAssignments";
            this.pnAssignments.Size = new System.Drawing.Size(217, 79);
            this.pnAssignments.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(-11, 14);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(228, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "      Assignments";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.assignments);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 658);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 38);
            this.panel3.TabIndex = 11;
            // 
            // pnLogout
            // 
            this.pnLogout.Controls.Add(this.button7);
            this.pnLogout.Location = new System.Drawing.Point(3, 702);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Size = new System.Drawing.Size(217, 79);
            this.pnLogout.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(-14, 16);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(231, 46);
            this.button7.TabIndex = 2;
            this.button7.Text = "Logout";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.LogOut);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            // 
            // roundedPanel
            // 
            this.roundedPanel.BackColor = System.Drawing.Color.White;
            this.roundedPanel.Controls.Add(this.num2);
            this.roundedPanel.Controls.Add(this.date);
            this.roundedPanel.Controls.Add(this.label13);
            this.roundedPanel.Controls.Add(this.num1);
            this.roundedPanel.Controls.Add(this.label11);
            this.roundedPanel.Controls.Add(this.labelEmail);
            this.roundedPanel.Controls.Add(this.label8);
            this.roundedPanel.Controls.Add(this.labelpass);
            this.roundedPanel.Controls.Add(this.label10);
            this.roundedPanel.Controls.Add(this.labelid);
            this.roundedPanel.Controls.Add(this.labelusrname);
            this.roundedPanel.Controls.Add(this.label7);
            this.roundedPanel.Controls.Add(this.labelname);
            this.roundedPanel.Controls.Add(this.label5);
            this.roundedPanel.Controls.Add(this.label3);
            this.roundedPanel.Controls.Add(this.label4);
            this.roundedPanel.Location = new System.Drawing.Point(266, 84);
            this.roundedPanel.Name = "roundedPanel";
            this.roundedPanel.Size = new System.Drawing.Size(897, 661);
            this.roundedPanel.TabIndex = 15;
            this.roundedPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // num2
            // 
            this.num2.AutoSize = true;
            this.num2.BackColor = System.Drawing.Color.White;
            this.num2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num2.ForeColor = System.Drawing.Color.Black;
            this.num2.Location = new System.Drawing.Point(580, 452);
            this.num2.Name = "num2";
            this.num2.Size = new System.Drawing.Size(181, 47);
            this.num2.TabIndex = 19;
            this.num2.Text = "*number*";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.BackColor = System.Drawing.Color.White;
            this.date.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.ForeColor = System.Drawing.Color.Black;
            this.date.Location = new System.Drawing.Point(334, 528);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(125, 47);
            this.date.TabIndex = 18;
            this.date.Text = "*date*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(16, 528);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(268, 47);
            this.label13.TabIndex = 17;
            this.label13.Text = "Joining Date   :";
            // 
            // num1
            // 
            this.num1.AutoSize = true;
            this.num1.BackColor = System.Drawing.Color.White;
            this.num1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num1.ForeColor = System.Drawing.Color.Black;
            this.num1.Location = new System.Drawing.Point(278, 452);
            this.num1.Name = "num1";
            this.num1.Size = new System.Drawing.Size(181, 47);
            this.num1.TabIndex = 16;
            this.num1.Text = "*number*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(3, 452);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(280, 47);
            this.label11.TabIndex = 15;
            this.label11.Text = "Phone Number:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.White;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.Black;
            this.labelEmail.Location = new System.Drawing.Point(260, 301);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(277, 47);
            this.labelEmail.TabIndex = 14;
            this.labelEmail.Text = "*email address*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(45, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 47);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email          :";
            // 
            // labelpass
            // 
            this.labelpass.AutoSize = true;
            this.labelpass.BackColor = System.Drawing.Color.White;
            this.labelpass.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelpass.ForeColor = System.Drawing.Color.Black;
            this.labelpass.Location = new System.Drawing.Point(262, 377);
            this.labelpass.Name = "labelpass";
            this.labelpass.Size = new System.Drawing.Size(123, 47);
            this.labelpass.TabIndex = 12;
            this.labelpass.Text = "*pass*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(45, 377);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(214, 47);
            this.label10.TabIndex = 11;
            this.label10.Text = "Password   :";
            // 
            // labelid
            // 
            this.labelid.AutoSize = true;
            this.labelid.BackColor = System.Drawing.Color.White;
            this.labelid.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelid.ForeColor = System.Drawing.Color.Black;
            this.labelid.Location = new System.Drawing.Point(261, 62);
            this.labelid.Name = "labelid";
            this.labelid.Size = new System.Drawing.Size(84, 47);
            this.labelid.TabIndex = 10;
            this.labelid.Text = "*id*";
            // 
            // labelusrname
            // 
            this.labelusrname.AutoSize = true;
            this.labelusrname.BackColor = System.Drawing.Color.White;
            this.labelusrname.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelusrname.ForeColor = System.Drawing.Color.Black;
            this.labelusrname.Location = new System.Drawing.Point(258, 216);
            this.labelusrname.Name = "labelusrname";
            this.labelusrname.Size = new System.Drawing.Size(193, 47);
            this.labelusrname.TabIndex = 9;
            this.labelusrname.Text = "*usrname*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(44, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 47);
            this.label7.TabIndex = 8;
            this.label7.Text = "User Name :";
            // 
            // labelname
            // 
            this.labelname.AutoSize = true;
            this.labelname.BackColor = System.Drawing.Color.White;
            this.labelname.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelname.ForeColor = System.Drawing.Color.Black;
            this.labelname.Location = new System.Drawing.Point(261, 138);
            this.labelname.Name = "labelname";
            this.labelname.Size = new System.Drawing.Size(143, 47);
            this.labelname.TabIndex = 7;
            this.labelname.Text = "*name*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(296, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 47);
            this.label5.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(45, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 47);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name         :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(45, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 47);
            this.label4.TabIndex = 5;
            this.label4.Text = "ID               :";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.roundedPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfileForm";
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminLogo)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.pnDashboard.ResumeLayout(false);
            this.pnAccount.ResumeLayout(false);
            this.pnCourses.ResumeLayout(false);
            this.pnQuizes.ResumeLayout(false);
            this.pnAssignments.ResumeLayout(false);
            this.pnLogout.ResumeLayout(false);
            this.roundedPanel.ResumeLayout(false);
            this.roundedPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnHam;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox adminLogo;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel pnDashboard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnCourses;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnQuizes;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnAssignments;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel roundedPanel;
        private System.Windows.Forms.Label num2;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label num1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelpass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelid;
        private System.Windows.Forms.Label labelusrname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}