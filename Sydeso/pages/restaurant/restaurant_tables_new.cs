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
    public partial class restaurant_tables_new : Form
    {
        public restaurant_tables_new()
        {
            InitializeComponent();
        }

        static restaurant_tables_new add; static DialogResult result = DialogResult.No;
        restaurant_helper rh = new restaurant_helper();

        public static DialogResult _Show()
        {
            add = new restaurant_tables_new();
            add.ShowDialog();
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
                    if (rh.res_table_create(txtName.Text, txtDesc.Text))
                        result = DialogResult.Yes; this.Close();
                    break;
            }
        } 
        #endregion
    }
}
