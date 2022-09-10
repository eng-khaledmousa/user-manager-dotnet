using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using UserManager.Entities;

namespace UserManager.Repositories{
    class DepartmentRepository : IDepartmentRepository
    {
        string path;
        public DepartmentRepository(string FilePath)
        {
            path = FilePath;
        }

        public List<Department> GetDepartments()
        {
            string allText = System.IO.File.ReadAllText(@""+path);
            
            List<Department> jsonObject = JsonConvert.DeserializeObject<List<Department>>(allText);
            return jsonObject;
        }
    }
}