using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using webapi.Models;

var builder = WebApplication.CreateBuilder(args);


ConfigurationManager configuration = builder.Configuration;

builder.Services.AddAuthentication(options =>
{

	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

//Jwt Bearer
.AddJwtBearer(options =>
 {
	 options.SaveToken = true;
	 options.RequireHttpsMetadata = false;
	 options.TokenValidationParameters = new TokenValidationParameters
	 {
		 ValidateIssuer = true,
		 ValidateAudience = true,
		 ValidAudience = configuration["JWT:ValidAudience"],
		 ValidIssuer = configuration["JWT:ValidIssuer"],
		 IssuerSigningKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(configuration["JWT:Secret"]))
	 };
 });


//CORS
var myCors = "appCors";
builder.Services.AddCors(options =>
{
	options.AddPolicy(myCors, policy =>
	{
		policy.WithOrigins("https://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
	});
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Connection to database - DefaultConnection is into appsettings.json file
builder.Services.AddDbContext<ContactsDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

//adding authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
