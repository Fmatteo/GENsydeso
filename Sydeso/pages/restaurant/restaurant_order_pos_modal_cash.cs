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
    public partial class restaurant_order_pos_modal_cash : Form
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

        public restaurant_order_pos_modal_cash()
        {
            InitializeComponent();
        }

        static restaurant_order_pos_modal_cash modal; static String value = "";
        public static String _Show(String total)
        {
            modal = new restaurant_order_pos_modal_cash();
            modal.txtAmountDue.Text = total;
            modal.ShowDialog();
            return value;
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

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtCashTendered.Text) >= Convert.ToDouble(txtAmountDue.Text))
            {
                value = txtCashTendered.Text; this.Close();
            }
        }

        private void txtCashTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control c = sender as Control;
            if ((!char.IsDigit(e.KeyChar) || c.Text.Length >= 11) && (e.KeyChar != 8) && (e.KeyChar != '.' || c.Text.Contains(".")))
                e.Handled = true;
        }

        double cash = 0;

        private void txtCashTendered_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCashTendered.Text))
                cash = Convert.ToDouble(txtCashTendered.Text);
            else
                cash = 0;

            ComputeChange();
        }

        private void ComputeChange()
        {
            restaurant_helper rh = new restaurant_helper();
            txtCashChange.Text = rh.hookDecimal((cash - Convert.ToDouble(txtAmountDue.Text)).ToString());
        }
    }
}
