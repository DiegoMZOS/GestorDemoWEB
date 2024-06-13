using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionGestor.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        public ActionResult Colaborador()
        {
            return View();
        }
        public ActionResult Vehiculo()
        {
            return View();
        }
        public ActionResult Trabajos()
        {
            return View();
        }
        public ActionResult Proveedor()
        {
            return View();
        }
    }
}