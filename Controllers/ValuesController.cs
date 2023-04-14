using Newtonsoft.Json;
using NOSTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NOSTAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public void GuardaSolicitud(string sol, HttpPostedFileBase[] files)
        {
            Solicitud s = new Solicitud();
            try
            {

                s = JsonConvert.DeserializeObject<Models.Solicitud>(sol);
                RespuestaJson rj = Solicitud.GuardaSolicitud(s,files);
                //return Json(rj, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                RespuestaJson r = new RespuestaJson(null, "error", e.Message);
                //return Json(r, JsonRequestBehavior.AllowGet);

            }


        }
    }
}
