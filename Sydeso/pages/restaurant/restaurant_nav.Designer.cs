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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(restaurant_nav));
            this.pnlAnimator = new BunifuAnimatorNS.Animator(this.components);
            this.pnl_sidemenu = new Sydeso.CustomFlowPanel();
            this.customPanel2 = new Sydeso.CustomPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnProducts = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOrder = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSales = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnTables = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEmployees = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCustomers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAccounts = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHistory = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnl_sidemenu.SuspendLayout();
            this.customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAnimator
            // 
            this.pnlAnimator.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.pnlAnimator.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.pnlAnimator.DefaultAnimation = animation1;
            // 
            // pnl_sidemenu
            // 
            this.pnl_sidemenu.BackColor = System.Drawing.Color.White;
            this.pnl_sidemenu.Controls.Add(this.customPanel2);
            this.pnl_sidemenu.Controls.Add(this.btnDashboard);
            this.pnl_sidemenu.Controls.Add(this.btnProducts);
            this.pnl_sidemenu.Controls.Add(this.btnOrder);
            this.pnl_sidemenu.Controls.Add(this.btnSales);
            this.pnl_sidemenu.Controls.Add(this.btnTables);
            this.pnl_sidemenu.Controls.Add(this.btnEmployees);
            this.pnl_sidemenu.Controls.Add(this.btnCustomers);
            this.pnl_sidemenu.Controls.Add(this.btnAccounts);
            this.pnl_sidemenu.Controls.Add(this.btnHistory);
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
            // btnDashboard
            // 
            this.btnDashboard.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDashboard.BorderRadius = 0;
            this.btnDashboard.ButtonText = "     Dashboard";
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnDashboard, BunifuAnimatorNS.DecorationType.None);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDashboard.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Iconimage")));
            this.btnDashboard.Iconimage_right = null;
            this.btnDashboard.Iconimage_right_Selected = null;
            this.btnDashboard.Iconimage_Selected = null;
            this.btnDashboard.IconZoom = 70D;
            this.btnDashboard.IsTab = false;
            this.btnDashboard.Location = new System.Drawing.Point(0, 100);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Normalcolor = System.Drawing.Color.White;
            this.btnDashboard.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnDashboard.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDashboard.selected = false;
            this.btnDashboard.Size = new System.Drawing.Size(230, 48);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnDashboard.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnProducts
            // 
            this.btnProducts.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnProducts.BackColor = System.Drawing.Color.White;
            this.btnProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProducts.BorderRadius = 0;
            this.btnProducts.ButtonText = "     Products";
            this.btnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnProducts, BunifuAnimatorNS.DecorationType.None);
            this.btnProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnProducts.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProducts.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnProducts.Iconimage")));
            this.btnProducts.Iconimage_right = null;
            this.btnProducts.Iconimage_right_Selected = null;
            this.btnProducts.Iconimage_Selected = null;
            this.btnProducts.IconZoom = 70D;
            this.btnProducts.IsTab = false;
            this.btnProducts.Location = new System.Drawing.Point(0, 148);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(0);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Normalcolor = System.Drawing.Color.White;
            this.btnProducts.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnProducts.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnProducts.selected = false;
            this.btnProducts.Size = new System.Drawing.Size(230, 48);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnProducts.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnOrder
            // 
            this.btnOrder.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnOrder.BackColor = System.Drawing.Color.White;
            this.btnOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrder.BorderRadius = 0;
            this.btnOrder.ButtonText = "     Order/POS";
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnOrder, BunifuAnimatorNS.DecorationType.None);
            this.btnOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnOrder.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOrder.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOrder.Iconimage")));
            this.btnOrder.Iconimage_right = null;
            this.btnOrder.Iconimage_right_Selected = null;
            this.btnOrder.Iconimage_Selected = null;
            this.btnOrder.IconZoom = 70D;
            this.btnOrder.IsTab = false;
            this.btnOrder.Location = new System.Drawing.Point(0, 196);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Normalcolor = System.Drawing.Color.White;
            this.btnOrder.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnOrder.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnOrder.selected = false;
            this.btnOrder.Size = new System.Drawing.Size(230, 48);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnOrder.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnSales
            // 
            this.btnSales.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnSales.BackColor = System.Drawing.Color.White;
            this.btnSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSales.BorderRadius = 0;
            this.btnSales.ButtonText = "     Sales/Expenses";
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnSales, BunifuAnimatorNS.DecorationType.None);
            this.btnSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSales.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSales.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSales.Iconimage")));
            this.btnSales.Iconimage_right = null;
            this.btnSales.Iconimage_right_Selected = null;
            this.btnSales.Iconimage_Selected = null;
            this.btnSales.IconZoom = 70D;
            this.btnSales.IsTab = false;
            this.btnSales.Location = new System.Drawing.Point(0, 244);
            this.btnSales.Margin = new System.Windows.Forms.Padding(0);
            this.btnSales.Name = "btnSales";
            this.btnSales.Normalcolor = System.Drawing.Color.White;
            this.btnSales.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnSales.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSales.selected = false;
            this.btnSales.Size = new System.Drawing.Size(230, 48);
            this.btnSales.TabIndex = 4;
            this.btnSales.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSales.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnTables
            // 
            this.btnTables.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnTables.BackColor = System.Drawing.Color.White;
            this.btnTables.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTables.BorderRadius = 0;
            this.btnTables.ButtonText = "     Manage Tables";
            this.btnTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnTables, BunifuAnimatorNS.DecorationType.None);
            this.btnTables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnTables.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTables.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnTables.Iconimage")));
            this.btnTables.Iconimage_right = null;
            this.btnTables.Iconimage_right_Selected = null;
            this.btnTables.Iconimage_Selected = null;
            this.btnTables.IconZoom = 70D;
            this.btnTables.IsTab = false;
            this.btnTables.Location = new System.Drawing.Point(0, 292);
            this.btnTables.Margin = new System.Windows.Forms.Padding(0);
            this.btnTables.Name = "btnTables";
            this.btnTables.Normalcolor = System.Drawing.Color.White;
            this.btnTables.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnTables.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnTables.selected = false;
            this.btnTables.Size = new System.Drawing.Size(230, 48);
            this.btnTables.TabIndex = 5;
            this.btnTables.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnTables.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnEmployees.BackColor = System.Drawing.Color.White;
            this.btnEmployees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmployees.BorderRadius = 0;
            this.btnEmployees.ButtonText = "     Employees";
            this.btnEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnEmployees, BunifuAnimatorNS.DecorationType.None);
            this.btnEmployees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEmployees.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEmployees.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEmployees.Iconimage")));
            this.btnEmployees.Iconimage_right = null;
            this.btnEmployees.Iconimage_right_Selected = null;
            this.btnEmployees.Iconimage_Selected = null;
            this.btnEmployees.IconZoom = 70D;
            this.btnEmployees.IsTab = false;
            this.btnEmployees.Location = new System.Drawing.Point(0, 340);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Normalcolor = System.Drawing.Color.White;
            this.btnEmployees.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnEmployees.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEmployees.selected = false;
            this.btnEmployees.Size = new System.Drawing.Size(230, 48);
            this.btnEmployees.TabIndex = 6;
            this.btnEmployees.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEmployees.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnCustomers.BackColor = System.Drawing.Color.White;
            this.btnCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomers.BorderRadius = 0;
            this.btnCustomers.ButtonText = "     Customers";
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnCustomers, BunifuAnimatorNS.DecorationType.None);
            this.btnCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCustomers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCustomers.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCustomers.Iconimage")));
            this.btnCustomers.Iconimage_right = null;
            this.btnCustomers.Iconimage_right_Selected = null;
            this.btnCustomers.Iconimage_Selected = null;
            this.btnCustomers.IconZoom = 70D;
            this.btnCustomers.IsTab = false;
            this.btnCustomers.Location = new System.Drawing.Point(0, 388);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(0);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Normalcolor = System.Drawing.Color.White;
            this.btnCustomers.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnCustomers.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCustomers.selected = false;
            this.btnCustomers.Size = new System.Drawing.Size(230, 48);
            this.btnCustomers.TabIndex = 7;
            this.btnCustomers.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnCustomers.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnAccounts
            // 
            this.btnAccounts.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnAccounts.BackColor = System.Drawing.Color.White;
            this.btnAccounts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccounts.BorderRadius = 0;
            this.btnAccounts.ButtonText = "     Accounts";
            this.btnAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnAccounts, BunifuAnimatorNS.DecorationType.None);
            this.btnAccounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnAccounts.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAccounts.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAccounts.Iconimage")));
            this.btnAccounts.Iconimage_right = null;
            this.btnAccounts.Iconimage_right_Selected = null;
            this.btnAccounts.Iconimage_Selected = null;
            this.btnAccounts.IconZoom = 70D;
            this.btnAccounts.IsTab = false;
            this.btnAccounts.Location = new System.Drawing.Point(0, 436);
            this.btnAccounts.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Normalcolor = System.Drawing.Color.White;
            this.btnAccounts.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnAccounts.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnAccounts.selected = false;
            this.btnAccounts.Size = new System.Drawing.Size(230, 48);
            this.btnAccounts.TabIndex = 8;
            this.btnAccounts.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnAccounts.TextFont = new System.Drawing.Font("Calibri", 12F);
            // 
            // btnHistory
            // 
            this.btnHistory.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.btnHistory.BackColor = System.Drawing.Color.White;
            this.btnHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistory.BorderRadius = 0;
            this.btnHistory.ButtonText = "     History";
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnimator.SetDecoration(this.btnHistory, BunifuAnimatorNS.DecorationType.None);
            this.btnHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnHistory.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHistory.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnHistory.Iconimage")));
            this.btnHistory.Iconimage_right = null;
            this.btnHistory.Iconimage_right_Selected = null;
            this.btnHistory.Iconimage_Selected = null;
            this.btnHistory.IconZoom = 70D;
            this.btnHistory.IsTab = false;
            this.btnHistory.Location = new System.Drawing.Point(0, 484);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Normalcolor = System.Drawing.Color.White;
            this.btnHistory.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(252)))), ((int)(((byte)(246)))));
            this.btnHistory.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnHistory.selected = false;
            this.btnHistory.Size = new System.Drawing.Size(230, 48);
            this.btnHistory.TabIndex = 9;
            this.btnHistory.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnHistory.TextFont = new System.Drawing.Font("Calibri", 12F);
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
        public Bunifu.Framework.UI.BunifuFlatButton btnDashboard;
        public Bunifu.Framework.UI.BunifuFlatButton btnProducts;
        public Bunifu.Framework.UI.BunifuFlatButton btnOrder;
        public Bunifu.Framework.UI.BunifuFlatButton btnSales;
        public Bunifu.Framework.UI.BunifuFlatButton btnTables;
        public Bunifu.Framework.UI.BunifuFlatButton btnEmployees;
        public Bunifu.Framework.UI.BunifuFlatButton btnCustomers;
        public Bunifu.Framework.UI.BunifuFlatButton btnAccounts;
        public Bunifu.Framework.UI.BunifuFlatButton btnHistory;
    }
}
