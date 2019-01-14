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
    }
}
