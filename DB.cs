using MySql.Data.MySqlClient;


namespace ulugbek_csharp {
    internal class DB {

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=project_database");

        public void openConnection() {
            if (connection.State == System.Data.ConnectionState.Closed) {
                connection.Open(); //open connection with database
            }
        }

        public void closeConnection() {
            if (connection.State == System.Data.ConnectionState.Open) {
                connection.Close(); //close connection with database
            }
        }

 
        public MySqlConnection getConnection() {
            return connection;
        }
    }
}
