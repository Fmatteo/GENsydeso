
using System.Windows.Forms;

namespace Sydeso
{
    public class CustomFlowPanel : FlowLayoutPanel
    {
        public CustomFlowPanel()
        {
            this.DoubleBuffered = true;
            this.Resize += CustomFlowPanel_Resize;
        }

        private void CustomFlowPanel_Resize(object sender, System.EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                c.Width = this.Width;
            }
        }
    }
}
