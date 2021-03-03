using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dev2012.Web.Models.MetaData
{
    [MetadataType(typeof(Publisher.Metadata))]
    public partial class Publisher
    {
        private sealed class Metadata
        {
            [Required]
            [StringLength(15, MinimumLength = 8, ErrorMessage = "Mã không được nhỏ hơn 8 ký tự và lớn hơn 15 ký tự")]
            [DisplayName("Mã NXB")]
            public string Code { get; set; }

            [Required(ErrorMessage = "Tên không được để trống")]
            [DisplayName("Tên NXB")]
            public string Name { get; set; }

            [DisplayName("Chú thích")]
            public string Notes { get; set; }

            [Required]
            [Range(0, 1, ErrorMessage = "Trạng thái chỉ có thể là 0 hoặc 1")]
            [DisplayName("Trạng thái")]
            public Nullable<byte> Status { get; set; }

        }
    }
}