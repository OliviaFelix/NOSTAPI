using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NOSTAPI.Models
{
    public class Datos
    {
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conx"].ToString());
        public static int commtime = 10000000;
    }
}