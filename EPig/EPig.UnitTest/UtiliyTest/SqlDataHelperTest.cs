using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPig.Utiliy;

namespace EPig.UnitTest.UtiliyTest
{
    [TestClass]
    public class SqlDataHelperTest
    {
        [TestMethod]
        public void CreateIDTest()
        {
            string s = SqlDataHelper.CreateID();
            Assert.IsNotNull(s);
        }
    }
}
