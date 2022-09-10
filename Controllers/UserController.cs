using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManager.Dtos;
using UserManager.Entities;
using UserManager.Repositories;

namespace UserManager.Controllers{
    [ApiController]
    [Route("users")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var items = (await repository.GetUsersAsync()).Select(user => user.AsDto());
            return items;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(Guid id)
        {
            var user = await repository.GetUserAsync(id);
            if(user is null)
            {
                return NotFound();
            }
            return user.AsDto();
        }
        [HttpGet("check/{username}")]
        public async Task<bool> CheckUserExistAsync(string username)
        {
            return await repository.CheckUserExistAsync(username);
        }
        
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto userDto)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                UserName = userDto.UserName,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                Email = userDto.Email,
                Department = userDto.Department,
                CreatedAt = DateTimeOffset.UtcNow
            };
            await repository.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserAsync), new {id = user.Id}, user.AsDto());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(Guid id, UpdateUserDto userDto)
        {
            var existingUser = await repository.GetUserAsync(id);
            if(existingUser is null)
            {
                return NotFound();
            }
            Console.WriteLine(userDto.Department);
            User user = existingUser with{
                UserName = userDto.UserName,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Department = userDto.Department
            };
            await repository.UpdateUserAsync(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid id)
        {
            User existingUser = await repository.GetUserAsync(id);
            if(existingUser is null)
            {
                return NotFound();
            }
            await repository.DeleteUserAsync(existingUser);
            return NoContent();
        }
        [HttpGet("departments")]
        public object GetDepartments()
        {
            string allText = System.IO.File.ReadAllText(@"Entities/departments.json");
            
            var jsonObject = JsonConvert.DeserializeObject<List<Department>>(allText);
            return jsonObject;
        }
    }

}