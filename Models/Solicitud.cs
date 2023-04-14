using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NOSTAPI.Models
{
    public class Solicitud
    {
        public int Id { get; set; }
        public string Fecha_Impresion { get; set; }
        public int Dependencia { get; set; }
        public string Folio { get; set; }
        public int TipoSolicitud { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Accesibilidad { get; set; }

        public int MedioRecepcionNotificaciones { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Correo { get; set; }
        public string RutaEvidencia { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAdicional { get; set; }
        public string Fecha_Respuesta { get; set; }
        public string Fecha_Aclaracion { get; set; }
        public string Fecha_Prorroga { get; set; }


        public static RespuestaJson GuardaSolicitud(Solicitud s, HttpPostedFileBase[] files)
        {
            RespuestaJson rj = null;
            try
            {
                if (files!=null)
                {
                    rj = Archivo.GuardarArchivo(files);
                    if (rj.Status == "ok")
                    {
                        s.RutaEvidencia = rj.Dato.ToString();
                        s.Fecha_Aclaracion = s.Fecha_Aclaracion.Replace("-", "");
                        s.Fecha_Impresion = s.Fecha_Impresion.Replace("-", "");
                        s.Fecha_Prorroga = s.Fecha_Prorroga.Replace("-", "");
                        s.Fecha_Respuesta = s.Fecha_Respuesta.Replace("-", "");
                        s.Id = Datos.connection.QuerySingleOrDefault<int>(@"GuardaSolicitud", s, commandTimeout: Datos.commtime, commandType: System.Data.CommandType.StoredProcedure);
                        if (s.Id != 0)
                        {
                            rj = new RespuestaJson(s.Id, "ok", "");
                        }
                        else
                        {
                            rj = new RespuestaJson(null, "error", "No se pudo Guardar la solicitud");
                        }
                    }
                    else
                    {
                        return rj;
                    }

                }
                else {
                    rj = new RespuestaJson(null, "error", "No se pudo Guardar la solicitud, agregue archivo");
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