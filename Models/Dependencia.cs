using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOSTAPI.Models
{
    public class Dependencia
    {
        public int id { get; set; }
        public string name { get; set; }

        public static RespuestaJson GuardaDependencia(Dependencia dep)
        {
            RespuestaJson rj = null;
            try
            {


                dep.id = Datos.connection.QuerySingleOrDefault<int>(@"GuardaDependencia", dep, commandTimeout: Datos.commtime, commandType: System.Data.CommandType.StoredProcedure);
                if (dep.id != 0)
                {
                    rj = new RespuestaJson(dep.id, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo Guardar la Dependencia");
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
        public static RespuestaJson CargaDependencias(bool todos)
        {
            RespuestaJson rj = null;
            try
            {
                IEnumerable<Dependencia> Lista = Datos.connection.Query<Dependencia>(@"CargaDependencias", new{todos=todos }, commandType: System.Data.CommandType.StoredProcedure);
                
                if (Lista != null)
                {
                    rj = new RespuestaJson(Lista, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo cargar la lista de Dependencias");
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