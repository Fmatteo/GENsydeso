using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sydeso
{
    public class database_helper
    {
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

        public void account_insert(String fname, String lname, String user, String pass)
        {
            Connect();
            cmd = new MySqlCommand("INSERT INTO system_accounts(Firstname, Lastname, Username, Password)values(@fname, @lname, @user, @pass)", con);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", hashPass(pass));
            cmd.ExecuteNonQuery();
            Disconnect();
        }

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
    }
}
