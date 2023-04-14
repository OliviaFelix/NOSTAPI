using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOSTAPI.Models
{
    public class MediosRecepcionNotificaciones
    {
        public int id { get; set; }
        public string name { get; set; }

        public static RespuestaJson GuardaMediosRecepcionNotificaciones(MediosRecepcionNotificaciones mrn)
        {
            RespuestaJson rj = null;
            try
            {


                mrn.id = Datos.connection.QuerySingleOrDefault<int>(@"GuardaMediosRecepcionNotificaciones", mrn, commandTimeout: Datos.commtime, commandType: System.Data.CommandType.StoredProcedure);
                if (mrn.id != 0)
                {
                    rj = new RespuestaJson(mrn.id, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo Guardar Medios de Recepcion de Notificaciones");
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
        public static RespuestaJson CargaMediosRecepcionNotificaciones(bool todos)
        {
            RespuestaJson rj = null;
            try
            {
                IEnumerable<MediosRecepcionNotificaciones> Lista = Datos.connection.Query<MediosRecepcionNotificaciones>(@"CargaMediosRecepcionNotificaciones", new { todos = todos }, commandType: System.Data.CommandType.StoredProcedure);

                if (Lista != null)
                {
                    rj = new RespuestaJson(Lista, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo cargar la lista de Medios de Recepcion de Notificaciones");
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