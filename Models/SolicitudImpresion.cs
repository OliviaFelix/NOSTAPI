using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOSTAPI.Models
{
    public class SolicitudImpresion:Solicitud
    {
        public string NameDependencia { get; set; }        
        public string NameTipoSolicitud { get; set; }        
        public string NameAccesibilidad { get; set; }
        public string NameMedioRecepcionNotificaciones { get; set; }

        public static RespuestaJson CargaListaSolicitudes()
        {
            RespuestaJson rj = null;
            try
            {
                IEnumerable<SolicitudImpresion> Lista = Datos.connection.Query<SolicitudImpresion>(@"CargaListaSolicitudes", null, commandType: System.Data.CommandType.StoredProcedure);

                if (Lista != null)
                {
                    rj = new RespuestaJson(Lista, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo cargar la lista de Solicitudes");
                }


                return rj;
            }
            catch (Exception e)
            {
                Datos.connection.Close();
                rj = new RespuestaJson(null, "error", e.Message);
                return rj;
            }

        }
    }
}