using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users = _context.Users.ToListAsync();

            return await users;
        }
        //api/users/3 => is going to get the user with id 3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(){
            var user = _context.Users.FindAsync();

            return await user;
        }

        

        
    }
}