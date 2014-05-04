using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPig.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPig.Model.Entities
{
    [Table("DbNews")]
    public class ENews
    {
        [Column("NID")]
        public String ID { get; set; }

        [Column("NTitle")]
        public String Title { get; set; }

        [Column("NTime")]
        public DateTime CreateTime { get; set; }

        [Column("NSCID")]
        public String SubCategoryID { get; set; }

        [Column("NOpTime")]
        public DateTime? LazyTime { get; set; }

        [Column("NContent")]
        public String Content { get; set; }

        [Column("NCount")]
        public int WatchCount { get; set; }

        [Column("UID")]
        public String UserID { get; set; }

        [Column("DID")]
        public String DepartmentID { get; set; }

        [Column("NState")]
        public NewState State { get; set; }
    }
}
