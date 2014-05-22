using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPig.Resposity;
using EPig.Model.Entities;
using System.Reflection;
using System.Configuration;
using EPig.Utiliy;
using EPig.Resposity.Method;
using EPig.Resposity.Interface;

namespace EPig.UnitTest
{
    [TestClass]
    public class UserResposityTest
    {
        public IUserRepository ur = new UserRepository();
    }
}
