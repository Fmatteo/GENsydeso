using DGVPrinterHelper;
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
    public partial class DateTimeRecord_View : Form
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

        private DataTable dt = new DataTable();
        private int pageSize;
        private int currentPage = 1;
        private int totalPage = 0;
        private List<String> acc_detail;

        database_helper db = new database_helper();

        public DateTimeRecord_View(String user)
        {
            this.acc_detail = db.account_details(user);

            InitializeComponent();
            InitializeColumns();
        }

        private void DateTimeRecord_View_Load(object sender, EventArgs e)
        {
            txtPage.ContextMenu = new ContextMenu();
            cbEntries.SelectedIndex = 0;
            pageSize = Convert.ToInt32(cbEntries.SelectedItem.ToString());

            dataGridView1.Focus();
            LoadTable(DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy"), currentPage, pageSize);
            txtStart.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd-MM-yyyy");
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

        #region LoadTable
        /// <summary>
        /// Initializes the Columns inside the DataTable
        /// </summary>
        private void InitializeColumns()
        {
            dt.Columns.Add("Employee Name");
            dt.Columns.Add("Time In");
            dt.Columns.Add("Time Out");
            dt.Columns.Add("Date");
        }

        /// <summary>
        /// Calculate the number of pages
        /// </summary>
        private void CalculatePages()
        {
            int rowCount = dt.Rows.Count;
            totalPage = rowCount / pageSize;

            if (rowCount % pageSize > 0)
                totalPage += 1;

            if (pageSize == 1 || totalPage == 0)
                lblTotalPage.Text = "/1";
            else
                lblTotalPage.Text = "/" + totalPage;

            lblTotalPage.Left = dataGridView1.Width;
            txtPage.Left = lblTotalPage.Location.X - txtPage.Width - 2;
        }

        /// <summary>
        /// Loads the table with pagination
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        private void LoadTable(String start, String end, int page, int pageSize)
        {
            dt.Clear();
            dataGridView1.DataSource = db.dtr_view(dt, start, end, page, pageSize);

            dataGridView1.CurrentCell = null;

            // Calls the method to calculate the pages..
            CalculatePages();
        }
        #endregion

        #region Pagination Logics
        /// <summary>
        /// Pagination buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pagination_button_click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnFirst":
                    currentPage = 1;
                    break;

                case "btnBack":
                    if (currentPage > 1)
                        currentPage--;
                    break;

                case "btnNext":
                    if (currentPage < totalPage)
                        currentPage++;
                    break;

                case "btnLast":
                    currentPage = totalPage;
                    break;

                default:
                    break;

            }

            LoadTable(dateStart.Value.ToString("dd-MM-yyyy"), dateEnd.Value.ToString("dd-MM-yyyy"), currentPage, pageSize);
            txtPage.Text = currentPage.ToString();
        }

        /// <summary>
        /// Page text changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page_textchanged(object sender, EventArgs e)
        {
            int current, total; TextBox c = sender as TextBox;
            int.TryParse(c.Text, out current);
            int.TryParse(lblTotalPage.Text.Replace("/", ""), out total);

            if (current > total || c.Text == "0")
                c.Text = total.ToString();
            else
            {
                if (c.Text != string.Empty)
                    currentPage = Convert.ToInt32(c.Text);
                LoadTable(dateStart.Value.ToString("dd-MM-yyyy"), dateEnd.Value.ToString("dd-MM-yyyy"), currentPage, pageSize);
            }

            c.SelectionStart = c.Text.Length;
        }

        /// <summary>
        /// Page key pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page_keypress(object sender, KeyPressEventArgs e)
        {
            int total; TextBox c = sender as TextBox;
            int.TryParse(lblTotalPage.Text.Replace("/", ""), out total);

            // Check if not the input char is a digit
            // Check if not the length >= totalpage length
            // Check if not the input char is backspace
            if (((!char.IsDigit(e.KeyChar)) || c.Text.Length >= lblTotalPage.Text.Length - 1) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void cbEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;
            if (c.SelectedItem.ToString() == "ALL")
                pageSize = -1;
            else
                pageSize = Convert.ToInt32(c.SelectedItem.ToString());

            currentPage = 1;
            LoadTable(dateStart.Value.ToString("dd-MM-yyyy"), dateEnd.Value.ToString("dd-MM-yyyy"), currentPage, pageSize);
            txtPage.Text = currentPage.ToString();
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DGVPrinter printer = new DGVPrinter();
                printer.PageSettings.Landscape = true;
                printer.Title = "Date Time Record from " + dateStart.Value.ToString("MMMM dd, yyyy") + " to " + dateEnd.Value.ToString("MMMM dd, yyyy");
                printer.TitleAlignment = StringAlignment.Near;
                printer.SubTitle = "Date Generated: " + DateTime.Now.ToString("MMMM dd, yyyy");
                printer.SubTitleAlignment = StringAlignment.Near;
                printer.SubTitleSpacing = 20;

                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.CellAlignment = StringAlignment.Near;
                printer.Footer = string.Format("Prepared by: {0}", acc_detail[1] + " " + acc_detail[2]);
                printer.PrintPreviewDataGridView(dataGridView1);
            }
        }

        #region Date Logics
        private void date_valuechanged(Object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "dateStart":
                    txtStart.Text = dateStart.Value.ToString("dd-MM-yyyy");
                    break;
                default:
                    txtEnd.Text = dateEnd.Value.ToString("dd-MM-yyyy");
                    break;
            }

            LoadTable(dateStart.Value.ToString("dd-MM-yyyy"), dateEnd.Value.ToString("dd-MM-yyyy"), currentPage, pageSize);
        }

        private void text_keypress(Object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void text_enter(Object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "txtStart":
                    dateStart.Select();
                    SendKeys.Send("%{DOWN}");
                    break;
                default:
                    dateEnd.Select();
                    SendKeys.Send("%{DOWN}");
                    break;
            }
        }

        private void text_leave(Object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "txtStart":
                    dateStart.Select();
                    SendKeys.Send("%{DOWN}");
                    break;
                default:
                    dateEnd.Select();
                    SendKeys.Send("%{DOWN}");
                    break;
            }
        } 
        #endregion
    }
}
