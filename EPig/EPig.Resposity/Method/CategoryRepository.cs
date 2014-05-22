using EPig.Model.Constaint;
using EPig.Model.Entities;
using EPig.Model.Enums;
using EPig.Resposity.Interface;
using EPig.Utiliy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Method
{
    /// <summary>
    /// 分类功能接口的具体实现
    /// </summary>
    public class CategoryRepository : BaseResposity, ICategoryRepository
    {
        /// <summary>
        /// 判断是否存在分类
        /// </summary>
        /// <param name="cid">分类id</param>
        /// <returns>存在返回true否则返回false</returns>
        public bool ExistedCategory(int cid)
        {
            int count = (from item in Context.Categorys
                         where item.ID.Equals(cid)
                         select item).Count();
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 判断是否存在分类
        /// </summary>
        /// <param name="suggestUrl">建议Url</param>
        /// <returns>存在返回true否则返回false</returns>
        public bool ExistedCategory(String suggestUrl, int? cid = null)
        {
            int count = 0;
            var exists = from item in Context.Categorys
                        where item.SuggestUrl.Equals(suggestUrl)
                        select item;
            if (cid != null)
            {
                count = exists.Where(a => !a.SuggestUrl.Equals(suggestUrl)).Count();
            }
            else
            {
                count = exists.Count();
            }
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 判断是否存在重复的分类名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ExistedCategoryName(String name, int? cid = null)
        {
            int count = 0;
            var exists = from item in Context.Categorys
                         where item.Name.Equals(name)
                         select item;
            if (cid != null)
            {
                count = exists.Where(a => !a.ID.Equals(cid)).Count();
            }
            else
            {
                count = exists.Count();
            }
            return count > 0 ? true : false;
        }

        #region ICategoryRepository接口实现

        //相关注释见接口

        public IList<Category> GetAllCategorys(int? page = null, int? count = null)
        {
            var result = new List<Category>();
            if (page != null && count != null)
            {
                int skipCount = page.Value * count.Value;
                result = Context.Categorys.Skip(skipCount).Take(count.Value).ToList();
            }
            else
            {
                result = Context.Categorys.ToList();
            }
            return result;
        }

        public Category GetCategoryById(int cid)
        {
            if (ExistedCategory(cid))
            {
                Category result = (from item in Context.Categorys
                                   where item.ID.Equals(cid)
                                   select item).FirstOrDefault();
                return result;
            }
            return null;
        }

        public Category GetCategoryBySuggestUrl(string suggestUrl)
        {
            if (ExistedCategory(suggestUrl))
            {
                Category result = (from item in Context.Categorys
                                   where item.SuggestUrl.Equals(suggestUrl)
                                   select item).FirstOrDefault();
                return result;
            }
            return null;
        }

        public void AddCategory(string name, string suggestUrl, string imgPath, int? parentId)
        {
            if (ExistedCategoryName(name))
            {
                throw new ExistedCategoryNameException();
            }
            if (ExistedCategory(suggestUrl))
            {
                throw new ExistedSuggestUrlException();
            }
            if (parentId != null && !ExistedCategory(parentId.Value))
            {
                throw new NotFoundCategoryException();
            }
            Category c = Context.Categorys.Create();
            c.Name = name.Trim();
            c.SuggestUrl = suggestUrl;
            c.ImgPath = imgPath;
            c.ParentID = parentId;
            Context.Categorys.Add(c);
            Context.SaveChanges();
        }

        public void DeleteCategoryById(int cid)
        {
            if (Context.News.Where(a => a.CategoryID.Equals(cid)).Count() > 0)
            {
                throw new CategoryHaveNewsException();
            }
            if (!ExistedCategory(cid))
            {
                throw new NotFoundCategoryException();
            }
            Category c = GetCategoryById(cid);
            if (c != null)
            {
                Context.Categorys.Remove(c);
                Context.SaveChanges();
            }
        }

        public void EditCategoryById(int cid, string name, string suggestUrl = null, string imgPth = null, int? parentID = null)
        {
            if (!ExistedCategory(cid))
            {
                throw new NotFoundCategoryException();
            }
            if (parentID != null && !ExistedCategory(parentID.Value))
            {
                throw new NotFoundCategoryException();
            }
            if (ExistedCategoryName(name, cid))
            {
                throw new ExistedCategoryNameException();
            }
            if (ExistedCategory(suggestUrl, cid))
            {
                throw new ExistedSuggestUrlException();
            }
            Category c = GetCategoryById(cid);
            if (c != null)
            {
                c.Name = name ?? c.Name;
                c.SuggestUrl = suggestUrl ?? c.SuggestUrl;
                c.ImgPath = imgPth ?? c.ImgPath;
                c.ParentID = parentID ?? c.ParentID;
                Context.Categorys.Attach(c);
                Context.SaveChanges();
            }
        }

        #endregion ICategoryRepository接口实现
    }
}
