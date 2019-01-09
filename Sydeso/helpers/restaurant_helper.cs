using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Sydeso
{
    class restaurant_helper : database_helper
    {
        /*private MySqlConnection con;
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
        }*/

        #region restaurant_accounts
        public void account_insert_privileges(String user)
        {
            int id = Convert.ToInt32(account_details(user)[0]);
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
        #endregion

        #region restaurant_products
        public DataTable res_product_view(DataTable data, String search, int page, int pageSize)
        {
            String query = "";
            if (pageSize != -1)
            {
                if (page == 1)
                {
                    query = "SELECT * FROM restaurant_products WHERE ID Like @search OR Name LIKE @search OR Category LIKE @search ORDER BY Name LIMIT " + pageSize;
                }
                else
                {
                    int prev = (page - 1) * pageSize;
                    query = "SELECT * FROM restaurant_products WHERE ID Like @search OR Name LIKE @search OR Category LIKE @search ORDER BY Name LIMIT " + prev + ", " + pageSize;
                }
            }
            else
            {
                query = "SELECT * FROM restaurant_products WHERE ID Like @search OR Name LIKE @search OR Category LIKE @search ORDER BY Name";
            }

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.Add(new MySqlParameter("search", search + "%"));
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                data.Rows.Add(new Object[] {
                    dr[0], dr[1], dr[2], dr[3], hookDecimal(dr[4].ToString()), dr[5]
                });
            }
            return data;
        }
        
        public Boolean res_product_insert(String name, String qty, String reorder, String price, String cat, String path)
        {
            String query = "";

            if (string.IsNullOrWhiteSpace(path))
            {
                query = "INSERT INTO restaurant_products(Name, Qty, Reorder, Price, Category)values(@name, @qty, @reorder, @price, @cat)";
            }
            else
            {
                query = "INSERT INTO restaurant_products(Name, Qty, Reorder, Price, Category, Image)values(@name, @qty, @reorder, @price, @cat, @image)";
            }

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            // Checks if qty has value..
            if (!string.IsNullOrWhiteSpace(qty))
                cmd.Parameters.AddWithValue("@qty", qty);
            else // if do not have value insert null value
                cmd.Parameters.AddWithValue("@qty", null);
            // Checks if reorder has value..
            if (!string.IsNullOrWhiteSpace(reorder))
                cmd.Parameters.AddWithValue("@reorder", reorder);
            else // if do not have value insert null value
                cmd.Parameters.AddWithValue("@reorder", null);

            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@cat", cat);

            if (!string.IsNullOrWhiteSpace(path))
                cmd.Parameters.AddWithValue("@image", File.ReadAllBytes(path));

            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public Boolean res_product_update(String id, String name, String qty, String reorder, String price, String cat, String path)
        {
            String query = "";
            if (string.IsNullOrWhiteSpace(path))
            {
                query = "UPDATE restaurant_products SET Name = @name, Qty = @qty, Reorder = @reorder, Price = @price, Category = @cat WHERE ID = @id";
            }
            else
            {
                query = "UPDATE restaurant_products SET Name = @name, Qty = @qty, Reorder = @reorder, Price = @price, Category = @cat, Image = @image WHERE ID = @id";
            }

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@reorder", reorder);
            cmd.Parameters.AddWithValue("@price", hookDecimal(price));
            cmd.Parameters.AddWithValue("@cat", cat);

            if (!string.IsNullOrWhiteSpace(path))
                cmd.Parameters.AddWithValue("@image", File.ReadAllBytes(path));

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();

            return true;
        }

        /// <summary>
        /// Deletes the record with specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean res_product_delete(String id)
        {
            Connect();
            cmd = new MySqlCommand("DELETE FROM restaurant_products WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public Boolean res_product_stockin(String id, String qty)
        {
            Connect();
            cmd = new MySqlCommand("UPDATE restaurant_products SET Qty = @qty WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }
        #endregion

        #region restaurant_category
        public Boolean res_category_exist(String name)
        {
            Connect();
            cmd = new MySqlCommand("SELECT Name FROM restaurant_category WHERE Name = @name", con);
            cmd.Parameters.AddWithValue("@name", name);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            { return true; }
            dr.Close();
            Disconnect();
            return false;
        }

        public Boolean res_category_insert(String name)
        {
            Connect();
            cmd = new MySqlCommand("INSERT INTO restaurant_category(Name)values(@name)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        private List<String> _res_category_view;
        public List<String> res_category_view()
        {
            _res_category_view = new List<string>();
            Connect();
            cmd = new MySqlCommand("SELECT Name FROM restaurant_category", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                _res_category_view.Add(dr["Name"].ToString());
            }
            dr.Close();
            Disconnect();
            return _res_category_view;
        }
        #endregion
    }
}
