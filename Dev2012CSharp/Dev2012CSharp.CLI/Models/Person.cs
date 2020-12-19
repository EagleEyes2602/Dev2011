using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Models
{
    public abstract class Person
    {
        public void Speak()
        {
            Console.WriteLine("Hello world !!!");
        }

        public abstract void DoWork();
        public abstract void EnviromentWork();
    }
}
