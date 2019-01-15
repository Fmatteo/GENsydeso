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
        static String _id = "";
        restaurant_helper rh = new restaurant_helper();

        public static DialogResult _Show(String id)
        {
            reserve = new restaurant_tables_reserve();
            _id = id;
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
            if (datePicker.Value >= DateTime.Now)
                txtDate.Text = datePicker.Value.ToString("MMMM dd, yyyy");
            else
            {
                datePicker.Value = DateTime.Now;
                txtDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            }
        }

        private void cbNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = cbNames.SelectedItem.ToString().Remove(0, 3);
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
                    String name = "";
                    if (cbNames.SelectedIndex >= 0)
                    {
                        name = cbNames.SelectedItem.ToString();
                    }
                    else
                    {
                        name = txtName.Text;
                    }

                    if (rh.res_table_reserve(_id, name, datePicker.Value.ToString("yyyy-MM-dd")))
                    {
                        result = DialogResult.Yes; this.Close();
                    }
                    break;
            }
        }
        #endregion

        private void restaurant_tables_reserve_Load(object sender, EventArgs e)
        {
            List<String> names = rh.res_table_get_customer();

            foreach (var name in names)
            {
                cbNames.Items.Add(name);
            }
        }
    }
}
