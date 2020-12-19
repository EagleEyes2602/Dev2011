using Dev2012CSharp.CLI.Models;
using System.Collections.Generic;

namespace Dev2012CSharp.CLI.Interface
{
    public interface IStudentService
    {
        // GetById
        Student GetById(int id);

        // GetAll
        List<Student> GetAll();

        // Insert
        int Insert(Student student);

        // Update
        int Update(Student student);

        // Delete
        int Delete(Student student);
        void Print(List<Student> students);
    }
}