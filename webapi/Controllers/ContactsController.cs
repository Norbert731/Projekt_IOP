using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using webapi.Models;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {



        private readonly ContactsDbContext _dbcontext;

        public ContactsController(ContactsDbContext _context)
        {
            _dbcontext = _context;
        }

        [Authorize]
        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> ListUsers = _dbcontext.Users.ToList();
                if (ListUsers != null)
                {
                    return Ok(ListUsers);
                }
                else
                {
                    return Ok("database without contacts");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       

    }
}
