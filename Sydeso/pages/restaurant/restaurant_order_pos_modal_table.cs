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
    public partial class restaurant_order_pos_modal_table : Form
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

        String _choice = "", _cname = "";
        public restaurant_order_pos_modal_table(String choice, String cname)
        {
            _choice = choice;
            _cname = cname;
            InitializeComponent();
        }

        private void restaurant_order_pos_modal_table_Load(object sender, EventArgs e)
        {
            LoadTable("");
        }

        restaurant_helper rh = new restaurant_helper();

        private void LoadTable(String search)
        {
            this.SuspendLayout();
            pnl_items.Controls.Clear();

            List<restaurant_table_detail> list = rh.res_table_detail(search);

            int count = 0, offSetX = 0, offSetY = 1;
            for (int i = 0; i < list.Count; i++)
            {
                count++;

                list[i].Location = new Point(offSetX, offSetY);

                foreach (Control c in list[i].Controls)
                {
                    c.Click += table_click;
                    foreach (Control d in c.Controls)
                        d.Click += table_click;
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
            this.ResumeLayout();
        }

        String _id, _name, _desc, _status;

        private void table_click(object sender, EventArgs e)
        {
            Control c = sender as Control;
            Control d = c.Parent;

            try
            {
                restaurant_table_detail a = d.Parent as restaurant_table_detail;

                _id = a.Table_ID.ToString();
                _name = a.Table_Name;
                _desc = a.Table_Desc;
                _status = a.Table_Status;
            }
            catch (Exception)
            {
                restaurant_table_detail a = c.Parent as restaurant_table_detail;

                _id = a.Table_ID.ToString();
                _name = a.Table_Name;
                _desc = a.Table_Desc;
                _status = a.Table_Status;
            }

            MessageBox.Show(String.Format("{0}\n{1}\n{2}\n{3}", _id, _name, _desc, _status));
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
                LoadTable(c.Text);
            else
                LoadTable("");
            c.SelectionStart = c.Text.Length;
        }
        #endregion

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_id))
            {
                rh.res_table_choose(_choice, _cname, _status, _id);
                this.Close();
            }
            else
            {
                rh.alert("Error: ", "Please specify the table details before clicking yes button.", "danger");
            }
        }
    }
}
