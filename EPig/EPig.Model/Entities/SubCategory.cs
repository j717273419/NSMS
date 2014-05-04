using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EPig.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPig.Model.Entities
{
    [Table("FcSubCary")]
    public class SubCategory
    {
        [Column("SCID")]
        public String ID { get; set; }

        [Column("SCName")]
        public String Name { get; set; }

        [Column("SCState")]
        public CategoryStateType State { get; set; }

        [Column("SCTotal")]
        public int NewsTotal { get; set; }

        [Column("CID")]
        public String BigCategoryID { get; set; }
    }
}
