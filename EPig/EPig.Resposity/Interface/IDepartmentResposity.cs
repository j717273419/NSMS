using EPig.Model.Entities;
using EPig.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPig.Resposity.Interface
{
    public interface IDepartmentResposity
    {
        EDepartment AddDepartment(String name,DepartmentType state);
        void EditDepartment(String id, String name, DepartmentType state);
        void DeleteDepartmentById(String id);
        EDepartment GetDepartmentById(String id);
    }
}
