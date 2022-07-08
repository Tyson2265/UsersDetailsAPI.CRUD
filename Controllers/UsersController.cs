using Microsoft.AspNetCore.Mvc;
using web_api_2.Context;
using web_api_2.Models;

namespace web_api_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly DataContext _dbContext;

        public UsersController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            return _dbContext.Users.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Users> GetUsers(int id)
        {
            return _dbContext.Users.Find(id);
        }
        [HttpPost("addUser")]
        public async Task<ActionResult<string>>AddUser(Users registerObject)
        {
            var user = new Users
            {
                Id = registerObject.Id,
                Name = registerObject.Name,
                Email = registerObject.Email,
                Number = registerObject.Number,
                Password = registerObject.Password
            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return "User Added";
        }
        [HttpPost("UpdateUser")]
        public async Task<ActionResult<string>> UpdateUser(Users updateObject)
        {
            var currentUser = _dbContext.Users.Where(x => x.Id == updateObject.Id).FirstOrDefault<Users>();
            if (currentUser != null)
            {
                currentUser.Name = updateObject.Name;
                currentUser.Email = updateObject.Email;
                currentUser.Number = updateObject.Number;
                currentUser.Password = updateObject.Password;

                _dbContext.SaveChanges();
            }
            else
            {
                return "User Not Found";
              
            };
          
            return "User Updated";
        }

        [HttpDelete("DeleteUser")]

        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not Valid");
            }
            var currentUser = _dbContext.Users.Where(_x => _x.Id == id).FirstOrDefault<Users>();
            if(currentUser != null)
            {
                _dbContext.Entry(currentUser).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            else
            {
                return "User not deleted";
            }
            return "User Deleted";
        }






    }
}
