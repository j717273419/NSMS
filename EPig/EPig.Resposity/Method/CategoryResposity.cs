using EPig.Model.Constaint;
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
    public class CategoryResposity : BaseResposity, ICategoryResposity
    {
        /// <summary>
        /// 获取大类信息
        /// </summary>
        public BigCategory GetBigCategoryByID(string id)
        {
            return Dc.BigCategory.Find(id);
        }

        /// <summary>
        /// 获取小类信息
        /// </summary>
        public SubCategory GetSubCategoryByID(string id)
        {
            SubCategory subCate = Dc.SubCategory.Find(id);
            return subCate;
        }

        /// <summary>
        /// 获取大类下的小类
        /// </summary>
        public List<SubCategory> GetSubCategoryListByBID(string bid)
        {
            List<SubCategory> subCates = (from item in Dc.SubCategory
                                          where item.BigCategoryID.Equals(bid)
                                          select item).ToList();
            return subCates;
        }

        /// <summary>
        /// 获取所有大类
        /// </summary>
        public List<BigCategory> GetAllBigCategory()
        {
            List<BigCategory> bigCates = null;
            bigCates = Dc.BigCategory.ToList();
            return bigCates;
        }

        /// <summary>
        /// 获取所有小类
        /// </summary>
        public List<SubCategory> GetAllSubCategory()
        {
            List<SubCategory> subCates = null;
            subCates = Dc.SubCategory.ToList();
            return subCates;
        }

        /// <summary>
        /// 增加该子分类下的新闻总数
        /// </summary>
        public void AddSubCategoryCount(string id)
        {
            SubCategory subCate = (from item in Dc.SubCategory
                                   where item.ID.Equals(id)
                                   select item).FirstOrDefault();
            if (subCate == null)
            {
                throw new DbNotFoundException();
            }
            else
            {
                subCate.NewsTotal += 1;
                try
                {
                    Dc.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    throw new DbSaveException();
                }
            }
        }

        /// <summary>
        /// 添加一个大分类
        /// </summary>
        public BigCategory AddBigCategory(String name, CategoryStateType state)
        {
            BigCategory bigCate = (from item in Dc.BigCategory
                                   where item.Name.Equals(name)
                                   select item).FirstOrDefault();
            if (bigCate == null)
            {
                bigCate = Dc.BigCategory.Create();
                bigCate.Name = name;
                bigCate.State = state;
                bigCate.ID = SqlDataHelper.CreateID();
                bigCate.CreateTime = DateTime.Now;
                Dc.BigCategory.Add(bigCate);
                try
                {
                    Dc.SaveChanges();
                }
                catch (Exception)
                {
                    throw new DbSaveException();
                }
            }
            else
            {
                throw new ExistedCategoryNameException();
            }
            return bigCate;
        }

        /// <summary>
        /// 添加一个小分类
        /// </summary>
        public SubCategory AddSubCategory(String id, String name, CategoryStateType state)
        {
            SubCategory subC = new SubCategory();
            subC.BigCategoryID = id;
            subC.Name = name;
            int count = (from item in Dc.BigCategory
                         where item.ID.Equals(subC.BigCategoryID)
                         select item).Count();
            if (count > 0)
            {
                count = (from item in Dc.SubCategory
                         where item.Name.Equals(subC.Name)
                         && item.BigCategoryID.Equals(id)
                         select item).Count();
                if (count <= 0)
                {
                    subC.ID = SqlDataHelper.CreateID();
                    subC.NewsTotal = 0;
                    subC.State = Model.Enums.CategoryStateType.Enabled;
                    Dc.SubCategory.Add(subC);
                    try
                    {
                        Dc.SaveChanges();
                    }
                    catch (InvalidOperationException)
                    {
                        throw new DbSaveException();
                    }
                }
                else
                {
                    throw new ExistedCategoryNameException();
                }
            }
            else
            {
                throw new DbNotFoundException();
            }
            return subC;
        }

        /// <summary>
        /// 删除父类以及对应的子类
        /// </summary>
        public void DeleteBigCategory(string id)
        {
            BigCategory bigCate = Dc.BigCategory.Find(id);
            if (bigCate == null)
            {
                throw new DbNotFoundException();
            }
            else
            {
                List<SubCategory> SucList = (from item in Dc.SubCategory
                                             where item.BigCategoryID.Equals(bigCate.ID)
                                             select item).ToList();
                Dc.BigCategory.Remove(bigCate);
                Dc.SubCategory.RemoveRange(SucList);
                try
                {
                    Dc.SaveChanges();
                }
                catch (Exception)
                {
                    throw new DbDeleteException();
                }
            }
        }

        /// <summary>
        /// 删除子类
        /// </summary>
        public void DeleteSubCategory(string id)
        {
            SubCategory subCate = Dc.SubCategory.Find(id);
            if (subCate == null)
            {
                throw new DbNotFoundException();
            }
            else
            {
                Dc.SubCategory.Remove(subCate);
                try
                {
                    Dc.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    throw new DbDeleteException();
                }
            }
        }

        /// <summary>
        /// 修改父类
        /// </summary>
        public void EditBigCategory(String id, String name, CategoryStateType state)
        {
            BigCategory bigC = GetBigCategoryByID(id);
            if (bigC == null)
            {
                throw new DbNotFoundException();
            }
            int count = (from item in Dc.BigCategory
                         where !item.ID.Equals(id)
                         && item.Name.Equals(name)
                         select item).Count();
            if (count > 0)
            {
                throw new ExistedCategoryNameException();
            }
            else
            {
                bigC.State = state;
                if (name != null)
                {
                    bigC.Name = name;
                }
                try
                {
                    Dc.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    throw new DbSaveException();
                }
            }
        }

        /// <summary>
        /// 修改子类
        /// </summary>
        public void EditSubCategory(String id, String name, String parentid, CategoryStateType state)
        {
            SubCategory subC = GetSubCategoryByID(id);
            if (subC == null)
            {
                throw new DbNotFoundException();
            }
            
            if (parentid != null)
            {
                BigCategory bigCate = Dc.BigCategory.Find(parentid);
                if (bigCate == null)
                {
                    throw new DbNotFoundException();
                }
            }
            if (name != null)
            {
                subC.Name = name;
            }
            if (parentid != null)
            {
                subC.BigCategoryID = parentid;
            }
            subC.State = state;
            try
            {
                Dc.SaveChanges();
            }
            catch (Exception)
            {
                throw new DbSaveException();
            }
        }
    }
}
