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
            con = new MySqlConnection("server=localhost; user=root; database=sydeso");
            con.Open();
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
                cmd.Parameters.AddWithValue("@image", File.ReadAllBytes(path));

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
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
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
    }
}
