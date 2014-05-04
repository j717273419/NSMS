using EPig.Model;
using EPig.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Interface
{
    public interface IUserResposity
    {
        EUser GetUserById(String id);
        EUser GetUserByUserName(String userName);
        EUser Register(String userName, String passWord, String nickName);
        void ChangeUserInfo(String id, int? age, DateTime? brithDate, bool? sex);
        void ChangePassword(String id, String passWord);
        void ChangePhoneNum(String id, String phoneNum);
        void ChangeEmail(String id, String email);
        EUser Login(String username, String pwd);
    }
}
