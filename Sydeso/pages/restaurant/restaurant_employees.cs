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
    public partial class restaurant_employees : Form
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

        private int pageSize;
        private int currentPage = 1;
        private int totalPage = 0;

        private String id;
        restaurant_helper rh = new restaurant_helper();

        public restaurant_employees()
        {
            InitializeComponent();
        }

        #region LoadTable
        /// <summary>
        /// Calculate the number of pages
        /// </summary>
        private void CalculatePages()
        {
            int rowCount = rh.res_emp_count();
            totalPage = rowCount / pageSize;

            if (rowCount % pageSize > 0)
                totalPage += 1;

            if (pageSize == 1 || totalPage == 0)
                lblTotalPage.Text = "/1";
            else
                lblTotalPage.Text = "/" + totalPage;

            lblTotalPage.Left = customPanel6.Width;
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
            this.SuspendLayout();
            customPanel6.Controls.Clear();

            List<restaurant_emp_detail> data = rh.res_emp_read(search, page, pageSize);
            int offX = 0, offY = 0, count = 0;

            for(int i = 0; i < data.Count; i++)
            {
                data[i].Cursor = Cursors.Hand;
                data[i].Click += emp_click;
                data[i].DoubleClick += emp_doubleclick;
                data[i].Location = new Point(offX, offY);
                offX += data[i].Width;
                count++;
                if (count == (customPanel6.Width / data[i].Width))
                {
                    offY += data[i].Height;
                    offX = 0;
                    count = 0;
                }

                if (i % 2 == 0)
                {
                    data[i].BackColor = Color.FromArgb(210, 210, 209);
                }

                customPanel6.Controls.Add(data[i]);
            }

            // Calls the method to calculate the pages..
            this.ResumeLayout();
            CalculatePages();
        }

        private void emp_doubleclick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (restaurant_employees_update._Show(id) == DialogResult.Yes)
                {
                    rh.alert("Notification: ", "Employee updated successfully.", "information");
                    LoadTable("", currentPage, pageSize);
                    id = "";
                }
            }
            else
            {
                rh.alert("Error: ", "Please specify the account you want to modify.\nSelect first a account then try again.", "danger");
            }
        }

        private void emp_click(object sender, EventArgs e)
        {
            for (int i = 0; i < customPanel6.Controls.Count; i++)
            {
                customPanel6.Controls[i].BackColor = Color.FromArgb(220, 220, 219);

                if (i % 2 == 0)
                {
                    customPanel6.Controls[i].BackColor = Color.FromArgb(210, 210, 209);
                }
            }

            restaurant_emp_detail c = sender as restaurant_emp_detail;
            c.BackColor = Color.LightYellow;

            id = c.emp_id;
        }

        #endregion

        private void restaurant_employees_Load(object sender, EventArgs e)
        {
            txtPage.ContextMenu = new ContextMenu();
            cbEntries.SelectedIndex = 0;
            pageSize = Convert.ToInt32(cbEntries.SelectedItem.ToString());
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

        private void crud_button_click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnNew":
                    if (restaurant_employees_new._Show() == DialogResult.Yes)
                    {
                        rh.alert("Notification: ", "Employee created successfully.", "information");
                        LoadTable("", currentPage, pageSize);
                    }
                    break;

                default:
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        rh.res_emp_delete(id);
                        rh.alert("Notification: ", "Employee deleted successfully.", "information");
                        LoadTable("", currentPage, pageSize);
                        id = "";
                    }
                    else
                        rh.alert("Error: ", "Please specify the account you want to modify.\nSelect first a account then try again.", "danger");
                    break;
            }
        }
        #endregion

        private void restaurant_employees_SizeChanged(object sender, EventArgs e)
        {
            LoadTable("", currentPage, pageSize);
        }
    }
}
