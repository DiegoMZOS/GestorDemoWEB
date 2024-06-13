using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Colaborador
    {
        private CD_Colaborador objCapaDato = new CD_Colaborador();

        public List<Colaboradores> Listar()
        {
            return objCapaDato.Listar();
        }

        public void Registrar(Colaboradores colaborador)
        {
            try
            {
                // Verificar campo NombresColaborador
                if (string.IsNullOrWhiteSpace(colaborador.NombresColaborador))
                {
                    throw new Exception("El campo Nombres es obligatorio.");
                }

                // Verificar campo ApellidoPaterno
                if (string.IsNullOrWhiteSpace(colaborador.ApellidoPaterno))
                {
                    throw new Exception("El campo Apellido Paterno es obligatorio.");
                }

                // Verificar campo Direccion
                if (string.IsNullOrWhiteSpace(colaborador.Direccion))
                {
                    throw new Exception("El campo Dirección es obligatorio.");
                }

                // Llamar al método Registrar de la capa de datos
                objCapaDato.Registrar(colaborador);
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
                // Llama al método de la capa de datos para editar el colaborador
                objCapaDato.Editar(colaborador);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o errores si es necesario
                throw new Exception("Error al editar colaborador en la capa de negocio: " + ex.Message);
            }
        }

        public void Borrar(int idColaborador)
        {
            try
            {
                // Llama al método de la capa de datos para borrar el colaborador
                objCapaDato.Borrar(idColaborador);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o errores si es necesario
                throw new Exception("Error al borrar colaborador en la capa de negocio: " + ex.Message);
            }
        }
    }
}
