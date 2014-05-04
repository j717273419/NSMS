using EPig.Model.Constaint;
using EPig.Model.Entities;
using EPig.Resposity.Interface;
using EPig.Resposity.ThrowErr;
using EPig.Utiliy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Method
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserResposity : BaseResposity, IUserResposity
    {
        /// <summary>
        /// 修改基本信息
        /// </summary>
        public void ChangeUserInfo(String id, int? age, DateTime? brithDate, bool? sex)
        {
            EUser user = GetUserById(id);
            if (user == null)
            {
                throw new DbNotFoundException();
            }
            else
            {
                if (age != null)
                {
                    user.Age = age;
                }
                if (brithDate != null)
                {
                    user.BrithDate = brithDate;
                }
                if (sex != null)
                {
                    user.Sex = sex;
                }
                try
                {
                    Dc.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    throw new DbSaveException();
                }
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public void ChangePassword(String id, String passWord)
        {
            EUser user = GetUserById(id);
            if (user == null)
            {
                throw new DbNotFoundException();
            }
            else
            {
                user.Password = passWord;
                try
                {
                    Dc.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    throw new DbSaveException();
                }
            }
        }

        /// <summary>
        /// 修改手机号码
        /// </summary>
        public void ChangePhoneNum(String id, String phoneNum)
        {
            EUser user = GetUserById(id);
            if (user == null)
            {
                throw new DbNotFoundException();
            }
            else
            {
                user.PhoneNum = phoneNum;
                try
                {
                    Dc.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    throw new DbSaveException();
                }
            }
        }

        /// <summary>
        /// 修改邮箱地址
        /// </summary>
        public void ChangeEmail(String id, String email)
        {
            EUser user = GetUserById(id);
            if (user == null)
            {
                throw new DbNotFoundException();
            }
            else
            {
                user.Email = email;
                try
                {
                    Dc.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    throw new DbSaveException();
                }
            }
        }

        /// <summary>
        /// 根据用户标识查找用户
        /// </summary>
        public EUser GetUserById(String id)
        {
            EUser user = Dc.User.Find(id);
            return user;
        }

        /// <summary>
        /// 根据用户名查找用户
        /// </summary>
        public EUser GetUserByUserName(String userName)
        {
            EUser user = (from d in Dc.User
                          where d.UserName.Equals(userName)
                          select d).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        public EUser Login(string username, string pwd)
        {
            List<EUser> users = (from item in Dc.User
                                 where item.UserName.Equals(username) && item.Password.Equals(pwd)
                                 select item).ToList();
            if (users.Count > 0)
            {
                return users[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        public EUser Register(String userName, String passWord, String nickName)
        {
            EUser user = GetUserByUserName(userName);
            if (user != null)
            {
                throw new ExistedUserNameException();
            }
            EUser saveUser = Dc.User.Create();
            saveUser.ID = SqlDataHelper.CreateID();
            saveUser.RegsTime = DateTime.Now;
            saveUser.State = Model.Enums.UserStateType.Enabled;
            saveUser.URole = Model.Enums.UserRoleType.User;
            saveUser.UserName = userName;
            saveUser.Password = passWord;
            saveUser.NickName = nickName;
            Dc.User.Add(user);
            try
            {
                Dc.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new DbSaveException();
            }
            return saveUser;
        }
    }
}
