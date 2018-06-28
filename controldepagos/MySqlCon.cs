using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace controldepagos
{
    class MySqlCon
    {
        MySqlConnection connection;
        public bool CreateConnection()
        {
            string myConnectionstring = "server=localhost;uid=root;pwd=29.Mayo1972;database=pagos_colegio;";
            try
            {
                connection = new MySqlConnection(myConnectionstring);
                connection.Open();
                return true;
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }
        }

        public string Execute(string pQuery)
        {
            if (connection.State != ConnectionState.Open)
                CreateConnection();
            try
            {
                MySqlCommand myCommand = new MySqlCommand(pQuery, connection);
                myCommand.CommandType = CommandType.Text;
                string rows = myCommand.ExecuteScalar().ToString();
                return rows;

            }
            catch (Exception exc)
            {
                error = exc.Message;
                return "-1";
            }

        }

        public DataTable fillTable(string pQuery)
        {
            DataTable dt = new DataTable();
            if (connection.State != ConnectionState.Open)
                CreateConnection();
            try
            {
                MySqlCommand myCommand = new MySqlCommand(pQuery, connection);
                myCommand.CommandType = CommandType.Text;
                MySqlDataAdapter ad = new MySqlDataAdapter(myCommand);
                ad.Fill(dt);

            }
            catch (Exception exc)
            {
                error = exc.Message;

            }
            return dt;

        }

        public string error { get; set; }
    }
}