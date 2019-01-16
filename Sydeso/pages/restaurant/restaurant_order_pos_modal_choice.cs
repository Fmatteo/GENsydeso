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
    public partial class restaurant_order_pos_modal_choice : Form
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

        static restaurant_order_pos_modal_choice modal; static String value = "";
        static String _total;

        public static String _Show(String total)
        {
            modal = new restaurant_order_pos_modal_choice();
            _total = total;
            modal.ShowDialog();
            return value;
        }

        public restaurant_order_pos_modal_choice()
        {
            InitializeComponent();
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

        private void button_click(object sender, EventArgs e)
        {
            Control c = sender as Control;
            switch (c.Name)
            {
                case "btnComplete":
                    value = restaurant_order_pos_modal_cash._Show(_total);
                    break;
                default:
                    value = c.Text;
                    break;
            }

            this.Close();
        }
    }
}
