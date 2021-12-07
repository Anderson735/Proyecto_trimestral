using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_trimestral.Models
{
    public class DataBase
    {
        MySqlConnection connection;

        public DataBase()
        {
            connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=Dragon77;database=pt2;");
        }

        public string consultaSQL(string sql)
        {
            string resultado = "";

            try
            {
                connection.Open();

                MySqlCommand comand = new MySqlCommand(sql, connection);
                int resultCount = comand.ExecuteNonQuery();

                if (resultCount > -1)
                {
                    resultado = "Correcto";
                }
                else
                {
                    resultado = "Incorrecto";

                }

                connection.Close();
            }
            catch
            {
                resultado = "Error";
            }

            return resultado;
        }
        

        public DataTable getTabla(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);

                connection.Close();
                adapter.Dispose();
            }
            catch
            {
                dt = null;
            }


            return dt;
        }

    }
}
