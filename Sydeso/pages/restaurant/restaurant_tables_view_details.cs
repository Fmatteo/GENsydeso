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
    public partial class restaurant_tables_view_details : Form
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

        public restaurant_tables_view_details()
        {
            InitializeComponent();
        }

        static restaurant_tables_view_details view; static DialogResult result = DialogResult.No;
        static restaurant_helper rh = new restaurant_helper();

        public static DialogResult _Show(String id, String status)
        {
            view = new restaurant_tables_view_details();

            switch (status)
            {
                case "RESERVED":
                    view.dataGridView1.DataSource = rh.res_table_read_details_reserved(id);
                    view.dataGridView2.Visible = false;
                    view.label2.Visible = false;
                    view.dataGridView1.Height = 323;
                    break;
                default:
                    view.dataGridView1.DataSource = rh.res_table_read_details_occupied(id);
                    view.dataGridView2.DataSource = rh.res_table_read_details_occupied_item(view.dataGridView1[0, 0].Value.ToString());
                    break;
            }

            view.ShowDialog();
            return result;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Visible)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    String id = row.Cells[0].Value.ToString();

                    dataGridView2.DataSource = rh.res_table_read_details_occupied_item(id);
                }
            }
        }
    }
}
