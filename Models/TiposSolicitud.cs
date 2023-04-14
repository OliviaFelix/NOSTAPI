using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOSTAPI.Models
{
    public class TiposSolicitud
    {
        public int id { get; set; }
        public string name { get; set; }

        public static RespuestaJson GuardaTiposSolicitud(TiposSolicitud ts)
        {
            RespuestaJson rj = null;
            try
            {


                ts.id = Datos.connection.QuerySingleOrDefault<int>(@"GuardaTiposSolicitud", ts, commandTimeout: Datos.commtime, commandType: System.Data.CommandType.StoredProcedure);
                if (ts.id != 0)
                {
                    rj = new RespuestaJson(ts.id, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo Guardar el Tipo de Solicitud");
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

        public static RespuestaJson CargaTiposSolicitud(bool todos)
        {
            RespuestaJson rj = null;
            try
            {
                IEnumerable<TiposSolicitud> Lista = Datos.connection.Query<TiposSolicitud>(@"CargaTiposSolicitud", new { todos = todos }, commandType: System.Data.CommandType.StoredProcedure);

                if (Lista != null)
                {
                    rj = new RespuestaJson(Lista, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo cargar la lista de Tipos de Solicitud");
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