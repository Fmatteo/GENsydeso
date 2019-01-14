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
    public partial class restaurant_tables_update : Form
    {
        public restaurant_tables_update()
        {
            InitializeComponent();
        }

        static restaurant_tables_update update; static DialogResult result = DialogResult.No;
        static restaurant_helper rh = new restaurant_helper();
        static List<String> table_detail;

        public static DialogResult _Show(String id)
        {
            update = new restaurant_tables_update();
            table_detail = rh.res_table_read_id(id);
            update.txtName.Text = table_detail[1];
            update.txtDesc.Text = table_detail[2];
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
        private void button_click(Object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnExit":
                case "btnNo":
                    result = DialogResult.No; this.Close();
                    break;

                default:
                    if (rh.res_table_update(table_detail[0], txtName.Text, txtDesc.Text))
                        result = DialogResult.Yes; this.Close();
                    break;
            }
        }
        #endregion
    }
}
