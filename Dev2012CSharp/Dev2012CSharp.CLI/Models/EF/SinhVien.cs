//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dev2012CSharp.CLI.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            this.KetQua = new HashSet<KetQua>();
        }
    
        public int Id { get; set; }
        public int IdLop { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public Nullable<double> DiemTrungBinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQua> KetQua { get; set; }
        public virtual Lop Lop { get; set; }
    }
}
