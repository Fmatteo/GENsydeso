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
    public partial class restaurant_employees_update : Form
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

        public restaurant_employees_update()
        {
            InitializeComponent();
        }

        static restaurant_employees_update update; static DialogResult result = DialogResult.No;
        static restaurant_helper rh = new restaurant_helper();
        static List<Object> list;

        public static DialogResult _Show(String id)
        {
            list = rh.res_emp_read_id(id);
            update = new restaurant_employees_update();
            update.txtFname.Text = list[1].ToString();
            update.txtLname.Text = list[2].ToString();
            update.txtUser.Text = list[3].ToString();

            if (!string.IsNullOrWhiteSpace(list[4].ToString()))
                update.pbImage.Image = (Image)list[4];

            update.ShowDialog();
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
                    if (!string.IsNullOrWhiteSpace(txtUser.Text) && !string.IsNullOrWhiteSpace(txtFname.Text) && !string.IsNullOrWhiteSpace(txtLname.Text))
                    {
                        if (rh.res_emp_update(list[0].ToString(), txtFname.Text, txtLname.Text, txtUser.Text, txtPass.Text, pbImage.ImageLocation))
                        {
                            result = DialogResult.Yes; this.Close();
                        }
                        else
                        {
                            txtUser.Focus();
                            rh.alert("Error: ", "Username already taken.\nPlease pick another one.", "danger");
                        }
                    }
                    else
                    {
                        rh.alert("Error: ", "Please fill up the required fields to proceed.", "danger");
                    }
                    break;

                case "btnNo":
                    result = DialogResult.No; this.Close();
                    break;
            }
        }
        #endregion

        #region Text Password Logics
        private void textbox_textchanged(object sender, EventArgs e)
        {
            Control c = sender as Control;

            if (!string.IsNullOrWhiteSpace(c.Text))
                pbEye.Visible = true;
            else
                pbEye.Visible = false;
        }

        private void pbEye_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '•')
            {
                txtPass.PasswordChar = '\0';
                pbEye.Image = Image.FromFile(Application.StartupPath + "/icons/icon_show_red.png");
            }
            else
            {
                txtPass.PasswordChar = '•';
                pbEye.Image = Image.FromFile(Application.StartupPath + "/icons/icon_hide_red.png");
            }
        }
        #endregion

        private void pbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose your logo";
            ofd.Filter = "All Files|*.png; *.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = ofd.FileName;
            }
        }
    }
}
