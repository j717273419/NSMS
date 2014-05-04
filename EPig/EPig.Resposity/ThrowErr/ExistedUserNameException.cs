using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.ThrowErr
{
    public class ExistedUserNameException : Exception
    {
        private string message = "已存在该用户名";
        public override string Message
        {
            get
            {
                return message;
            }
        }
    }
}
