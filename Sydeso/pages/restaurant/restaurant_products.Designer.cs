namespace Sydeso
{
    partial class restaurant_products
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(restaurant_products));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.customPanel5 = new Sydeso.CustomPanel();
            this.btnStockOut = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnStockIn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDelete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNew = new Bunifu.Framework.UI.BunifuFlatButton();
            this.customPanel4 = new Sydeso.CustomPanel();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.customPanel1 = new Sydeso.CustomPanel();
            this.borderedPanel2 = new Sydeso.BorderedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEntries = new System.Windows.Forms.ComboBox();
            this.btnPrint = new Bunifu.Framework.UI.BunifuFlatButton();
            this.borderedPanel1 = new Sydeso.BorderedPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.customPanel2 = new Sydeso.CustomPanel();
            this.customPanel3 = new Sydeso.CustomPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.customPanel5.SuspendLayout();
            this.customPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.customPanel1.SuspendLayout();
            this.borderedPanel2.SuspendLayout();
            this.borderedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.customPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // customPanel5
            // 
            this.customPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel5.BackColor = System.Drawing.Color.White;
            this.customPanel5.Controls.Add(this.btnStockOut);
            this.customPanel5.Controls.Add(this.btnStockIn);
            this.customPanel5.Controls.Add(this.btnDelete);
            this.customPanel5.Controls.Add(this.btnNew);
            this.customPanel5.Location = new System.Drawing.Point(30, 556);
            this.customPanel5.Name = "customPanel5";
            this.customPanel5.Size = new System.Drawing.Size(791, 81);
            this.customPanel5.TabIndex = 2;
            // 
            // btnStockOut
            // 
            this.btnStockOut.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnStockOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnStockOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStockOut.BorderRadius = 0;
            this.btnStockOut.ButtonText = "STOCK OUT";
            this.btnStockOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockOut.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStockOut.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnStockOut.Iconimage")));
            this.btnStockOut.Iconimage_right = null;
            this.btnStockOut.Iconimage_right_Selected = null;
            this.btnStockOut.Iconimage_Selected = null;
            this.btnStockOut.IconZoom = 70D;
            this.btnStockOut.IsTab = false;
            this.btnStockOut.Location = new System.Drawing.Point(528, 18);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnStockOut.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(163)))), ((int)(((byte)(148)))));
            this.btnStockOut.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStockOut.selected = false;
            this.btnStockOut.Size = new System.Drawing.Size(161, 44);
            this.btnStockOut.TabIndex = 6;
            this.btnStockOut.Textcolor = System.Drawing.Color.White;
            this.btnStockOut.TextFont = new System.Drawing.Font("Calibri", 11F);
            this.btnStockOut.Click += new System.EventHandler(this.crud_button_click);
            // 
            // btnStockIn
            // 
            this.btnStockIn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnStockIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnStockIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStockIn.BorderRadius = 0;
            this.btnStockIn.ButtonText = "STOCK IN";
            this.btnStockIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockIn.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStockIn.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnStockIn.Iconimage")));
            this.btnStockIn.Iconimage_right = null;
            this.btnStockIn.Iconimage_right_Selected = null;
            this.btnStockIn.Iconimage_Selected = null;
            this.btnStockIn.IconZoom = 70D;
            this.btnStockIn.IsTab = false;
            this.btnStockIn.Location = new System.Drawing.Point(361, 18);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnStockIn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(163)))), ((int)(((byte)(148)))));
            this.btnStockIn.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStockIn.selected = false;
            this.btnStockIn.Size = new System.Drawing.Size(161, 44);
            this.btnStockIn.TabIndex = 5;
            this.btnStockIn.Textcolor = System.Drawing.Color.White;
            this.btnStockIn.TextFont = new System.Drawing.Font("Calibri", 11F);
            this.btnStockIn.Click += new System.EventHandler(this.crud_button_click);
            // 
            // btnDelete
            // 
            this.btnDelete.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.ButtonText = "DELETE RECORD";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDelete.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDelete.Iconimage")));
            this.btnDelete.Iconimage_right = null;
            this.btnDelete.Iconimage_right_Selected = null;
            this.btnDelete.Iconimage_Selected = null;
            this.btnDelete.IconZoom = 70D;
            this.btnDelete.IsTab = false;
            this.btnDelete.Location = new System.Drawing.Point(194, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnDelete.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(163)))), ((int)(((byte)(148)))));
            this.btnDelete.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDelete.selected = false;
            this.btnDelete.Size = new System.Drawing.Size(161, 44);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Textcolor = System.Drawing.Color.White;
            this.btnDelete.TextFont = new System.Drawing.Font("Calibri", 11F);
            this.btnDelete.Click += new System.EventHandler(this.crud_button_click);
            // 
            // btnNew
            // 
            this.btnNew.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.BorderRadius = 0;
            this.btnNew.ButtonText = "NEW RECORD";
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNew.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNew.Iconimage")));
            this.btnNew.Iconimage_right = null;
            this.btnNew.Iconimage_right_Selected = null;
            this.btnNew.Iconimage_Selected = null;
            this.btnNew.IconZoom = 70D;
            this.btnNew.IsTab = false;
            this.btnNew.Location = new System.Drawing.Point(27, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnNew.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(163)))), ((int)(((byte)(148)))));
            this.btnNew.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNew.selected = false;
            this.btnNew.Size = new System.Drawing.Size(161, 44);
            this.btnNew.TabIndex = 3;
            this.btnNew.Textcolor = System.Drawing.Color.White;
            this.btnNew.TextFont = new System.Drawing.Font("Calibri", 11F);
            this.btnNew.Click += new System.EventHandler(this.crud_button_click);
            // 
            // customPanel4
            // 
            this.customPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel4.BackColor = System.Drawing.Color.White;
            this.customPanel4.Controls.Add(this.txtPage);
            this.customPanel4.Controls.Add(this.lblTotalPage);
            this.customPanel4.Controls.Add(this.btnNext);
            this.customPanel4.Controls.Add(this.btnBack);
            this.customPanel4.Controls.Add(this.btnFirst);
            this.customPanel4.Controls.Add(this.btnLast);
            this.customPanel4.Controls.Add(this.dataGridView1);
            this.customPanel4.Location = new System.Drawing.Point(30, 129);
            this.customPanel4.Name = "customPanel4";
            this.customPanel4.Size = new System.Drawing.Size(791, 407);
            this.customPanel4.TabIndex = 1;
            // 
            // txtPage
            // 
            this.txtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPage.BackColor = System.Drawing.Color.White;
            this.txtPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPage.Font = new System.Drawing.Font("Calibri", 10F);
            this.txtPage.Location = new System.Drawing.Point(675, 331);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(65, 17);
            this.txtPage.TabIndex = 6;
            this.txtPage.Text = "1";
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPage.TextChanged += new System.EventHandler(this.page_textchanged);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.Location = new System.Drawing.Point(739, 331);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(19, 15);
            this.lblTotalPage.TabIndex = 5;
            this.lblTotalPage.Text = "/1";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(668, 354);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 30);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNext.TabIndex = 4;
            this.btnNext.TabStop = false;
            this.btnNext.Click += new System.EventHandler(this.pagination_button_click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(632, 354);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(30, 30);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBack.TabIndex = 3;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.pagination_button_click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnFirst.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Calibri", 9F);
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.Location = new System.Drawing.Point(573, 354);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(53, 30);
            this.btnFirst.TabIndex = 2;
            this.btnFirst.Text = "FIRST";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.pagination_button_click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnLast.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Calibri", 9F);
            this.btnLast.ForeColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(704, 354);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(53, 30);
            this.btnLast.TabIndex = 1;
            this.btnLast.Text = "LAST";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.pagination_button_click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(81)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(27, 23);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(737, 305);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.Controls.Add(this.borderedPanel2);
            this.customPanel1.Controls.Add(this.btnPrint);
            this.customPanel1.Controls.Add(this.borderedPanel1);
            this.customPanel1.Controls.Add(this.customPanel2);
            this.customPanel1.Location = new System.Drawing.Point(30, 27);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(791, 74);
            this.customPanel1.TabIndex = 0;
            // 
            // borderedPanel2
            // 
            this.borderedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.borderedPanel2.BackColor = System.Drawing.Color.Transparent;
            this.borderedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.borderedPanel2.Controls.Add(this.label2);
            this.borderedPanel2.Controls.Add(this.cbEntries);
            this.borderedPanel2.Location = new System.Drawing.Point(299, 15);
            this.borderedPanel2.Name = "borderedPanel2";
            this.borderedPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.borderedPanel2.Size = new System.Drawing.Size(123, 44);
            this.borderedPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "SHOW ENTRIES";
            // 
            // cbEntries
            // 
            this.cbEntries.BackColor = System.Drawing.Color.White;
            this.cbEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEntries.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbEntries.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.cbEntries.FormattingEnabled = true;
            this.cbEntries.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "500",
            "ALL"});
            this.cbEntries.Location = new System.Drawing.Point(5, 18);
            this.cbEntries.Name = "cbEntries";
            this.cbEntries.Size = new System.Drawing.Size(113, 21);
            this.cbEntries.TabIndex = 1;
            this.cbEntries.SelectedIndexChanged += new System.EventHandler(this.cbEntries_SelectedIndexChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.BorderRadius = 0;
            this.btnPrint.ButtonText = "PRINT";
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPrint.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnPrint.Iconimage")));
            this.btnPrint.Iconimage_right = null;
            this.btnPrint.Iconimage_right_Selected = null;
            this.btnPrint.Iconimage_Selected = null;
            this.btnPrint.IconZoom = 70D;
            this.btnPrint.IsTab = false;
            this.btnPrint.Location = new System.Drawing.Point(428, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(173)))), ((int)(((byte)(158)))));
            this.btnPrint.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(163)))), ((int)(((byte)(148)))));
            this.btnPrint.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPrint.selected = false;
            this.btnPrint.Size = new System.Drawing.Size(123, 44);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Textcolor = System.Drawing.Color.White;
            this.btnPrint.TextFont = new System.Drawing.Font("Calibri", 11F);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.borderedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.borderedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.borderedPanel1.Controls.Add(this.pictureBox3);
            this.borderedPanel1.Controls.Add(this.txtSearch);
            this.borderedPanel1.Location = new System.Drawing.Point(557, 15);
            this.borderedPanel1.Name = "borderedPanel1";
            this.borderedPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.borderedPanel1.Size = new System.Drawing.Size(200, 44);
            this.borderedPanel1.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(7, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.txtSearch.Location = new System.Drawing.Point(33, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "  SEARCH";
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.placeholder_keydown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.placeholder_keyup);
            // 
            // customPanel2
            // 
            this.customPanel2.Controls.Add(this.customPanel3);
            this.customPanel2.Controls.Add(this.label1);
            this.customPanel2.Location = new System.Drawing.Point(27, 15);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(186, 44);
            this.customPanel2.TabIndex = 0;
            // 
            // customPanel3
            // 
            this.customPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.customPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.customPanel3.Location = new System.Drawing.Point(0, 0);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(10, 44);
            this.customPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label1.Location = new System.Drawing.Point(31, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "LIST OF ITEMS";
            // 
            // restaurant_products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(850, 660);
            this.Controls.Add(this.customPanel5);
            this.Controls.Add(this.customPanel4);
            this.Controls.Add(this.customPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "restaurant_products";
            this.Load += new System.EventHandler(this.restaurant_products_Load);
            this.customPanel5.ResumeLayout(false);
            this.customPanel4.ResumeLayout(false);
            this.customPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.customPanel1.ResumeLayout(false);
            this.borderedPanel2.ResumeLayout(false);
            this.borderedPanel2.PerformLayout();
            this.borderedPanel1.ResumeLayout(false);
            this.borderedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPanel customPanel1;
        private CustomPanel customPanel2;
        private CustomPanel customPanel3;
        private System.Windows.Forms.Label label1;
        private BorderedPanel borderedPanel1;
        private System.Windows.Forms.TextBox txtSearch;
        private CustomPanel customPanel4;
        private BorderedPanel borderedPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEntries;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox btnNext;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Label lblTotalPage;
        private CustomPanel customPanel5;
        private Bunifu.Framework.UI.BunifuFlatButton btnNew;
        private Bunifu.Framework.UI.BunifuFlatButton btnStockOut;
        private Bunifu.Framework.UI.BunifuFlatButton btnStockIn;
        private Bunifu.Framework.UI.BunifuFlatButton btnDelete;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Bunifu.Framework.UI.BunifuFlatButton btnPrint;
    }
}