using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Models
{
    public partial class SinhVienModel
    {
        public int Id { get; set; }
        public int IdLop { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public double DiemTrungBinh { get; set; }
        public double DTB { get; set; }

        public SinhVienModel()
        {

        }

        public void Print()
        {
            Console.WriteLine($"Id: {this.Id}, IdLop: {this.IdLop}, HoVaTen: {this.Ho} {this.Ten}, NgaySinh: {this.NgaySinh.ToString("dd/MM/yyyy")}, Email: {this.Email}, DiaChi: {this.DiaChi}.");
        }
    }
}
