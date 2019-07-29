using GraduationTracker.Models;
using System.Collections.Generic;

namespace GraduationTracker.Services
{
    public interface IStudentRepository
    {
        List<Student> All();
        List<Student> All(int[] ids);
        Student GetById(int id);
        void Add(Student entity);
        void Update(Student entity);
        void Delete(Student entity);
    }
}
