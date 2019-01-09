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
    public partial class restaurant_category_add : Form
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

        public restaurant_category_add()
        {
            InitializeComponent();
        }

        static restaurant_category_add add; static DialogResult result = DialogResult.No;
        restaurant_helper rh = new restaurant_helper();

        public static DialogResult _Show()
        {
            add = new restaurant_category_add();
            add.ShowDialog();
            return result;
        }

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
                    result = DialogResult.No;
                    this.Close();
                    break;
                default:
                    if (!rh.res_category_exist(txtName.Text))
                    {
                        if (rh.res_category_insert(txtName.Text))
                        {
                            result = DialogResult.Yes; this.Close();
                        }
                    }
                    else
                    {
                        rh.alert("Error: ", "Category already exists.", "danger");
                    }
                    break;
            }
        }
        #endregion

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
    }
}
