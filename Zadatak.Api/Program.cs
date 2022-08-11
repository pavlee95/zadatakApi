using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using Zadatak.Api.Core;
using Zadatak.Application;
using Zadatak.Application.Commands;
using Zadatak.Application.Email;
using Zadatak.Application.Queries;
using Zadatak.EFDataAccess;
using Zadatak.Implementation.Commands;
using Zadatak.Implementation.Email;
using Zadatak.Implementation.Logging;
using Zadatak.Implementation.Queries;
using Zadatak.Implementation.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ZadatakContext>();
builder.Services.AddTransient<IUseCaseLogger, DataBaseUseCaseLogger>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<CreateRoleValidator>();
builder.Services.AddTransient<UpdateRoleValidator>();
builder.Services.AddTransient<ICreateRoleCommand, EFCreateRoleCommand>();
builder.Services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
builder.Services.AddTransient<IGetRolesQuery, EFGetRolesQuery>();
builder.Services.AddTransient<IEditRoleCommand, EFEditRoleCommand>();
builder.Services.AddTransient<IApplicationActor, AdminFakeActor>();
builder.Services.AddTransient<UseCaseExecutor>();
builder.Services.AddTransient<JwtManager>();
builder.Services.AddTransient<IGetUsersQuery, EFGetUsersQuery>();
builder.Services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();
builder.Services.AddTransient<RegisterUserValidator>();
builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();


builder.Services.AddTransient<IApplicationActor>(x =>  
{
    
    var accessor = x.GetService<IHttpContextAccessor>(); 
    var user = accessor.HttpContext.User;

    if (user.FindFirst("ActorData") == null) 
    {
        return new AnnonymusActor();
    }

    var actorString = user.FindFirst("ActorData").Value; 

    var actor = JsonConvert.DeserializeObject<JwtActor>(actorString); 

    return actor;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>  
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "asp_api", 
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
