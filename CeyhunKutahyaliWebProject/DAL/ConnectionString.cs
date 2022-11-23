using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeyhunKutahyaliWebProject.DAL
{
    public static class ConnectionString
    {
        private static string _connection = @"Data Source=DESKTOP-EFNF2JK\SQLEXPRESS; Initial Catalog = CeyhunKutahyaliWebSite; Integrated Security=True";
        public static string Connection { get { return _connection; } }

    }
}