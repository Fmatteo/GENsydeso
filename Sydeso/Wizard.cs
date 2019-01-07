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

        speech_helper speech = new speech_helper();
        general_helper x = new general_helper();
        database_helper db = new database_helper();
        restaurant_helper rh = new restaurant_helper();

        public Wizard()
        {
            speech.Speak("Greetings from System Development Solution, Welcome user.");
            InitializeComponent();
            speech.Speak("Before using the application, please tell us about you and your company. Simply, fill up the form below and hit next.");
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
                    groupBox2.BringToFront();
                    groupBox1.Enabled = !groupBox1.Enabled;

                    groupBox2.Enabled = !groupBox2.Enabled;

                    speech.CancelSpeaking();
                    speech.Speak("Now, select your business type and upload some logo if you have one.");
                }
                else
                {
                    speech.CancelSpeaking();
                    speech.Speak("Please input all the necessary fields to proceed.");
                    x.alert("Error: ", "Please fill up all required fields to proceed.", "danger");
                }
            }
            else if (groupBox2.Enabled == true)
            {
                if (cbBusinessType.SelectedIndex >= 0)
                {
                    groupBox3.BringToFront();
                    groupBox2.Enabled = !groupBox2.Enabled;

                    groupBox3.Enabled = !groupBox3.Enabled;

                    speech.CancelSpeaking();
                    speech.Speak("Finally, setup your own account to gain access and authority in the system.");
                }
                else
                {
                    speech.CancelSpeaking();
                    speech.Speak("Please provide the business type, the system needed it.");
                    x.alert("Error: ", "Please fill up all required fields to proceed.", "danger");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtUser.Text) && !string.IsNullOrWhiteSpace(txtPass.Text) && !string.IsNullOrWhiteSpace(txtFname.Text) && !string.IsNullOrWhiteSpace(txtLname.Text))
                {
                    try
                    {
                        db.account_insert(txtFname.Text, txtLname.Text, txtUser.Text, txtPass.Text);
                        rh.account_insert_privileges(txtUser.Text);
                        db.setup_config(txtCompanyName.Text, txtCompanyAddress.Text, txtCompanyPhone.Text, cbBusinessType.SelectedItem.ToString(), pbLogo.ImageLocation);
                        x.alert("Notification: ", "System configuration success.", "success");

                        speech.CancelSpeaking();
                        speech.SpeakFirst("That is all we need for now. Thank you for choosing System Development Solution as your partner in your business.");

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error: ");
                    }
                }
                else
                {
                    speech.CancelSpeaking();
                    speech.Speak("Please setup your account first before proceeding.");
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (groupBox2.Enabled == true)
            {
                speech.CancelSpeaking();
                speech.Speak("Please provide information about your company.");
                groupBox2.Enabled = !groupBox2.Enabled;

                groupBox1.BringToFront();
                groupBox1.Enabled = !groupBox1.Enabled;
                btnPrev.Enabled = !btnPrev.Enabled;
            }
            else
            {
                speech.CancelSpeaking();
                speech.Speak("Now, select your business type and upload some logo if you have one.");
                groupBox2.BringToFront();
                groupBox3.Enabled = !groupBox3.Enabled;

                groupBox2.Enabled = !groupBox2.Enabled;
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

        private void txtCompanyPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void pbEye_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '•')
            {
                txtPass.PasswordChar = '\0';
                pbEye.Image = Image.FromFile(Application.StartupPath + "/icons/icon_show.png");
            }
            else
            {
                txtPass.PasswordChar = '•';
                pbEye.Image = Image.FromFile(Application.StartupPath + "/icons/icon_hide.png");
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPass.Text))
            {
                pbEye.Visible = true;
            }
            else
            {
                pbEye.Visible = false;
            }
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose your logo";
            ofd.Filter = "PNG Files|*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbLogo.ImageLocation = ofd.FileName;
            }
        }
    }
}
