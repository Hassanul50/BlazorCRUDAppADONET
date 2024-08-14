using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services
{
    public interface IStudentServices
    {
        IEnumerable<StudentEntity> GetAllStudent();
        void AddStudent(StudentEntity student);
        void UpdateStudent(StudentEntity student);
        void DeleteStudent(int? StudentId);
    }
}
