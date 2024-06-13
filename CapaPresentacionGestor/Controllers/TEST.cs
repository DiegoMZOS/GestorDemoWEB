using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TuNamespace
{
    public class TuClase
    {
        public void EjemploConexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                    // Aquí podrías ejecutar consultas u otras operaciones en la base de datos.
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }
    }
}
