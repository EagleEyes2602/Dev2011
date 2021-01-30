using Dev2012.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dev2012.Web.ViewModel
{
    public partial class AboutViewModel
    {
        public AccountModel Account { get; set; }
        public List<InformationModel> AccountInformation { get; set; }
    }
}