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
    public partial class restaurant_products_stock_in : Form
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

        public restaurant_products_stock_in()
        {
            InitializeComponent();
        }

        static restaurant_products_stock_in stock; static DialogResult result = DialogResult.No;
        restaurant_helper rh = new restaurant_helper();

        public static DialogResult _Show(String id)
        {
            stock = new restaurant_products_stock_in();
            stock.label.Text += id;
            stock.ShowDialog();
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
                case "btnNo":
                    result = DialogResult.No; this.Close();
                    break;
                default:
                    String qty = "0";
                    if (!string.IsNullOrWhiteSpace(txtQty.Text))
                        qty = txtQty.Text;

                    if (rh.res_product_stock_in(label.Text[label.Text.Length - 1].ToString(), qty))
                    {
                        result = DialogResult.Yes; this.Close();
                    }
                    break;
            }
        } 
        #endregion

        #region Data Validations
        private void textbox_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        } 
        #endregion
    }
}
