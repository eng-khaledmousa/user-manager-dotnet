using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using UserManager.Dtos;
using UserManager.Repositories;

namespace UserManager.Controllers{
    [ApiController]
    [Route("departments")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DepartmentController: ControllerBase
    {
        private readonly IDepartmentRepository repository;

        public DepartmentController(IDepartmentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<DepartmentDto> GetDepartments()
        {
            return repository.GetDepartments().Select(dep => dep.AsDto());
        }
    }

}