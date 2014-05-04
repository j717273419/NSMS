using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPig.Models
{
    public class UserRegViewModel
    {
        [Required(ErrorMessage = "用户名不能为空"), RegularExpression(@"[a-zA-Z1-9]{6,20}", ErrorMessage = "用户不符合要求")]
        public String UserName { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Required(ErrorMessage = "密码不能为空"), RegularExpression(@"[a-zA-Z1-9]{6,20}", ErrorMessage = "密码不符合要求")]
        public String Password { get; set; }

        [Required(ErrorMessage = "昵称不能为空"), RegularExpression(@"[a-zA-Z1-9]{6,20}", ErrorMessage = "昵称不符合要求")]
        public String Nick { get; set; }

        [Required(ErrorMessage = "验证码不能为空"), RegularExpression(@"[a-zA-Z1-9]{4}", ErrorMessage = "验证格式不正确")]
        public String ValidCode { get; set; }
    }
}