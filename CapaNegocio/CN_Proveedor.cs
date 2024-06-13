using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objCapaDato = new CD_Proveedor();
        public List<Proveedor> Listar()
        {
            return objCapaDato.Listar();
        }

        public void Insertar(Proveedor proveedor)
        {
            objCapaDato.Insertar(proveedor);
        }
        public void Editar(Proveedor proveedor)
        {
            try
            {
                // Llama al método de la capa de datos para editar el proveedor
                objCapaDato.Editar(proveedor);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o errores si es necesario
                throw new Exception("Error al editar proveedor en la capa de negocio: " + ex.Message);
            }
        }
        public void Borrar(int idProveedor)
        {
            try
            {
                // Llama al método de la capa de datos para borrar el proveedor
                objCapaDato.Borrar(idProveedor);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o errores si es necesario
                throw new Exception("Error al borrar proveedor en la capa de negocio: " + ex.Message);
            }
        }

    }
}
