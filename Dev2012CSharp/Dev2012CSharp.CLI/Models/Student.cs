using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Models
{
    public class Student
    {
        private string ho;
        private string ten;
        private int tuoi;
        private DateTime ngaySinh;
        private bool gioiTinh;

        // read only
        // write only
        // read / write
        public string Ho
        {
            get { return ho; }
            set { ho = value; }
        }
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        public int Tuoi
        {
            get { return tuoi; }
            set { tuoi = value; }
        }
        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        public bool GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        // Phương thức khởi tạo
        // Không tham số
        public Student()
        {
            this.Ho = "Nguyễn";
            this.Ten = "Đạt";
            this.Tuoi = 20;
            this.NgaySinh = new DateTime(2000, 3, 8);
            this.GioiTinh = true;
        }

        ~Student()
        {
            Console.WriteLine("Đối tượng đã bị hủy");
        }

        /// <summary>
        /// Phương thức khởi tạo có tham số
        /// </summary>
        /// <param name="Ho">Họ</param>
        /// <param name="Ten">Tên</param>
        /// <param name="Tuoi">Tuổi</param>
        /// <param name="NgaySinh">Ngày sinh</param>
        /// <param name="GioiTinh">Giới tính</param>
        public Student(string Ho, string Ten, int Tuoi, DateTime NgaySinh, bool GioiTinh)
        {
            this.Ho = Ho;
            this.Ten = Ten;
            this.Tuoi = Tuoi;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="Ho">Họ</param>
        /// <param name="Ten">Tên</param>
        /// <param name="Tuoi">Tuổi</param>
        /// <param name="NgaySinh">Ngày sinh</param>
        /// <param name="GioiTinh">Giới tính</param>
        public void Print(string Ho, string Ten, int Tuoi, DateTime NgaySinh, bool GioiTinh)
        {
            Console.WriteLine("Họ: " + Ho);
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="Ho">Họ</param>
        /// <param name="Ten">Tên</param>
        /// <param name="Tuoi">Tuổi</param>
        /// <param name="NgaySinh">Ngày sinh</param>
        /// <param name="GioiTinh">Giới tính</param>
        public void Print()
        {
            Console.WriteLine("Họ và tên: " + this.Ho + " " + this.Ten);
            Console.WriteLine("Tuổi: " + this.Tuoi);
            Console.WriteLine("Ngày sinh: " + this.NgaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Giới tính: " + this.GioiTinh);
        }
    }
}
