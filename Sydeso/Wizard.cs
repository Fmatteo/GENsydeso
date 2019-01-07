using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Sydeso
{
    public partial class Wizard : Form
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

        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        public Wizard()
        {
            speechSynthesizer.SpeakAsync("Greetings from System Development Solution, Welcome user.");
            InitializeComponent();
            speechSynthesizer.SpeakAsync("Before using the application, please tell us about you and your company. Simply, fill up the form below and hit next.");
        }

        private void Wizard_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true)
            {
                if (!string.IsNullOrWhiteSpace(txtCompanyName.Text) && !string.IsNullOrWhiteSpace(txtCompanyAddress.Text) && !string.IsNullOrWhiteSpace(txtCompanyPhone.Text))
                {
                    btnPrev.Enabled = !btnPrev.Enabled;
                    groupBox1.SendToBack();
                    groupBox1.Enabled = !groupBox1.Enabled;

                    groupBox2.Enabled = !groupBox2.Enabled;
                    speechSynthesizer.SpeakAsync("Now, select your business type and upload some logo if you have one.");
                }
                else
                {
                    speechSynthesizer.SpeakAsyncCancelAll();
                    speechSynthesizer.SpeakAsync("Please input all the necessary fields to proceed.");
                    MessageBox.Show("Please input all required fields to proceed", "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (cbBusinessType.SelectedIndex >= 0)
                {
                    speechSynthesizer.SpeakAsync("That is all we need for now. Thank you!");
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (groupBox2.Enabled == true)
            {
                groupBox2.SendToBack();
                groupBox2.Enabled = !groupBox2.Enabled;

                groupBox1.Enabled = !groupBox1.Enabled;
                btnPrev.Enabled = !btnPrev.Enabled;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the installation process?", "Notice: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #region Draggable Form
        private bool move;
        private Point lastPoint;
        private void Wizard_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            lastPoint = e.Location;
        }

        private void Wizard_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.Location = new Point((this.Location.X - lastPoint.X) + e.X, (this.Location.Y - lastPoint.Y) + e.Y);
            }
        }

        private void Wizard_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        } 
        #endregion
    }
}
