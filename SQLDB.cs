using System;

using System.Collections.Generic;

using System.Text;

using System.Diagnostics;

using System.IO;

using System.Data;

using System.data.sqlclient

namespace SQLDB_byJAL
{

    public class Connect

    {

        Log log = new Log();//desative ou use o meu Log mais atualizado.

        

        private SqlConnection connection;

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

            connection = new SqlConnection(connectionString);            

        }

        

        public bool Open()

        {

            try

            {

                connection.Open();

                return true;

            }

            catch (SqlException ex)

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

            using (SqlConnection connection = new SqlConnection(string.Format("SERVER={0}; UID={1}; PASSWORD={2}; DATABASE={3};", server,uid,password,database)))
            {

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = new SqlCommand(string.Format(query, args), connection);

                adapter.Fill(ds);

                connection.Close();

            }

        }

    }

}
