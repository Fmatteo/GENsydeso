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
    public partial class restaurant_order_pos_modal_name : Form
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

        restaurant_helper rh = new restaurant_helper();
        static restaurant_order_pos_modal_name modal; static String name = "WALK-IN";

        public static String _Show()
        {
            modal = new restaurant_order_pos_modal_name();
            modal.ShowDialog();
            return name;
        }

        public restaurant_order_pos_modal_name()
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

        private void cbNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = cbNames.SelectedItem.ToString().Remove(0, 3);
        }

        private void restaurant_order_pos_modal_name_Load(object sender, EventArgs e)
        {
            List<String> names = rh.res_table_get_customer();

            foreach (var name in names)
            {
                cbNames.Items.Add(name);
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (cbNames.SelectedIndex >= 0)
            {
                name = cbNames.SelectedItem.ToString();
            }
            else
            {
                name = txtName.Text;
            }

            this.Close();
        }
    }
}
