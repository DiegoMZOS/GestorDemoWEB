using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Proveedor
    {
		public int IdProveedor { get; set; }
		public int CodigoProveedor { get; set; }
        public int RUC { get; set; }
        public string RazonSocial { get; set; }
        public string ActividadEconomica { get; set; }
        public string DireccionProveedor { get; set; }
        public string PaisProveedor { get; set; }
        public string ProvinciaProveedor { get; set; }
        public string DepartamentoProveedor { get; set; }
        public string DistritoProveedor { get; set; }
        public string ReferenciaProovedor { get; set; }
        public string NombreResponsable { get; set; }
        public string ApellidoMaternoResponsable { get; set; }
        public string ApellidoPaternoResponsable { get; set; }
        public int TelefonoResponsable { get; set; }
        public string CorreoResponsable { get; set; }

    }
}
