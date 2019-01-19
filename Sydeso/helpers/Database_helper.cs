using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Sydeso
{
    public class database_helper
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

        public MySqlConnection con;
        public MySqlCommand cmd;
        public MySqlDataReader dr;

        public void Connect()
        {
            /* try
             {
                 //con = new MySqlConnection("server=198.91.81.6; user=ilscodes_user123; password=password1234; database=ilscodes_test");
                 String conString = "SERVER=sql12.freesqldatabase.com; PORT=3306; DATABASE=sql12274214; UID=sql12274214; PASSWORD=FgzNGXisLd;";
                 con = new MySqlConnection();
                 con.ConnectionString = conString;
                 con.Open();
             }
             catch (Exception)
             {
                 alert("Error: ", "Please check your internet connection.\nCannot connect to the database.", "danger");
             }*/

            using (con = new MySqlConnection("server=localhost; user=root; database=sydeso"))
            {
                con.Open();
            }
        }

        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        public String hashPass(String pass)
        {
            MD5 md5 = MD5.Create();
            byte[] hashMD5 = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            String resultMD5 = BitConverter.ToString(hashMD5);

            SHA512 sha512 = SHA512.Create();
            byte[] hashSHA512 = sha512.ComputeHash(Encoding.UTF8.GetBytes(resultMD5));
            String resultSHA512 = BitConverter.ToString(hashSHA512).Replace("-", "");

            return resultSHA512;
        }

        #region System Accounts
        public Boolean account_insert(String fname, String lname, String user, String pass)
        {
            if (account_username_exist("0", user))
                return false;

            Connect();
            cmd = new MySqlCommand("INSERT INTO system_accounts(Firstname, Lastname, Username, Password)values(@fname, @lname, @user, @pass)", con);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", hashPass(pass));
            cmd.ExecuteNonQuery();
            Disconnect();

            return true;
        }

        public Boolean account_login(String user, String pass)
        {
            Connect();
            cmd = new MySqlCommand("SELECT * FROM system_accounts WHERE Username = @user AND Password = @pass", con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", hashPass(pass));
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return true;
            }
            dr.Close();
            Disconnect();
            return false;
        }

        /// <summary>
        /// Gets the account details...
        /// </summary>
        private List<String> _account_details;
        public List<String> account_details(String user)
        {
            _account_details = new List<string>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM system_accounts WHERE Username = @user", con);
            cmd.Parameters.AddWithValue("@user", user);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _account_details.Add(dr["ID"].ToString());
                _account_details.Add(dr["Firstname"].ToString());
                _account_details.Add(dr["Lastname"].ToString());
                _account_details.Add(dr["Username"].ToString());
            }
            dr.Close();
            Disconnect();
            return _account_details;
        }

        public Boolean account_update(String id, String fname, String lname, String user, String pass)
        {
            String query = "";
            if (account_username_exist(id, user))
                return false;

            if (!string.IsNullOrWhiteSpace(pass))
                query = "UPDATE system_accounts SET Firstname = @fname, Lastname = @lname, Username = @user, Password = @pass WHERE ID = @id";
            else
                query = "UPDATE system_accounts SET Firstname = @fname, Lastname = @lname, Username = @user WHERE ID = @id";

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@user", user);

            if (!string.IsNullOrWhiteSpace(pass))
                cmd.Parameters.AddWithValue("@pass", hashPass(pass));

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();

            return true;
        }

        public Boolean account_delete(String id)
        {
            Connect();
            cmd = new MySqlCommand("DELETE FROM system_accounts WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public Boolean account_username_exist(String id, String user)
        {
            Connect();
            cmd = new MySqlCommand("SELECT Username FROM system_accounts WHERE Username = @user AND ID != @id", con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            { return true; }
            dr.Close();
            Disconnect();
            return false;
        }

        private List<String> _account_details_by_id;
        public List<String> account_details_by_id(String id)
        {
            _account_details_by_id = new List<String>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM system_accounts WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _account_details_by_id.Add(dr["ID"].ToString());
                _account_details_by_id.Add(dr["Firstname"].ToString());
                _account_details_by_id.Add(dr["Lastname"].ToString());
                _account_details_by_id.Add(dr["Username"].ToString());
            }
            dr.Close();
            Disconnect();
            return _account_details_by_id;
        }
        #endregion

        #region System Config
        /// <summary>
        /// Check if the system undergone already with the setup
        /// </summary>
        /// <returns></returns>
        public Boolean setup()
        {
            Connect();
            cmd = new MySqlCommand("SELECT COUNT(*) as row_count FROM system_config", con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (Convert.ToInt32(dr["row_count"]) > 0)
                {
                    return true;
                }
            }
            Disconnect();
            return false;
        }

        public void updateVat(String vat)
        {
            Connect();
            cmd = new MySqlCommand("UPDATE system_config SET Vat = @vat WHERE ID = 1", con);
            cmd.Parameters.AddWithValue("@vat", vat);
            cmd.ExecuteNonQuery();
            Disconnect();
        }

        public String getVat()
        {
            Connect();
            cmd = new MySqlCommand("SELECT Vat FROM system_config WHERE ID = 1", con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return dr[0].ToString();
            }
            dr.Close();
            Disconnect();
            return "";
        }

        /// <summary>
        /// After the setup, save all the data from the user...
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="btype"></param>
        /// <param name="path"></param>
        public void setup_config(String name, String address, String phone, String btype, String path)
        {
            String query = "";
            if (string.IsNullOrWhiteSpace(path))
            {
                query = "INSERT INTO system_config(Company_Name, Company_Address, Company_Phone, Business_Type)values(@name, @add, @phone, @type)";
            }
            else
            {
                query = "INSERT INTO system_config(Company_Name, Company_Address, Company_Phone, Business_Type, Company_Logo)values(@name, @add, @phone, @type, @image)";
            }

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@add", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@type", btype);

            if (!string.IsNullOrWhiteSpace(path))
            {
                Image logo = Image.FromFile(path);
                Bitmap bmp = toWhiteScale((Bitmap)logo);
                
                cmd.Parameters.AddWithValue("@image", imageToByteArray((Image)bmp));
            }

            cmd.ExecuteNonQuery();
            Disconnect();
        }

        /// <summary>
        /// Get the details about the system configuration
        /// </summary>
        private List<Object> _get_setup_config;
        public List<Object> get_setup_config()
        {
            _get_setup_config = new List<Object>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM system_config", con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _get_setup_config.Add(dr["ID"]);
                _get_setup_config.Add(dr["Company_Name"]);
                _get_setup_config.Add(dr["Company_Address"]);
                _get_setup_config.Add(dr["Company_Phone"]);
                _get_setup_config.Add(dr["Business_Type"]);

                try
                {
                    _get_setup_config.Add((Bitmap)Image.FromStream(new MemoryStream((System.Byte[])dr["Company_Logo"])));
                }
                catch (Exception)
                {
                    _get_setup_config.Add("");
                }

                _get_setup_config.Add(dr["TIN"]);
            }
            dr.Close();
            Disconnect();

            return _get_setup_config;
        }
        #endregion

        #region General Functions
        public String hookDecimal(String str1)
        {
            String str = str1;
            if (!str.Contains("."))
            {
                str += ".00";
            }
            else
            {
                String[] number = str.Split('.');
                if (number[1].Length == 0)
                {
                    str = number[0] + ".00";
                }

                else if (number[1].Length == 1)
                {
                    str = number[0] + "." + number[1] + "0";
                }

                else
                {
                    str = number[0] + "." + number[1][0] + number[1][1];
                }
            }
            return str;
        }

        public String FormatLabel(int num)
        {
            String temp = String.Format("{0:n0}", num);
            return temp;
        }

        public String FormatLabel1(double num)
        {
            String temp = String.Format("{0:n0}", num);
            return temp;
        }

        public String formatCurrency(String text)
        {
            String newText = "", temp = "", dec = "";
            String[] split;

            if (text.Contains("."))
            {
                split = text.Split('.');
                temp = split[0];
                dec = split[1];
            }
            else
                temp = text;

            int count = 0;
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                newText += temp[i];
                count++;
                if (count == 3)
                {
                    count = 0;
                    if (i != 0)
                        newText += ",";
                }
            }

            temp = "";
            for (int j = newText.Length - 1; j >= 0; j--)
            {
                temp += newText[j];
            }

            if (text.Contains("."))
                temp += "." + dec;

            return temp;
        }

        private Bitmap toWhiteScale(Bitmap logo)
        {
            for (var i = 0; i < logo.Width; i++)
            {
                for (var j = 0; j < logo.Height; j++)
                {
                    var originalColor = logo.GetPixel(i, j);
                    var grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    var corEmEscalaDeCinza = Color.FromArgb(originalColor.A, 255, 255, 255);
                    logo.SetPixel(i, j, corEmEscalaDeCinza);
                }
            }

            return logo;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion

        #region DateTimeRecord
        private Boolean dtr_login(String user, String pass)
        {
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_employee WHERE Username = @user AND Password = @pass", con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", hashPass(pass));
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return true;
            }
            dr.Close();
            Disconnect();
            return false;
        }

        private String dtr_get_id_by_user(String user)
        {
            String id = "";
            Connect();
            cmd = new MySqlCommand("SELECT ID FROM restaurant_employee WHERE Username = @user", con);
            cmd.Parameters.AddWithValue("@user", user);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                id = dr[0].ToString();
            }
            dr.Close();
            Disconnect();
            return id;
        }

        private Boolean dtr_exists_time_in(String id, String date)
        {
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_employee_time_in_out WHERE Employee_ID = @id AND Date = @date", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@date", date);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return true;
            }
            dr.Close();
            Disconnect();
            return false;
        }

        public void dtr_time_in(String user, String pass)
        {
            if (!dtr_login(user, pass))
            {
                alert("Error: ", "Incorrect username or password.\nPlease try again.", "danger");
                return;
            }

            String id = dtr_get_id_by_user(user);
            String dateNow = DateTime.Now.ToString("yyyy-MM-dd");

            if (dtr_exists_time_in(id, dateNow))
            {
                alert("Error: ", "This account has already checked in for today.", "danger");
                return;
            } 
            
            Connect();
            cmd = new MySqlCommand("INSERT INTO restaurant_employee_time_in_out(Employee_ID, Timein, Date)VALUES(@id, @in, @date)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@in", DateTime.Now.ToString("hh:mm:ss tt"));
            cmd.Parameters.AddWithValue("@date", dateNow);
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Checking in successfully, have a nice day.", "success");
        }

        public void dtr_time_out(String user, String pass)
        {
            if (!dtr_login(user, pass))
            {
                alert("Error: ", "Incorrect username or password.\nPlease try again.", "danger");
                return;
            }

            String id = dtr_get_id_by_user(user);
            String dateNow = DateTime.Now.ToString("yyyy-MM-dd");

            if (!dtr_exists_time_in(id, dateNow))
            {
                alert("Error: ", "This account has not yet checked in for today.", "danger");
                return;
            }

            Connect();
            cmd = new MySqlCommand("UPDATE restaurant_employee_time_in_out SET Timeout = @out WHERE Employee_ID = @id AND Date = @date", con);
            cmd.Parameters.AddWithValue("@out", DateTime.Now.ToString("hh:mm:ss tt"));
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@date", dateNow);
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Checking out successfully, see you tomorrow.", "success");
        }

        public DataTable dtr_view(DataTable data, String startDate, String endDate, int page, int pageSize)
        {
            String query = "";

            if (pageSize != -1)
            {
                if (page == 1)
                {
                    query = "SELECT restaurant_employee.Firstname, restaurant_employee.Lastname, restaurant_employee_time_in_out.Timein, restaurant_employee_time_in_out.Timeout, restaurant_employee_time_in_out.Date FROM restaurant_employee INNER JOIN restaurant_employee_time_in_out ON restaurant_employee.ID = restaurant_employee_time_in_out.Employee_ID WHERE Date BETWEEN @start AND @end ORDER BY restaurant_employee_time_in_out.Date, restaurant_employee.Firstname LIMIT " + pageSize;
                }
                else
                {
                    int prev = (page - 1) * pageSize;
                    query = "SELECT restaurant_employee.Firstname, restaurant_employee.Lastname, restaurant_employee_time_in_out.Timein, restaurant_employee_time_in_out.Timeout, restaurant_employee_time_in_out.Date FROM restaurant_employee INNER JOIN restaurant_employee_time_in_out ON restaurant_employee.ID = restaurant_employee_time_in_out.Employee_ID WHERE Date BETWEEN @start AND @end ORDER BY restaurant_employee_time_in_out.Date, restaurant_employee.Firstname LIMIT " + prev + ", " + pageSize;
                }
            }
            else
            {
                query = "SELECT restaurant_employee.Firstname, restaurant_employee.Lastname, restaurant_employee_time_in_out.Timein, restaurant_employee_time_in_out.Timeout, restaurant_employee_time_in_out.Date FROM restaurant_employee INNER JOIN restaurant_employee_time_in_out ON restaurant_employee.ID = restaurant_employee_time_in_out.Employee_ID WHERE Date BETWEEN @start AND @end ORDER BY restaurant_employee_time_in_out.Date, restaurant_employee.Firstname";
            }

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@start", Convert.ToDateTime(startDate));
            cmd.Parameters.AddWithValue("@end", Convert.ToDateTime(endDate));
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                data.Rows.Add(new Object[] {
                    dr[0] + " " + dr[1], dr[2], dr[3], Convert.ToDateTime(dr[4]).ToString("MMMM dd, yyyy")
                });
            }
            dr.Close();
            Disconnect();
            return data;
        }
        #endregion

        #region Printing

        public void print_receipt(Graphics g, DataGridView dgv, String order_type, String acc_name, String invoice, String amountDue, String cash, String change, String disc, String discPerc, String vatExempt, String vat, String vatPerc, String cust_name)
        {
            List<Object> com_details = get_setup_config();
            String com_name = com_details[1].ToString();
            String com_add = com_details[2].ToString();
            String com_phone = com_details[3].ToString();
            String com_tin = com_details[6].ToString();

            Bitmap com_logo = database_helper.ResizeImage((Image)com_details[5], 100, 100);
            Bitmap logo = database_helper.ResizeImage(Image.FromFile(Application.StartupPath + "/icons/sydeso.png"), 100, 100);

            int pageWidth = 200;

            SolidBrush brush = new SolidBrush(Color.Black);

            Font font_12 = new Font("Courier New", 12);
            Font font_12B = new Font("Courier New", 12, FontStyle.Bold);

            int startX = 0;
            int startY = 10;
            int offSet = 40;

            g.DrawImage(toGrayScale(com_logo), ((pageWidth * 2 - 100) / 2), startY);
            startY += 100;

            g.DrawString(com_name, font_12B, brush, ((pageWidth - Measure(g, com_name, font_12B) / 2)), startY);
            startY += (int)font_12B.GetHeight();

            g.DrawString(com_add, font_12, brush, ((pageWidth - Measure(g, com_add, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Phone Number: " + com_phone, font_12, brush, ((pageWidth - Measure(g, "Phone Number: " + com_phone, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("TIN #: " + com_tin, font_12, brush, ((pageWidth - Measure(g, "TIN No.: " + com_tin, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            //g.DrawLine(Pens.Black, new Point(0, startY), new Point(pageWidth * 2, startY));
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //

            g.DrawString("SALES RECEIPT", font_12B, brush, ((pageWidth - Measure(g, "SALES RECEIPT", font_12B) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Sales Invoice No.: ", font_12, brush, startX, startY);
            g.DrawString(invoice, font_12, brush, (pageWidth * 2 - Measure(g, invoice, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Time Generated: ", font_12, brush, startX, startY);
            g.DrawString(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), font_12, brush, (pageWidth * 2 - Measure(g, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Cashier: ", font_12, brush, startX, startY);
            g.DrawString(acc_name.ToUpper(), font_12, brush, (pageWidth * 2 - Measure(g, acc_name.ToUpper(), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Order Type: ", font_12, brush, startX, startY);
            g.DrawString(order_type, font_12, brush, (pageWidth * 2 - Measure(g, order_type, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Payment Method: ", font_12, brush, startX, startY);
            g.DrawString("CASH", font_12, brush, (pageWidth * 2 - Measure(g, "CASH", font_12)), startY);
            startY += (int)font_12.GetHeight();

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("ITEM NAME", font_12B, brush, startX, startY);
            g.DrawString("AMOUNT", font_12B, brush, (pageWidth * 2 - Measure(g, "AMOUNT", font_12B)), startY);
            startY += (int)font_12.GetHeight();

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                String prod_name = dgv[1, i].Value.ToString();
                String qty = dgv[3, i].Value.ToString();
                String price = dgv[2, i].Value.ToString();
                String total = hookDecimal(dgv[4, i].Value.ToString());

                String detail = qty + "PC(s) @ " + hookDecimal(price);

                // Product name
                g.DrawString(prod_name, font_12, brush, startX, startY);

                startY += (int)font_12.GetHeight();
                g.DrawString(detail, font_12, brush, startX + offSet, startY);
                g.DrawString(total, font_12, brush, (pageWidth * 2 - Measure(g, total, font_12)), startY);

                startY += (int)font_12.GetHeight();
            }

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Amount Due: ", font_12, brush, startX, startY);
            g.DrawString(hookDecimal(amountDue), font_12, brush, (pageWidth * 2 - Measure(g, hookDecimal(amountDue), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Cash Tendered: ", font_12, brush, startX, startY);
            g.DrawString(hookDecimal(cash), font_12, brush, (pageWidth * 2 - Measure(g, hookDecimal(cash), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Change Due: ", font_12, brush, startX, startY);
            g.DrawString(hookDecimal(change), font_12, brush, (pageWidth * 2 - Measure(g, hookDecimal(change), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Discount: (" + hookDecimal(discPerc) + "%)", font_12, brush, startX, startY);
            g.DrawString(hookDecimal(disc), font_12, brush, (pageWidth * 2 - Measure(g, hookDecimal(disc), font_12)), startY);
            startY += (int)font_12.GetHeight();

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("VATable Sales: ", font_12, brush, startX, startY);
            g.DrawString(hookDecimal(amountDue), font_12, brush, (pageWidth * 2 - Measure(g, hookDecimal(amountDue), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("VAT Exempt Sales: ", font_12, brush, startX, startY);
            g.DrawString(hookDecimal(vatExempt), font_12, brush, (pageWidth * 2 - Measure(g, hookDecimal(vatExempt), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Zero-Rated Sales: ", font_12, brush, startX, startY);
            g.DrawString("0.00", font_12, brush, (pageWidth * 2 - Measure(g, "0.00", font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString(hookDecimal(vatPerc) + "% VAT Sales: ", font_12, brush, startX, startY);
            g.DrawString(hookDecimal(vat), font_12, brush, (pageWidth * 2 - Measure(g, hookDecimal(vat), font_12)), startY);
            startY += (int)font_12.GetHeight();

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Sold To: ", font_12, brush, startX, startY);
            g.DrawString(cust_name, font_12, brush, (pageWidth * 2 - Measure(g, cust_name, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("TIN No.: ", font_12, brush, startX, startY);
            g.DrawString("______________________", font_12, brush, (pageWidth * 2 - Measure(g, "______________________", font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Address: ", font_12, brush, startX, startY);
            g.DrawString("______________________", font_12, brush, (pageWidth * 2 - Measure(g, "______________________", font_12)), startY);
            startY += (int)font_12.GetHeight() + 10;

            // - >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LINE BREAK <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< - //
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Thank you for purchasing!", font_12B, brush, ((pageWidth - Measure(g, "Thank you for purchasing!", font_12B) / 2)), startY);
            startY += (int)font_12B.GetHeight() + 10;

            g.DrawString("Powered by: ", font_12B, brush, ((pageWidth - Measure(g, "Powered by: ", font_12B) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawImage(toGrayScale(logo), ((pageWidth * 2 - 100) / 2), startY);
            startY += 100;

            g.DrawString("System Development Solution", font_12, brush, ((pageWidth - Measure(g, "System Development Solution", font_12) / 2)), startY);
        }

        private int Measure(Graphics g, String text, Font font)
        {
            int size = (int)g.MeasureString(text, font).Width;
            return size;
        }

        private String insertLine(Graphics g, Font font, int size)
        {
            String line = "";
            while (true)
            {
                if ((int)g.MeasureString(line, font).Width < size * 2)
                {
                    line += "=";

                    if ((int)g.MeasureString(line, font).Width > size * 2)
                    {
                        line.Remove(0);
                        break;
                    }
                }
            }
            return line;
        }

        private Bitmap toGrayScale(Bitmap logo)
        {
            for (var i = 0; i < logo.Width; i++)
            {
                for (var j = 0; j < logo.Height; j++)
                {
                    var originalColor = logo.GetPixel(i, j);
                    var grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                    var corEmEscalaDeCinza = Color.FromArgb(originalColor.A, 0, 0, 0);
                    logo.SetPixel(i, j, corEmEscalaDeCinza);
                }
            }

            return logo;
        }

        public void print_order(Graphics g, DataGridView dgv, String acc_name, String order, String cus_name)
        {
            List<Object> com_details = get_setup_config();
            String com_name = com_details[1].ToString();
            String com_add = com_details[2].ToString();
            String com_phone = com_details[3].ToString();
            String com_tin = com_details[6].ToString();

            Bitmap com_logo = database_helper.ResizeImage((Image)com_details[5], 100, 100);
            Bitmap logo = database_helper.ResizeImage(Image.FromFile(Application.StartupPath + "/icons/sydeso.png"), 100, 100);

            int pageWidth = 200;

            SolidBrush brush = new SolidBrush(Color.Black);

            Font font_12 = new Font("Courier New", 12);
            Font font_12B = new Font("Courier New", 12, FontStyle.Bold);

            int startX = 0;
            int startY = 10;

            g.DrawImage(toGrayScale(com_logo), ((pageWidth * 2 - 100) / 2), startY);
            startY += 100;

            g.DrawString(com_name, font_12B, brush, ((pageWidth - Measure(g, com_name, font_12B) / 2)), startY);
            startY += (int)font_12B.GetHeight();

            g.DrawString(com_add, font_12, brush, ((pageWidth - Measure(g, com_add, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("Phone Number: " + com_phone, font_12, brush, ((pageWidth - Measure(g, "Phone Number: " + com_phone, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("TIN #: " + com_tin, font_12, brush, ((pageWidth - Measure(g, "TIN No.: " + com_tin, font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            //g.DrawLine(Pens.Black, new Point(0, startY), new Point(pageWidth * 2, startY));
            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("ORDER STUB", font_12B, brush, ((pageWidth - Measure(g, "ORDER STUB", font_12B) / 2)), startY);
            startY += (int)font_12B.GetHeight();

            g.DrawString("Time Generated: ", font_12, brush, startX, startY);
            g.DrawString(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), font_12, brush, (pageWidth * 2 - Measure(g, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("STUB NO.: ", font_12, brush, startX, startY);
            g.DrawString("000001", font_12, brush, (pageWidth * 2 - Measure(g, "000001", font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("ISSUED BY: ", font_12, brush, startX, startY);
            g.DrawString(acc_name, font_12, brush, (pageWidth * 2 - Measure(g, acc_name, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("ISSUED TO: ", font_12, brush, startX, startY);
            g.DrawString(cus_name, font_12, brush, (pageWidth * 2 - Measure(g, cus_name, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString("ORDER TYPE: ", font_12, brush, startX, startY);
            g.DrawString(order, font_12, brush, (pageWidth * 2 - Measure(g, order, font_12)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight();

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                String prod_name = dgv[1, i].Value.ToString();
                String qty = dgv[3, i].Value.ToString();

                // Product name
                g.DrawString(" - \t" + qty + "\t" + prod_name, font_12, brush, startX, startY);

                startY += (int)font_12.GetHeight();
            }

            g.DrawString(insertLine(g, font_12, pageWidth), font_12, brush, ((pageWidth - Measure(g, insertLine(g, font_12, pageWidth), font_12) / 2)), startY);
            startY += (int)font_12.GetHeight() + 10;

            g.DrawString("Powered by: ", font_12B, brush, ((pageWidth - Measure(g, "Powered by: ", font_12B) / 2)), startY);
            startY += (int)font_12.GetHeight();

            g.DrawImage(toGrayScale(logo), ((pageWidth * 2 - 100) / 2), startY);
            startY += 100;

            g.DrawString("System Development Solution", font_12, brush, ((pageWidth - Measure(g, "System Development Solution", font_12) / 2)), startY);
        }

        #endregion
    }
}
