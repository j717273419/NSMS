using EPig.Model.Entities;
using EPig.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Interface
{
    public interface INewsResposity
    {
        ENews AddNews(String title, String categoryId, String userId, String departId, String content, NewState state = NewState.Enabled, DateTime? openTime = null);
        void EditNews(String id, String title, String categoryId, String userId, String departId, String content, NewState state = NewState.Enabled, DateTime? openTime = null);
        void ClearOpenTime(String id);
        void AddClickCount(String id);
        void DeleteNews(String id);
        ENews GetNews(String id);
        List<ENews> GetNewsByCategoryID(String categoryId,int count,int page = 0,bool asc = true);
    }
}
