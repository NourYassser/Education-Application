using System.Text;
using EducationApplication.BLL.AutoMapper;
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
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<EducationDbContext>()
                .AddDefaultTokenProviders();

//Identity User
/*builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<EducationDbContext>();*/
//Registering Repos
/*builder.Services.AddScoped<IAdminRepositroy, AdminRepositroy>();*/
builder.Services.AddScoped<IinstructorRpo, InstructorRpo>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
/*builder.Services.AddScoped<IAdminRepo, AttemptsRepo>();*/

//Registering Managers
/*builder.Services.AddScoped<IAdminManger, AdminManger>();*/
builder.Services.AddScoped<IinstructorManager, InstructorManager>();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddSingleton<IEmailSender<IdentityUser>, EmailSender>();


// Add JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
/*builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(Option =>
{
    //SecurityKey
    *//*var SecretKeyString = builder.Configuration.GetSection("SecretKey").Value;
    var SecretKeyByte = Encoding.ASCII.GetBytes(SecretKeyString);
    */
/*SecurityKey securityKey = new SymmetricSecurityKey(SecretKeyByte);*//*
IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
#endregion
Option.TokenValidationParameters = new TokenValidationParameters
{
    IssuerSigningKey = securityKey,
    ValidateIssuer = true,
    ValidateAudience = true,
};*//*
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
};
});*/

var app = builder.Build();

/*app.UseMiddleware<GlobalErrorHandlingMiddleware>();*/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<IdentityUser>();
app.MapControllers();

app.Run();
