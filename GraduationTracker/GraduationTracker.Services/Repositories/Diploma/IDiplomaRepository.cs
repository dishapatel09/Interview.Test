using GraduationTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace GraduationTracker.Services
{
    public interface IDiplomaRepository
    {
        List<Diploma> All();
        List<Diploma> All(int[] ids);
        Diploma GetById(int id);
        void Add(Diploma entity);
        void Update(Diploma entity);
        void Delete(Diploma entity);
    }
}
