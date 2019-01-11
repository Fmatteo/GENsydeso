﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    }
}
