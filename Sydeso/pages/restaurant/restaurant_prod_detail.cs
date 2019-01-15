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
    public partial class restaurant_prod_detail : UserControl
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

        public restaurant_prod_detail()
        {
            InitializeComponent();
        }

        private int _id;

        public int Product_ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _name;

        public String Product_Name
        {
            get { return _name; }
            set { _name = value; lblName.Text = value; lblName.Left = (lblName.Parent.Width - lblName.Width) / 2; }
        }

        private String _price;

        public String Product_Price
        {
            get { return _price; }
            set { _price = value; lblPrice.Text = value; lblPrice.Left = (lblPrice.Parent.Width - lblPrice.Width) / 2; }
        }

        private Image _image;

        public Image Product_Image
        {
            get { return _image; }
            set { _image = value; pbImage.Image = value; }
        }
    }
}
