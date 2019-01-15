using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

        public Boolean account_delete_privileges(String id)
        {
            Connect();
            cmd = new MySqlCommand("DELETE FROM restaurant_accounts_privileges WHERE Account_ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public Boolean account_update_privileges(String id, Boolean dash, Boolean prod, Boolean order, Boolean sales, Boolean tables, Boolean emp, Boolean cust, Boolean acc, Boolean his)
        {
            Connect();
            cmd = new MySqlCommand("UPDATE restaurant_accounts_privileges SET Dashboard = @dash, Products = @prod, Order_POS = @order, Sales_Expenses = @sales, Tables = @table, Employees = @emp, Customers = @cust, Accounts = @acc, History = @his WHERE Account_ID = @id", con);
            cmd.Parameters.AddWithValue("@dash", dash ? 1 : 0);
            cmd.Parameters.AddWithValue("@prod", prod ? 1 : 0);
            cmd.Parameters.AddWithValue("@order", order ? 1 : 0);
            cmd.Parameters.AddWithValue("@sales", sales ? 1 : 0);
            cmd.Parameters.AddWithValue("@table", tables ? 1 : 0);
            cmd.Parameters.AddWithValue("@emp", emp ? 1 : 0);
            cmd.Parameters.AddWithValue("@cust", cust ? 1 : 0);
            cmd.Parameters.AddWithValue("@acc", acc ? 1 : 0);
            cmd.Parameters.AddWithValue("@his", his ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        private List<Boolean> _account_privileges_detail;
        public List<Boolean> account_privileges_detail(String id)
        {
            _account_privileges_detail = new List<Boolean>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_accounts_privileges WHERE Account_ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _account_privileges_detail.Add(Convert.ToBoolean(dr[2])); // Dashboard up to..
                _account_privileges_detail.Add(Convert.ToBoolean(dr[3]));
                _account_privileges_detail.Add(Convert.ToBoolean(dr[4]));
                _account_privileges_detail.Add(Convert.ToBoolean(dr[5]));
                _account_privileges_detail.Add(Convert.ToBoolean(dr[6]));
                _account_privileges_detail.Add(Convert.ToBoolean(dr[7]));
                _account_privileges_detail.Add(Convert.ToBoolean(dr[8]));
                _account_privileges_detail.Add(Convert.ToBoolean(dr[9]));
                _account_privileges_detail.Add(Convert.ToBoolean(dr[10])); // History
            }
            dr.Close();
            Disconnect();
            return _account_privileges_detail;
        }

        public DataTable account_view(DataTable data, String id, String search, int page, int pageSize)
        {
            String query = "";

            if (pageSize != -1)
            {
                if (page == 1)
                {
                    query = "SELECT system_accounts.ID, system_accounts.Firstname, system_accounts.Lastname, restaurant_accounts_privileges.Dashboard, restaurant_accounts_privileges.Products, restaurant_accounts_privileges.Order_POS, restaurant_accounts_privileges.Sales_Expenses, restaurant_accounts_privileges.Tables, restaurant_accounts_privileges.Employees, restaurant_accounts_privileges.Customers, restaurant_accounts_privileges.Accounts, restaurant_accounts_privileges.History FROM system_accounts INNER JOIN restaurant_accounts_privileges ON system_accounts.ID = restaurant_accounts_privileges.Account_ID WHERE (system_accounts.Firstname LIKE @search OR system_accounts.Lastname LIKE @search OR system_accounts.ID LIKE @search) ORDER BY system_accounts.Firstname LIMIT " + pageSize;
                }
                else
                {
                    int prev = (page - 1) * pageSize;
                    query = "SELECT system_accounts.ID, system_accounts.Firstname, system_accounts.Lastname, restaurant_accounts_privileges.Dashboard, restaurant_accounts_privileges.Products, restaurant_accounts_privileges.Order_POS, restaurant_accounts_privileges.Sales_Expenses, restaurant_accounts_privileges.Tables, restaurant_accounts_privileges.Employees, restaurant_accounts_privileges.Customers, restaurant_accounts_privileges.Accounts, restaurant_accounts_privileges.History FROM system_accounts INNER JOIN restaurant_accounts_privileges ON system_accounts.ID = restaurant_accounts_privileges.Account_ID WHERE (system_accounts.Firstname LIKE @search OR system_accounts.Lastname LIKE @search OR system_accounts.ID LIKE @search) ORDER BY system_accounts.Firstname LIMIT " + prev + ", " + pageSize;
                }
            }
            else
            {
                query = "SELECT system_accounts.ID, system_accounts.Firstname, system_accounts.Lastname, restaurant_accounts_privileges.Dashboard, restaurant_accounts_privileges.Products, restaurant_accounts_privileges.Order_POS, restaurant_accounts_privileges.Sales_Expenses, restaurant_accounts_privileges.Tables, restaurant_accounts_privileges.Employees, restaurant_accounts_privileges.Customers, restaurant_accounts_privileges.Accounts, restaurant_accounts_privileges.History FROM system_accounts INNER JOIN restaurant_accounts_privileges ON system_accounts.ID = restaurant_accounts_privileges.Account_ID WHERE (system_accounts.Firstname LIKE @search OR system_accounts.Lastname LIKE @search OR system_accounts.ID LIKE @search) ORDER BY system_accounts.Firstname";
            }

            Connect();
            cmd = new MySqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@search", search + "%");
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                data.Rows.Add(new Object[] {
                    dr[0], dr[1] + " " + dr[2],
                    Convert.ToBoolean(dr[3]),
                    Convert.ToBoolean(dr[4]),
                    Convert.ToBoolean(dr[5]),
                    Convert.ToBoolean(dr[6]),
                    Convert.ToBoolean(dr[7]),
                    Convert.ToBoolean(dr[8]),
                    Convert.ToBoolean(dr[9]),
                    Convert.ToBoolean(dr[10]),
                    Convert.ToBoolean(dr[11])
                });
            }
            dr.Close();
            Disconnect();
            return data;
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

            double total = 0; int qty = 0;
            while (dr.Read())
            {
                qty = 0;
                if (!string.IsNullOrWhiteSpace(dr[2].ToString()))
                    qty = Convert.ToInt32(dr[2]);
                else
                    qty = 0;
                data.Rows.Add(new Object[] {
                    dr[0], dr[1], dr[2], dr[3], dr[5], hookDecimal(dr[4].ToString()), hookDecimal(FormatLabel1((Convert.ToDouble(qty) * Convert.ToDouble(dr[4]))))
                });

                total += Convert.ToDouble(qty) * Convert.ToDouble(dr[4]);
            }

            if (total != 0)
                data.Rows.Add("", "", "", "", "", "Grand Total: ", hookDecimal(FormatLabel1(Convert.ToDouble(total))));
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
                cmd.Parameters.AddWithValue("@image", imageToByteArray(ResizeImage(Image.FromFile(path), 252, 300)));

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

        public int res_table_available()
        {
            Connect();
            cmd = new MySqlCommand("SELECT COUNT(*) as available FROM restaurant_table WHERE Status = @status", con);
            cmd.Parameters.AddWithValue("@status", "VACANT");
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return Convert.ToInt32(dr["available"]);
            }
            Disconnect();
            return 0;
        }

        public int res_table_reserved()
        {
            Connect();
            cmd = new MySqlCommand("SELECT COUNT(*) as reserved FROM restaurant_table WHERE Status = @status", con);
            cmd.Parameters.AddWithValue("@status", "RESERVED");
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return Convert.ToInt32(dr["reserved"]);
            }
            Disconnect();
            return 0;
        }

        public int res_table_count()
        {
            Connect();
            cmd = new MySqlCommand("SELECT COUNT(*) as table_count FROM restaurant_table", con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return Convert.ToInt32(dr["table_count"]);
            }
            Disconnect();
            return 0;
        }
        #endregion

        #region restaurant_employees
        public Boolean res_emp_username_exist(String id, String user)
        {
            Connect();
            cmd = new MySqlCommand("SELECT Username FROM restaurant_employee WHERE Username = @user AND ID != @id", con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return true;
            }
            dr.Close();
            Disconnect();
            return false;
        }

        public Boolean res_emp_create(String fname, String lname, String user, String pass, String path)
        {
            if (res_emp_username_exist("0", user))
                return false;

            String query = "";

            if (!string.IsNullOrWhiteSpace(path))
                query = "INSERT INTO restaurant_employee(Firstname, Lastname, Username, Password, Image)values(@fname, @lname, @user, @pass, @image)";
            else
                query = "INSERT INTO restaurant_employee(Firstname, Lastname, Username, Password)values(@fname, @lname, @user, @pass)";

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", hashPass(pass));

            if (!string.IsNullOrWhiteSpace(path))
                cmd.Parameters.AddWithValue("@image", imageToByteArray(ResizeImage(Image.FromFile(path), 120, 135)));

            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        private List<restaurant_emp_detail> emp_details;
        public List<restaurant_emp_detail> res_emp_read(String search, int page, int pageSize)
        {
            emp_details = new List<restaurant_emp_detail>();

            String query = "";

            if (page != -1)
            {
                if (page == 1)
                {
                    query = "SELECT * FROM restaurant_employee WHERE ID Like @search OR Firstname LIKE @search OR Lastname LIKE @search ORDER BY Firstname LIMIT " + pageSize;
                }
                else
                {
                    int prev = (page - 1) * pageSize;
                    query = "SELECT * FROM restaurant_employee WHERE ID Like @search OR Firstname LIKE @search OR Lastname LIKE @search ORDER BY Firstname LIMIT " + prev + ", " + pageSize;
                }
            }
            else
            {
                query = "SELECT * FROM restaurant_employee WHERE ID Like @search OR Firstname LIKE @search OR Lastname LIKE @search ORDER BY Firstname";
            }
            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@search", search + "%");
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                restaurant_emp_detail list = new restaurant_emp_detail();
                list.emp_id = dr[0].ToString();
                list.emp_name = dr[1].ToString() + " " + dr[2].ToString();
                list.emp_user = dr[3].ToString();

                try
                {
                    list.emp_image = byteArrayToImage((byte[])dr[5]);
                }
                catch (Exception)
                {
                    list.emp_image = null;
                }
                emp_details.Add(list);
            }
            dr.Close();
            Disconnect();
            return emp_details;
        }

        public Boolean res_emp_update(String id, String fname, String lname, String user, String pass, String path)
        {
            if (res_emp_username_exist(id, user))
                return false;

            String query = "";

            if (!string.IsNullOrWhiteSpace(pass))
                query = "UPDATE restaurant_employee SET Firstname = @fname, Lastname = @lname, Username = @user, Password = @pass";
            else
                query = "UPDATE restaurant_employee SET Firstname = @fname, Lastname = @lname, Username = @user";

            if (!string.IsNullOrWhiteSpace(path))
                query += ", Image = @image";

            query += " WHERE ID = @id";

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@user", user);

            if (!string.IsNullOrWhiteSpace(pass))
                cmd.Parameters.AddWithValue("@pass", hashPass(pass));

            if (!string.IsNullOrWhiteSpace(path))
                cmd.Parameters.AddWithValue("@image", imageToByteArray(ResizeImage(Image.FromFile(path), 120, 135)));

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public Boolean res_emp_delete(String id)
        {
            Connect();
            cmd = new MySqlCommand("DELETE FROM restaurant_employee WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        private List<Object> emp_details_id;
        public List<Object> res_emp_read_id(String id)
        {
            emp_details_id = new List<Object>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_employee WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                restaurant_emp_detail list = new restaurant_emp_detail();

                emp_details_id.Add(dr[0]);
                emp_details_id.Add(dr[1]);
                emp_details_id.Add(dr[2]);
                emp_details_id.Add(dr[3]);

                try
                {
                    emp_details_id.Add(byteArrayToImage((byte[])dr[5]));
                }
                catch (Exception)
                {
                    emp_details_id.Add("");
                }
            }
            dr.Close();
            Disconnect();
            return emp_details_id;
        }

        public int res_emp_count()
        {
            Connect();
            cmd = new MySqlCommand("SELECT COUNT(*) as count_emp FROM restaurant_employee", con);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return Convert.ToInt32(dr[0]);
            }
            dr.Close();
            Disconnect();
            return 0;
        }
        #endregion

        #region restaurant_customers
        private Boolean res_cust_email_exist(String id, String email)
        {
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_customers WHERE Email_Address = @email AND ID != @id", con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                alert("Error: ", "Email is already in use.\nPlease pick another one.", "danger");
                return true;
            }
            dr.Close();
            Disconnect();
            return false;
        }

        public Boolean res_cust_create(String name, String bday, String num, String email)
        {
            if (res_cust_email_exist("0", email))
                return false;

            Connect();
            cmd = new MySqlCommand("INSERT INTO restaurant_customers(Name, Birthdate, Phone_Number, Email_Address)values(@name, @bday, @num, @email)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@bday", Convert.ToDateTime(bday));
            cmd.Parameters.AddWithValue("@num", num);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Creating record of a customer successfully.", "information");
            return true;
        }

        public DataTable res_cust_read(DataTable data, String search, int page, int pageSize)
        {
            String query = "";

            if (page != -1)
            {
                if (page == 1)
                {
                    query = "SELECT * FROM restaurant_customers WHERE ID Like @search OR Name Like @search OR Email_Address Like @search ORDER BY Name LIMIT " + pageSize;
                }
                else
                {
                    int prev = (page - 1) * pageSize;
                    query = "SELECT * FROM restaurant_customers WHERE ID Like @search OR Name Like @search OR Email_Address Like @search ORDER BY Name LIMIT " + prev + ", " + pageSize;
                }
            }
            else
            {
                query = "SELECT * FROM restaurant_customers WHERE ID Like @search OR Name Like @search OR Email_Address Like @search ORDER BY Name";
            }
            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@search", search + "%");
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                data.Rows.Add(new Object[] {
                    dr[0], dr[1], Convert.ToDateTime(dr[2]).ToString("MMMM dd, yyyy"), dr[3], dr[4]
                });
            }
            dr.Close();
            Disconnect();
            return data;
        }

        private List<String> _res_cust_read_id;
        public List<String> res_cust_read_id(String id)
        {
            _res_cust_read_id = new List<String>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_customers WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _res_cust_read_id.Add(dr[0].ToString());
                _res_cust_read_id.Add(dr[1].ToString());
                _res_cust_read_id.Add(dr[2].ToString());
                _res_cust_read_id.Add(dr[3].ToString());
                _res_cust_read_id.Add(dr[4].ToString());
            }
            dr.Close();
            Disconnect();
            return _res_cust_read_id;
        }

        public Boolean res_cust_update(String id, String name, String bday, String num, String email)
        {
            if (res_cust_email_exist(id, email))
                return false;

            Connect();
            cmd = new MySqlCommand("UPDATE restaurant_customers SET Name = @name, Birthdate = @bday, Phone_Number = @num, Email_Address = @email WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@bday", Convert.ToDateTime(bday));
            cmd.Parameters.AddWithValue("@num", num);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Updating an existing customer record successfully.", "information");
            return true;
        }

        public Boolean res_cust_delete(String id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                alert("Error: ", "Please specify the product you want to modify.\nSelect first a product then try again.", "danger");
                return false;
            }

            Connect();
            cmd = new MySqlCommand("DELETE FROM restaurant_customers WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Deleting a customer record successfully.", "information");
            return true;
        }
        #endregion

        #region restaurant_tables
        private Boolean res_table_name_exists(String id, String name)
        {
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_table WHERE Name = @name AND ID != @id", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                alert("Error: ", "Table name is already existing.\nPlease pick another one.", "danger");
                return true;
            }
            dr.Close();
            Disconnect();
            return false;
        }

        public Boolean res_table_create(String name, String desc)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(desc))
            {
                alert("Error: ", "Please fill up all required fields to proceed.", "danger");
                return false;
            }
            if (res_table_name_exists("0", name))
                return false;

            Connect();
            cmd = new MySqlCommand("INSERT INTO restaurant_table(Name, Description, Status)VALUES(@name, @desc, @status)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@status", "VACANT");
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Creating table record successfully.", "information");
            return true;
        }

        public DataTable res_table_read(DataTable data, String search, int page, int pageSize)
        {
            String query = "";

            if (page != -1)
            {
                if (page == 1)
                {
                    query = "SELECT * FROM restaurant_table WHERE ID LIKE @search OR Description LIKE @search OR Status LIKE @search ORDER BY ID LIMIT " + pageSize;
                }
                else
                {
                    int prev = (page - 1) * pageSize;
                    query = "SELECT * FROM restaurant_table WHERE ID LIKE @search OR Description LIKE @search OR Status LIKE @search ORDER BY ID LIMIT " + prev + ", " + pageSize;

                }
            }
            else
            {
                query = "SELECT * FROM restaurant_table WHERE ID LIKE @search OR Description LIKE @search OR Status LIKE @search ORDER BY ID";
            }

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@search", search + "%");
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                data.Rows.Add(new Object[] {
                    dr[0], dr[1], dr[2], dr[3]
                });
            }
            dr.Close();
            Disconnect();

            return data;
        }

        private List<String> _res_table_read_id;
        public List<String> res_table_read_id(String id)
        {
            _res_table_read_id = new List<String>();
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_table WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _res_table_read_id.Add(dr[0].ToString());
                _res_table_read_id.Add(dr[1].ToString());
                _res_table_read_id.Add(dr[2].ToString());
                _res_table_read_id.Add(dr[3].ToString());
            }
            dr.Close();
            Disconnect();
            return _res_table_read_id;
        }

        public Boolean res_table_update(String id, String name, String desc)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(desc))
            {
                alert("Error: ", "Please fill up all required fields to proceed.", "danger");
                return false;
            }

            if (res_table_name_exists(id, name))
                return false;

            Connect();
            cmd = new MySqlCommand("UPDATE restaurant_table SET Name = @name, Description = @desc WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Updating table record successfully.", "information");
            return true;
        }

        public Boolean res_table_delete(String id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                alert("Error: ", "Please specify the table you want to modify.\nSelect first a table then try again.", "danger");
                return false;
            }

            Connect();
            cmd = new MySqlCommand("DELETE FROM restaurant_table WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Deleting table record successfully.", "information");
            return true;
        }

        private DataTable _res_table_read_details_occupied;
        public DataTable res_table_read_details_occupied(String id)
        {
            _res_table_read_details_occupied = new DataTable();
            _res_table_read_details_occupied.Columns.Add("Order ID");
            _res_table_read_details_occupied.Columns.Add("Order Customer Name");
            _res_table_read_details_occupied.Columns.Add("Order Qty");
            _res_table_read_details_occupied.Columns.Add("Order Price");
            _res_table_read_details_occupied.Columns.Add("Order Total");

            Connect();
            cmd = new MySqlCommand("SELECT restaurant_order.ID, restaurant_order.Customer_Name, restaurant_order_details.Product_Name, restaurant_order_details.Qty, restaurant_order_details.Price, restaurant_order_details.Qty * restaurant_order_details.Price as Total FROM restaurant_order INNER JOIN restaurant_order_details ON restaurant_order.ID = restaurant_order_details.Order_ID WHERE restaurant_order.Table_ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                _res_table_read_details_occupied.Rows.Add(new Object[] {
                    dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()
                }); 
            }
            dr.Close();
            Disconnect();
            return _res_table_read_details_occupied;
        }

        private DataTable _res_table_read_details_reserved;
        public DataTable res_table_read_details_reserved(String id)
        {
            _res_table_read_details_reserved = new DataTable();
            _res_table_read_details_reserved.Columns.Add("Table ID");
            _res_table_read_details_reserved.Columns.Add("Table Name");
            _res_table_read_details_reserved.Columns.Add("Table Description");
            _res_table_read_details_reserved.Columns.Add("Customer Name");
            _res_table_read_details_reserved.Columns.Add("Date of Reservation");

            Connect();
            cmd = new MySqlCommand("SELECT restaurant_table.ID, restaurant_table.Name, restaurant_table.Description, restaurant_table_booking.Customer_Name, restaurant_table_booking.Date FROM restaurant_table INNER JOIN restaurant_table_booking ON restaurant_table.ID = restaurant_table_booking.Table_ID WHERE restaurant_table.ID = @id ORDER BY Date", con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                _res_table_read_details_reserved.Rows.Add(new Object[] {
                    dr[0], dr[1], dr[2], dr[3], Convert.ToDateTime(dr[4]).ToString("MMMM dd, yyyy")
                });
            }
            dr.Close();
            Disconnect();

            return _res_table_read_details_reserved;
        }

        #region Reservation

        private Boolean res_table_reserve_exists(String id, String date)
        {
            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_table_booking WHERE Table_ID = @id AND Date = @date", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@date", date);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                alert("Notification: ", "This table is already reserved for this day.", "information");
                return true;
            }
            dr.Close();
            Disconnect();
            return false;
        }

        public Boolean res_table_reserve(String id, String name, String date)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(date))
            {
                alert("Error: ", "Please fill up all the required fields to proceed.", "danger");
                return false;
            }

            if (res_table_reserve_exists(id, date))
            {
                return false;
            }
            string[] cust_detail = name.Split(':');

            Connect();
            cmd = new MySqlCommand("INSERT INTO restaurant_table_booking(Table_ID, Customer_ID, Customer_Name, Date)VALUES(@tid, @cid, @cname, @date)", con);
            cmd.Parameters.AddWithValue("@tid", id);
            cmd.Parameters.AddWithValue("@cid", cust_detail[0].Trim());
            cmd.Parameters.AddWithValue("@cname", name.Replace(cust_detail[0] + ": ", "").Trim());
            cmd.Parameters.AddWithValue("@date", date);
            cmd.ExecuteNonQuery();
            Disconnect();

            Connect();
            cmd = new MySqlCommand("UPDATE restaurant_table SET Status = @status WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@status", "RESERVED");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();

            alert("Notification: ", "Reserving a table successfully.", "information");
            return true;
        }

        private List<String> cust;
        public List<String> res_table_get_customer()
        {
            cust = new List<String>();
            Connect();
            cmd = new MySqlCommand("SELECT ID, Name FROM restaurant_customers", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cust.Add(dr[0].ToString() + ": " + dr[1].ToString());
            }
            dr.Close();
            Disconnect();
            return cust;
        }

        private DataTable _res_table_get_reservation;
        public DataTable res_table_get_reservation(String search)
        {
            _res_table_get_reservation = new DataTable();
            _res_table_get_reservation.Columns.Add("ID");
            _res_table_get_reservation.Columns.Add("Table ID");
            _res_table_get_reservation.Columns.Add("Customer ID");
            _res_table_get_reservation.Columns.Add("Customer Name");
            _res_table_get_reservation.Columns.Add("Date of Reservation");

            Connect();
            cmd = new MySqlCommand("SELECT * FROM restaurant_table_booking WHERE Customer_Name LIKE @search OR MONTHNAME(Date) LIKE @search ORDER BY Date", con);
            cmd.Parameters.AddWithValue("@search", search + "%");
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                String id = "";

                if (dr[1].ToString() == "0")
                    id = "N/A";
                else
                    id = dr[1].ToString();

                _res_table_get_reservation.Rows.Add(new Object[] {
                    dr[0], id, dr[2], dr[3], Convert.ToDateTime(dr[4]).ToString("MMMM dd, yyyy")
                });
            }
            dr.Close();
            Disconnect();
            return _res_table_get_reservation;
        }

        public Boolean res_table_cancel_reservation(String id, String tid)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                alert("Error: ", "Please specify the table you want to modify.\nSelect first a table then try again.", "danger");
                return false;
            }

            Connect();
            cmd = new MySqlCommand("DELETE FROM restaurant_table_booking WHERE ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Disconnect();

            int count = 0;
            Connect();
            cmd = new MySqlCommand("SELECT COUNT(*) as row FROM restaurant_table_booking WHERE Table_ID = @tid", con);
            cmd.Parameters.AddWithValue("@tid", tid);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                count = Convert.ToInt32(dr["row"]);
            }
            Disconnect();

            if (count == 0)
            {
                Connect();
                cmd = new MySqlCommand("UPDATE restaurant_table SET Status = @status WHERE ID = @tid", con);
                cmd.Parameters.AddWithValue("@status", "VACANT");
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.ExecuteNonQuery();
                Disconnect();
            }

            alert("Notification: ", "Cancellation of Reservatin successfully.", "information");
            return true;
        }

        #endregion
        #endregion

        #region restaurant_pos

        private List<restaurant_prod_detail> _prod;
        public List<restaurant_prod_detail> res_pos_get_prod(String search, String cat)
        {
            _prod = new List<restaurant_prod_detail>();
            String query = "SELECT * FROM restaurant_products WHERE Name LIKE @search";

            if (cat != "ALL")
                query += " AND Category = @cat";

            query += " ORDER BY Name";

            Connect();
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@search", search + "%");

            if (cat != "ALL")
                cmd.Parameters.AddWithValue("@cat", cat);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                restaurant_prod_detail list = new restaurant_prod_detail();
                list.Product_ID = Convert.ToInt32(dr[0]);
                list.Product_Name = dr[1].ToString();
                list.Product_Price = hookDecimal(dr[4].ToString());

                try
                {
                    list.Product_Image = byteArrayToImage((byte[])dr[6]);
                }
                catch (Exception)
                {
                    list.Product_Image = Image.FromFile(Application.StartupPath + "/icons/icon_unknown.png");
                }
                _prod.Add(list);
            }
            dr.Close();
            Disconnect();

            return _prod;
        }

        #endregion
    }
}
