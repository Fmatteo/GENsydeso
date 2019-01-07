using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Sydeso
{
    class restaurant_helper
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        private void Connect()
        {
            con = new MySqlConnection("server=localhost; user=root; database=sydeso");
            con.Open();
        }

        private void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        public void account_insert_privileges(String user)
        {
            int id = Convert.ToInt32(account_get_user_details(user)[0]);
            Connect();
            cmd = new MySqlCommand("INSERT INTO restaurant_accounts_privileges(Account_ID, Dashboard, Products, Order_POS, Sales_Expenses, Tables, Employees, Customers, Accounts, History)values(@id, @dash, @prod, @order, @sales, @table, @emp, @cus, @acc, @his)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@dash", 1);
            cmd.Parameters.AddWithValue("@prod", 1);
            cmd.Parameters.AddWithValue("@order", 1);
            cmd.Parameters.AddWithValue("@sales", 1);
            cmd.Parameters.AddWithValue("@table", 1);
            cmd.Parameters.AddWithValue("@emp", 1);
            cmd.Parameters.AddWithValue("@cus", 1);
            cmd.Parameters.AddWithValue("@acc", 1);
            cmd.Parameters.AddWithValue("@his", 1);
            cmd.ExecuteNonQuery();
            Disconnect();
        }

        private List<String> _account_user_details;
        public List<String> account_get_user_details(String user)
        {
            _account_user_details = new List<string>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM system_accounts WHERE Username = @user", con);
            cmd.Parameters.AddWithValue("@user", user);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _account_user_details.Add(dr["ID"].ToString());
                _account_user_details.Add(dr["Firstname"].ToString());
                _account_user_details.Add(dr["Lastname"].ToString());
                _account_user_details.Add(dr["Username"].ToString());
            }
            dr.Close();

            Disconnect();
            return _account_user_details;
        }
    }
}
