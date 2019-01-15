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
    public partial class restaurant_order_pos : Form
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

        public restaurant_order_pos()
        {
            InitializeComponent();

            LoadTable("", "ALL");
            InitializeCategory();
        }

        restaurant_helper rh = new restaurant_helper();

        private void restaurant_order_pos_Load(object sender, EventArgs e)
        {
            cbCat.SelectedIndex = 0;
        }

        #region LoadTable

        private void LoadTable(String search, String cat)
        {
            pnl_items.Controls.Clear();
            List<restaurant_prod_detail> list = rh.res_pos_get_prod(search, cat);

            if (list.Count >= 7)
            {
                if (pnl_items.Width != pnl_items.MaximumSize.Width)
                {
                    pnl_receipt.Width -= 15;
                    pnl_total.Width -= 15;
                    pnl_items.Width += 15;
                    pnl_items.Left -= 15;
                    pnl_header.Width += 15;
                    pnl_header.Left -= 15;
                }
            }
            else
            {
                if (pnl_items.Width == pnl_items.MaximumSize.Width)
                {
                    pnl_items.Left += 15;
                    pnl_items.Width -= 15;
                    pnl_header.Left += 15;
                    pnl_header.Width -= 15;

                    pnl_receipt.Width += 15;
                    pnl_total.Width += 15;
                }
            }

            int count = 0, offSetX = 0, offSetY = 1;
            for (int i = 0; i < list.Count; i++)
            {
                count++;

                list[i].Location = new Point(offSetX, offSetY);

                foreach (Control c in list[i].Controls)
                {
                    c.Click += product_click;
                    foreach(Control d in c.Controls)
                        d.Click += product_click;
                }

                this.pnl_items.Controls.Add(list[i]);
                offSetX += list[i].Width + 1;

                if (count == 3)
                {
                    count = 0;
                    offSetX = 0;
                    offSetY += list[i].Height + 1;
                }
            }

            pnl_items.AutoScroll = false;
            pnl_items.HorizontalScroll.Enabled = false;
            pnl_items.HorizontalScroll.Visible = false;
            pnl_items.HorizontalScroll.Maximum = 0;
            pnl_items.AutoScroll = true;
        }

        private String _id, _name, _price, _qty, _total;

        private void product_click(object sender, EventArgs e)
        {
            Control c = sender as Control;
            Control d = c.Parent;

            try
            {
                restaurant_prod_detail a = d.Parent as restaurant_prod_detail;

                _id = a.Product_ID.ToString();
                _name = a.Product_Name;
                _price = a.Product_Price;
                _qty = "1";
                _total = a.Product_Price;
            }
            catch (Exception)
            {
                restaurant_prod_detail a = c.Parent as restaurant_prod_detail;

                _id = a.Product_ID.ToString();
                _name = a.Product_Name;
                _price = a.Product_Price;
                _qty = "1";
                _total = a.Product_Price;
            }

            bool found = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ID"].Value.ToString() == _id)
                {
                    found = true;
                    row.Cells["Qty"].Value = Convert.ToInt32(row.Cells["Qty"].Value) + 1;
                    row.Cells["Total"].Value = rh.hookDecimal(rh.FormatLabel1(Convert.ToDouble(row.Cells["Qty"].Value) * Convert.ToDouble(row.Cells["Price"].Value)));
                }
            }

            if (!found)
            {
                dataGridView1.Rows.Add(new Object[] {
                    _id, _name, rh.hookDecimal(rh.FormatLabel1(Convert.ToDouble(_price))), _qty, rh.hookDecimal(rh.FormatLabel1(Convert.ToDouble(_total)))
                });
            }
        }

        #endregion

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
                LoadTable(c.Text, cbCat.SelectedItem.ToString());
            else
                LoadTable("", cbCat.SelectedItem.ToString());
            c.SelectionStart = c.Text.Length;
        }
        #endregion

        private void cbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable("", cbCat.SelectedItem.ToString());
        }

        private void InitializeCategory()
        {
            List<String> cats = rh.res_category_view();

            foreach (var cat in cats)
            {
                cbCat.Items.Add(cat);
            }
        }
    }
}
