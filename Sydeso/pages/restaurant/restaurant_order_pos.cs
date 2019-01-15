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

            lblOrderType.Text = restaurant_order_pos_modal._Show();
            customer = restaurant_order_pos_modal_name._Show();

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
                    print.Document = doc;
                    //preview.Document = doc;
                    doc.PrintPage += new PrintPageEventHandler(Doc_PrintPage);

                    //preview.ShowDialog();

                    DialogResult res = print.ShowDialog();

                    if (res == DialogResult.OK)
                    {
                        doc.Print();

                        change = rh.hookDecimal((Convert.ToDouble(cash_tendered) - Convert.ToDouble(lblAmountDue.Text)).ToString());
                        rh.sales_create(customer, acc_detail[0], cash_tendered, lblDiscount.Text + "(" + txtDiscount.Text + "%)", lblAmountDue.Text, change);
                        String sid = rh.sales_number_get().ToString();

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            String pid = dataGridView1[0, i].Value.ToString();
                            String qty = dataGridView1[3, i].Value.ToString();
                            String price = dataGridView1[2, i].Value.ToString();

                            rh.sales_details_create(sid, pid, qty, price);
                        }

                        dataGridView1.Rows.Clear();
                        CalculateTotal();
                    }
                }

                MessageBox.Show("Transaction Done");
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            List<Object> com_details = rh.get_setup_config();
            String com_name = com_details[1].ToString();
            String com_add = com_details[2].ToString();
            String com_phone = com_details[3].ToString();
            String com_tin = "00000000000000";

            int pageWidth = 200;

            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);

            Font font_12 = new Font("Courier New", 12);
            Font font_12B = new Font("Courier New", 12, FontStyle.Bold);
            Font font_18 = new Font("Courier New", 18, FontStyle.Bold);

            int startX = 0;
            int startY = 10;
            int offSet = 40;

            g.DrawString(com_name, font_18, brush, ((pageWidth - Measure(g, com_name, font_18) / 2)), startY);
            startY += (int)font_18.GetHeight();

            g.DrawString(com_add, font_12, brush, ((pageWidth - Measure(g, com_add, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Phone Number: " + com_phone, font_12, brush, ((pageWidth - Measure(g, "Phone Number: " + com_phone, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("TIN #: " + com_tin, font_12, brush, ((pageWidth - Measure(g, "TIN No.: " + com_tin, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            //g.DrawLine(Pens.Black, new Point(0, startY), new Point(pageWidth * 2, startY));
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //

            g.DrawString("SALES RECEIPT", font_12B, brush, ((pageWidth - Measure(g, "SALES RECEIPT", font_12B) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Sales Invoice No.: ", font_12, brush, startX, startY);
            g.DrawString(rh.sales_or_number(), font_12, brush, (pageWidth * 2 - Measure(g, rh.sales_or_number(), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Time Generated: ", font_12, brush, startX, startY);
            g.DrawString(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), font_12, brush, (pageWidth * 2 - Measure(g, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Cashier: ", font_12, brush, startX, startY);
            g.DrawString(acc_detail[1].ToUpper(), font_12, brush, (pageWidth * 2 - Measure(g, acc_detail[1].ToUpper(), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Order Type: ", font_12, brush, startX, startY);
            g.DrawString(lblOrderType.Text, font_12, brush, (pageWidth * 2 - Measure(g, lblOrderType.Text, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Payment Method: ", font_12, brush, startX, startY);
            g.DrawString("CASH", font_12, brush, (pageWidth * 2 - Measure(g, "CASH", font_12)), startY);
            startY += (int)font_12.GetHeight();

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("ITEM NAME", font_12B, brush, startX, startY);
            g.DrawString("AMOUNT", font_12B, brush, (pageWidth * 2 - Measure(g, "AMOUNT", font_12B)), startY);
            startY += (int)font_12.GetHeight();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                String prod_name = dataGridView1[1, i].Value.ToString();
                String qty = dataGridView1[3, i].Value.ToString();
                String price = dataGridView1[2, i].Value.ToString();
                String total = rh.hookDecimal(dataGridView1[4, i].Value.ToString());

                String detail = qty + "PC(s) @ " + rh.hookDecimal(price);

                // Product name
                g.DrawString(prod_name, font_12, brush, startX, startY);

                startY += (int)font_12.GetHeight();
                g.DrawString(detail, font_12, brush, startX + offSet, startY);
                g.DrawString(total, font_12, brush, (pageWidth * 2 - Measure(g, total, font_12)), startY);

                startY += (int)font_12.GetHeight();
            }

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Amount Due: ", font_12B, brush, startX, startY);
            g.DrawString(lblAmountDue.Text, font_12, brush, (pageWidth * 2 - Measure(g, lblAmountDue.Text, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Cash Tendered: ", font_12B, brush, startX, startY);
            g.DrawString(rh.hookDecimal(cash_tendered), font_12, brush, (pageWidth * 2 - Measure(g, rh.hookDecimal(cash_tendered), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Change Due: ", font_12B, brush, startX, startY);
            g.DrawString(change, font_12, brush, (pageWidth * 2 - Measure(g, change, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Discount: (" + lblDiscount.Text + "%)", font_12B, brush, startX, startY);
            g.DrawString(lblDiscount.Text, font_12, brush, (pageWidth * 2 - Measure(g, lblDiscount.Text, font_12)), startY);
            startY += (int)font_12.GetHeight();

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("VATable Sales: ", font_12, brush, startX, startY);
            g.DrawString(lblAmountDue.Text, font_12, brush, (pageWidth * 2 - Measure(g, lblAmountDue.Text, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("VAT Exempt Sales: ", font_12, brush, startX, startY);
            g.DrawString(lblTotal.Text, font_12, brush, (pageWidth * 2 - Measure(g, lblTotal.Text, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Zero-Rated Sales: ", font_12, brush, startX, startY);
            g.DrawString("0.00", font_12, brush, (pageWidth * 2 - Measure(g, "0.00", font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString(txtVat.Text + "% VAT Sales: ", font_12B, brush, startX, startY);
            g.DrawString(lblVat.Text, font_12, brush, (pageWidth * 2 - Measure(g, lblVat.Text, font_12)), startY);
            startY += (int)font_12.GetHeight();

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Sold To: ", font_12, brush, startX, startY);
            g.DrawString(customer, font_12, brush, (pageWidth * 2 - Measure(g, customer, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("TIN No.: ", font_12, brush, startX, startY);
            g.DrawString("______________________", font_12, brush, (pageWidth * 2 - Measure(g, "______________________", font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Address: ", font_12, brush, startX, startY);
            g.DrawString("______________________", font_12, brush, (pageWidth * 2 - Measure(g, "______________________", font_12)), startY);
            startY += (int)font_12.GetHeight() + 10;

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Thank you for purchasing!", font_12B, brush, ((pageWidth - Measure(g, "Thank you for purchasing!", font_12B) / 2)), startY);
            startY += (int)font_12B.GetHeight() + 10;

            g.DrawString("Powered by: ", font_12B, brush, ((pageWidth - Measure(g, "Powered by: ", font_12B) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("System Development Solution", font_12, brush, ((pageWidth - Measure(g, "System Development Solution", font_12) / 2)), startY);
        }

        private int Measure(Graphics g, String text, Font font)
        {
            int size = (int)g.MeasureString(text, font).Width;
            return size;
        }

        private String insertLine(Graphics g, Font font, int size)
        {
            String line = "";
            while (true)
            {
                if ((int)g.MeasureString(line, font).Width < size * 2)
                {
                    line += "=";

                    if ((int)g.MeasureString(line, font).Width > size * 2)
                    {
                        line.Remove(0);
                        break;
                    }
                }
            }
            return line;
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
