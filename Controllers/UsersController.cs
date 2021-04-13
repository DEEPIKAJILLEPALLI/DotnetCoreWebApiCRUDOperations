using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNETCORECRUDOperationsDemo.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
        
    {

        protected List<User> users = new List<User>();
        public UsersController()
        {
            users.Add(new User() { Id = 1, Firstname = "Ugo", Lastname = "Lattanzi", Twitter = "@imperugo" });
            users.Add(new User() { Id = 2, Firstname = "Simone", Lastname = "Chiaretta", Twitter = "@simonech" });
        }
        [HttpGet]
        public User[] Get()
        {

            return users.ToArray();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            //var users = new[] { new User()
            //    { Id = 1, Firstname = "Ugo", Lastname = "Lattanzi", Twitter = "@imperugo" },
            //        new User() { Id = 2, Firstname = "Simone", Lastname = "Chiaretta", Twitter = "@simonech" },
            //    };
            return users.FirstOrDefault(x => x.Id == id);
        }
        // Adding user 
        [HttpPost]
        public IActionResult Update([FromBody] User user)
        {
            //var users = new List<User>();
            users.Add(user);
            return new CreatedResult($"/api/users/{user.Id}", user);
        }
        //Deleting user 
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            //var users = new List<User>
            //{
            //    new User() {Id = 1, Firstname = "Ugo", Lastname = "Lattanzi", Twitter = "@imperugo"},
            //    new User() {Id = 2, Firstname = "Simone", Lastname = "Chiaretta", Twitter = "@simonech"}
            //};
            var user = users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                users.Remove(user);
                return new EmptyResult();
            }
            return new NotFoundResult();
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Twitter { get; set; }
    }
}
