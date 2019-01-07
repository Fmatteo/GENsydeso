using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sydeso
{
    public class general_helper
    {
        Notification notif = null;

        public void alert(String title, String message, String type)
        {
            if (notif == null)
            {
                notif = new Notification(title, message, type);
                notif.FormClosed += Notif_FormClosed;
                notif.Show();
            }
        }

        private void Notif_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            notif = null;
        }
    }
}
