using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPig.Model.Entities;
using EPig.Resposity.Method;
using System.Collections.Generic;
using EPig.Resposity.Interface;

namespace EPig.UnitTest.ResposityTest
{
    [TestClass]
    public class NewsResposityTest
    {
        public INewsRepository nr = new NewsRepository();
    }
}
