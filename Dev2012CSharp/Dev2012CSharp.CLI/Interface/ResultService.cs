using Dev2012CSharp.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2012CSharp.CLI.Interface
{
    public partial class ResultService
    {
        public List<Result> InitData()
        {
            return new List<Result>()
            {
                new Result()
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1,
                    Score = 3.9
                },
                new Result()
                {
                    Id = 2,
                    StudentId = 1,
                    SubjectId = 2,
                    Score = 6.9
                },
                new Result()
                {
                    Id = 3,
                    StudentId = 1,
                    SubjectId = 3,
                    Score = 8.4
                },
                new Result()
                {
                    Id = 4,
                    StudentId = 2,
                    SubjectId = 1,
                    Score = 5.2
                },
                new Result()
                {
                    Id = 5,
                    StudentId = 2,
                    SubjectId = 2,
                    Score = 7.5
                },
                new Result()
                {
                    Id = 6,
                    StudentId = 2,
                    SubjectId = 3,
                    Score = 9.0
                },
            };
        }
    }
}
