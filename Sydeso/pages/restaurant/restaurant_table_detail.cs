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
    public partial class restaurant_table_detail : UserControl
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

        public restaurant_table_detail()
        {
            InitializeComponent();
        }

        private int _id;

        public int Table_ID
        {
            get { return _id; }
            set { _id = value; lblID.Text = value.ToString(); lblID.Left = (this.Width - lblID.Width) / 2; }
        }

        private String _name;

        public String Table_Name
        {
            get { return _name; }
            set { _name = value; lblName.Text = value; lblName.Left = (this.Width - lblName.Width) / 2; }
        }

        private String _desc;

        public String Table_Desc
        {
            get { return _desc; }
            set { _desc = value; lblDesc.Text = value; lblDesc.Left = (this.Width - lblDesc.Width) / 2; }
        }

        private String _status;

        public String Table_Status
        {
            get { return _status; }
            set
            {
                _status = value;
                lblStatus.Text = value;
                if (value != "VACANT")
                {
                    if (value == "OCCUPIED")
                    {
                        this.BackColor = Color.Teal;
                        this.pbImage.Image = Image.FromFile(Application.StartupPath + "/icons/icon_table_white.png");

                        foreach (Control c in borderedPanel1.Controls)
                            if (c is Label)
                                c.ForeColor = Color.White;
                    }
                    else
                    {
                        this.BackColor = Color.Yellow;
                        this.pbImage.Image = Image.FromFile(Application.StartupPath + "/icons/icon_table_black.png");

                        foreach (Control c in borderedPanel1.Controls)
                            if (c is Label)
                                c.ForeColor = Color.Black;
                    }
                }
                lblStatus.Left = (this.Width - lblStatus.Width) / 2;
            }
        }
    }
}
