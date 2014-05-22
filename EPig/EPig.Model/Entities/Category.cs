using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPig.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPig.Model.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Column("CID")]
        public int? ID { get; set; }

        //父类id
        [Column("CParentID")]
        public int? ParentID { get; set; }

        //分类名称
        [Column("CName")]
        public String Name { get; set; }

        //建议url
        [Column("CSuggestUrl")]
        public String SuggestUrl { get; set; }

        //微缩图
        [Column("CImgPath")]
        public String ImgPath { get; set; }
    }
}