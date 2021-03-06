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
    public partial class restaurant_customers_new : Form
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

        public restaurant_customers_new()
        {
            InitializeComponent();
        }

        static restaurant_customers_new add; static DialogResult result = DialogResult.No;
        restaurant_helper rh = new restaurant_helper();

        public static DialogResult _Show()
        {
            add = new restaurant_customers_new();
            add.ShowDialog();
            return result;
        }

        private void restaurant_customer_create_Load(object sender, EventArgs e)
        {
            foreach (Control c in pnl_container.Controls)
            {
                if (c is BorderedPanel)
                    foreach (Control d in c.Controls)
                        if (d is TextBox)
                            d.ContextMenu = new ContextMenu();
            }
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

        #region Button Logics
        private void button_click(Object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnExit":
                case "btnNo":
                    result = DialogResult.No; this.Close();
                    break;
                default:
                    if (!string.IsNullOrWhiteSpace(txtFname.Text) && !string.IsNullOrWhiteSpace(txtLname.Text) && !string.IsNullOrWhiteSpace(txtPhone.Text) && !string.IsNullOrWhiteSpace(txtBday.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        if (rh.res_cust_create(txtFname.Text + " " + txtLname.Text, datePicker.Value.ToString(), txtPhone.Text, txtEmail.Text))
                        {
                            result = DialogResult.Yes; this.Close();
                        }
                    }
                    else
                        rh.alert("Error: ", "Please fill up all the required fields to proceed.", "danger");
                    break;
            }
        }
        #endregion

        #region Date Picker Logic
        private void txtBday_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtBday_Enter(object sender, EventArgs e)
        {
            datePicker.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void txtBday_Leave(object sender, EventArgs e)
        {
            datePicker.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            txtBday.Text = datePicker.Value.ToString("dd-MM-yyyy");
        }

        #endregion

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
