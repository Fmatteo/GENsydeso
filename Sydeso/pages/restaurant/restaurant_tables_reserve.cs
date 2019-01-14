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
    public partial class restaurant_tables_reserve : Form
    {
        public restaurant_tables_reserve()
        {
            InitializeComponent();
        }

        static restaurant_tables_reserve reserve; static DialogResult result = DialogResult.No;

        public static DialogResult _Show(String id)
        {
            reserve = new restaurant_tables_reserve();
            reserve.ShowDialog();
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

        #region Functions
        private void txtDate_Enter(object sender, EventArgs e)
        {
            datePicker.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            datePicker.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            txtDate.Text = datePicker.Value.ToString("MMMM dd, yyyy");
        }

        private void cbNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = cbNames.SelectedItem.ToString();
        }

        private void button_click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnExit":
                case "btnNo":
                    result = DialogResult.No; this.Close();
                    break;
                default:
                    result = DialogResult.Yes; this.Close();
                    break;
            }
        } 
        #endregion
    }
}
