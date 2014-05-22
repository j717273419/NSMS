using EPig.Model.Constaint;
using EPig.Model.Entities;
using EPig.Resposity.Interface;
using EPig.Utiliy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Method
{
    /// <summary>
    /// 用户功能的具体实现
    /// </summary>
    public class UserRepository : BaseResposity, IUserRepository
    {
        /// <summary>
        /// 判断是否存在用户
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>存在则返回true否则返回false</returns>
        public bool ExistUser(int uid)
        {
            int count = (from item in Context.Users
                         where item.ID.Equals(uid)
                         select item).Count();
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 判断是否存在用户名
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>存在则返回true否则返回false</returns>
        public bool ExistUserName(string userName)
        {
            int count = (from item in Context.Users
                         where item.UserName.Equals(userName)
                         select item).Count();
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 判断是否存在邮箱
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="uid">排除的用户</param>
        /// <returns>存在则返回true否则返回false</returns>
        public bool ExistEmail(string email, int? uid = null)
        {
            int count = 0;
            var users = from item in Context.Users
                        where item.Email.Equals(email)
                        select item;
            if (uid != null)
            {
                count = users.Where(a => !a.ID.Equals(uid)).Count();
            }
            else
            {
                count = users.Count();
            }
            return count > 0 ? true : false;
        }

        #region IUserRepository接口实现

        //注释见接口

        public User GetUserById(int uid)
        {
            if (ExistUser(uid))
            {
                User u = (from item in Context.Users
                          where item.ID.Equals(uid)
                          select item).FirstOrDefault();
                return u;
            }
            return null;
        }

        public IList<User> GetAllUser(int? page = null, int? count = null)
        {
            var users = new List<User>();
            if (page != null && count != null)
            {
                int skipCount = page.Value * count.Value;
                users = Context.Users.Skip(skipCount).Take(count.Value).ToList();
            }
            else
            {
                users = Context.Users.ToList();
            }
            return users;
        }

        public void AddUser(string userName, string nickName, string pwd, Model.Enums.UserRoleType role)
        {
            if (ExistUserName(userName))
            {
                throw new ExistedUserNameException();
            }
            User u = Context.Users.Create();
            u.UserName = userName;
            u.NickName = nickName;
            u.Password = pwd;
            u.URole = role;
            u.RegsTime = DateTime.Now;
            Context.Users.Add(u);
            Context.SaveChanges();
        }

        public void EditUser(int uid, string nickName, string pwd = null, bool? sex = null, string phoneNum = null, string email = null, DateTime? birthDate = null, int? age = null)
        {
            if (!ExistUser(uid))
            {
                throw new NofFoundUserException();
            }
            if (email != null && !ExistEmail(email, uid))
            {
                throw new ExistedEmailException();
            }
            User u = GetUserById(uid);
            if (u != null)
            {
                u.NickName = nickName ?? u.NickName;
                u.Password = pwd ?? u.Password;
                u.Sex = sex ?? u.Sex;
                u.PhoneNum = phoneNum ?? u.PhoneNum;
                u.Email = email ?? u.Email;
                u.BrithDate = birthDate ?? u.BrithDate;
                u.Age = age ?? u.Age;
                Context.Users.Attach(u);
                Context.SaveChanges();
            }
        }

        #endregion IUserRepository接口实现
    }
}
