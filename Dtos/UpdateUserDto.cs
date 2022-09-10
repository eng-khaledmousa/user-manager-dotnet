using System.ComponentModel.DataAnnotations;

namespace UserManager.Dtos
{
        public record UpdateUserDto{
        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string UserName {get; init;}
        [Required]
        [StringLength(50, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[.#?!@$%^&*-]).{8,}$", ErrorMessage = "Please enter a valid password")]
        public string Password {get; init;}
        [StringLength(25, MinimumLength = 5)]
        public string FirstName {get; init;}
        [StringLength(25, MinimumLength = 5)]
        public string LastName {get; init;}
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter a valid email address")]
        public string Email {get; init;}
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11)]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber {get; init;}
        public string Department {get; init;}
    }
}