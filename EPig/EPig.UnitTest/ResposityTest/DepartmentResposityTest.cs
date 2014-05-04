using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPig.Resposity.Method;
using EPig.Model.Entities;
using EPig.Resposity.ThrowErr;

namespace EPig.UnitTest.ResposityTest
{
    [TestClass]
    public class DepartmentResposityTest
    {
        private DepartmentResposity dr = new DepartmentResposity();

        [TestMethod]
        public void DepartmentTest()
        {
            EDepartment ed = dr.AddDepartment("部门", Model.Enums.DepartmentType.Enabled);
            ed = dr.GetDepartmentById(ed.ID);
            Assert.IsNotNull(ed);

            dr.EditDepartment(ed.ID, "修改后的部门", Model.Enums.DepartmentType.Enabled);
            ed = dr.GetDepartmentById(ed.ID);
            Assert.AreEqual(ed.Name, "修改后的部门");

            dr.DeleteDepartmentById(ed.ID);

            ed = dr.GetDepartmentById(ed.ID);
            Assert.IsNull(ed);
        }
    }
}
