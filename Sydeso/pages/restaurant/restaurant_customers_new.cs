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
    public partial class restaurant_customer_create : Form
    {
        public restaurant_customer_create()
        {
            InitializeComponent();
        }

        static restaurant_customer_create add; static DialogResult result = DialogResult.No;

        public static DialogResult _Show()
        {
            add = new restaurant_customer_create();
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
    }
}
