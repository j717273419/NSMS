using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPig.Model.Entities;
using EPig.Resposity.Method;
using System.Collections.Generic;

namespace EPig.UnitTest.ResposityTest
{
    [TestClass]
    public class NewsResposityTest
    {
        private NewsResposity nr = new NewsResposity();
        private CategoryResposity cr = new CategoryResposity();
        private DepartmentResposity dr = new DepartmentResposity();

        [TestMethod]
        public void NewsTest()
        {
            BigCategory bc = cr.AddBigCategory("分类1", Model.Enums.CategoryStateType.Enabled);
            SubCategory sc = cr.AddSubCategory(bc.ID, "自分类", Model.Enums.CategoryStateType.Enabled);
            EDepartment ed = dr.AddDepartment("部门", Model.Enums.DepartmentType.Enabled);

            ENews news = nr.AddNews("新闻", sc.ID, "20140314165749811156", ed.ID, "asdsa");
            news = nr.GetNews(news.ID);
            Assert.IsNotNull(news);

            List<ENews> newss = nr.GetNewsByCategoryID(sc.ID, 8);
            Assert.AreEqual(newss.Count, 1);

            nr.EditNews(news.ID, "修改后的标题", null, null, null, null);
            news = nr.GetNews(news.ID);
            Assert.AreEqual(news.Title, "修改后的标题");

            nr.AddClickCount(news.ID);
            news = nr.GetNews(news.ID);
            Assert.AreEqual(news.WatchCount, 1);

            nr.DeleteNews(news.ID);

            news = nr.GetNews(news.ID);
            Assert.IsNull(news);

            cr.DeleteBigCategory(bc.ID);
            dr.DeleteDepartmentById(ed.ID);
        }
    }
}
