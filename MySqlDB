using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


namespace MySQLDB_byJAL
{
    public class Connect
    {
        Log log = new Log();//desative ou use o meu Log mais atualizado.
        
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "DbTeste";
        private string uid = "root"
        private string password = "root";
        public string connectionString;
        public bool Connected = false;

        public Connect()
        {
            Init();
            Connected = true;
        }
        
        public void Init()
        {        
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);            
        }
        
        public bool Open()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        log.Warn("Cannot connect to server.  Contact administrator");

                        break;

                    case 1045:
                        log.Warn("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        
        private bool Close()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                log.Write("",ex);
                return false;
            }
        }

        public void Exec(DataSet ds,string query,params object[] args)
        {
            using (MySqlConnection connection = new MySqlConnection(string.Format("SERVER={0}; UID={1}; PASSWORD={2}; DATABASE={3};", configserver.server, configserver.uid, configserver.password, configserver.database)))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(string.Format(query, args), connection);
                adapter.Fill(ds);
                connection.Close();
            }
        }
    }
}
