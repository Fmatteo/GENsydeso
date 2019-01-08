namespace Sydeso
{
    partial class restaurant_nav
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(restaurant_nav));
            this.pnlAnimator = new BunifuAnimatorNS.Animator(this.components);
            this.pnl_sidemenu = new Sydeso.CustomFlowPanel();
            this.customPanel2 = new Sydeso.CustomPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.btnDashboard_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnProducts_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOrder_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSales_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnTables_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEmployees_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCustomers_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAccounts_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHistory_Res = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnl_sidemenu.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAnimator
            // 
            this.pnlAnimator.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.pnlAnimator.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.pnlAnimator.DefaultAnimation = animation3;
            // 
            // pnl_sidemenu
            // 
            this.pnl_sidemenu.BackColor = System.Drawing.Color.White;
            this.pnl_sidemenu.Controls.Add(this.customPanel2);
            this.pnl_sidemenu.Controls.Add(this.btnDashboard_Res);
            this.pnl_sidemenu.Controls.Add(this.btnProducts_Res);
            this.pnl_sidemenu.Controls.Add(this.btnOrder_Res);
            this.pnl_sidemenu.Controls.Add(this.btnSales_Res);
            this.pnl_sidemenu.Controls.Add(this.btnTables_Res);
            this.pnl_sidemenu.Controls.Add(this.btnEmployees_Res);
            this.pnl_sidemenu.Controls.Add(this.btnCustomers_Res);
            this.pnl_sidemenu.Controls.Add(this.btnAccounts_Res);
            this.pnl_sidemenu.Controls.Add(this.btnHistory_Res);
            this.pnlAnimator.SetDecoration(this.pnl_sidemenu, BunifuAnimatorNS.DecorationType.None);
            this.pnl_sidemenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_sidemenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_sidemenu.Location = new System.Drawing.Point(0, 0);
            this.pnl_sidemenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_sidemenu.MaximumSize = new System.Drawing.Size(230, 660);
            this.pnl_sidemenu.MinimumSize = new System.Drawing.Size(48, 660);
            this.pnl_sidemenu.Name = "pnl_sidemenu";
            this.pnl_sidemenu.Size = new System.Drawing.Size(230, 660);
            this.pnl_sidemenu.TabIndex = 5;
            // 
            // customPanel2
            // 
            this.customPanel2.Controls.Add(this.label1);
            this.customPanel2.Controls.Add(this.pbMenu);
            this.pnlAnimator.SetDecoration(this.customPanel2, BunifuAnimatorNS.DecorationType.None);
            this.customPanel2.Location = new System.Drawing.Point(0, 0);
            this.customPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(230, 100);
            this.customPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.pnlAnimator.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.label1.Location = new System.Drawing.Point(59, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "M E N U";
            // 
            // pbMenu
            // 
            this.pbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.pbMenu, BunifuAnimatorNS.DecorationType.None);
            this.pbMenu.Image = ((System.Drawing.Image)(resources.GetObject("pbMenu.Image")));
            this.pbMenu.Location = new System.Drawing.Point(7, 33);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(35, 35);
            this.pbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMenu.TabIndex = 0;
            this.pbMenu.TabStop = false;
            this.pbMenu.Click += new System.EventHandler(this.pbMenu_Click);
            // 
            // btnDashboard_Res
            // 
            this.btnDashboard_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnDashboard_Res.BackColor = System.Drawing.Color.White;
            this.btnDashboard_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDashboard_Res.BorderRadius = 0;
            this.btnDashboard_Res.ButtonText = "     Dashboard";
            this.btnDashboard_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnDashboard_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnDashboard_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDashboard_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDashboard_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDashboard_Res.Iconimage")));
            this.btnDashboard_Res.Iconimage_right = null;
            this.btnDashboard_Res.Iconimage_right_Selected = null;
            this.btnDashboard_Res.Iconimage_Selected = null;
            this.btnDashboard_Res.IconZoom = 70D;
            this.btnDashboard_Res.IsTab = false;
            this.btnDashboard_Res.Location = new System.Drawing.Point(0, 100);
            this.btnDashboard_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard_Res.Name = "btnDashboard_Res";
            this.btnDashboard_Res.Normalcolor = System.Drawing.Color.White;
            this.btnDashboard_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnDashboard_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDashboard_Res.selected = false;
            this.btnDashboard_Res.Size = new System.Drawing.Size(230, 48);
            this.btnDashboard_Res.TabIndex = 1;
            this.btnDashboard_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDashboard_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnProducts_Res
            // 
            this.btnProducts_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnProducts_Res.BackColor = System.Drawing.Color.White;
            this.btnProducts_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProducts_Res.BorderRadius = 0;
            this.btnProducts_Res.ButtonText = "     Products";
            this.btnProducts_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnProducts_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnProducts_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnProducts_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProducts_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnProducts_Res.Iconimage")));
            this.btnProducts_Res.Iconimage_right = null;
            this.btnProducts_Res.Iconimage_right_Selected = null;
            this.btnProducts_Res.Iconimage_Selected = null;
            this.btnProducts_Res.IconZoom = 70D;
            this.btnProducts_Res.IsTab = false;
            this.btnProducts_Res.Location = new System.Drawing.Point(0, 148);
            this.btnProducts_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnProducts_Res.Name = "btnProducts_Res";
            this.btnProducts_Res.Normalcolor = System.Drawing.Color.White;
            this.btnProducts_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnProducts_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnProducts_Res.selected = false;
            this.btnProducts_Res.Size = new System.Drawing.Size(230, 48);
            this.btnProducts_Res.TabIndex = 2;
            this.btnProducts_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnProducts_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnOrder_Res
            // 
            this.btnOrder_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnOrder_Res.BackColor = System.Drawing.Color.White;
            this.btnOrder_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrder_Res.BorderRadius = 0;
            this.btnOrder_Res.ButtonText = "     Order/POS";
            this.btnOrder_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnOrder_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnOrder_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnOrder_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOrder_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOrder_Res.Iconimage")));
            this.btnOrder_Res.Iconimage_right = null;
            this.btnOrder_Res.Iconimage_right_Selected = null;
            this.btnOrder_Res.Iconimage_Selected = null;
            this.btnOrder_Res.IconZoom = 70D;
            this.btnOrder_Res.IsTab = false;
            this.btnOrder_Res.Location = new System.Drawing.Point(0, 196);
            this.btnOrder_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnOrder_Res.Name = "btnOrder_Res";
            this.btnOrder_Res.Normalcolor = System.Drawing.Color.White;
            this.btnOrder_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnOrder_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnOrder_Res.selected = false;
            this.btnOrder_Res.Size = new System.Drawing.Size(230, 48);
            this.btnOrder_Res.TabIndex = 3;
            this.btnOrder_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnOrder_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnSales_Res
            // 
            this.btnSales_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnSales_Res.BackColor = System.Drawing.Color.White;
            this.btnSales_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSales_Res.BorderRadius = 0;
            this.btnSales_Res.ButtonText = "     Sales/Expenses";
            this.btnSales_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnSales_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnSales_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSales_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSales_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSales_Res.Iconimage")));
            this.btnSales_Res.Iconimage_right = null;
            this.btnSales_Res.Iconimage_right_Selected = null;
            this.btnSales_Res.Iconimage_Selected = null;
            this.btnSales_Res.IconZoom = 70D;
            this.btnSales_Res.IsTab = false;
            this.btnSales_Res.Location = new System.Drawing.Point(0, 244);
            this.btnSales_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnSales_Res.Name = "btnSales_Res";
            this.btnSales_Res.Normalcolor = System.Drawing.Color.White;
            this.btnSales_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnSales_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSales_Res.selected = false;
            this.btnSales_Res.Size = new System.Drawing.Size(230, 48);
            this.btnSales_Res.TabIndex = 4;
            this.btnSales_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSales_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnTables_Res
            // 
            this.btnTables_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnTables_Res.BackColor = System.Drawing.Color.White;
            this.btnTables_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTables_Res.BorderRadius = 0;
            this.btnTables_Res.ButtonText = "     Manage Tables";
            this.btnTables_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnTables_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnTables_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnTables_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTables_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnTables_Res.Iconimage")));
            this.btnTables_Res.Iconimage_right = null;
            this.btnTables_Res.Iconimage_right_Selected = null;
            this.btnTables_Res.Iconimage_Selected = null;
            this.btnTables_Res.IconZoom = 70D;
            this.btnTables_Res.IsTab = false;
            this.btnTables_Res.Location = new System.Drawing.Point(0, 292);
            this.btnTables_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnTables_Res.Name = "btnTables_Res";
            this.btnTables_Res.Normalcolor = System.Drawing.Color.White;
            this.btnTables_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnTables_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnTables_Res.selected = false;
            this.btnTables_Res.Size = new System.Drawing.Size(230, 48);
            this.btnTables_Res.TabIndex = 5;
            this.btnTables_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnTables_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnEmployees_Res
            // 
            this.btnEmployees_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnEmployees_Res.BackColor = System.Drawing.Color.White;
            this.btnEmployees_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmployees_Res.BorderRadius = 0;
            this.btnEmployees_Res.ButtonText = "     Employees";
            this.btnEmployees_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnEmployees_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnEmployees_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEmployees_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEmployees_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEmployees_Res.Iconimage")));
            this.btnEmployees_Res.Iconimage_right = null;
            this.btnEmployees_Res.Iconimage_right_Selected = null;
            this.btnEmployees_Res.Iconimage_Selected = null;
            this.btnEmployees_Res.IconZoom = 70D;
            this.btnEmployees_Res.IsTab = false;
            this.btnEmployees_Res.Location = new System.Drawing.Point(0, 340);
            this.btnEmployees_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnEmployees_Res.Name = "btnEmployees_Res";
            this.btnEmployees_Res.Normalcolor = System.Drawing.Color.White;
            this.btnEmployees_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnEmployees_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEmployees_Res.selected = false;
            this.btnEmployees_Res.Size = new System.Drawing.Size(230, 48);
            this.btnEmployees_Res.TabIndex = 6;
            this.btnEmployees_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEmployees_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnCustomers_Res
            // 
            this.btnCustomers_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnCustomers_Res.BackColor = System.Drawing.Color.White;
            this.btnCustomers_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomers_Res.BorderRadius = 0;
            this.btnCustomers_Res.ButtonText = "     Customers";
            this.btnCustomers_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnCustomers_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnCustomers_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCustomers_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCustomers_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCustomers_Res.Iconimage")));
            this.btnCustomers_Res.Iconimage_right = null;
            this.btnCustomers_Res.Iconimage_right_Selected = null;
            this.btnCustomers_Res.Iconimage_Selected = null;
            this.btnCustomers_Res.IconZoom = 70D;
            this.btnCustomers_Res.IsTab = false;
            this.btnCustomers_Res.Location = new System.Drawing.Point(0, 388);
            this.btnCustomers_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnCustomers_Res.Name = "btnCustomers_Res";
            this.btnCustomers_Res.Normalcolor = System.Drawing.Color.White;
            this.btnCustomers_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnCustomers_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCustomers_Res.selected = false;
            this.btnCustomers_Res.Size = new System.Drawing.Size(230, 48);
            this.btnCustomers_Res.TabIndex = 7;
            this.btnCustomers_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCustomers_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnAccounts_Res
            // 
            this.btnAccounts_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnAccounts_Res.BackColor = System.Drawing.Color.White;
            this.btnAccounts_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccounts_Res.BorderRadius = 0;
            this.btnAccounts_Res.ButtonText = "     Accounts";
            this.btnAccounts_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnAccounts_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnAccounts_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnAccounts_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAccounts_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAccounts_Res.Iconimage")));
            this.btnAccounts_Res.Iconimage_right = null;
            this.btnAccounts_Res.Iconimage_right_Selected = null;
            this.btnAccounts_Res.Iconimage_Selected = null;
            this.btnAccounts_Res.IconZoom = 70D;
            this.btnAccounts_Res.IsTab = false;
            this.btnAccounts_Res.Location = new System.Drawing.Point(0, 436);
            this.btnAccounts_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccounts_Res.Name = "btnAccounts_Res";
            this.btnAccounts_Res.Normalcolor = System.Drawing.Color.White;
            this.btnAccounts_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnAccounts_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnAccounts_Res.selected = false;
            this.btnAccounts_Res.Size = new System.Drawing.Size(230, 48);
            this.btnAccounts_Res.TabIndex = 8;
            this.btnAccounts_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnAccounts_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnHistory_Res
            // 
            this.btnHistory_Res.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnHistory_Res.BackColor = System.Drawing.Color.White;
            this.btnHistory_Res.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistory_Res.BorderRadius = 0;
            this.btnHistory_Res.ButtonText = "     History";
            this.btnHistory_Res.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnHistory_Res, BunifuAnimatorNS.DecorationType.None);
            this.btnHistory_Res.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnHistory_Res.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHistory_Res.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnHistory_Res.Iconimage")));
            this.btnHistory_Res.Iconimage_right = null;
            this.btnHistory_Res.Iconimage_right_Selected = null;
            this.btnHistory_Res.Iconimage_Selected = null;
            this.btnHistory_Res.IconZoom = 70D;
            this.btnHistory_Res.IsTab = false;
            this.btnHistory_Res.Location = new System.Drawing.Point(0, 484);
            this.btnHistory_Res.Margin = new System.Windows.Forms.Padding(0);
            this.btnHistory_Res.Name = "btnHistory_Res";
            this.btnHistory_Res.Normalcolor = System.Drawing.Color.White;
            this.btnHistory_Res.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnHistory_Res.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnHistory_Res.selected = false;
            this.btnHistory_Res.Size = new System.Drawing.Size(230, 48);
            this.btnHistory_Res.TabIndex = 9;
            this.btnHistory_Res.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnHistory_Res.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // restaurant_nav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_sidemenu);
            this.pnlAnimator.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.MaximumSize = new System.Drawing.Size(230, 660);
            this.MinimumSize = new System.Drawing.Size(48, 660);
            this.Name = "restaurant_nav";
            this.Size = new System.Drawing.Size(230, 660);
            this.pnl_sidemenu.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomPanel customPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMenu;
        private BunifuAnimatorNS.Animator pnlAnimator;
        public CustomFlowPanel pnl_sidemenu;
        public Bunifu.Framework.UI.BunifuFlatButton btnDashboard_Res;
        public Bunifu.Framework.UI.BunifuFlatButton btnProducts_Res;
        public Bunifu.Framework.UI.BunifuFlatButton btnOrder_Res;
        public Bunifu.Framework.UI.BunifuFlatButton btnSales_Res;
        public Bunifu.Framework.UI.BunifuFlatButton btnTables_Res;
        public Bunifu.Framework.UI.BunifuFlatButton btnEmployees_Res;
        public Bunifu.Framework.UI.BunifuFlatButton btnCustomers_Res;
        public Bunifu.Framework.UI.BunifuFlatButton btnAccounts_Res;
        public Bunifu.Framework.UI.BunifuFlatButton btnHistory_Res;
    }
}
