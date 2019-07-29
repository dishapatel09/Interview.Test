using GraduationTracker.Models;
using System.Collections.Generic;

namespace GraduationTracker.Services
{
    public interface IRequirementRepository
    {
        List<Requirement> All();
        List<Requirement> All(int[] ids);
        Requirement GetById(int id);
        void Add(Requirement entity);
        void Update(Requirement entity);
        void Delete(Requirement entity);
    }
}
