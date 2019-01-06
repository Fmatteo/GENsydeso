using MySql.Data.MySqlClient;

namespace Sydeso
{
    public class database_helper
    {
        public MySqlConnection con;

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
    }
}
