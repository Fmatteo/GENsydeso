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
        #region Variables
        private DataTable dt = new DataTable();
        private int pageSize;
        private int currentPage = 1;
        private int totalPage = 0;
        private String id, name, price;

        restaurant_helper rh = new restaurant_helper();
        #endregion
        public restaurant_products()
        {
            InitializeComponent();
            InitializeColumns();
        }

        #region LoadTable
        /// <summary>
        /// Initializes the Columns inside the DataTable
        /// </summary>
        private void InitializeColumns()
        {
            dt.Columns.Add("Product Code", typeof(int));
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Qty.", typeof(int));
            dt.Columns.Add("Reorder Point", typeof(int));
            dt.Columns.Add("Price");
            dt.Columns.Add("Category");
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
        private void LoadTable(String search, int page, int pageSize)
        {
            dt.Clear();
            dataGridView1.DataSource = rh.res_product_view(dt, search, page, pageSize);

            dataGridView1.CurrentCell = null;

            // Calls the method to calculate the pages..
            CalculatePages();
        }
        #endregion

        private void restaurant_products_Load(object sender, EventArgs e)
        {
            txtPage.ContextMenu = new ContextMenu();
            cbEntries.SelectedIndex = 0;
            pageSize = Convert.ToInt32(cbEntries.SelectedItem.ToString());

            LoadTable("", currentPage, pageSize);
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
                LoadTable(c.Text, currentPage, pageSize);
            else
                LoadTable("", currentPage, pageSize);
            c.SelectionStart = c.Text.Length;
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

            LoadTable("", currentPage, pageSize);
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
                LoadTable("", currentPage, pageSize);
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
            LoadTable("", currentPage, pageSize);
            txtPage.Text = currentPage.ToString();
        }
        #endregion

        #region CRUD Logics
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                name = row.Cells[1].Value.ToString();
                price = row.Cells[4].Value.ToString();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();

                if (restaurant_products_update._Show(id) == DialogResult.Yes)
                {
                    rh.alert("Notification: ", "Updating existing record successfully.", "information");
                    LoadTable("", currentPage, pageSize);
                    id = "";
                }
            }
        }

        private void crud_button_click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnNew":
                    if (restaurant_products_new._Show() == DialogResult.Yes)
                    {
                        rh.alert("Notification: ", "Creating new record successfully.", "information");
                        LoadTable("", currentPage, pageSize);
                    }
                    break;

                case "btnDelete":
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        if (rh.res_product_delete(id))
                        {
                            rh.alert("Notification: ", "Record deleted successfully.", "information");
                            LoadTable("", currentPage, pageSize);
                            id = "";
                        }
                    }
                    else
                        rh.alert("Error: ", "Please specify the product you want to modify.\nSelect first a product then try again.", "danger");
                    break;

                case "btnStockIn":
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        if (restaurant_products_stock_in._Show(id) == DialogResult.Yes)
                        {
                            rh.alert("Notification: ", "Product quantity updated.", "information");
                            LoadTable("", currentPage, pageSize);
                            id = "";
                        }
                    }
                    else
                        rh.alert("Error: ", "Please specify the product you want to modify.\nSelect first a product then try again.", "danger");
                    break;

                default:
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        if (restaurant_products_stock_out._Show(id, name, price) == DialogResult.Yes)
                        {
                            rh.alert("Notification: ", "Product stock out success.", "information");
                            LoadTable("", currentPage, pageSize);
                            id = "";
                        }
                    }
                    else
                        rh.alert("Error: ", "Please specify the product you want to modify.\nSelect first a product then try again.", "danger");
                    break;
            }
        }
        #endregion
    }
}
