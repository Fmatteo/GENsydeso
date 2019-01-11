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
    public partial class restaurant_emp_detail : UserControl
    {
        public restaurant_emp_detail()
        {
            InitializeComponent();
        }

        private String _id;

        public String emp_id
        {
            get { return _id; }
            set { _id = value; this.lblID.Text = value; }
        }

        private String _name;

        public String emp_name
        {
            get { return _name; }
            set { _name = value; this.lblName.Text = value; this.lblName.Left = (this.ClientSize.Width - this.lblName.Width) / 2; }
        }

        private String _user;

        public String emp_user
        {
            get { return _user; }
            set { _user = value; this.lblUser.Text = value; this.lblUser.Left = (this.ClientSize.Width - this.lblUser.Width) / 2; }
        }

        private Image _image;

        public Image emp_image
        {
            get { return _image; }
            set { _image = value; this.pbImage.Image = value; }
        }
    }
}
