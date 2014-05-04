using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPig.Resposity.Method;
using EPig.Model.Entities;
using System.Collections.Generic;
using EPig.Resposity.ThrowErr;

namespace EPig.UnitTest.ResposityTest
{
    [TestClass]
    public class CategoryResposityTest
    {
        private CategoryResposity cr = new CategoryResposity();

        [TestMethod]
        public void BigCategoryTest()
        {
            bool result = false;
            BigCategory bc = cr.AddBigCategory("测试分类", Model.Enums.CategoryStateType.Enabled);
            bc = cr.GetBigCategoryByID(bc.ID);
            Assert.IsNotNull(bc);

            try
            {
                cr.AddBigCategory("测试分类", Model.Enums.CategoryStateType.Enabled);
            }
            catch (ExistedCategoryNameException)
            {
                result = true;
            }
            Assert.IsTrue(result);

            List<BigCategory> bcs = cr.GetAllBigCategory();
            Assert.AreEqual(bcs.Count, 1);

            cr.EditBigCategory(bc.ID, "修改后的分类", Model.Enums.CategoryStateType.Enabled);
            bc = cr.GetBigCategoryByID(bc.ID);
            Assert.AreEqual(bc.Name, "修改后的分类");

            cr.DeleteBigCategory(bc.ID);

            bc = cr.GetBigCategoryByID(bc.ID);
            Assert.IsNull(bc);
        }

        [TestMethod]
        public void SubCategoryTest()
        {
            BigCategory bc = cr.AddBigCategory("测试分类1", Model.Enums.CategoryStateType.Enabled);

            SubCategory sc = cr.AddSubCategory(bc.ID, "测试小类", Model.Enums.CategoryStateType.Enabled);
            sc = cr.GetSubCategoryByID(sc.ID);
            Assert.IsNotNull(sc);

            bool result = false;
            try
            {
                cr.AddSubCategory(bc.ID, "测试小类", Model.Enums.CategoryStateType.Enabled);
            }
            catch (ExistedCategoryNameException)
            {
                result = true;
            }
            Assert.IsTrue(result);

            List<SubCategory> scs = cr.GetAllSubCategory();
            Assert.AreEqual(scs.Count, 1);

            scs = cr.GetSubCategoryListByBID(bc.ID);
            Assert.AreEqual(scs.Count, 1);

            cr.EditSubCategory(sc.ID, "修改后的分类", null, Model.Enums.CategoryStateType.Enabled);
            sc = cr.GetSubCategoryByID(sc.ID);
            Assert.AreEqual(sc.Name, "修改后的分类");

            cr.DeleteSubCategory(sc.ID);

            sc = cr.GetSubCategoryByID(sc.ID);
            Assert.IsNull(sc);

            cr.DeleteBigCategory(bc.ID);
        }
    }
}
