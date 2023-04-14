using NOSTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NOSTAPI.Controllers
{
    public class CatalogosController : Controller
    {
        [HttpPost]
        public JsonResult GuardaDependencia(Dependencia dependencia)
        {
            try
            {                
                RespuestaJson rj = Dependencia.GuardaDependencia(dependencia);
                return Json(rj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        public JsonResult GuardaMediosRecepcionNotificaciones(MediosRecepcionNotificaciones mrn)
        {
            try
            {
                RespuestaJson rj = MediosRecepcionNotificaciones.GuardaMediosRecepcionNotificaciones(mrn);
                return Json(rj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult GuardaTiposAccesibilidad(TiposAccesibilidad ta)
        {
            try
            {
                RespuestaJson rj = TiposAccesibilidad.GuardaTiposAccesibilidad(ta);
                return Json(rj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult GuardaTiposSolicitud(TiposSolicitud ts)
        {
            try
            {
                RespuestaJson rj = TiposSolicitud.GuardaTiposSolicitud(ts);
                return Json(rj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);

            }


        }

        [HttpGet]
        public JsonResult CargaDependencias(bool todos=true)
        {
            try
            {
                RespuestaJson rj = Dependencia.CargaDependencias(todos);
                return Json(rj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);

            }


        }

        [HttpGet]
        public JsonResult CargaMediosRecepcionNotificaciones(bool todos = true)
        {
            try
            {
                RespuestaJson rj = MediosRecepcionNotificaciones.CargaMediosRecepcionNotificaciones(todos);
                return Json(rj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);

            }


        }

        [HttpGet]
        public JsonResult CargaTiposAccesibilidad(bool todos = true)
        {
            try
            {
                RespuestaJson rj = TiposAccesibilidad.CargaTiposAccesibilidad(todos);
                return Json(rj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);

            }


        }

        [HttpGet]
        public JsonResult CargaTiposSolicitud(bool todos = true)
        {
            try
            {
                RespuestaJson rj = TiposSolicitud.CargaTiposSolicitud(todos);
                return Json(rj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);

            }


        }

    }
}