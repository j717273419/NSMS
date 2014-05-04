using EPig.Model.Entities;
using EPig.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Interface
{
    public interface ICategoryResposity
    {
        BigCategory GetBigCategoryByID(String id);
        SubCategory GetSubCategoryByID(String id);
        List<SubCategory> GetSubCategoryListByBID(String bid);
        List<BigCategory> GetAllBigCategory();
        List<SubCategory> GetAllSubCategory();
        void AddSubCategoryCount(String id);
        BigCategory AddBigCategory(String name, CategoryStateType state);
        SubCategory AddSubCategory(String id, String name, CategoryStateType state);
        void DeleteBigCategory(String id);
        void DeleteSubCategory(String id);
        void EditBigCategory(String id,String name,CategoryStateType state);
        void EditSubCategory(String id, String name,String parentid, CategoryStateType state);
    }
}
