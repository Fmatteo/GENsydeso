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
    public partial class Login_DTR : Form
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

        public Login_DTR()
        {
            InitializeComponent();
        }

        static Login_DTR login; static String result = "";
        public static String _Show()
        {
            login = new Login_DTR();
            login.ShowDialog();
            return result;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            result = ""; this.Close();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUser.Text) && !string.IsNullOrWhiteSpace(txtPass.Text))
            {
                if (db.account_login(txtUser.Text, txtPass.Text))
                {
                    result = txtUser.Text;
                    db.alert("Notification: ", "Login Success", "success");
                    this.Close();
                }
                else
                {
                    db.alert("Error: ", "Invalid Username or Password.\nPlease try again..", "danger");
                }
            }
            else
            {
                db.alert("Error: ", "Please fill up all the required fields to proceed.", "danger");
            }
        }
    }
}
