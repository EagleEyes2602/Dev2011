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
    
    public partial class Reader
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public byte Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<decimal> Money { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public Nullable<int> GeographyId { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> UpdatedTime { get; set; }
        public Nullable<System.DateTime> DeletedTime { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public string Notes { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}