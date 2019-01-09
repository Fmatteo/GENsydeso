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
    public partial class restaurant_products_new : Form
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

        public restaurant_products_new()
        {
            InitializeComponent();
            InitializeTextBox();
            LoadCategory();
        }

        static restaurant_products_new add; static DialogResult result = DialogResult.No;
        restaurant_helper rh = new restaurant_helper();

        public static DialogResult _Show()
        {
            add = new restaurant_products_new();
            add.ShowDialog();
            return result;
        }

        #region InitializeTextBox

        /// <summary>
        /// Set this so that user cannot copy paste (right click then copy/paste)
        /// </summary>
        private void InitializeTextBox()
        {
            foreach (Control b in pnl_container.Controls)
                foreach (Control c in b.Controls)
                    if (c is TextBox)
                    {
                        TextBox t = c as TextBox;
                        t.ContextMenu = new ContextMenu();
                    }
        }
        #endregion

        #region InitializeCategory
        private void LoadCategory()
        {
            cbCategory.Items.Clear();
            List<String> category = rh.res_category_view();
            foreach (var i in category)
            {
                cbCategory.Items.Add(i);
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

        #region Button Logics
        private void button_click(object sender, EventArgs e)
        {
            Control c = sender as Control;

            switch (c.Name)
            {
                case "btnExit":
                    result = DialogResult.No; this.Close();
                    break;

                case "btnYes":
                    if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))
                    {
                        String qty = "", reorder = "";
                        if (!string.IsNullOrWhiteSpace(txtQty.Text))
                        {
                            if (string.IsNullOrWhiteSpace(txtReorder.Text))
                            {
                                int getQty;
                                int.TryParse(txtQty.Text, out getQty);

                                reorder = (getQty / 2).ToString();
                            }
                            else
                            {
                                reorder = txtReorder.Text;
                            }

                            qty = txtQty.Text;
                        }

                        if (cbCategory.SelectedIndex >= 0)
                        {
                            if (rh.res_product_insert(txtName.Text, qty, reorder, txtPrice.Text, cbCategory.SelectedItem.ToString(), pbImage.ImageLocation))
                                result = DialogResult.Yes; this.Close();
                        }
                        else
                        {
                            if (rh.res_product_insert(txtName.Text, qty, reorder, txtPrice.Text, "", pbImage.ImageLocation))
                                result = DialogResult.Yes; this.Close();
                        }
                    }
                    else
                    {
                        rh.alert("Notification: ", "Please do not leave empty either\nproduct name or product price.", "information");
                    }
                    break;

                case "btnNo":
                    result = DialogResult.No; this.Close();
                    break;

                case "pbImage":
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Title = "Choose your product image";
                    ofd.Filter = "All Files|*.jpg; *png";

                    if (ofd.ShowDialog() == DialogResult.OK)
                        pbImage.ImageLocation = ofd.FileName;
                    break;

                default:
                    // Add Category Pop Up
                    if (restaurant_category_add._Show() == DialogResult.Yes)
                    {
                        rh.alert("Notification: ", "Category added.", "information");
                        LoadCategory();
                    }
                    break;
            }
        }
        #endregion

        #region TextBox Data Validations
        private void textbox_keypress(object sender, KeyPressEventArgs e)
        {
            TextBox c = sender as TextBox;

            switch (c.Name)
            {
                case "txtQty":
                case "txtReorder":
                    if ((!char.IsDigit(e.KeyChar) || c.Text.Length >= 11) && e.KeyChar != 8)
                        e.Handled = true;
                    break;
                default:
                    if ((!char.IsDigit(e.KeyChar) || c.Text.Length >= 11) && (e.KeyChar != 8) && (e.KeyChar != '.' || c.Text.Contains(".")))
                        e.Handled = true;
                    break;
            }
        } 
        #endregion
    }
}
