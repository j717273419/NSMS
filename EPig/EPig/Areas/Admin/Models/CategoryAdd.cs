using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPig.Areas.Admin.Models
{
    public class CategoryAdd
    {
        public String CType { get; set; }
        public String CName { get; set; }
        public String CSuggestUrl { get; set; }
        public HttpPostedFileBase CFileUp { get; set; }
    }
}