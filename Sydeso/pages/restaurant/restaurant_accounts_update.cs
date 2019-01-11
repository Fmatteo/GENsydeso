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
    public partial class restaurant_accounts_update : Form
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

        public restaurant_accounts_update()
        {
            InitializeComponent();
        }

        static restaurant_accounts_update update; static DialogResult result = DialogResult.No;
        static restaurant_helper rh = new restaurant_helper();
        private static List<String> acc;
        private static List<Boolean> priv;

        public static DialogResult _Show(String id)
        {
            update = new restaurant_accounts_update();
            acc = rh.account_details_by_id(id);
            priv = rh.account_privileges_detail(id);

            update.txtFname.Text = acc[1];
            update.txtLname.Text = acc[2];
            update.txtUser.Text = acc[3];

            update.cbDash.Checked = priv[0];
            update.cbProd.Checked = priv[1];
            update.cbOrder.Checked = priv[2];
            update.cbSales.Checked = priv[3];
            update.cbTables.Checked = priv[4];
            update.cbEmp.Checked = priv[5];
            update.cbCust.Checked = priv[6];
            update.cbAcc.Checked = priv[7];
            update.cbHis.Checked = priv[8];

            update.ShowDialog();
            return result;
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

        #region Button Logics
        private void button_click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnExit":
                    result = DialogResult.No; this.Close();
                    break;

                case "btnYes":
                    if (!string.IsNullOrWhiteSpace(txtUser.Text))
                    {
                        if (rh.account_update(acc[0], txtFname.Text, txtLname.Text, txtUser.Text, txtPass.Text))
                        {
                            if (rh.account_update_privileges(acc[0], cbDash.Checked, cbProd.Checked, cbOrder.Checked, cbSales.Checked, cbTables.Checked, cbEmp.Checked, cbCust.Checked, cbAcc.Checked, cbHis.Checked))
                            {
                                result = DialogResult.Yes; this.Close();
                            }
                        }
                        else
                        {
                            txtUser.Focus();
                            rh.alert("Error: ", "Username already taken.\nPlease pick another one.", "danger");
                        }
                    }
                    break;

                case "btnNo":
                    result = DialogResult.No; this.Close();
                    break;
            }
        }
        #endregion

        #region Text Password Logics
        private void textbox_textchanged(object sender, EventArgs e)
        {
            Control c = sender as Control;

            if (!string.IsNullOrWhiteSpace(c.Text))
                pbEye.Visible = true;
            else
                pbEye.Visible = false;
        }

        private void pbEye_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '•')
            {
                txtPass.PasswordChar = '\0';
                pbEye.Image = Image.FromFile(Application.StartupPath + "/icons/icon_show_red.png");
            }
            else
            {
                txtPass.PasswordChar = '•';
                pbEye.Image = Image.FromFile(Application.StartupPath + "/icons/icon_hide_red.png");
            }
        }
        #endregion
    }
}
