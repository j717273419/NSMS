using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPig.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPig.Model.Entities
{
    [Table("FcCategory")]
    public class BigCategory
    {
        public BigCategory()
        {
            State = CategoryStateType.Enabled;
        }

        [Column("CID")]
        public String ID { get; set; }

        [Column("CName")]
        public String Name { get; set; }

        [Column("CState")]
        public CategoryStateType State { get; set; }

        [Column("CTime")]
        public DateTime CreateTime { get; set; }
    }
}
