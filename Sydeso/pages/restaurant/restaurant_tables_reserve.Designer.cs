namespace Sydeso
{
    partial class restaurant_tables_reserve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(restaurant_tables_reserve));
            this.pnl_container = new Sydeso.CustomPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.borderedPanel2 = new Sydeso.BorderedPanel();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.borderedPanel1 = new Sydeso.BorderedPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbNames = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.pnl_toolbar = new Sydeso.CustomPanel();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_container.SuspendLayout();
            this.borderedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.borderedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnl_toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_container
            // 
            this.pnl_container.Controls.Add(this.label2);
            this.pnl_container.Controls.Add(this.borderedPanel2);
            this.pnl_container.Controls.Add(this.borderedPanel1);
            this.pnl_container.Controls.Add(this.label3);
            this.pnl_container.Controls.Add(this.btnYes);
            this.pnl_container.Controls.Add(this.btnNo);
            this.pnl_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_container.Location = new System.Drawing.Point(0, 60);
            this.pnl_container.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_container.Name = "pnl_container";
            this.pnl_container.Size = new System.Drawing.Size(400, 207);
            this.pnl_container.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(37, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Reservation Date";
            // 
            // borderedPanel2
            // 
            this.borderedPanel2.BackColor = System.Drawing.Color.Transparent;
            this.borderedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.borderedPanel2.Controls.Add(this.datePicker);
            this.borderedPanel2.Controls.Add(this.txtDate);
            this.borderedPanel2.Controls.Add(this.pictureBox3);
            this.borderedPanel2.Location = new System.Drawing.Point(40, 112);
            this.borderedPanel2.Name = "borderedPanel2";
            this.borderedPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.borderedPanel2.Size = new System.Drawing.Size(323, 30);
            this.borderedPanel2.TabIndex = 5;
            // 
            // datePicker
            // 
            this.datePicker.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.CustomFormat = "";
            this.datePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datePicker.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.datePicker.Location = new System.Drawing.Point(302, 5);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(16, 20);
            this.datePicker.TabIndex = 4;
            this.datePicker.TabStop = false;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.txtDate.Location = new System.Drawing.Point(31, 5);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(265, 20);
            this.txtDate.TabIndex = 0;
            this.txtDate.Enter += new System.EventHandler(this.txtDate_Enter);
            this.txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDate_KeyPress);
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(5, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.borderedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.borderedPanel1.Controls.Add(this.pictureBox2);
            this.borderedPanel1.Controls.Add(this.txtName);
            this.borderedPanel1.Controls.Add(this.cbNames);
            this.borderedPanel1.Location = new System.Drawing.Point(40, 56);
            this.borderedPanel1.Name = "borderedPanel1";
            this.borderedPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.borderedPanel1.Size = new System.Drawing.Size(323, 30);
            this.borderedPanel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(5, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.txtName.Location = new System.Drawing.Point(31, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 20);
            this.txtName.TabIndex = 0;
            // 
            // cbNames
            // 
            this.cbNames.BackColor = System.Drawing.Color.White;
            this.cbNames.DropDownWidth = 287;
            this.cbNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbNames.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbNames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.cbNames.FormattingEnabled = true;
            this.cbNames.Location = new System.Drawing.Point(31, 4);
            this.cbNames.Name = "cbNames";
            this.cbNames.Size = new System.Drawing.Size(287, 21);
            this.cbNames.TabIndex = 3;
            this.cbNames.TabStop = false;
            this.cbNames.SelectedIndexChanged += new System.EventHandler(this.cbNames_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(37, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Customer Name (Free-Type)";
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(183)))), ((int)(((byte)(168)))));
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(288, 148);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 30);
            this.btnYes.TabIndex = 1;
            this.btnYes.TabStop = false;
            this.btnYes.Text = "YES";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.button_click);
            // 
            // btnNo
            // 
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnNo.Location = new System.Drawing.Point(207, 148);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 30);
            this.btnNo.TabIndex = 0;
            this.btnNo.TabStop = false;
            this.btnNo.Text = "NO";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.button_click);
            // 
            // pnl_toolbar
            // 
            this.pnl_toolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.pnl_toolbar.Controls.Add(this.btnExit);
            this.pnl_toolbar.Controls.Add(this.label1);
            this.pnl_toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_toolbar.Location = new System.Drawing.Point(0, 0);
            this.pnl_toolbar.Name = "pnl_toolbar";
            this.pnl_toolbar.Size = new System.Drawing.Size(400, 60);
            this.pnl_toolbar.TabIndex = 4;
            this.pnl_toolbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseDown);
            this.pnl_toolbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseMove);
            this.pnl_toolbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_toolbar_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(377, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.button_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "RESERVE TABLE";
            // 
            // restaurant_tables_reserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 267);
            this.Controls.Add(this.pnl_container);
            this.Controls.Add(this.pnl_toolbar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "restaurant_tables_reserve";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.restaurant_tables_reserve_Load);
            this.pnl_container.ResumeLayout(false);
            this.pnl_container.PerformLayout();
            this.borderedPanel2.ResumeLayout(false);
            this.borderedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.borderedPanel1.ResumeLayout(false);
            this.borderedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnl_toolbar.ResumeLayout(false);
            this.pnl_toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPanel pnl_container;
        private BorderedPanel borderedPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private CustomPanel pnl_toolbar;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNames;
        private System.Windows.Forms.Label label2;
        private BorderedPanel borderedPanel2;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}