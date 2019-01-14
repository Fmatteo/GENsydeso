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
    public partial class restaurant_tables_reservation : Form
    {
        public restaurant_tables_reservation()
        {
            InitializeComponent();
        }

        restaurant_helper rh = new restaurant_helper();

        private void restaurant_tables_reservation_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rh.res_table_get_reservation("");
        }

        #region Placeholder Logics
        private void placeholder_keydown(object sender, KeyEventArgs e)
        {
            TextBox c = sender as TextBox;
            if (c.Text == "  SEARCH")
                c.Text = "";
        }

        private void placeholder_keyup(object sender, KeyEventArgs e)
        {
            TextBox c = sender as TextBox;
            if (string.IsNullOrWhiteSpace(c.Text))
                c.Text = "  SEARCH";

            if (c.Text != "  SEARCH")
                dataGridView1.DataSource = rh.res_table_get_reservation(c.Text);
            else
                dataGridView1.DataSource = rh.res_table_get_reservation("");
            c.SelectionStart = c.Text.Length;
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
