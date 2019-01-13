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
    public partial class DateTimeRecord : Form
    {
        public DateTimeRecord()
        {
            InitializeComponent();
            InitializeDateTime();
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

        #region Initialize Date Time

        private void InitializeDateTime()
        {
            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += timer_tick;
            t.Start();

            lblTime.Text = DateTime.Now.ToString("hh\nmm\ntt");
            lblDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");

            foreach (Control c in pnl_datetime.Controls)
            {
                c.Left = (pnl_datetime.Width - c.Width) / 2;
            }
        }

        private void timer_tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh\nmm\ntt");
            lblDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");

            foreach (Control c in pnl_datetime.Controls)
            {
                c.Left = (pnl_datetime.Width - c.Width) / 2;
            }
        } 
        #endregion

        database_helper db = new database_helper();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Buttons Logic
        private bool checkIn;

        private void buttons_click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnIn":
                    checkIn = true;

                    btnIn.Normalcolor = Color.FromArgb(47, 193, 178);
                    btnOut.Normalcolor = Color.FromArgb(27, 173, 158);
                    pnl_form.Enabled = true;
                    this.Width = this.MaximumSize.Width;
                    break;
                case "btnOut":
                    checkIn = false;

                    btnOut.Normalcolor = Color.FromArgb(47, 193, 178);
                    btnIn.Normalcolor = Color.FromArgb(27, 173, 158);
                    pnl_form.Enabled = true;
                    this.Width = this.MaximumSize.Width;
                    break;
                default:
                    if (checkIn)
                        db.dtr_time_in(txtUser.Text, txtPass.Text);
                    else
                        db.dtr_time_out(txtUser.Text, txtPass.Text);
                    break;
            }
        } 
        #endregion
    }
}
