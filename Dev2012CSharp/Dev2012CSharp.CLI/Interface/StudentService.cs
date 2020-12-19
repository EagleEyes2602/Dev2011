using Dev2012CSharp.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Interface
{
    public class StudentService : IStudentService
    {
        public List<Student> students;
        public StudentService()
        {
            // Khởi tạo dữ liệu
            // Coi như đây là 1 DB
            students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Ho = "Quan",
                    Ten = "Viet",
                    Tuoi = 23,
                },
                new Student()
                {
                    Id = 2,
                    Ho = "Nguyen Anh",
                    Ten = "Tuan",
                    Tuoi = 23,
                },
            };
        }

        public List<Student> GetAll()
        {
            // Trả về toàn bộ dữ liệu
            return students;
        }

        public Student GetById(int id)
        {
            // Lấy ra thông tin những sinh viên có Id = id
            // select * from students where id = @id
            var result = students.Where(x => x.Id == id);

            // Top 1
            return result.FirstOrDefault();
        }

        public int Insert(Student student)
        {
            students.Add(student);
            return 1;
        }

        public int Update(Student student)
        {
            this.Delete(student);
            this.Insert(student);
            return 1;
        }
        public int Delete(Student student)
        {
            students.Remove(students.Where(x=>x.Id == student.Id).FirstOrDefault());
            return 1;
        }

        public void Print(List<Student> students)
        {
            foreach (var item in students)
            {
                item.Print();
            }
        }
    }
}
