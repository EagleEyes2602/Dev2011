using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Models
{
    /// <summary>
    /// Lớp khoa
    /// </summary>
    public class Department
    {
        // Thuộc tính
        protected int Id { get; set; }
        protected string Ten { get; set; }
        protected string Phong { get; set; }

        // Hàm tạo không tham số
        protected Department()
        {
            this.Id = 0;
            this.Ten = string.Empty;
            this.Phong = string.Empty;
        }

        // Hàm tạo có tham số
        protected Department(int id, string ten, string phong)
        {
            this.Id = id;
            this.Ten = ten;
            this.Phong = phong;
        }

        // Phương thức
        public virtual void Print()
        {
            Console.WriteLine($"Khoa:: Id: {this.Id}, Tên: {this.Ten}, Phòng: {this.Phong}");
        }

        public virtual void Update(int id, string ten, string phong)
        {
            this.Id = id;
            this.Ten = ten;
            this.Phong = phong;
            Console.WriteLine($"Thông tin Khoa sau khi sửa:: Id: {this.Id}, Tên: {this.Ten}, Phòng: {this.Phong}");
        }
    }
}
