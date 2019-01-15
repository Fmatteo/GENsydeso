namespace Sydeso
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.customPanel3 = new Sydeso.CustomPanel();
            this.btnDTR = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLogin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.borderedPanel2 = new Sydeso.BorderedPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.borderedPanel1 = new Sydeso.BorderedPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customPanel4 = new Sydeso.CustomPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.customPanel3.SuspendLayout();
            this.borderedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.borderedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // customPanel3
            // 
            this.customPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.customPanel3.Controls.Add(this.label4);
            this.customPanel3.Controls.Add(this.label1);
            this.customPanel3.Controls.Add(this.btnDTR);
            this.customPanel3.Controls.Add(this.btnLogin);
            this.customPanel3.Controls.Add(this.borderedPanel2);
            this.customPanel3.Controls.Add(this.borderedPanel1);
            this.customPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel3.Location = new System.Drawing.Point(0, 0);
            this.customPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(446, 446);
            this.customPanel3.TabIndex = 3;
            this.customPanel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseDown);
            this.customPanel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseMove);
            this.customPanel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseUp);
            // 
            // btnDTR
            // 
            this.btnDTR.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDTR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDTR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDTR.BorderRadius = 2;
            this.btnDTR.ButtonText = "Check In/Out";
            this.btnDTR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDTR.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDTR.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDTR.Iconimage")));
            this.btnDTR.Iconimage_right = null;
            this.btnDTR.Iconimage_right_Selected = null;
            this.btnDTR.Iconimage_Selected = null;
            this.btnDTR.IconZoom = 70D;
            this.btnDTR.IsTab = false;
            this.btnDTR.Location = new System.Drawing.Point(66, 326);
            this.btnDTR.Name = "btnDTR";
            this.btnDTR.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDTR.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnDTR.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDTR.selected = false;
            this.btnDTR.Size = new System.Drawing.Size(150, 41);
            this.btnDTR.TabIndex = 10;
            this.btnDTR.TabStop = false;
            this.btnDTR.Textcolor = System.Drawing.Color.White;
            this.btnDTR.TextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDTR.Click += new System.EventHandler(this.btnDTR_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.BorderRadius = 2;
            this.btnLogin.ButtonText = "          Proceed";
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogin.Iconimage = null;
            this.btnLogin.Iconimage_right = ((System.Drawing.Image)(resources.GetObject("btnLogin.Iconimage_right")));
            this.btnLogin.Iconimage_right_Selected = null;
            this.btnLogin.Iconimage_Selected = null;
            this.btnLogin.IconZoom = 80D;
            this.btnLogin.IsTab = false;
            this.btnLogin.Location = new System.Drawing.Point(230, 326);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnLogin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnLogin.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogin.selected = false;
            this.btnLogin.Size = new System.Drawing.Size(150, 41);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.TabStop = false;
            this.btnLogin.Textcolor = System.Drawing.Color.White;
            this.btnLogin.TextFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // borderedPanel2
            // 
            this.borderedPanel2.BackColor = System.Drawing.Color.White;
            this.borderedPanel2.BorderColor = System.Drawing.Color.White;
            this.borderedPanel2.Controls.Add(this.pictureBox2);
            this.borderedPanel2.Controls.Add(this.txtPass);
            this.borderedPanel2.Controls.Add(this.label3);
            this.borderedPanel2.Location = new System.Drawing.Point(66, 247);
            this.borderedPanel2.Name = "borderedPanel2";
            this.borderedPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.borderedPanel2.Size = new System.Drawing.Size(314, 57);
            this.borderedPanel2.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(22, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.txtPass.Location = new System.Drawing.Point(46, 31);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(240, 18);
            this.txtPass.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label3.Location = new System.Drawing.Point(18, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.BackColor = System.Drawing.Color.White;
            this.borderedPanel1.BorderColor = System.Drawing.Color.White;
            this.borderedPanel1.Controls.Add(this.pictureBox1);
            this.borderedPanel1.Controls.Add(this.txtUser);
            this.borderedPanel1.Controls.Add(this.label2);
            this.borderedPanel1.Location = new System.Drawing.Point(66, 166);
            this.borderedPanel1.Name = "borderedPanel1";
            this.borderedPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.borderedPanel1.Size = new System.Drawing.Size(314, 57);
            this.borderedPanel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.txtUser.Location = new System.Drawing.Point(46, 31);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(240, 18);
            this.txtUser.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label2.Location = new System.Drawing.Point(18, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 22F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(145, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 41);
            this.label1.TabIndex = 12;
            this.label1.Text = "WELCOME";
            // 
            // customPanel4
            // 
            this.customPanel4.BackColor = System.Drawing.Color.White;
            this.customPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customPanel4.BackgroundImage")));
            this.customPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.customPanel4.Controls.Add(this.btnExit);
            this.customPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.customPanel4.Location = new System.Drawing.Point(446, 0);
            this.customPanel4.Name = "customPanel4";
            this.customPanel4.Size = new System.Drawing.Size(446, 446);
            this.customPanel4.TabIndex = 12;
            this.customPanel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseDown);
            this.customPanel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseMove);
            this.customPanel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 12.5F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(126, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Please login your account";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(423, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(892, 446);
            this.Controls.Add(this.customPanel3);
            this.Controls.Add(this.customPanel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login | Date Time Record";
            this.customPanel3.ResumeLayout(false);
            this.customPanel3.PerformLayout();
            this.borderedPanel2.ResumeLayout(false);
            this.borderedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.borderedPanel1.ResumeLayout(false);
            this.borderedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomPanel customPanel3;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogin;
        private BorderedPanel borderedPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private BorderedPanel borderedPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuFlatButton btnDTR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private CustomPanel customPanel4;
        private System.Windows.Forms.PictureBox btnExit;
    }
}