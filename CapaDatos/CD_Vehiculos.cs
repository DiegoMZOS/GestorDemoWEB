using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Vehiculo
    {
        public List<Vehiculos> Listar()
        {
            List<Vehiculos> lista = new List<Vehiculos>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT IdVehiculo, IdProveedor, CodigoVehiculo, TipoVehiculo, MotorVehiculo, MarcaVehiculo, FechaFabricacion, ColorVehiculo FROM VEHICULOS";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Vehiculos()
                            {
                                IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]),
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                CodigoVehiculo = Convert.ToInt32(dr["CodigoVehiculo"]),
                                TipoVehiculo = dr["TipoVehiculo"].ToString(),
                                MotorVehiculo = dr["MotorVehiculo"].ToString(),
                                MarcaVehiculo = dr["MarcaVehiculo"].ToString(),
                                FechaFabricacion = Convert.ToDateTime(dr["FechaFabricacion"]),
                                ColorVehiculo = dr["ColorVehiculo"].ToString()
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Vehiculos>();
            }

            return lista;
        }

        public void Registrar(Vehiculos vehiculo)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("AgregarVehiculo", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProveedor", vehiculo.IdProveedor);
                    cmd.Parameters.AddWithValue("@CodigoVehiculo", vehiculo.CodigoVehiculo);
                    cmd.Parameters.AddWithValue("@TipoVehiculo", vehiculo.TipoVehiculo);
                    cmd.Parameters.AddWithValue("@MotorVehiculo", vehiculo.MotorVehiculo);
                    cmd.Parameters.AddWithValue("@MarcaVehiculo", vehiculo.MarcaVehiculo);
                    cmd.Parameters.AddWithValue("@FechaFabricacion", vehiculo.FechaFabricacion);
                    cmd.Parameters.AddWithValue("@ColorVehiculo", vehiculo.ColorVehiculo);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar vehículo: " + ex.Message);
            }
        }

        public void Editar(Vehiculos vehiculo)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "EXEC EditarVehiculo @IdVehiculo, @IdProveedor, @CodigoVehiculo, @TipoVehiculo, @MotorVehiculo, @MarcaVehiculo, @FechaFabricacion, @ColorVehiculo";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdVehiculo", vehiculo.IdVehiculo);
                    cmd.Parameters.AddWithValue("@IdProveedor", vehiculo.IdProveedor);
                    cmd.Parameters.AddWithValue("@CodigoVehiculo", vehiculo.CodigoVehiculo);
                    cmd.Parameters.AddWithValue("@TipoVehiculo", vehiculo.TipoVehiculo);
                    cmd.Parameters.AddWithValue("@MotorVehiculo", vehiculo.MotorVehiculo);
                    cmd.Parameters.AddWithValue("@MarcaVehiculo", vehiculo.MarcaVehiculo);
                    cmd.Parameters.AddWithValue("@FechaFabricacion", vehiculo.FechaFabricacion);
                    cmd.Parameters.AddWithValue("@ColorVehiculo", vehiculo.ColorVehiculo);
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar vehículo en la base de datos: " + ex.Message);
            }
        }

        public void Borrar(int idVehiculo)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("BorrarVehiculo", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar vehículo en la base de datos: " + ex.Message);
            }
        }
    }
}
