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
    /// 新闻功能的具体实现
    /// </summary>
    public class NewsRepository : BaseResposity, INewsRepository
    {
        /// <summary>
        /// 判断是否存在新闻
        /// </summary>
        /// <param name="nid">新闻id</param>
        /// <returns>存在则返回true否则返回false</returns>
        protected bool ExistedNews(int nid)
        {
            int count = (from item in Context.News
                         where item.ID.Equals(nid)
                         select item).Count();
            return count > 0 ? true : false;
        }

        #region INewsRepository接口实现

        //注释见接口

        public News GetNewsById(int nid)
        {
            if (ExistedNews(nid))
            {
                News n = (from item in Context.News
                          where item.ID.Equals(nid)
                          select item).FirstOrDefault();
                return n;
            }
            return null;
        }

        public IList<News> GetAllNews(int? page = null, int? count = null, int? cid = null)
        {
            var news = new List<News>();
            if (page != null && count != null)
            {
                int skipCount = page.Value * count.Value;
                news = Context.News.Skip(skipCount).Take(count.Value).ToList();
            }
            else if (cid != null)
            {
                news = Context.News.Where(a => a.CategoryID.Equals(cid)).ToList();
            }
            else if (page != null && count != null && cid != null)
            {
                int skipCount = page.Value * count.Value;
                news = Context.News.Where(a => a.CategoryID.Equals(cid)).Skip(skipCount).Take(count.Value).ToList();
            }
            else
            {
                news = Context.News.ToList();
            }
            return news;
        }

        public void AddNews(string title, int cid, string content, string userId)
        {
            CategoryRepository cpository = new CategoryRepository();
            if (cpository.ExistedCategory(cid))
            {
                News n = Context.News.Create();
                n.Title = title;
                n.CategoryID = cid;
                n.Content = content;
                n.UserID = userId;
                n.PublishTime = DateTime.Now;
                Context.News.Add(n);
                Context.SaveChanges();
            }
            else
            {
                throw new NotFoundCategoryException();
            }
        }

        public void EditNews(int nid, string title, int? cid = null, string conetnt = null)
        {
            if (!ExistedNews(nid))
            {
                throw new NotFoundNewsException();
            }
            CategoryRepository crepositroy = new CategoryRepository();
            if (cid != null && !crepositroy.ExistedCategory(cid.Value))
            {
                throw new NotFoundCategoryException();
            }
            News n = GetNewsById(nid);
            if (n != null)
            {
                n.Title = title ?? n.Title;
                n.CategoryID = cid ?? n.CategoryID;
                n.Content = conetnt ?? n.Content;
                Context.News.Attach(n);
                Context.SaveChanges();
            }
        }

        public void DeleteNews(int nid)
        {
            if (!ExistedNews(nid))
            {
                throw new NotFoundNewsException();
            }
            News n = GetNewsById(nid);
            if (n != null)
            {
                Context.News.Remove(n);
                Context.SaveChanges();
            }
        }

        public int AddWatchCount(int nid)
        {
            int result = 0;
            if (!ExistedNews(nid))
            {
                throw new NotFoundNewsException();
            }
            News n = GetNewsById(nid);
            if (n != null)
            {
                n.WatchCount++;
                result = n.WatchCount;
                Context.News.Attach(n);
                Context.SaveChanges();
            }
            return result;
        }

        #endregion INewsRepository接口实现
    }
}
