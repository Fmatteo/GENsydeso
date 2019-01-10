using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;

namespace Sydeso
{
    class restaurant_helper : database_helper
    {
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

        public Boolean res_product_name_exist(String id, String name)
        {
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_products WHERE Name = @name AND ID != @id", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return true;
            }
            dr.Close();
            Disconnect();
            return false;
        }

        private List<Object> _res_product_detail;
        public List<Object> res_product_detail(String id)
        {
            _res_product_detail = new List<Object>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_products WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _res_product_detail.Add(dr["ID"]);
                _res_product_detail.Add(dr["Name"]);
                _res_product_detail.Add(dr["Qty"]);
                _res_product_detail.Add(dr["Reorder"]);
                _res_product_detail.Add(dr["Price"]);
                _res_product_detail.Add(dr["Category"]);

                try
                {
                    _res_product_detail.Add((Bitmap)Image.FromStream(new MemoryStream((System.Byte[])dr["Image"])));
                }
                catch (Exception)
                {
                    _res_product_detail.Add("");
                }
            }
            dr.Close();
            Disconnect();
            return _res_product_detail;
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

        public Boolean res_product_stock_in(String id, String qty)
        {
            List<Object> prod_details = res_product_detail(id);
            String query = "";
            if (!string.IsNullOrWhiteSpace(prod_details[2].ToString()))
                query = "UPDATE restaurant_products SET Qty = Qty + @qty WHERE ID = @id";
            else
                query = "UPDATE restaurant_products SET Qty = @qty, Reorder = @qty/2 WHERE ID = @id";

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(qty));
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public Boolean res_product_stock_out(String id, String name, String qty, String price, String total, String remark)
        {
            Connect();
            cmd = new MySqlCommand("INSERT INTO restaurant_stock_out(Name, Qty, Price, Total, Remark)values(@name, @qty, @price, @total, @remark)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@remark", remark);
            cmd.ExecuteNonQuery();
            Disconnect();

            Connect();
            cmd = new MySqlCommand("UPDATE restaurant_products SET Qty = Qty - @qty WHERE ID = @id", con);
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

        #region restaurant_dashboard
        public int res_stock_reorder()
        {
            Connect();
            cmd = new MySqlCommand("SELECT COUNT(*) as reorder FROM restaurant_products WHERE Qty <= Reorder", con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return Convert.ToInt32(dr["reorder"]);
            }
            dr.Close();
            Disconnect();
            return 0;
        }

        public int res_stock_empty()
        {
            Connect();
            cmd = new MySqlCommand("SELECT COUNT(*) as empty FROM restaurant_products WHERE Qty = 0", con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return Convert.ToInt32(dr["empty"]);
            }
            dr.Close();
            Disconnect();
            return 0;
        }
        #endregion
    }
}
