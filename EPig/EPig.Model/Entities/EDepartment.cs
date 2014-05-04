using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EPig.Model.Enums;

namespace EPig.Model.Entities
{
    [Table("DbDpnt")]
    public class EDepartment
    {
        [Column("DID")]
        public String ID { get; set; }

        [Column("DName")]
        public String Name { get; set; }

        [Column("DState")]
        public DepartmentType State { get; set; }
    }
}
