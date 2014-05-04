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
    public class NewsResposity : BaseResposity, INewsResposity
    {
        /// <summary>
        /// 添加新闻
        /// </summary>
        public ENews AddNews(string title, string categoryId, string userId, string departId, string content, NewState state = NewState.Enabled, DateTime? openTime = null)
        {
            ENews news = Dc.News.Create();
            news.ID = SqlDataHelper.CreateID();
            news.CreateTime = DateTime.Now;
            news.Content = content;
            news.DepartmentID = departId;
            news.LazyTime = openTime;
            news.State = state;
            news.SubCategoryID = categoryId;
            news.Title = title;
            news.UserID = userId;
            news.WatchCount = 0;
            Dc.News.Add(news);
            try
            {
                Dc.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new DbSaveException();
            }
            return news;
        }

        /// <summary>
        /// 修改新闻
        /// </summary>
        public void EditNews(string id, string title, string categoryId, string userId, string departId, string content,NewState state = NewState.Enabled, DateTime? openTime = null)
        {
            ENews news = GetNews(id);
            if (news == null)
            {
                throw new DbNotFoundException();
            }
            if (title != null)
            {
                news.Title = title;
            }
            if (categoryId != null)
            {
                SubCategory subC = Dc.SubCategory.Find(categoryId);
                if (subC == null)
                {
                    throw new DbNotFoundException();
                }
                news.SubCategoryID = categoryId;
            }
            if (userId != null)
            {
                EUser user = Dc.User.Find(userId);
                if (user == null)
                {
                    throw new DbNotFoundException();
                }
                news.UserID = userId;
            }
            if (departId != null)
            {
                EDepartment dp = Dc.Department.Find(departId);
                if (dp == null)
                {
                    throw new DbNotFoundException();
                }
                news.DepartmentID = departId;
            }
            if (content != null)
            {
                news.Content = content;
            }
            if (openTime != null)
            {
                news.LazyTime = openTime;
            }
            news.State = state;
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
        /// 清除延时开启
        /// </summary>
        public void ClearOpenTime(string id)
        {
            ENews news = GetNews(id);
            if (news == null)
            {
                throw new DbNotFoundException();
            }
            news.LazyTime = null;
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
        /// 增加查看数
        /// </summary>
        public void AddClickCount(string id)
        {
            ENews news = GetNews(id);
            if (news == null)
            {
                throw new DbNotFoundException();
            }
            news.WatchCount += 1;
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
        /// 删除新闻
        /// </summary>
        public void DeleteNews(string id)
        {
            ENews news = GetNews(id);
            if (news == null)
            {
                throw new DbNotFoundException();
            }
            Dc.News.Remove(news);
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
        /// 获取新闻
        /// </summary>
        public ENews GetNews(String id)
        {
            return Dc.News.Find(id);
        }

        /// <summary>
        /// 根据分类分页获取新闻
        /// </summary>
        public List<ENews> GetNewsByCategoryID(String categoryId, int count, int page = 0, bool asc = true)
        {
            List<ENews> news = null;
            if (asc)
            {
                news = (from item in Dc.News
                        where item.SubCategoryID.Equals(categoryId)
                        orderby item.CreateTime
                        select item).Skip(count * page).Take(count).ToList();
            }
            else
            {
                news = (from item in Dc.News
                        where item.SubCategoryID.Equals(categoryId)
                        orderby item.CreateTime descending
                        select item).Skip(count * page).Take(count).ToList();
            }
            return news;
        }
    }
}
