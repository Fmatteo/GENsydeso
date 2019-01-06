using MySql.Data.MySqlClient;

namespace Sydeso
{
    class restaurant_helper : database_helper
    {
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        public void account_insert()
        {
            Connect();
            Disconnect();
        }
    }
}
