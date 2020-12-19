using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Models
{
    public class Employee : Person
    {
        public override void DoWork()
        {
            Console.WriteLine("DoWork");
        }

        public override void EnviromentWork()
        {
            Console.WriteLine("EnviromentWork");
        }
    }
}
