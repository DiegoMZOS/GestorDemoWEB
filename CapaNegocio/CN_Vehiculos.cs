using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Vehiculo
    {
        private CD_Vehiculo objCapaDato = new CD_Vehiculo();

        public List<Vehiculos> Listar()
        {
            return objCapaDato.Listar();
        }

        public void Insertar(Vehiculos vehiculo)
        {
            objCapaDato.Insertar(vehiculo);
        }

        public void Editar(Vehiculos vehiculo)
        {
            try
            {
                // Llama al método de la capa de datos para editar el vehículo
                objCapaDato.Editar(vehiculo);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o errores si es necesario
                throw new Exception("Error al editar vehículo en la capa de negocio: " + ex.Message);
            }
        }

        public void Borrar(int idVehiculo)
        {
            try
            {
                // Llama al método de la capa de datos para borrar el vehículo
                objCapaDato.Borrar(idVehiculo);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o errores si es necesario
                throw new Exception("Error al borrar vehículo en la capa de negocio: " + ex.Message);
            }
        }
    }
}
