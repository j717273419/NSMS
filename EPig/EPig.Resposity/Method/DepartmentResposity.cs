using EPig.Model.Entities;
using EPig.Model.Enums;
using EPig.Resposity.Interface;
using EPig.Resposity.ThrowErr;
using EPig.Utiliy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Method
{
    public class DepartmentResposity : BaseResposity, IDepartmentResposity
    {
        /// <summary>
        /// 添加一个部门
        /// </summary>
        public EDepartment AddDepartment(string name, DepartmentType state)
        {
            EDepartment dp = Dc.Department.Create();
            dp.ID = SqlDataHelper.CreateID();
            dp.Name = name;
            dp.State = state;
            try
            {
                Dc.Department.Add(dp);
                Dc.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new DbSaveException();
            }
            return dp;
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        public void EditDepartment(string id, string name, DepartmentType state)
        {
            EDepartment dp = Dc.Department.Find(id);
            if (dp == null)
            {
                throw new DbNotFoundException();
            }
            int count = (from item in Dc.Department
                        where item.Name.Equals(name)
                        && !item.ID.Equals(id)
                        select item).Count();
            if (count > 0)
            {
                throw new ExistedDepartmentNameException();
            }
            if (name != null)
            {
                dp.Name = name;
            }
            dp.State = state;
            try
            {
                Dc.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new DbSaveException();
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        public void DeleteDepartmentById(string id)
        {
            EDepartment dp = Dc.Department.Find(id);
            if (dp == null)
            {
                throw new DbNotFoundException();
            }
            Dc.Department.Remove(dp);
            try
            {
                Dc.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new DbDeleteException();
            }
        }

        /// <summary>
        /// 获取部门
        /// </summary>
        public EDepartment GetDepartmentById(string id)
        {
            return Dc.Department.Find(id);
        }
    }
}
