using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sydeso
{
    public partial class Main_Form : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        #region Variables
        database_helper db = new database_helper();
        speech_helper speech = new speech_helper();
        List<Object> config;
        List<String> account_details;
        private String _user;
        restaurant_nav res_nav = new restaurant_nav();
        #endregion

        public Main_Form()
        {
            #region Initialize Wizard
            if (!db.setup()) // If hasn't setup yet
            {
                String wizard = Wizard._Show();

                if (string.IsNullOrWhiteSpace(wizard))
                {
                    Environment.Exit(0);
                }
            }
            #endregion
            #region Initialize Login

            _user = Login_DTR._Show();
            if (string.IsNullOrWhiteSpace(_user))
            {
                Environment.Exit(0);
            }
            else
            {
                account_details = db.account_details(_user);
                speech.Speak("Good day! Welcome " + account_details[1] + " " + account_details[2] + ". Have a nice day!");
            }

            #endregion

            InitializeComponent();

            #region Initialize Navigation

            config = db.get_setup_config();

            switch (config[4].ToString())
            {
                case "Restaurant":
                    res_nav.Parent = this;
                    res_nav.Dock = DockStyle.Left;
                    res_nav.BringToFront();
                    res_nav.Show();

                    foreach (Control c in res_nav.pnl_sidemenu.Controls)
                    {
                        c.Click += Menu_Item_Click;
                    }

                    break;
                default:
                    break;
            }
            this.pnl_content.BringToFront();
            #endregion

            // Loads the icon..
            if (config[5].ToString() != "") // Check if there is an icon saved..
                pbIcon.Image = (Image)config[5];
        }

        #region Draggable
        private bool move;
        private Point lastPoint;
        private void pnl_toolbar_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            lastPoint = e.Location;
        }

        private void pnl_toolbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.Location = new Point((this.Location.X - lastPoint.X) + e.X, (this.Location.Y - lastPoint.Y) + e.Y);
            }
        }

        private void pnl_toolbar_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        } 
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Initialize Dashboard

        /// <summary>
        /// Sets dashboard(default page) depending on the chosen business type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Form_Load(object sender, EventArgs e)
        {
            switch (config[4].ToString())
            {
                case "Restaurant":
                    if (res_dash == null)
                    {
                        res_dash = new restaurant_dashboard();
                        res_dash.TopLevel = false;
                        res_dash.Parent = this.pnl_content;
                        res_dash.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        res_dash.FormClosed += Res_dash_FormClosed;
                        res_dash.Show();
                        res_nav.btnDashboard_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Page(s) Variables

        restaurant_dashboard res_dash = null;
        restaurant_products res_prod = null;
        restaurant_order_pos res_order = null;
        restaurant_sales_expenses res_sales = null;
        restaurant_tables res_tables = null;
        restaurant_employees res_emp = null;
        restaurant_customers res_cust = null;
        restaurant_accounts res_acc = null;
        restaurant_history res_hist = null;

        #endregion

        private void Menu_Item_Click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                #region Restaurant Pages
                case "btnDashboard_Res":
                    if (res_prod != null)
                        res_prod.Close();
                    if (res_order != null)
                        res_order.Close();
                    if (res_sales != null)
                        res_sales.Close();
                    if (res_tables != null)
                        res_tables.Close();
                    if (res_cust != null)
                        res_cust.Close();
                    if (res_acc != null)
                        res_acc.Close();
                    if (res_hist != null)
                        res_hist.Close();
                    if (res_emp != null)
                        res_emp.Close();

                    if (res_dash == null)
                    {
                        res_dash = new restaurant_dashboard();
                        res_dash.TopLevel = false;
                        res_dash.Parent = this.pnl_content;
                        res_dash.FormClosed += Res_dash_FormClosed;
                        res_dash.Left = (this.pnl_content.Width - res_dash.Width) / 2;
                        res_dash.Show();
                        res_nav.btnDashboard_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                case "btnProducts_Res":
                    if (res_order != null)
                        res_order.Close();
                    if (res_sales != null)
                        res_sales.Close();
                    if (res_tables != null)
                        res_tables.Close();
                    if (res_cust != null)
                        res_cust.Close();
                    if (res_acc != null)
                        res_acc.Close();
                    if (res_hist != null)
                        res_hist.Close();
                    if (res_dash != null)
                        res_dash.Close();
                    if (res_emp != null)
                        res_emp.Close();

                    if (res_prod == null)
                    {
                        res_prod = new restaurant_products();
                        res_prod.TopLevel = false;
                        res_prod.Parent = this.pnl_content;
                        res_prod.FormClosed += Res_prod_FormClosed;
                        res_prod.Width = this.pnl_content.Width;
                        res_prod.Show();
                        res_nav.btnProducts_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                case "btnOrder_Res":
                    if (res_prod != null)
                        res_prod.Close();
                    if (res_sales != null)
                        res_sales.Close();
                    if (res_tables != null)
                        res_tables.Close();
                    if (res_cust != null)
                        res_cust.Close();
                    if (res_acc != null)
                        res_acc.Close();
                    if (res_hist != null)
                        res_hist.Close();
                    if (res_dash != null)
                        res_dash.Close();
                    if (res_emp != null)
                        res_emp.Close();

                    if (res_order == null)
                    {
                        res_order = new restaurant_order_pos(); ;
                        res_order.TopLevel = false;
                        res_order.Parent = this.pnl_content;
                        res_order.FormClosed += Res_order_FormClosed;
                        res_order.Show();
                        res_nav.btnOrder_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                case "btnSales_Res":
                    if (res_prod != null)
                        res_prod.Close();
                    if (res_order != null)
                        res_order.Close();
                    if (res_tables != null)
                        res_tables.Close();
                    if (res_cust != null)
                        res_cust.Close();
                    if (res_acc != null)
                        res_acc.Close();
                    if (res_hist != null)
                        res_hist.Close();
                    if (res_dash != null)
                        res_dash.Close();
                    if (res_emp != null)
                        res_emp.Close();

                    if (res_sales == null)
                    {
                        res_sales = new restaurant_sales_expenses();
                        res_sales.TopLevel = false;
                        res_sales.Parent = this.pnl_content;
                        res_sales.FormClosed += Res_sales_FormClosed;
                        res_sales.Show();
                        res_nav.btnSales_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                case "btnTables_Res":
                    if (res_prod != null)
                        res_prod.Close();
                    if (res_order != null)
                        res_order.Close();
                    if (res_sales != null)
                        res_sales.Close();
                    if (res_cust != null)
                        res_cust.Close();
                    if (res_acc != null)
                        res_acc.Close();
                    if (res_hist != null)
                        res_hist.Close();
                    if (res_dash != null)
                        res_dash.Close();
                    if (res_emp != null)
                        res_emp.Close();

                    if (res_tables == null)
                    {
                        res_tables = new restaurant_tables();
                        res_tables.TopLevel = false;
                        res_tables.Parent = this.pnl_content;
                        res_tables.FormClosed += Res_tables_FormClosed;
                        res_tables.Show();
                        res_nav.btnTables_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                case "btnEmployees_Res":
                    if (res_prod != null)
                        res_prod.Close();
                    if (res_order != null)
                        res_order.Close();
                    if (res_sales != null)
                        res_sales.Close();
                    if (res_tables != null)
                        res_tables.Close();
                    if (res_cust != null)
                        res_cust.Close();
                    if (res_acc != null)
                        res_acc.Close();
                    if (res_hist != null)
                        res_hist.Close();
                    if (res_dash != null)
                        res_dash.Close();

                    if (res_emp == null)
                    {
                        res_emp = new restaurant_employees();
                        res_emp.TopLevel = false;
                        res_emp.Parent = this.pnl_content;
                        res_emp.FormClosed += Res_emp_FormClosed;
                        res_emp.Show();
                        res_nav.btnEmployees_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                case "btnCustomers_Res":
                    if (res_prod != null)
                        res_prod.Close();
                    if (res_order != null)
                        res_order.Close();
                    if (res_sales != null)
                        res_sales.Close();
                    if (res_tables != null)
                        res_tables.Close();
                    if (res_acc != null)
                        res_acc.Close();
                    if (res_hist != null)
                        res_hist.Close();
                    if (res_dash != null)
                        res_dash.Close();
                    if (res_emp != null)
                        res_emp.Close();

                    if (res_cust == null)
                    {
                        res_cust = new restaurant_customers();
                        res_cust.TopLevel = false;
                        res_cust.Parent = this.pnl_content;
                        res_cust.FormClosed += Res_cust_FormClosed;
                        res_cust.Show();
                        res_nav.btnCustomers_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                case "btnAccounts_Res":
                    if (res_prod != null)
                        res_prod.Close();
                    if (res_order != null)
                        res_order.Close();
                    if (res_sales != null)
                        res_sales.Close();
                    if (res_tables != null)
                        res_tables.Close();
                    if (res_cust != null)
                        res_cust.Close();
                    if (res_hist != null)
                        res_hist.Close();
                    if (res_dash != null)
                        res_dash.Close();
                    if (res_emp != null)
                        res_emp.Close();

                    if (res_acc == null)
                    {
                        res_acc = new restaurant_accounts();
                        res_acc.TopLevel = false;
                        res_acc.Parent = this.pnl_content;
                        res_acc.FormClosed += Res_acc_FormClosed;
                        res_acc.Show();
                        res_nav.btnAccounts_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break;
                case "btnHistory_Res":
                    if (res_prod != null)
                        res_prod.Close();
                    if (res_order != null)
                        res_order.Close();
                    if (res_sales != null)
                        res_sales.Close();
                    if (res_tables != null)
                        res_tables.Close();
                    if (res_cust != null)
                        res_cust.Close();
                    if (res_acc != null)
                        res_acc.Close();
                    if (res_dash != null)
                        res_dash.Close();
                    if (res_emp != null)
                        res_emp.Close();

                    if (res_hist == null)
                    {
                        res_hist = new restaurant_history();
                        res_hist.TopLevel = false;
                        res_hist.Parent = this.pnl_content;
                        res_hist.FormClosed += Res_hist_FormClosed;
                        res_hist.Show();
                        res_nav.btnHistory_Res.Normalcolor = Color.FromArgb(233, 233, 233);
                    }
                    break; 
                #endregion
                default:
                    break;
            }
        }

        #region Restaurant Pages
        private void Res_hist_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnHistory_Res.Normalcolor = Color.White;
            res_hist = null;
        }

        private void Res_acc_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnAccounts_Res.Normalcolor = Color.White;
            res_acc = null;
        }

        private void Res_cust_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnCustomers_Res.Normalcolor = Color.White;
            res_cust = null;
        }

        private void Res_emp_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnEmployees_Res.Normalcolor = Color.White;
            res_emp = null;
        }

        private void Res_tables_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnTables_Res.Normalcolor = Color.White;
            res_tables = null;
        }

        private void Res_sales_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnSales_Res.Normalcolor = Color.White;
            res_sales = null;
        }

        private void Res_order_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnOrder_Res.Normalcolor = Color.White;
            res_order = null;
        }

        private void Res_prod_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnProducts_Res.Normalcolor = Color.White;
            res_prod = null;
        }

        private void Res_dash_FormClosed(object sender, FormClosedEventArgs e)
        {
            res_nav.btnDashboard_Res.Normalcolor = Color.White;
            res_dash = null;
        } 
        #endregion

        private void pnl_content_SizeChanged(object sender, EventArgs e)
        {
            if (res_dash != null)
            {
                res_dash.Left = (this.pnl_content.Width - res_dash.Width) / 2;
            }

            if (res_prod != null)
            {
                res_prod.Width = this.pnl_content.Width;
            }
        }

        #region Voice Command
        private bool voice;
        private void btnToggleVoiceCommand_Click(object sender, EventArgs e)
        {
            if (!voice)
            {
                voice = true;
                btnToggleVoiceCommand.Image = Image.FromFile(Application.StartupPath + "/icons/icon_mic_on.png");

                speech.CancelSpeaking();
                speech.Speak("Voice command activated.");

                speech.StartRecognizing(account_details);
            }
            else
            {
                voice = false;
                btnToggleVoiceCommand.Image = Image.FromFile(Application.StartupPath + "/icons/icon_mic_off.png");

                speech.CancelSpeaking();
                speech.Speak("Voice command de-activated.");

                speech.StopRecognizing();
            }
        }
        #endregion
    }
}
