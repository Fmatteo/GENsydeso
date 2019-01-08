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
    public partial class restaurant_products : Form
    {
        public restaurant_products()
        {
            InitializeComponent();
        }

        private void restaurant_products_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("Name");

            dt.Rows.Add(new Object[] {
                "1", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            dt.Rows.Add(new Object[] {
                "2", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            dt.Rows.Add(new Object[] {
                "3", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            dt.Rows.Add(new Object[] {
                "3", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            dt.Rows.Add(new Object[] {
                "3", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            dt.Rows.Add(new Object[] {
                "3", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            dt.Rows.Add(new Object[] {
                "3", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            dt.Rows.Add(new Object[] {
                "3", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            dt.Rows.Add(new Object[] {
                "3", "@mingjoshua", "password", "Joshua Ming Ricohermoso"
            });

            cbEntries.SelectedIndex = 0;

            dataGridView1.DataSource = dt;
        }
    }
}
