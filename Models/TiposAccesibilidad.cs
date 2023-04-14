using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOSTAPI.Models
{
    public class TiposAccesibilidad
    {
        public int id { get; set; }
        public string name { get; set; }

        public static RespuestaJson GuardaTiposAccesibilidad(TiposAccesibilidad ta)
        {
            RespuestaJson rj = null;
            try
            {


                ta.id = Datos.connection.QuerySingleOrDefault<int>(@"GuardaTiposAccesibilidad", ta, commandTimeout: Datos.commtime, commandType: System.Data.CommandType.StoredProcedure);
                if (ta.id != 0)
                {
                    rj = new RespuestaJson(ta.id, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo Guardar el Tipo de Accesibilidad");
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
        public static RespuestaJson CargaTiposAccesibilidad(bool todos)
        {
            RespuestaJson rj = null;
            try
            {
                IEnumerable<TiposAccesibilidad> Lista = Datos.connection.Query<TiposAccesibilidad>(@"CargaTiposAccesibilidad", new { todos = todos }, commandType: System.Data.CommandType.StoredProcedure);

                if (Lista != null)
                {
                    rj = new RespuestaJson(Lista, "ok", "");
                }
                else
                {
                    rj = new RespuestaJson(null, "error", "No se pudo cargar la lista de Tipos de Accesibilidad");
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