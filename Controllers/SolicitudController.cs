using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NOSTAPI.Models;

namespace NOSTAPI.Controllers
{
    public class SolicitudController :  Controller
    {
        // GET: Solicitud
        [HttpPost]
        public JsonResult GuardaSolicitud(string solicitud, HttpPostedFileBase[] files)
        {
            Solicitud s = new Solicitud();
            try
            {

                s = JsonConvert.DeserializeObject<Models.Solicitud>(solicitud);          
                RespuestaJson rj = Solicitud.GuardaSolicitud(s,files);
                return  Json(rj, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                RespuestaJson r=new RespuestaJson(null, "error", e.Message);
                return Json(r, JsonRequestBehavior.AllowGet);

            }

            
        }
        
    }
}