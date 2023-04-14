using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace NOSTAPI.Models
{
    public class Archivo
    {
        public static string RutaArchivo = ConfigurationManager.AppSettings.Get("RutaArchivosSolicitud").ToString();


        public static  RespuestaJson GuardarArchivo(HttpPostedFileBase[] files)
        {
            RespuestaJson rj = null;
            string ruta = "";
            try
            {
                //c:\Ayuntamiento\AYTBecasControl\archivos\ArchivosBecas\1_20220520\IMG-20220520-WA0095.jpg

                if (!Directory.Exists(Path.Combine(RutaArchivo)))
                {
                    Directory.CreateDirectory(Path.Combine(RutaArchivo));
                }
                if (files.Length > 0)
                {

                        foreach (HttpPostedFileBase file in files)
                        {
                        ruta = Path.Combine(RutaArchivo, file.FileName);
                       
                                try
                                {

                                    file.SaveAs(ruta);
                                }
                                catch (Exception ex)
                                {
                            rj = new RespuestaJson(null, "error", ex.Message);
                            return null;
                                }
   
                            
                        }
                    



                }

               
                rj = new RespuestaJson(ruta, "ok", "");
                return rj;


            }
            catch (Exception ex)
            {
                rj = new RespuestaJson(null, "error", ex.Message);
                return rj;
            }

        }
    }
}