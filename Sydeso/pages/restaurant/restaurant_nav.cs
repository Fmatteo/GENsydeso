using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sydeso
{
    public partial class restaurant_nav : UserControl
    {
        public restaurant_nav()
        {
            InitializeComponent();
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            if (this.Width == this.MaximumSize.Width)
            {
                this.Visible = false;
                this.Width = this.MinimumSize.Width;
                pnlAnimator.ShowSync(this);
            }
            else
            {
                this.Visible = false;
                this.Width = this.MaximumSize.Width;
                pnlAnimator.ShowSync(this);
            }
        }
    }
}
