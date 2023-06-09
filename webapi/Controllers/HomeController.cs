using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace MvcContacts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContactsDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            // Manually create and configure the ContactsDbContext
            var optionsBuilder = new DbContextOptionsBuilder<ContactsDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-J1L2I8E; Database=ContactsDB; Trusted_Connection=True; TrustServerCertificate=True");
            _dbContext = new ContactsDbContext(optionsBuilder.Options);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index(string errorMessage = null)
{
    ViewBag.ErrorMessage = errorMessage;
     var entities = _dbContext.Users.FirstOrDefault();
     if (HttpContext.Session.GetInt32("UserId") != null)
    {
        // User is already logged in, redirect to the panel page
        return RedirectToAction("Panel");
    }
    return View(entities);
    
}

[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
       public IActionResult Panel()
{
    // Retrieve the logged-in user's ID from the session
    int? userId = HttpContext.Session.GetInt32("UserId");

    if (userId != null)
    {
        // Fetch the user data from the database based on the ID
        User user = _dbContext.Users.Find(userId);

        if (user != null)
        {
            // Pass the user data to the view
            return View(user);
        }
    }

    // Redirect to the login page if the user is not logged in or if the user data is not found
    return Redirect("/");
}

[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
[HttpPost]
public async Task<IActionResult> Login([FromForm] User user)
{
    try
    {
        // Check if the provided login and password match the data from the database
        User authenticatedUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);

        if (authenticatedUser != null)
        {
            // Store the authenticated user's ID in the session
            HttpContext.Session.SetInt32("UserId", authenticatedUser.Id);

            // Redirect to the success page if the user is authenticated
            
            return Redirect("/Home/Panel");
        }
        else
        {
            // Handle invalid login
            return RedirectToAction("Index", new { errorMessage = "Błędne dane logowania" });
        }
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}
[HttpPost]
public async Task<IActionResult> Register([FromForm] User user)
{
    try
    {
        // Check if the user object already has an 'Id' assigned or if it's 0
        if (user.Id != 0)
        {
            // Check if the specified 'Id' is already used by another user
            if (_dbContext.Users.Any(u => u.Id == user.Id))
            {
                // Generate a new unique 'Id' for the user
                user.Id = GenerateUniqueId();
            }
        }
        else
        {
            // Generate a new unique 'Id' for the user
            user.Id = GenerateUniqueId();
        }

        // Save the new user to the database
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        // Redirect to the login page after successful registration
        return RedirectToAction("Index");
    }
    catch (Exception ex)
    {
        if (ex.InnerException != null)
        {
            // Get the inner exception message
            string errorMessage = ex.InnerException.Message;
            return RedirectToAction("Index", new { errorMessage });
        }

        return RedirectToAction("Index", new { errorMessage = "An error occurred while registering the user." });
    }
}

// Generate a new unique 'Id' for the user
private int GenerateUniqueId()
{
    int newId;
    var random = new Random();

    // Generate a random number between 1 and int.MaxValue
    do
    {
        newId = random.Next(1, int.MaxValue);
    } while (_dbContext.Users.Any(u => u.Id == newId));

    return newId;
}




[HttpPost]
public IActionResult Logout()
{
    // Remove the stored user ID from the session to log out the user
    HttpContext.Session.Remove("UserId");

    // Redirect to the login page or any other desired page
    return Redirect("/");
}

    }
}
