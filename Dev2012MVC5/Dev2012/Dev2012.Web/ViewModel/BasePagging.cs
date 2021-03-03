using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dev2012.Web.ViewModel
{
    public class BasePaging<T>
    {
        public int TotalRecord { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public List<T> Data{ get; set; }

    }
}