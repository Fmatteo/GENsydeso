using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        String customer = "", cash_tendered = "";
        private List<String> acc_detail;

        public restaurant_order_pos(String user)
        {
            this.acc_detail = rh.account_details(user);

            InitializeComponent();

            LoadTable("", "ALL");
            InitializeCategory();
            
            txtVat.Text = rh.getVat();
        }

        restaurant_helper rh = new restaurant_helper();

        private void restaurant_order_pos_Load(object sender, EventArgs e)
        {
            lblOrderType.Left = pnl_total.Width - lblOrderType.Width - 10;

            cbCat.SelectedIndex = 0;
            vatPerc = Convert.ToDouble(txtVat.Text);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                openQty();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == Keys.F3)
            {
                deleteItem();
                return true;
            }

            if (keyData == Keys.F5)
            {
                openCash();
                return true;
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
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
                    btnQuantity.Left -= 15;
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

                    btnQuantity.Left += 15;
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
        private int index = 0;
        private double discPerc = 0, vatPerc = 0;

        private void product_click(object sender, EventArgs e)
        {
            if (!btnTransaction.Visible)
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

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                index = dataGridView1.Rows.Count - 1;

                dataGridView1.Focus();
                CalculateTotal();
            }
            else
            {
                rh.alert("Notification: ", "Click start transaction before proceeding.", "information");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteItem();
        }

        private void deleteItem()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (index == 0)
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                else
                    dataGridView1.Rows.RemoveAt(index);

                if (dataGridView1.Rows.Count - 1 != -1)
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
            }
            index = 0;

            CalculateTotal();
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            openQty();
        }

        private void openQty()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int newQty = restaurant_order_pos_quantity._Show();

                if (newQty != 0)
                {
                    dataGridView1.Rows[index].Cells["Qty"].Value = newQty;
                    dataGridView1.Rows[index].Cells["Total"].Value = rh.hookDecimal((Convert.ToDouble(dataGridView1.Rows[index].Cells["Qty"].Value) * Convert.ToDouble(dataGridView1.Rows[index].Cells["Price"].Value)).ToString());

                    CalculateTotal();
                }
            }
        }

        private void CalculateTotal()
        {
            double vat = 0, discount = 0, total = 0, subtotal = 0, amountdue = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                vat += Convert.ToDouble(row.Cells["Total"].Value.ToString()) * (vatPerc / 100);
                total += Convert.ToDouble(row.Cells["Total"].Value);

            }
            discount = total * (discPerc / 100);
            subtotal = total - discount;
            amountdue = subtotal + vat;

            lblTotal.Text = rh.hookDecimal(total.ToString());
            lblDiscount.Text = rh.hookDecimal(discount.ToString());
            lblSubTotal.Text = rh.hookDecimal(subtotal.ToString());
            lblVat.Text = rh.hookDecimal(vat.ToString());
            lblAmountDue.Text = rh.hookDecimal(amountdue.ToString());

            lblTotal.Left = pnl_total.Width - lblTotal.Width - 10;
            lblDiscount.Left = pnl_total.Width - lblDiscount.Width - 10;
            lblSubTotal.Left = pnl_total.Width - lblSubTotal.Width - 10;
            lblVat.Left = pnl_total.Width - lblVat.Width - 10;
            lblAmountDue.Left = pnl_total.Width - lblAmountDue.Width - 10;
        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVat.Text))
                vatPerc = 0;
            else
                vatPerc = Convert.ToDouble(txtVat.Text);
            try { CalculateTotal(); } catch (Exception) { }

            if (!string.IsNullOrWhiteSpace(txtVat.Text) && Convert.ToDouble(txtVat.Text) > 100)
            {
                txtVat.Text = "100";
                txtVat.SelectionStart = txtVat.Text.Length;
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
                discPerc = 0;
            else
                discPerc = Convert.ToDouble(txtDiscount.Text);
            try { CalculateTotal(); } catch (Exception) { }

            if (!string.IsNullOrWhiteSpace(txtDiscount.Text) && Convert.ToDouble(txtDiscount.Text) > 100)
            {
                txtDiscount.Text = "100";
                txtDiscount.SelectionStart = txtDiscount.Text.Length;
            }
        }

        private void txtVat_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtVat.Text))
                rh.updateVat(txtVat.Text);
        }

        private void text_keypress(object sender, KeyPressEventArgs e)
        {
            Control c = sender as Control;
            if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != 8) && (e.KeyChar != '.' || c.Text.Contains(".")))
                e.Handled = true;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            openCash();
        }

        String change = "";
        int mode = 0;

        private void openCash()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                cash_tendered = restaurant_order_pos_modal_choice._Show(lblAmountDue.Text);

                if (!string.IsNullOrWhiteSpace(cash_tendered))
                {
                    PrintDialog print = new PrintDialog();
                    PrintDocument doc = new PrintDocument();
                    //PrintPreviewDialog preview = new PrintPreviewDialog();
                    //doc.PrinterSettings.PrinterName = "Send To OneNote 2013";
                    print.Document = doc;
                    //preview.Document = doc;
                    doc.PrintPage += new PrintPageEventHandler(Doc_PrintPage);
                    //preview.ShowDialog();

                    switch (cash_tendered) // Result also
                    {
                        case "PENDING SALE":
                            mode = 2;

                            if (print.ShowDialog() == DialogResult.OK)
                            {
                                doc.Print();
                                rh.order_create(customer, acc_detail[0], lblDiscount.Text, txtDiscount.Text, lblAmountDue.Text, lblVat.Text, txtVat.Text, lblTotal.Text, lblOrderType.Text);
                                String oid = rh.order_number_get().ToString();

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    String pid = dataGridView1[0, i].Value.ToString();
                                    String qty = dataGridView1[3, i].Value.ToString();
                                    String price = dataGridView1[2, i].Value.ToString();

                                    rh.order_details_create(oid, pid, qty, price);
                                }
                            }
                            break;
                        default:
                            mode = 1;

                            if (print.ShowDialog() == DialogResult.OK)
                            {
                                doc.Print();

                                change = rh.hookDecimal((Convert.ToDouble(cash_tendered) - Convert.ToDouble(lblAmountDue.Text)).ToString());
                                rh.sales_create(customer, acc_detail[0], cash_tendered, lblDiscount.Text, txtDiscount.Text, lblAmountDue.Text, change, lblVat.Text, txtVat.Text, lblTotal.Text, lblOrderType.Text);
                                String sid = rh.sales_number_get().ToString();
                                rh.sales_customer_details_create(customer, sid, lblAmountDue.Text);

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    String pid = dataGridView1[0, i].Value.ToString();
                                    String qty = dataGridView1[3, i].Value.ToString();
                                    String price = dataGridView1[2, i].Value.ToString();

                                    rh.sales_details_create(sid, pid, qty, price);
                                }
                            }
                            break;
                    }


                    new restaurant_order_pos_modal_table(cash_tendered, customer).ShowDialog();

                    dataGridView1.Rows.Clear();
                    CalculateTotal();
                    mode = 0;

                    // Pick Tables...
                }

                rh.alert("Notification: ", "Transaction done. System is ready for the next transaction.", "success");
                btnTransaction.Visible = true;
            }
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            btnTransaction.Visible = false;
            lblOrderType.Text = restaurant_order_pos_modal._Show();
            customer = restaurant_order_pos_modal_name._Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            new restaurant_order_pos_pending().ShowDialog();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (mode == 1)
                rh.print_receipt(e.Graphics, dataGridView1, lblOrderType.Text, acc_detail[1], rh.sales_or_number(rh.sales_number_get().ToString()), lblAmountDue.Text, cash_tendered, change, lblDiscount.Text, txtDiscount.Text, lblTotal.Text, lblVat.Text, txtVat.Text, customer);
            else
                rh.print_order(e.Graphics, dataGridView1, acc_detail[1], lblOrderType.Text, customer);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
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
