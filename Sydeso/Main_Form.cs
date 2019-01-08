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

        database_helper db = new database_helper();
        speech_helper speech = new speech_helper();
        List<Object> config;
        List<String> account_details;
        private String _user;

        public Main_Form()
        {
            #region Initialize Wizard
            if (!db.setup()) // If hasn't setup yet
            {
                if (Wizard._Show() == DialogResult.No)
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

            #region Navigation

            config = db.get_setup_config();

            switch (config[4].ToString())
            {
                case "Restaurant":
                    restaurant_nav res_nav = new restaurant_nav();
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

        private void Menu_Item_Click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            MessageBox.Show(c.Name);
        }
    }
}
