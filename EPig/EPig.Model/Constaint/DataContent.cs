using EPig.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EPig.Model.Constaint
{
    public class DataContent : DbContext
    {
        public DataContent()
            : base("EPigData")
        {
        }


        public DbSet<EUser> User { get; set; }
        public DbSet<BigCategory> BigCategory { get; set; }
        public DbSet<EDepartment> Department { get; set; }
        public DbSet<ENews> News { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
    }
}
