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
    public class CD_Proveedor
    {
        public List<Proveedor> Listar()
        {

            List<Proveedor> lista = new List<Proveedor>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT IdProveedor, CodigoProveedor, RUC, FechaRegistro, RazonSocial, ActividadEconomica, DireccionProveedor, PaisProveedor, ProvinciaProveedor, DepartamentoProveedor, DistritoProveedor, ReferenciaProovedor, NombreResponsable, ApellidoMaternoResponsable, ApellidoPaternoResponsable, TelefonoResponsable, CorreoResponsable FROM PROVEEDOR";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                              new Proveedor()
                              {
                                  IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                  CodigoProveedor = Convert.ToInt32(dr["CodigoProveedor"]),
                                  RUC = Convert.ToInt32(dr["RUC"]),
                                  RazonSocial = dr["RazonSocial"].ToString(),
                                  ActividadEconomica = dr["ActividadEconomica"].ToString(),
                                  DireccionProveedor = dr["DireccionProveedor"].ToString(),
                                  PaisProveedor = dr["PaisProveedor"].ToString(),
                                  ProvinciaProveedor = dr["ProvinciaProveedor"].ToString(),
                                  DepartamentoProveedor = dr["DepartamentoProveedor"].ToString(),
                                  DistritoProveedor = dr["DistritoProveedor"].ToString(),
                                  ReferenciaProovedor = dr["ReferenciaProovedor"].ToString(),
                                  NombreResponsable = dr["NombreResponsable"].ToString(),
                                  ApellidoMaternoResponsable = dr["ApellidoMaternoResponsable"].ToString(),
                                  ApellidoPaternoResponsable = dr["ApellidoPaternoResponsable"].ToString(),
                                  TelefonoResponsable = Convert.ToInt32(dr["TelefonoResponsable"]),
                                  CorreoResponsable = dr["CorreoResponsable"].ToString()
                              }
                            );

                        }
                    }
                }
            }
            catch
            {
                lista = new List<Proveedor>();
            }

            return lista;
        }

        public void Insertar(Proveedor proveedor)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "InsertarProveedor";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUC", proveedor.RUC);
                    cmd.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@ActividadEconomica", proveedor.ActividadEconomica);
                    cmd.Parameters.AddWithValue("@DireccionProveedor", proveedor.DireccionProveedor);
                    cmd.Parameters.AddWithValue("@PaisProveedor", proveedor.PaisProveedor);
                    cmd.Parameters.AddWithValue("@ProvinciaProveedor", proveedor.ProvinciaProveedor);
                    cmd.Parameters.AddWithValue("@DepartamentoProveedor", proveedor.DepartamentoProveedor);
                    cmd.Parameters.AddWithValue("@DistritoProveedor", proveedor.DistritoProveedor);
                    cmd.Parameters.AddWithValue("@ReferenciaProovedor", proveedor.ReferenciaProovedor);
                    cmd.Parameters.AddWithValue("@NombreResponsable", proveedor.NombreResponsable);
                    cmd.Parameters.AddWithValue("@ApellidoMaternoResponsable", proveedor.ApellidoMaternoResponsable);
                    cmd.Parameters.AddWithValue("@ApellidoPaternoResponsable", proveedor.ApellidoPaternoResponsable);
                    cmd.Parameters.AddWithValue("@TelefonoResponsable", proveedor.TelefonoResponsable);
                    cmd.Parameters.AddWithValue("@CorreoResponsable", proveedor.CorreoResponsable);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
            }
        }

        // Editar proveedor
        public void Editar(Proveedor proveedor)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "EXEC EditarProveedor @IdProveedor, @RUC, @RazonSocial, @ActividadEconomica, @DireccionProveedor, @PaisProveedor, @ProvinciaProveedor, @DepartamentoProveedor, @DistritoProveedor, @ReferenciaProovedor, @NombreResponsable, @ApellidoMaternoResponsable, @ApellidoPaternoResponsable, @TelefonoResponsable, @CorreoResponsable";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("@RUC", proveedor.RUC);
                    cmd.Parameters.AddWithValue("@RazonSocial", proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@ActividadEconomica", proveedor.ActividadEconomica);
                    cmd.Parameters.AddWithValue("@DireccionProveedor", proveedor.DireccionProveedor);
                    cmd.Parameters.AddWithValue("@PaisProveedor", proveedor.PaisProveedor);
                    cmd.Parameters.AddWithValue("@ProvinciaProveedor", proveedor.ProvinciaProveedor);
                    cmd.Parameters.AddWithValue("@DepartamentoProveedor", proveedor.DepartamentoProveedor);
                    cmd.Parameters.AddWithValue("@DistritoProveedor", proveedor.DistritoProveedor);
                    cmd.Parameters.AddWithValue("@ReferenciaProovedor", proveedor.ReferenciaProovedor);
                    cmd.Parameters.AddWithValue("@NombreResponsable", proveedor.NombreResponsable);
                    cmd.Parameters.AddWithValue("@ApellidoMaternoResponsable", proveedor.ApellidoMaternoResponsable);
                    cmd.Parameters.AddWithValue("@ApellidoPaternoResponsable", proveedor.ApellidoPaternoResponsable);
                    cmd.Parameters.AddWithValue("@TelefonoResponsable", proveedor.TelefonoResponsable);
                    cmd.Parameters.AddWithValue("@CorreoResponsable", proveedor.CorreoResponsable);
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar proveedor en la base de datos: " + ex.Message);
            }
        }
        //borrar
        public void Borrar(int idProveedor)
        {
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "BorrarProveedor";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar proveedor en la base de datos: " + ex.Message);
            }
        }
    }
}
    
