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
    public class User
    {
        public User()
        {
            URole = UserRoleType.User;
        }

        [Key()]
        [Column("UID")]
        public String ID { get; set; }

        //注册时间
        [Column("URegsTime")]
        public DateTime RegsTime { get; set; }

        //用户名
        [Column("UName")]
        public String UserName { get; set; }

        //用户昵称
        [Column("UNick")]
        public String NickName { get; set; }

        //用户密码
        [Column("UPwd")]
        public String Password { get; set; }

        //年龄
        [Column("UAge")]
        public int? Age { get; set; }

        //生日
        [Column("UBrithDate")]
        public DateTime? BrithDate { get; set; }

        //邮箱
        [Column("UEmail")]
        public String Email { get; set; }

        //联系电话
        [Column("UMobPhone")]
        public String PhoneNum { get; set; }

        //性别
        [Column("USex")]
        public bool? Sex { get; set; }

        //角色
        [Column("URole")]
        public UserRoleType URole { get; set; }
    }
}
