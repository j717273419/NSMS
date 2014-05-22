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

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<News> News { get; set; }
    }
}
