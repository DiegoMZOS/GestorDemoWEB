using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionGestor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Colaboradores()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarColaboradores()
        {
            try
            {
                List<Colaboradores> oLista = new CN_Colaborador().Listar();
                return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al listar colaboradores: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult RegistrarColaborador(Colaboradores colaborador)
        {
            try
            {
                new CN_Colaborador().Registrar(colaborador);
                return Json(new { success = true, message = "Colaborador registrado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al registrar colaborador: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult EditarColaborador(Colaboradores colaborador)
        {
            try
            {
                new CN_Colaborador().Editar(colaborador);
                return Json(new { success = true, message = "Colaborador editado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al editar colaborador: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult BorrarColaborador(int idColaborador)
        {
            try
            {
                new CN_Colaborador().Borrar(idColaborador);
                return Json(new { success = true, message = "Colaborador borrado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al borrar colaborador: " + ex.Message });
            }
        }

        [HttpGet]
        public JsonResult ListarProveedor()
        {
            List<Proveedor> oLista = new List<Proveedor>();
            oLista = new CN_Proveedor().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarProveedor(Proveedor proveedor)
        {
            try
            {
                // Llamar al método Insertar de la capa de negocio
                new CN_Proveedor().Insertar(proveedor);

                // Enviar respuesta de éxito a la vista
                return Json(new { success = true, message = "Proveedor registrado correctamente." });
            }
            catch (Exception ex)
            {
                // Enviar respuesta de error a la vista
                return Json(new { success = false, message = "Error al registrar proveedor: " + ex.Message });
            }

        }

        [HttpPost]
        public JsonResult EditarProveedor(Proveedor proveedor)
        {
            try
            {
                // Llamar al método Editar de la capa de negocio
                new CN_Proveedor().Editar(proveedor);

                // Enviar respuesta de éxito a la vista
                return Json(new { success = true, message = "Proveedor editado correctamente." });
            }
            catch (Exception ex)
            {
                // Enviar respuesta de error a la vista
                return Json(new { success = false, message = "Error al editar proveedor: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult BorrarProveedor(int idProveedor)
        {
            try
            {
                // Llamar al método Borrar de la capa de negocio
                new CN_Proveedor().Borrar(idProveedor);

                // Enviar respuesta de éxito a la vista
                return Json(new { success = true, message = "Proveedor borrado correctamente." });
            }
            catch (Exception ex)
            {
                // Enviar respuesta de error a la vista
                return Json(new { success = false, message = "Error al borrar proveedor: " + ex.Message });
            }
        }
    }
}