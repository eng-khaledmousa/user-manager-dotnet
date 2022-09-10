using UserManager.Dtos;
using UserManager.Entities;

namespace UserManager{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto{
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Department = user.Department,
                CreatedAt = user.CreatedAt
            };
        }
        public static DepartmentDto AsDto(this Department dep)
        {
            return new DepartmentDto{
                Id = dep.Id,
                Name = dep.Name
            };
        }
    }
}