using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Entities;

namespace UserManager.Repositories{
    public interface IDepartmentRepository
    {
        List<Department> GetDepartments();
    }
}