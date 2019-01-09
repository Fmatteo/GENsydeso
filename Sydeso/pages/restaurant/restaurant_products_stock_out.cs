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
    public partial class restaurant_products_stock_out : Form
    {
        public restaurant_products_stock_out()
        {
            InitializeComponent();
        }

        static restaurant_products_stock_out stock; static DialogResult result = DialogResult.No;
        restaurant_helper rh = new restaurant_helper();
        private static String _id, _name, _price;

        public static DialogResult _Show(String id, String name, String price)
        {
            stock = new restaurant_products_stock_out();
            _id = id;
            _name = name;
            _price = price;
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
                    if (!string.IsNullOrWhiteSpace(txtQty.Text))
                    {
                        if (cbRemark.SelectedIndex >= 0)
                        {
                            double total;
                            total = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(_price);

                            if (rh.res_product_stock_out(_id, _name, txtQty.Text, _price, total.ToString(), cbRemark.SelectedItem.ToString()))
                            {
                                result = DialogResult.Yes; this.Close();
                            }
                        }
                        else
                        {
                            rh.alert("Notification: ", "Please include a remarks.", "information");
                        }
                    }
                    else
                        rh.alert("Error: ", "Please specify the number of items you wish to stock out.", "danger");
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
