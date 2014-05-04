using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EPig.Utiliy
{
    public static class StringHelper
    {
        /// <summary>
        /// 验证字符串是否安全
        /// 
        /// 引入SQL语句中必须经过该步骤
        /// </summary>
        public static bool ValidSimpleStringSecurity(String source)
        {
            Regex r = new Regex(@"^[a-zA-Z0-9\._@\u4e00-\u9fa5]*$", RegexOptions.IgnoreCase);
            return r.IsMatch(source);
        }

        /// <summary>
        /// 将字符串去空
        /// </summary>
        public static String TrimString(String source)
        {
            source = source == null ? String.Empty : source.Trim();
            return source;
        }
    }
}
