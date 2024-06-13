using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Colaborador
    {
        public List<Colaboradores> Listar()
        {
            List<Colaboradores> lista = new List<Colaboradores>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT IdColaborador, IdProveedor, CodigoColaborador, NombresColaborador, ApellidoPaterno, ApellidoMaterno, Direccion, TipoDocumento, NacionalidadColaborador, PuestoTrabajo, SexoColaborador, EstadoTrabajador FROM COLABORADORES";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Colaboradores()
                            {
                                IdColaborador = Convert.ToInt32(dr["IdColaborador"]),
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                CodigoColaborador = Convert.ToInt32(dr["CodigoColaborador"]),
                                NombresColaborador = dr["NombresColaborador"].ToString(),
                                ApellidoPaterno = dr["ApellidoPaterno"].ToString(),
                                ApellidoMaterno = dr["ApellidoMaterno"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NacionalidadColaborador = dr["NacionalidadColaborador"].ToString(),
                                PuestoTrabajo = dr["PuestoTrabajo"].ToString(),
                                SexoColaborador = dr["SexoColaborador"].ToString(),
                                EstadoTrabajador = Convert.ToBoolean(dr["EstadoTrabajador"])
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Colaboradores>();
            }

            return lista;
        }

        public void Registrar(Colaboradores colaborador)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("AgregarColaborador", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProveedor", colaborador.IdProveedor);
                    cmd.Parameters.AddWithValue("@CodigoColaborador", colaborador.CodigoColaborador);
                    cmd.Parameters.AddWithValue("@NombresColaborador", colaborador.NombresColaborador);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", colaborador.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", colaborador.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Direccion", colaborador.Direccion);
                    cmd.Parameters.AddWithValue("@TipoDocumento", colaborador.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NacionalidadColaborador", colaborador.NacionalidadColaborador);
                    cmd.Parameters.AddWithValue("@PuestoTrabajo", colaborador.PuestoTrabajo);
                    cmd.Parameters.AddWithValue("@SexoColaborador", colaborador.SexoColaborador);
                    cmd.Parameters.AddWithValue("@EstadoTrabajador", colaborador.EstadoTrabajador);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar colaborador: " + ex.Message);
            }
        }

        public void Editar(Colaboradores colaborador)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "EXEC EditarColaborador @IdColaborador, @IdProveedor, @CodigoColaborador, @NombresColaborador, @ApellidoPaterno, @ApellidoMaterno, @Direccion, @TipoDocumento, @NacionalidadColaborador, @PuestoTrabajo, @SexoColaborador, @EstadoTrabajador";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdColaborador", colaborador.IdColaborador);
                    cmd.Parameters.AddWithValue("@IdProveedor", colaborador.IdProveedor);
                    cmd.Parameters.AddWithValue("@CodigoColaborador", colaborador.CodigoColaborador);
                    cmd.Parameters.AddWithValue("@NombresColaborador", colaborador.NombresColaborador);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", colaborador.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", colaborador.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Direccion", colaborador.Direccion);
                    cmd.Parameters.AddWithValue("@TipoDocumento", colaborador.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NacionalidadColaborador", colaborador.NacionalidadColaborador);
                    cmd.Parameters.AddWithValue("@PuestoTrabajo", colaborador.PuestoTrabajo);
                    cmd.Parameters.AddWithValue("@SexoColaborador", colaborador.SexoColaborador);
                    cmd.Parameters.AddWithValue("@EstadoTrabajador", colaborador.EstadoTrabajador);
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar colaborador en la base de datos: " + ex.Message);
            }
        }

        public void Borrar(int idColaborador)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "BorrarColaborador";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdColaborador", idColaborador);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar colaborador en la base de datos: " + ex.Message);
            }
        }
    }
}
