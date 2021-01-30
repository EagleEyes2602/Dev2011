using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dev2012.Web.Models
{
    public class InformationModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}