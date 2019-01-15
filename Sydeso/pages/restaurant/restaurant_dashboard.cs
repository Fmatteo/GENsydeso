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
    public partial class restaurant_dashboard : Form
    {
        restaurant_helper rh = new restaurant_helper();
        public restaurant_dashboard()
        {
            InitializeComponent();

            lblTableAvailable.Text = rh.FormatLabel(rh.res_table_available()) + "/" + rh.FormatLabel(rh.res_table_count());
            lblTableReserved.Text = rh.FormatLabel(rh.res_table_reserved()) + "/" + rh.FormatLabel(rh.res_table_count());
            lblReorder.Text = rh.FormatLabel(rh.res_stock_reorder());
            lblNoStock.Text = rh.FormatLabel(rh.res_stock_empty());

            String sales = rh.res_sales_today();
            if (string.IsNullOrWhiteSpace(sales))
                lblSales.Text = rh.hookDecimal("0");
            else
                lblSales.Text = rh.hookDecimal(sales);

            RefreshLabel();
        }

        private void RefreshLabel()
        {
            foreach (Control c in this.Controls)
                if (c is CustomPanel)
                    foreach (Control d in c.Controls)
                        if (d is Label)
                            d.Left = c.Width - d.Width;
        }
    }
}
