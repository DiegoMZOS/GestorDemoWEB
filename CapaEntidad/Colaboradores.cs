using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
	public class Colaboradores
	{
		
        public int IdColaborador { get; set; }
        public int IdProveedor {get; set;}
        public int CodigoColaborador { get; set; }
        public string NombresColaborador { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string TipoDocumento { get; set; }
        public string NacionalidadColaborador { get; set; }
        public string PuestoTrabajo { get; set; }
        public string SexoColaborador { get; set; }
        public bool EstadoTrabajador { get; set; }
    }
}
