using EPig.Model.Entities;
using EPig.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Interface
{
    /// <summary>
    /// 分类功能接口
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <param name="page">需要获取哪一页</param>
        /// <param name="count">每页显示的项数</param>
        /// <returns>返回IList<Category>类型的新闻</returns>
        IList<Category> GetAllCategorys(int? page = null, int? count = null);

        /// <summary>
        /// 根据ID获取分类
        /// </summary>
        /// <param name="cid">分类ID</param>
        /// <returns>如果存在则返回，否则返回NULL</returns>
        Category GetCategoryById(int cid);

        /// <summary>
        /// 根据建议URL获取分类
        /// </summary>
        /// <param name="suggestUrl">建议URL</param>
        /// <returns>如果存在则返回，否则返回NULL</returns>
        Category GetCategoryBySuggestUrl(String suggestUrl);

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="name">分类名称</param>
        /// <param name="suggestUrl">建议URL</param>
        /// <param name="imgPath">微缩图</param>
        /// <param name="parentId">父类ID</param>
        /// <exception cref="ExistedCategoryNameException">存在重复的分类名称</exception>
        /// <exception cref="ExistedSuggestUrlException">存在重复的建议URL</exception>
        /// <exception cref="NotFoundCategoryException">指定的父类不存在</exception>
        void AddCategory(String name, String suggestUrl, String imgPath, int? parentId);

        /// <summary>
        /// 根据ID删除分类
        /// </summary>
        /// <param name="cid">分类ID</param>
        /// <exception cref="CategoryHaveNewsException">指定的分类下存在新闻</exception>
        /// <exception cref="NotFoundCategoryException">指定的分类不存在</exception>
        void DeleteCategoryById(int cid);

        /// <summary>
        /// 根据分类ID修改分类
        /// </summary>
        /// <param name="cid">分类ID</param>
        /// <param name="name">分类名称</param>
        /// <param name="suggestUrl">建议URL</param>
        /// <param name="imgPth">微缩图路径</param>
        /// <param name="parentID">父类ID</param>
        /// <exception cref="NotFoundCategoryException">不存在指定的分类</exception>
        /// <exception cref="ExistedCategoryNameException">存在重复的分类名称</exception>
        /// <exception cref="ExistedSuggestUrlException">存在重复的建议URL</exception>
        void EditCategoryById(int cid, String name, String suggestUrl = null, String imgPth = null, int? parentID = null);
    }

    #region 接口中的异常

    /// <summary>
    /// 查找不到指定的分类
    /// </summary>
    public class NotFoundCategoryException : ApplicationException
    {

    }

    /// <summary>
    /// 存在重复的分类名称异常
    /// </summary>
    public class ExistedCategoryNameException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "无法插入重复的分类名称";
            }
        }
    }

    /// <summary>
    /// 存在重复的建议URL
    /// </summary>
    public class ExistedSuggestUrlException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "无法插入重复的建议URL";
            }
        }
    }

    /// <summary>
    /// 分类下存在新闻
    /// </summary>
    public class CategoryHaveNewsException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "该分类下存在新闻";
            }
        }
    }

    #endregion 接口中的异常
}
