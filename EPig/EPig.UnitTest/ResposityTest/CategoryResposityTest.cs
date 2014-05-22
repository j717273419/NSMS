using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPig.Resposity.Method;
using EPig.Model.Entities;
using System.Collections.Generic;
using EPig.Resposity.Interface;

namespace EPig.UnitTest.ResposityTest
{
    [TestClass]
    public class CategoryResposityTest
    {
        private ICategoryRepository cr = new CategoryRepository();

        [TestMethod]
        public void TestAdd()
        {
            string name = "测试分类";
            string url = "test_url";
            try
            {
                cr.AddCategory(name, url, null, null);
            }
            catch(Exception)
            {
                Assert.Fail();
            }

            Category c = cr.GetCategoryBySuggestUrl(url);

            Assert.IsNotNull(c);

            cr.DeleteCategoryById(c.ID.Value);
        }

        [TestMethod]
        public void TestRepeatUrlAdd()
        {
            string name = "测试分类";
            string url = "test_url";
            bool isTrue = false;
            cr.AddCategory(name, url, null, null);
            try
            {
                cr.AddCategory("测试分类1", url, null, null);
            }
            catch (ExistedSuggestUrlException)
            {
                isTrue = true;
            }
            Assert.IsTrue(isTrue);

            Category c = cr.GetCategoryBySuggestUrl(url);
            Assert.IsNotNull(c);

            Category c1 = cr.GetCategoryById(c.ID.Value);
            Assert.IsNotNull(c1);

            cr.DeleteCategoryById(c1.ID.Value);
        }

        [TestMethod]
        public void TestRepeatNameAdd()
        {
            string name = "测试分类";
            string url = "test_url";
            bool isTrue = false;
            cr.AddCategory(name, url, null, null);
            try
            {
                cr.AddCategory(name, "test_url1", null, null);
            }
            catch (ExistedCategoryNameException)
            {
                isTrue = true;
            }
            Assert.IsTrue(isTrue);

            Category c = cr.GetCategoryBySuggestUrl(url);

            Assert.IsNotNull(c);
            cr.DeleteCategoryById(c.ID.Value);
        }
    }
}
