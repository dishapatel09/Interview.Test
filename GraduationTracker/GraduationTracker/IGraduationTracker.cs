using GraduationTracker.Models;
using GraduationTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public interface IGraduationTracker
    {
        Tuple<bool, Standing> HasGraduated(Diploma diploma, Student student);
        Standing GetStanding(int average);
    }
}
