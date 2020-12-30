using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public double Score { get; set; }
    }
}
