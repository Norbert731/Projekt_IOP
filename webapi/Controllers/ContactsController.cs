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

        [HttpGet]


        [Route("Users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
              List<User> ListUsers = _dbcontext.Users.ToList();
                if (ListUsers != null)
                {
                    return Ok( ListUsers);
                }
                else
                {
                    return Ok("database without contacts");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    //    public JsonResult Get()
    //    {
    //        string query = @"Select id, first_name, last_name, email, gender, city from dbo.Contacts_db";


    //        DataTable table = new DataTable();
    //        string sqlDataSource = _configuration.GetConnectionString("ContactsDB");
    //        SqlDataReader myReader;
    //        using (SqlConnection sqlCon = new SqlConnection(sqlDataSource) )
    //        {
    //            sqlCon.Open();
    //            using (SqlCommand myCommand = new SqlCommand(query, sqlCon))
    //            {
    //                myReader = myCommand.ExecuteReader();
    //                table.Load(myReader);
    //                myReader.Close();
    //                sqlCon.Close();
    //            }
    //        }

    //        return new JsonResult(table);
    //    }

        
    }
}
