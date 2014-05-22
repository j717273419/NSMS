using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPig.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EPig.Model.Entities
{
    [Table("News")]
    public class News
    {
        [Key]
        [Column("NID")]
        public String ID { get; set; }

        //标题
        [Column("NTitle")]
        public String Title { get; set; }

        //发表时间
        [Column("NPublishTime")]
        public DateTime PublishTime { get; set; }

        //分类id
        [Column("NCategoryID")]
        public int CategoryID { get; set; }

        //内容
        [Column("NContent")]
        public String Content { get; set; }

        //查看次数
        [Column("NWatchCount")]
        public int WatchCount { get; set; }

        //发表用户
        [Column("UID")]
        public String UserID { get; set; }
    }
}