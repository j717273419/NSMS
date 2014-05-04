using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Model.Enums
{
    public enum UserRoleType
    {
        Admin = 0x0f00,
        User = 0xf000,
        None = 0xffff
    }
}
