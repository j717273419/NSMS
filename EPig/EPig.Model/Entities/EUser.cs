using EPig.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EPig.Model.Entities
{
    [Table("DbUser")]
    public class EUser
    {
        public EUser()
        {
            State = UserStateType.Enabled;
            URole = UserRoleType.User;
        }

        [Key()]
        [Column("UID")]
        public String ID { get; set; }

        [Column("URegsTime")]
        public DateTime RegsTime { get; set; }

        [Column("UName")]
        public String UserName { get; set; }

        [Column("UNick")]
        public String NickName { get; set; }

        [Column("UPwd")]
        public String Password { get; set; }

        [Column("UAge")]
        public int? Age { get; set; }

        [Column("UBrithDate")]
        public DateTime? BrithDate { get; set; }

        [Column("UEmail")]
        public String Email { get; set; }

        [Column("MobPhone")]
        public String PhoneNum { get; set; }

        [Column("USex")]
        public bool? Sex { get; set; }

        [Column("UState")]
        public UserStateType State { get; set; }

        [Column("URole")]
        public UserRoleType URole { get; set; }
    }
}
