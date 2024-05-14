using BusinessLogic.DTO;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.DataContexts;
using DataAccess.Entitys;
using DataAccess.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Presentation.Extensions;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();

//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(jwtOption =>
//{
//    var key = builder.Configuration.GetValue<string>("JwtConfig:Key");
//    var keyBytes = Encoding.ASCII.GetBytes(key);
//    jwtOption.SaveToken = true;
//    jwtOption.TokenValidationParameters = new TokenValidationParameters
//    {
//        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
//        ValidateLifetime = true,
//        ValidateAudience = true,
//        ValidateIssuer = true
//    };
//});

builder.Services.AddDbContext<ContactsManagerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging();
    //options.UseInMemoryDatabase("DefaultConnection");
});

builder.Services.AddIdentityApiEndpoints<UserEntity>()
    .AddEntityFrameworkStores<ContactsManagerContext>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IValidator<ContactDto>, ContactDtoValidator>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

//Seed Database
//using (var scope = app.Services.CreateScope())
//{
//    var scopedProvider = scope.ServiceProvider;
//    var context = scopedProvider.GetRequiredService<ContactsManagerContext>();
//    context.Database.EnsureCreated();
//    await DataSeed.Seed(context);
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<UserEntity>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();



app.Run();
