using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPig.Resposity;
using EPig.Model.Entities;
using System.Reflection;
using System.Configuration;
using EPig.Utiliy;
using EPig.Resposity.Method;
using EPig.Resposity.ThrowErr;

namespace EPig.UnitTest
{
    [TestClass]
    public class UserResposityTest
    {
        UserRepository ur = new UserRepository();

        [TestMethod]
        public void RegisterTest()
        {
            bool result = false;
            try
            {
                ur.Register("123456", "123456", "123456");
            }
            catch (ExistedUserNameException)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetUserInfoTest()
        {
            User user = ur.GetUserById("20140314165749811156");
            Assert.IsNotNull(user);

            user = ur.GetUserById("20140314165749811152");
            Assert.IsNull(user);

            user = ur.GetUserByUserName("123456");
            Assert.IsNotNull(user);

            user = ur.GetUserByUserName("asd");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void ChangeUserTest()
        {
            bool result = false;

            ur.ChangeUserInfo("20140314165749811156", 5, DateTime.Now, false);
            User user = ur.GetUserById("20140314165749811156");
            Assert.AreEqual(user.Age, 5);

            try
            {
                ur.ChangeUserInfo("20140314165749811152", 3, DateTime.Now, false);
            }
            catch (DbNotFoundException)
            {
                result = true;
            }
            Assert.IsTrue(result);

            ur.ChangeEmail("20140314165749811156", "976691141@qq.com");
            user = ur.GetUserById("20140314165749811156");
            Assert.AreEqual(user.Email, "976691141@qq.com");

            ur.ChangePassword("20140314165749811156", "1234567");
            user = ur.GetUserById("20140314165749811156");
            Assert.AreEqual(user.Password, "1234567");

            ur.ChangePhoneNum("20140314165749811156", "123456789");
            user = ur.GetUserById("20140314165749811156");
            Assert.AreEqual(user.PhoneNum, "123456789");
        }

        [TestMethod]
        public void LoginTest()
        {
            User user = ur.Login("123456", "1234567");
            Assert.IsNotNull(user);
        }
    }
}
