using Dapper;
using Dev2012CSharp.CLI.Helpers;
using Dev2012CSharp.CLI.Interface;
using Dev2012CSharp.CLI.Models;
using Dev2012CSharp.CLI.Models.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using I = Dev2012CSharp.CLI.Interface;

namespace Dev2012CSharp.CLI
{
    internal class Program
    {
        private delegate string DelegateStr(string in1, string in2);
        static QLSVEntities db = new QLSVEntities();
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("START");
            // Một số kiểu dữ liệu cơ bản trong C#
            // char, string
            // Số:
            //  int: int16, int32, int 64; long
            //  decimal, double, float
            // bool
            // Class (lớp)
            // Array
            // Collection

            // Nhập xuất trong Console
            // Xuất dữ liệu
            // Console.Write
            // Console.WriteLine
            // Nhập liệu
            // Console.Read
            // Console.ReadKey
            // Console.ReadLine
            int runMode = 10;
            if (runMode == 0)
            {
                #region Cấu trúc rẽ nhánh

                int a = 100, b = 100;
                // Các biểu thức:
                // Số: >, >=, <, <=, ==, !=
                // ==, !=
                // = gán
                // not: !, and: &&, or: ||

                // if
                if (true)
                {
                    Console.WriteLine("if true 1");
                }
                // if else
                if (a == b)
                {
                    // Nếu a == b thì vào đây
                    Console.WriteLine("if true 2");
                }
                else
                {
                    // Nếu a != b thì vào đây
                    Console.WriteLine("else true");
                }
                // if else if
                if (a == b)
                {
                    // Nếu a == b thì vào đây
                }
                else if (a == 10)
                {
                    // Nếu a != b và a == 10 thì vào đây
                }
                // if lồng nhau

                // Switch case
                switch (a)
                {
                    case 1:
                        // a == 1 thì xử lý tại đây
                        break;

                    case 2:
                    case 3:
                        // a == 2 || a == 3 thì xử lý tại đây
                        break;

                    default:
                        // Không map với bất bỳ trường hợp nào ở trên
                        // Thì xử lý ở đây
                        break;
                }
                // Switch case lồng nhau

                #endregion Cấu trúc rẽ nhánh
            }
            else if (runMode == 1)
            {
                #region Cấu trúc lặp

                // while
                // Nếu biểu thức bên trong while() còn đúng thì vẫn lặp tiếp
                // 1. Kiểm tra biểu thức trong while
                // 2.1. Nếu đúng => 3
                // 2.2. Nếu sai => 4
                // 3. Thực hiện các câu lệnh trong while => 1
                // 4. Kết thúc
                // => Biên độ thức thi 0 => n

                // Thực hiện in từ 1-10
                int c = 1;
                Console.WriteLine("//==================================================//");
                while (c != 11)
                {
                    Console.WriteLine(c);
                    // c++ và ++c khác gì nhau ?
                    c++;
                }

                // do while
                // 1. Thực hiện các câu lệnh trong do
                // 2. Kiểm tra điều kiện trong while
                // 2.1 Nếu đúng => 1
                // 2.2 Nếu sai => 3
                // 3. Kết thúc
                // => Biên độ thức thi 1 => n
                c = 11;
                Console.WriteLine("//==================================================//");
                do
                {
                    Console.WriteLine(c);
                    //c--;
                } while (c != 11);

                // for
                // 1. int z = 0 thực hiện khởi tạo và gán biến chạy
                // 2. z < 10 kiểm tra điều kiện
                // 2.1 Nếu đúng => 3
                // 2.2 Nếu sai => 5
                // 3. Thực thi các câu lệnh trong for
                // 4. z++ Thực hiện bước nhảy => 2
                // 5. Kết thúc
                Console.WriteLine("//==================================================//");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("//==================================================//");
                int d = 10;
                for (int i = 0; i < d; i++)
                {
                    for (int z = d - i; z > 1; z--)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("//==================================================//");
                // Array
                int[] arr = new[] { 1, 6, 12, 0, 3, 6, 5, 6 };
                Console.WriteLine(arr[0]);
                arr[0] = 10;
                Console.WriteLine(arr[0]);
                Console.WriteLine("//==================================================//");
                // foreach
                //for (int i = 0; i < arr.Length; i++)
                //{
                //    Console.WriteLine(arr[i]);
                //}
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }

                #endregion Cấu trúc lặp
            }
            else if (runMode == 2)
            {
                #region Cấu trúc nhảy

                int[] arr = new[] { 1, 6, 12, 0, 3, 6, 5, 6 };

                // Break: thoát khỏi cấu trúc hiện tại

                // Continue:
                foreach (var item in arr)
                {
                    if (item == 12)
                    {
                        continue;
                    }
                    Console.WriteLine(item);
                }

                // Goto
                //Label: int cnt = 1;
                //    while (cnt < 10)
                //    {
                //        if (cnt == 9)
                //        {
                //            goto Label;
                //        }
                //        Console.WriteLine(cnt);
                //        cnt++;
                //    }

                // Return
                Console.WriteLine($"Mảng có {PrintArr(arr)} phần tử");

                #endregion Cấu trúc nhảy
            }
            else if (runMode == 3)
            {
                #region OOP

                // Class (Lớp)
                // Được xây dựng dựa trên các kiểu dữ liệu nguyên thủy hoặc class khác, ...
                // Trường, Thuộc tính, Phương thức

                //Student student1 = new Student();
                //Student student2 = new Student("Nguyễn", "Tuấn", 23, new DateTime(1997, 10, 20), true);
                //student1.Print();

                //Student student3 = new Student(1, "CNTT", "A101", "Nguyễn Anh", "Tuấn", 23, new DateTime(2020, 1, 1), true);

                //student3.Print();
                //Employee e = new Employee();
                //e.Speak();
                //e.DoWork();
                //e.EnviromentWork();

                StudentService service = new StudentService();
                var students = service.GetAll();
                service.Print(students);
                Console.WriteLine("Dữ liệu ban đầu ==============================================================");
                service.Insert(new Student()
                {
                    Id = 3,
                    Ho = "Nguyễn",
                    Ten = "Thảo",
                    Tuoi = 20
                });
                // sau khi insert
                service.Print(students);
                Console.WriteLine("Sau khi insert ==============================================================");
                service.Update(new Student()
                {
                    Id = 3,
                    Ho = "Nguyễn",
                    Ten = "Dũng",
                    Tuoi = 20
                });
                // sau khi update
                service.Print(students);
                Console.WriteLine("Sau khi update ==============================================================");
                service.Delete(new Student
                {
                    Id = 3,
                    Ho = "Nguyễn",
                    Ten = "Thảo",
                    Tuoi = 20
                });
                // sau khi xóa
                service.Print(students);
                Console.WriteLine("Sau khi delete ==============================================================");

                #endregion OOP
            }
            else if (runMode == 4)
            {
                // array
                // C1. Khai báo mảng int với cố định 10 phần tử
                int[] num1 = new int[11];
                // Set
                num1[0] = 10;
                // Get
                //Console.WriteLine($"num1[0]:{num1[0]}");

                // C2. Khai báo mảng int số lượng phẩn tử linh động
                int[] num2 = new int[] { 234, 34, 643, 1, 23, 12, 354, 7, 56 };

                // C3. Khai báo mảng int giống C2 nhưng ngắn hơn
                int[] num3 = { 6789, 56, 2, 346, 4, 9, 576, 5, 234, 56, 567, 97689, 56, 2, 345, 3, 44 };

                Console.WriteLine("Danh sách phần tử mảng num3:");
                for (int i = 0; i < num3.Count(); i++)
                {
                    Console.WriteLine($"num3[{i}]:{num3[i]}");
                }

                // Ref & Out
                int a = 10;
                int b = 20;
                Console.WriteLine($"Start A: {a} / B: {b}");
                Swap(ref a, ref b);
                Console.WriteLine($"End A: {a} / B: {b}");

                Console.WriteLine("Sắp xếp mảng num3:");
                // Sắp xếp
                for (int i = 0; i < num3.Length - 1; i++)
                {
                    for (int j = i; j < num3.Length; j++)
                    {
                        if (num3[i] > num3[j])
                        {
                            Swap(ref num3[i], ref num3[j]);
                        }
                    }
                }

                Array.Sort(num3);

                int arrIndex = Array.IndexOf(num3, 10);

                // In mảng
                for (int i = 0; i < num3.Count(); i++)
                {
                    Console.WriteLine($"num3[{i}]:{num3[i]}");
                }
            }
            else if (runMode == 5)
            {
                // collection
                // ArrayList
                Console.WriteLine("---------------------- ArrayList ----------------------");
                ArrayList arrayList = new ArrayList() { 3, "Devmaster", null, 'á' };
                var arr01 = arrayList[0];
                arrayList[0] = "3 Năm";
                arrayList.Add("VietQQ");
                arrayList.Insert(2, 10);
                foreach (var item in arrayList)
                {
                    Console.WriteLine(item);
                }
                arrayList.Clear();

                // HashTable
                Console.WriteLine("---------------------- HashTable ----------------------");
                Hashtable hashtable = new Hashtable();
                hashtable.Add(1, "VietQQ");
                hashtable.Add('a', null);
                hashtable.Add('2', "TuanNA");
                hashtable.Remove('a');
                foreach (DictionaryEntry item in hashtable)
                {
                    Console.WriteLine($"Key: {item.Key}_ Value: {item.Value}");
                }

                // SortedList
                Console.WriteLine("---------------------- SortedList ----------------------");
                SortedList sortedList = new SortedList();
                sortedList.Add(1, "VietQQ");
                sortedList.Add(12, null);
                sortedList.Add(6, "TuanNA");
                sortedList.Add(8, "TuanDA");
                sortedList.Add(10, "HungNS");
                sortedList.Add(2, "HungPS");
                sortedList.Add(-1, "DatNQ");
                foreach (DictionaryEntry item in sortedList)
                {
                    Console.WriteLine($"Key: {item.Key}_ Value: {item.Value}");
                }

                // Generic Collection
                // List<>
                Console.WriteLine("---------------------- List ----------------------");
                List<Student> students = new List<Student>()
                {
                    new Student()
                    {
                        Ho = "Hoàng Trung",
                        Ten = "Kiên",
                        Tuoi = 30
                    }
                };

                Student student1 = new Student();
                student1.Ho = "Nguyễn Anh";
                student1.Ten = "Tuấn";
                student1.Tuoi = 23;

                Student student2 = new Student();
                student2.Ho = "Quốc";
                student2.Ten = "Việt";
                student2.Tuoi = 23;

                students.Add(student1);
                students.Add(student2);
                // set
                students[0] = new Student()
                {
                    Ho = "Phạm Sỹ",
                    Ten = "Hưng",
                    Tuoi = 26
                };

                // get
                var studentTemp = students[0];
                studentTemp.Print();
                foreach (var student in students)
                {
                    student.Print();
                }

                // Dictionary<,>
                Console.WriteLine("---------------------- Dictionary ----------------------");
                Dictionary<string, Student> dic = new Dictionary<string, Student>()
                {
                    { "1", student1 },
                    {
                        "2", new Student(){
                            Ho = "Nguyễn Sinh",
                            Ten = "Hùng",
                            Tuoi = 23
                        }
                    }
                };
                dic.Add("3", student1);
                dic.Add("4", student2);

                //// Get
                //dic["3"].Print();
                //// Set
                //dic["3"] = student1;

                foreach (KeyValuePair<string, Student> item in dic)
                {
                    Console.WriteLine($"Key: {item.Key}");
                    Console.WriteLine("Value");
                    item.Value.Print();
                }

                // SortedList
                SortedList<string, Student> sortedListGeneric = new SortedList<string, Student>();
            }
            else if (runMode == 6)
            {
                // namespace
                Dev2012CSharp.CLI.Interface.StudentService service = new Dev2012CSharp.CLI.Interface.StudentService();
                I.StudentService serviceI = new I.StudentService();

                // exception
                // VD: kết nối đến DB
                // B1. Thực hiện xây dựng câu lệnh
                // "seelct * from table"
                // B2. Mở kết nối đến DB
                // B3. Thực thi câu lệnh đã xây dựng ở B1 và lấy kết quả trả về
                // B4. Đóng kết nối
                try
                {
                    // Những câu lệnh có khả năng sinh lỗi
                    int tu = 10;
                    int mau = 0;
                    float ketQua = tu / mau;

                    Student student = null;
                    Console.WriteLine(student.Ho);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Lỗi rổi: Không thể thao tác với dữ liệu null. {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    throw new VietQQException($"Lỗi rổi: Không thể chia 0. {ex.Message}");
                    //Console.WriteLine($"Lỗi rổi: Không thể chia 0. {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi rổi: {ex.Message}");
                    // Trong trường hợp trong TRY xảy ra lỗi thì sẽ đi vào catch
                    //throw;
                }
                finally
                {
                    // Lúc nào cũng vào đây dù có lỗi hay không
                }
            }
            else if (runMode == 7)
            {
                // delegate
                //() => (string)
                //() => ()

                DelegateStr delegateStr = new DelegateStr(ConvertStr);

                // MultiCasting
                delegateStr += ConcatStr;
                delegateStr -= ConvertStr;
                string result = delegateStr("Devmaster", "Academy");
                Console.WriteLine(result);

                // Hàm nặc danh
                DelegateStr dele = delegate (string a, string b)
                {
                    return a + " " + b;
                };

                // Hàm mũi tên
                // Lambda Expression
                DelegateStr dele1 = (string a, string b) =>
                {
                    return a + " " + b;
                };

                string res = dele("a", "b");

                List<Student> students = new List<Student>();

                // 3 loại delegate do hệ thống tạo ra
                // Action(16 param) (16 input) => void
                // lambda expression
                Action<string, string> action = (string inA, string inB) =>
                {
                    Console.WriteLine(inA + " " + inB);
                };

                action += (string inA, string inB) =>
                {
                    Console.WriteLine(inA + " " + inB);
                };

                action("Quản Quốc", "Việt");

                // Func(17 param) (16 input) => 1 dataType
                Func<string, string> func = (string name) =>
                {
                    return name + " đẹp zai";
                };
                Console.WriteLine(func("Việt"));

                // Predicate (1 input) => mặc định bool
                Predicate<string> predicate = (string check) =>
                {
                    //if (check == "Việt đẹp zai")
                    //{
                    //    return true;
                    //}
                    //return false;
                    return check == "Việt đẹp zai";
                };

                bool checkVietDZ = predicate("Việt đẹp zai");
                Console.WriteLine($"Việt có đz không? {checkVietDZ}");

                IEnumerable<Student> studentWhere = students.Where((x) => x.Ho == "Việt");

                // linq
                // linq method
                var resStudents = students.Where(x => x.Ten == "Việt").OrderBy(x => x.NgaySinh);


                // linq query
                StudentService studentService = new StudentService();
                var lstStudent = studentService.InitData();

                ResultService resultService = new ResultService();
                var lstResult = resultService.InitData();

                SubjectService subjectService = new SubjectService();
                var lstSubject = subjectService.InitData();

                var resStudents1 = (from s in lstStudent
                                    join r in lstResult on s.Id equals r.StudentId
                                    join su in lstSubject on r.SubjectId equals su.Id
                                    where r.Score > 5
                                    select new { HoTen = s.Ho + " " + s.Ten, s.Tuoi, r.Score, su.Name }).ToList();
            }
            else if (runMode == 8)
            {
                // ORM OBJECT RELATIONSHIP MANAGERMENT

                // ADO.net

                DataSet dataset = new DataSet();

                // 1. Xây dựng câu lệnh
                //chuỗi kết nối đến nguồn dữ liệu
                string connStr = @"Server=DESKTOP-A30ET4Q\EAGLEMSSQL17;Database=QLSV;Trusted_Connection=True;";

                //đối tượng kết nối tới cơ sở dữ liệu
                SqlConnection sqlconn = new SqlConnection(connStr);

                string sql = "select * from SinhVien";
                //Command điều khiển truy vấn sql
                SqlCommand sqlcmd = new SqlCommand(sql);

                // 2. Mở connection
                sqlconn.Open();

                // 3. Thực thi câu lệnh
                // 4. Nhận kết quả
                // ExecuteNonQuery: Giá trị trả về là số lượng record được tác động (Insert, Update, Delete)
                // ExecuteScalar: Giá trị trả về là 1 cell dữ liệu
                // ExecuteReader: Giá trị trả về là 1 table

                //var result = sqlcmd.ExecuteReader();

                var sqladapter = new SqlDataAdapter(sql, sqlconn);

                sqladapter.Fill(dataset);
                var res = DataTableHelper.ConvertDataTableToGenericList<SinhVienModel>(dataset.Tables[0]);
                sqladapter.Dispose();
                foreach (var item in res)
                {
                    item.Print();
                }
                // 5. Đóng connection
                sqlconn.Close();
            }
            else if (runMode == 9)
            {
                // EF6
                var sv = db.SinhVien.ToList();
                foreach (var item in sv)
                {
                    Console.WriteLine($"Id: {item.Id}, IdLop: {item.IdLop}, HoVaTen: {item.Ho} {item.Ten}, NgaySinh: {item.NgaySinh.Value.ToString("dd/MM/yyyy")}, Email: {item.Email}, DiaChi: {item.DiaChi}.");
                }
            }
            else if (runMode == 10)
            {
                // Dapper
                GenericService<SinhVienModel> genericService = new GenericService<SinhVienModel>();
                DynamicParameters param = new DynamicParameters();
                param.Add("@top", 100);
                param.Add("@totalRecord", 0, direction: ParameterDirection.Output);
                var lstSinhVien = genericService.ExcuteMany("spud_GetTopStudentByClass", param);
                int totalRecord = param.Get<int>("@totalRecord");

                foreach (var item in lstSinhVien)
                {
                    Console.WriteLine($"Id: {item.Id}, IdLop: {item.IdLop}, HoVaTen: {item.Ho} {item.Ten}, NgaySinh: {item.NgaySinh.ToString("dd/MM/yyyy")}, Email: {item.Email}, DiaChi: {item.DiaChi}.");
                }
            }
            Student[] students1 = new Student[]{
                new Student()
                {

                }
            };

            Console.WriteLine("END");
            Console.ReadKey();
        }

        private static void Swap(ref int intA, ref int intB)
        {
            int temp = intA;
            intA = intB;
            intB = temp;
        }

        private static int PrintArr(int[] arr)
        {
            foreach (var item in arr)
            {
                if (item == 12)
                {
                    continue;
                }
                Console.WriteLine(item);
            }
            return arr.Count();
        }

        private static string ConvertStr(string text1, string text2)
        {
            string output = "Ahihi::" + text1 + " " + text2;
            Console.WriteLine(output);
            return output;
        }

        private static string ConcatStr(string text1, string text2)
        {
            string output = "Ahoho::" + text1 + " " + text2;
            Console.WriteLine(output);
            return output;
        }
    }

    internal class VietQQException : Exception
    {
        public VietQQException(string message)
            : base(message)
        {
        }
    }
}