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
    public partial class restaurant_customers_details : Form
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

        String id;
        public restaurant_customers_details(String id, String name)
        {
            this.id = id;
            InitializeComponent();
            label2.Text += name;
        }

        restaurant_helper rh = new restaurant_helper();
        private void restaurant_customers_details_Load(object sender, EventArgs e)
        {
            txtStart.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");

            dataGridView1.DataSource = rh.res_cust_history(id, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != dataGridView1.Rows.Count - 1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                String id = row.Cells[0].Value.ToString();
                dataGridView2.DataSource = rh.res_cust_history_details(id);
                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value.ToString() == "Total:")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(205, 49, 49);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(205, 49, 49);
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value.ToString() == "No. of Items")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(205, 49, 49);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(205, 49, 49);
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        #region Date Logics
        private void date_valuechanged(Object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "dateStart":
                    txtStart.Text = dateStart.Value.ToString("yyyy-MM-dd");
                    break;
                default:
                    txtEnd.Text = dateEnd.Value.ToString("yyyy-MM-dd");
                    break;
            }
            dataGridView1.DataSource = rh.res_cust_history(id, dateStart.Value.ToString("yyyy-MM-dd"), dateEnd.Value.ToString("yyyy-MM-dd"));
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
    }
}
