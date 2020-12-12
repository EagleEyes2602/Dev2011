using Dev2012CSharp.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI
{
    class Program
    {
        static void Main(string[] args)
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
            int runMode = 3;
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
                #endregion
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
                #endregion
            }
            else if (runMode == 3)
            {
                #region OOP
                // Class (Lớp)
                // Được xây dựng dựa trên các kiểu dữ liệu nguyên thủy hoặc class khác, ...
                // Trường, Thuộc tính, Phương thức

                Student student1 = new Student();
                Student student2 = new Student("Nguyễn", "Tuấn", 23, new DateTime(1997, 10, 20), true);
                student1.Print();
                #endregion
            }

            Console.WriteLine("END");
            Console.ReadKey();
        }

        static int PrintArr(int[] arr)
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
    }
}
