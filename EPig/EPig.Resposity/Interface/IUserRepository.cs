using EPig.Model;
using EPig.Model.Entities;
using EPig.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Interface
{
    /// <summary>
    /// 用户功能接口
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>查找到则返回，否则返回NULL</returns>
        User GetUserById(int uid);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns>返回IList<User>类型的用户</returns>
        IList<User> GetAllUser(int? page = null, int? count = null);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="nickName">昵称</param>
        /// <param name="pwd">密码</param>
        /// <param name="role">角色</param>
        /// <exception cref="ExistedUserNameException">存在重复的用户名</exception>
        void AddUser(String userName, String nickName, String pwd, UserRoleType role);

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="nickName">昵称</param>
        /// <param name="pwd">密码</param>
        /// <param name="sex">性别</param>
        /// <param name="phoneNum">手机号</param>
        /// <param name="email">邮箱</param>
        /// <param name="birthDate">生日</param>
        /// <param name="age">年龄</param>
        /// <exception cref="ExistedEmailException">存在重复的邮箱</exception>
        /// <exception cref="NofFoundUserException">不存在指定的用户</exception>
        void EditUser(int uid, String nickName, String pwd = null, bool? sex = null, string phoneNum = null, String email = null, DateTime? birthDate, int? age);

    }

    #region 接口中的异常

    /// <summary>
    /// 存在重复的用户名
    /// </summary>
    public class ExistedUserNameException : ApplicationException
    {
    }

    /// <summary>
    /// 存在重复的邮箱
    /// </summary>
    public class ExistedEmailException : ApplicationException
    {
    }

    /// <summary>
    /// 不存在指定的用户
    /// </summary>
    public class NofFoundUserException : ApplicationException
    {

    }

    #endregion 接口中的异常
}
