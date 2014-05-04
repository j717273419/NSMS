using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Utiliy
{
    public class SqlDataHelper
    {
        public static string CreateID()
        {
            String s = DateTime.Now.ToString("yyyyMMddHHmmssff");
            Random r = new Random();
            string t = r.Next(1000, 9999).ToString();
            return s + t;
        }
    }
}
