using System;

namespace UserManager.Dtos
{
        public record UserDto{
        public Guid Id {get; init;}
        public string UserName {get; init;}
        public string Password {get; init;}
        public string FirstName {get; init;}
        public string LastName {get; init;}
        public string Email {get; init;}
        public string PhoneNumber {get; init;}
        public string Department {get; init;}
        public DateTimeOffset CreatedAt {get; init;}
    }
}