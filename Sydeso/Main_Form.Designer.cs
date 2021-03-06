﻿namespace Sydeso
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.pnl_content = new Sydeso.CustomPanel();
            this.pnl_toolbar = new Sydeso.CustomPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.btnToggleVoiceCommand = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.btnShutdown = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnCheckIn = new System.Windows.Forms.PictureBox();
            this.pnl_toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToggleVoiceCommand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShutdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckIn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_content
            // 
            this.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_content.Location = new System.Drawing.Point(0, 60);
            this.pnl_content.Name = "pnl_content";
            this.pnl_content.Size = new System.Drawing.Size(1080, 660);
            this.pnl_content.TabIndex = 3;
            this.pnl_content.SizeChanged += new System.EventHandler(this.pnl_content_SizeChanged);
            // 
            // pnl_toolbar
            // 
            this.pnl_toolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.pnl_toolbar.Controls.Add(this.btnCheckIn);
            this.pnl_toolbar.Controls.Add(this.label1);
            this.pnl_toolbar.Controls.Add(this.pbIcon);
            this.pnl_toolbar.Controls.Add(this.btnToggleVoiceCommand);
            this.pnl_toolbar.Controls.Add(this.btnSettings);
            this.pnl_toolbar.Controls.Add(this.btnShutdown);
            this.pnl_toolbar.Controls.Add(this.btnExit);
            this.pnl_toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_toolbar.Location = new System.Drawing.Point(0, 0);
            this.pnl_toolbar.Name = "pnl_toolbar";
            this.pnl_toolbar.Size = new System.Drawing.Size(1080, 60);
            this.pnl_toolbar.TabIndex = 1;
            this.pnl_toolbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseDown);
            this.pnl_toolbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseMove);
            this.pnl_toolbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(71, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "APPLICATION NAME";
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(25, 10);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(40, 40);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 4;
            this.pbIcon.TabStop = false;
            // 
            // btnToggleVoiceCommand
            // 
            this.btnToggleVoiceCommand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleVoiceCommand.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleVoiceCommand.Image")));
            this.btnToggleVoiceCommand.Location = new System.Drawing.Point(921, 29);
            this.btnToggleVoiceCommand.Name = "btnToggleVoiceCommand";
            this.btnToggleVoiceCommand.Size = new System.Drawing.Size(25, 25);
            this.btnToggleVoiceCommand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnToggleVoiceCommand.TabIndex = 3;
            this.btnToggleVoiceCommand.TabStop = false;
            this.btnToggleVoiceCommand.Visible = false;
            this.btnToggleVoiceCommand.Click += new System.EventHandler(this.btnToggleVoiceCommand_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(983, 29);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(25, 25);
            this.btnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSettings.TabIndex = 2;
            this.btnSettings.TabStop = false;
            // 
            // btnShutdown
            // 
            this.btnShutdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShutdown.Image = ((System.Drawing.Image)(resources.GetObject("btnShutdown.Image")));
            this.btnShutdown.Location = new System.Drawing.Point(1043, 29);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(25, 25);
            this.btnShutdown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnShutdown.TabIndex = 1;
            this.btnShutdown.TabStop = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1057, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckIn.Image")));
            this.btnCheckIn.Location = new System.Drawing.Point(952, 29);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(25, 25);
            this.btnCheckIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCheckIn.TabIndex = 6;
            this.btnCheckIn.TabStop = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.pnl_content);
            this.Controls.Add(this.pnl_toolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.pnl_toolbar.ResumeLayout(false);
            this.pnl_toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToggleVoiceCommand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShutdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnExit;
        private CustomPanel pnl_toolbar;
        public CustomPanel pnl_content;
        private System.Windows.Forms.PictureBox btnToggleVoiceCommand;
        private System.Windows.Forms.PictureBox btnSettings;
        private System.Windows.Forms.PictureBox btnShutdown;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnCheckIn;
    }
}

