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
    public partial class Notification : Form
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

        public Notification(String title, String message, String message_type)
        {
            InitializeComponent();

            lblTitle.Text = title;
            lblMessage.Text = message;

            switch (message_type)
            {
                case "information":
                    pbIcon.Image = Image.FromFile(Application.StartupPath + "/icons/icon_information.png");
                    this.pnlParent.BackColor = Color.FromArgb(108, 117, 125);
                    break;
                case "success":
                    pbIcon.Image = Image.FromFile(Application.StartupPath + "/icons/icon_success.png");
                    this.pnlParent.BackColor = Color.FromArgb(40, 167, 69);
                    break;
                case "danger":
                    pbIcon.Image = Image.FromFile(Application.StartupPath + "/icons/icon_danger.png");
                    this.pnlParent.BackColor = Color.FromArgb(220, 53, 69);
                    break;
                default: break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height - 60;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;

            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
