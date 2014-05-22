using EPig.Model.Entities;
using EPig.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Interface
{
    /// <summary>
    /// 新闻功能接口
    /// </summary>
    public interface INewsRepository
    {
        /// <summary>
        /// 根据ID获取新闻
        /// </summary>
        /// <param name="nid">新闻ID</param>
        /// <returns>如果存在则返回否则返回NULL</returns>
        News GetNewsById(int nid);

        /// <summary>
        /// 获取所有新闻
        /// </summary>
        /// <param name="page">需要获取哪一页</param>
        /// <param name="count">每页显示的项数</param>
        /// <param name="cid">所属分类id</param>
        /// <returns>返回IList<News>类型的数据</returns>
        IList<News> GetAllNews(int? page = null, int? count = null, int? cid = null);

        /// <summary>
        /// 新建一个新闻
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="cid">分类Id</param>
        /// <param name="content">内容</param>
        /// <param name="userId">发表用户id</param>
        /// <exception cref="NotFoundCategoryException">指定的分类不存在</exception>
        void AddNews(String title, int cid, String content, String userId);

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="nid">需要修改的新闻id</param>
        /// <param name="title">标题</param>
        /// <param name="cid">分类id</param>
        /// <param name="conetnt">内容</param>
        /// <exception cref="NotFoundNewsException">不存在指定的新闻</exception>
        /// <exception cref="NotFoundCategoryException">不存在指定的分类</exception>
        void EditNews(int nid, String title, int? cid = null, String conetnt = null);

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="nid">需要删除的新闻id</param>
        /// <exception cref="NotFoundNewsException">不存在指定的新闻</exception>
        void DeleteNews(int nid);

        /// <summary>
        /// 增加新闻的查看次数
        /// </summary>
        /// <param name="nid">新闻id</param>
        /// <returns>返回增加后的新闻查看次数</returns>
        /// <exception cref="NotFoundNewsException">不存在指定的新闻</exception>
        int AddWatchCount(int nid);
    }

    #region 接口异常

    /// <summary>
    /// 查找不到指定的新闻
    /// </summary>
    public class NotFoundNewsException : ApplicationException
    {
    }

    #endregion 接口异常
}