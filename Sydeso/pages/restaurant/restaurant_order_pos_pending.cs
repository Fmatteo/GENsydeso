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
    public partial class restaurant_order_pos_pending : Form
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

        public restaurant_order_pos_pending()
        {
            InitializeComponent();

            dataGridView1.DataSource = rh.order_pending("");
        }

        #region Placeholder Logics
        private void placeholder_keydown(object sender, KeyEventArgs e)
        {
            TextBox c = sender as TextBox;
            if (c.Text == "  SEARCH")
                c.Text = "";
        }

        restaurant_helper rh = new restaurant_helper();

        private void placeholder_keyup(object sender, KeyEventArgs e)
        {
            TextBox c = sender as TextBox;
            if (string.IsNullOrWhiteSpace(c.Text))
                c.Text = "  SEARCH";

            if (c.Text != "  SEARCH")
                dataGridView1.DataSource = rh.order_pending(txtSearch.Text);
            else
                dataGridView1.DataSource = rh.order_pending("");
            c.SelectionStart = c.Text.Length;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        String id, acc, amount, cus, tid;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                tid = row.Cells[1].Value.ToString();    
                cus = row.Cells[2].Value.ToString();
                acc = row.Cells[3].Value.ToString();
                amount = row.Cells[4].Value.ToString();
            }
        }

        String cash, change;
        List<String> missing;

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                PrintDialog print = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                //PrintPreviewDialog preview = new PrintPreviewDialog();
                //doc.PrinterSettings.PrinterName = "Send To OneNote 2013";
                print.Document = doc;
                //preview.Document = doc;
                doc.PrintPage += new PrintPageEventHandler(Doc_PrintPage);

                missing = rh.order_pending_missing(id);

                cash = restaurant_order_pos_modal_cash._Show(amount);
                change = (Convert.ToDouble(cash) - Convert.ToDouble(amount)).ToString();

                if (print.ShowDialog() == DialogResult.OK)
                {
                    rh.sales_create(missing[7] + ": " + cus, missing[6], cash, missing[1], missing[2], amount, change, missing[4], missing[5], missing[3], missing[0]);
                    doc.Print();

                    List<List<String>> items = rh.order(id);

                    foreach (var list in items)
                    {
                        rh.sales_details_create(rh.sales_number_get().ToString(), list[0], list[1], list[2]);
                    }

                    rh.order_update_status(id);
                    rh.alert("Notification: ", "Transaction done. System is ready for the next transaction.", "success");

                    // Refresh the Table
                    dataGridView1.DataSource = rh.order_pending("");
                }
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            DataGridView dgv = new DataGridView();
            dgv.DataSource = rh.order_pending_details(id);
            rh.print_receipt(e.Graphics, dgv, missing[0], acc, rh.sales_or_number((rh.sales_number_get()).ToString()), rh.hookDecimal(amount), cash, change, missing[1], missing[2], missing[3], missing[4], missing[5], cus);
        }
    }
}
