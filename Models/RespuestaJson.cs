using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOSTAPI.Models
{
    public class RespuestaJson
    {
        public string Status { get; set; }
        public object Dato { get; set; }
        public string Error { get; set; }
        public RespuestaJson(object dato, string status, string error)
        {
            Dato = dato;
            Error = dato == null ? error : "";
            Status = dato == null ? "error" : status;
        }

        public RespuestaJson(object dato, string status, int Observacion)
        {
            string obs = "";
            switch (Observacion)
            {
                case 1:
                    obs = "No hay datos";
                    break;

            }

            Dato = dato;
            Error = dato == null ? obs : "";
            Status = status;
        }


    }
}