//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dev2012.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Releaser
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
