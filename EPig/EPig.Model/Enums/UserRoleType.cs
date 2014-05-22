using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Model.Enums
{
    public enum UserRoleType
    {
        None = 0,
        /// <summary>
        /// 普通用户
        /// </summary>
        User = 1,
        /// <summary>
        /// 管理员
        /// </summary>
        Admin = 2,
        All = 3
    }
}
