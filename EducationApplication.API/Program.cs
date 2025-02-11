using System.Text;
using EducationApplication.BLL.AutoMapper;
using EducationApplication.BLL.Manager.Auth;
using EducationApplication.BLL.Manager.InstructorManager;
using EducationApplication.BLL.Manager.StudentManager;
using EducationApplication.BLL.Middlewares;
using EducationApplication.DAL.Data.DbHelper;
using EducationApplication.DAL.Data.Model;
using EducationApplication.DAL.Repos.InstructorRpo;
using EducationApplication.DAL.Repos.StudentRpo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<EducationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddAutoMapper(map => map.AddProfile(new MappingProfile()));

//Identity Role
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;

    // User settings
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<EducationDbContext>()
.AddDefaultTokenProviders();

//Identity User

//Registering Repos
builder.Services.AddScoped<IinstructorRpo, InstructorRpo>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();

//Registering Managers
builder.Services.AddScoped<IinstructorManager, InstructorManager>();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddSingleton<IEmailSender<IdentityUser>, EmailSender>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"]
        };
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Student", "Instructor" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
/*app.UseMiddleware<GlobalErrorHandlingMiddleware>();*/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

builder.Services.AddAuthorization();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
