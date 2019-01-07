using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sydeso
{
    class BorderedPanel : Panel
    {
        public BorderedPanel()
        {
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.Padding = new Padding(2);
            this.Resize += new EventHandler(Refresh);
        }

        private Color _borderColor;
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        private void Refresh(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.Clear(SystemColors.Window);
            using (Pen borderPen = new Pen(_borderColor))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
            }
            base.OnPaint(e);
        }
    }
}