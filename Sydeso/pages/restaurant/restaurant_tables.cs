﻿using System;
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
    public partial class restaurant_tables : Form
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

        #region Variables
        private DataTable dt = new DataTable();
        private int pageSize;
        private int currentPage = 1;
        private int totalPage = 0;
        private String id, status;

        restaurant_helper rh = new restaurant_helper();
        #endregion

        public restaurant_tables()
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
            dt.Columns.Add("ID");
            dt.Columns.Add("Table Name");
            dt.Columns.Add("Table Description");
            dt.Columns.Add("Table Status");
        }

        /// <summary>
        /// Calculate the number of pages
        /// </summary>
        private void CalculatePages()
        {
            try
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

            catch (Exception) { }
        }

        /// <summary>
        /// Loads the table with pagination
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        private void LoadTable(String search, int page, int pageSize)
        {
            this.SuspendLayout();
            dt.Clear();
            dataGridView1.DataSource = rh.res_table_read(dt, search, page, pageSize);

            dataGridView1.CurrentCell = null;

            // Calls the method to calculate the pages..
            CalculatePages();
            this.ResumeLayout();
        }
        #endregion

        private void restaurant_tables_Load(object sender, EventArgs e)
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

        /// <summary>
        /// Update Part of CRUD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                status = row.Cells[3].Value.ToString();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.SuspendLayout();
            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                i++;
                row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 219);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(205, 49, 49);
                row.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
                row.DefaultCellStyle.SelectionForeColor = Color.AliceBlue;

                if (i == 2)
                {
                    i = 0;
                    row.DefaultCellStyle.BackColor = Color.FromArgb(237, 242, 246);
                }

                if (row.Cells["Table Status"].Value.ToString() == "RESERVED")
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = Color.Yellow;
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                }

                if (row.Cells["Table Status"].Value.ToString() == "OCCUPIED")
                {
                    row.DefaultCellStyle.BackColor = Color.Teal;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.Teal;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
            this.ResumeLayout();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();

                if (restaurant_tables_update._Show(id) == DialogResult.Yes)
                {
                    LoadTable("", currentPage, pageSize);
                    id = "";
                }
            }
        }

        private void restaurant_tables_SizeChanged(object sender, EventArgs e)
        {
            LoadTable("", currentPage, pageSize);
        }

        private void crud_button_click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnNew":
                    if (restaurant_tables_new._Show() == DialogResult.Yes)
                        LoadTable("", currentPage, pageSize);
                    break;

                case "btnDelete":
                    if (rh.res_table_delete(id))
                        LoadTable("", currentPage, pageSize);
                    break;

                case "btnReserve":
                    if (string.IsNullOrWhiteSpace(id))
                    {
                        rh.alert("Error: ", "Please specify the table you want to modify.\nSelect first a table then try again.", "danger");
                        return;
                    }

                    if (restaurant_tables_reserve._Show(id) == DialogResult.Yes)
                    {
                        LoadTable("", currentPage, pageSize);
                        id = "";
                    }
                    break;

                case "btnViewReservation":
                    new restaurant_tables_reservation().ShowDialog();
                    LoadTable("", currentPage, pageSize);
                    break;

                default:
                    if (string.IsNullOrWhiteSpace(id))
                    {
                        rh.alert("Error: ", "Please specify the table you want to modify.\nSelect first a table then try again.", "danger");
                        return;
                    }

                    if (status != "VACANT")
                    {
                        restaurant_tables_view_details._Show(id, status);
                        id = "";
                        status = "";
                    }
                    else
                        rh.alert("Notification: ", "This table is vacant, no information to view.", "information");
                    break;
            }
        }
        #endregion
    }
}
