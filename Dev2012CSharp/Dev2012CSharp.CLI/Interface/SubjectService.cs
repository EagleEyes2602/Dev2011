using Dev2012CSharp.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Interface
{
    public partial class SubjectService
    {
        public List<Subject> InitData()
        {
            return new List<Subject>()
            {
                new Subject()
                {
                    Id = 1,
                    Name = "CSDL"
                },
                new Subject()
                {
                    Id = 2,
                    Name = "Lập trình trực quan"
                },
                new Subject()
                {
                    Id = 3,
                    Name = "Công nghệ Java"
                }
            };
        }
    }
}
