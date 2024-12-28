using DataNexus;
using DataNexus.Auth;
using DataNexus.Repositories;
using DataNexus.UnitOfWork;
using Domain.Interfaces;
//using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using System.Text.Json.Serialization;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddControllers().AddJsonOptions(options =>
{
   // options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
})
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue; // Set to maximum limit
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var configuration = builder.Configuration;
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();

//Add Database Connections
var connectionString = config.GetConnectionString("dbcs") ?? throw new InvalidOperationException("Connection string 'SQLServerIdentityConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Add Identity:basic configuration::
builder.Services.AddIdentity<UserIdentity, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//For Unit Of Work
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<DbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("dbcs")),
                    ServiceLifetime.Transient);
//Dep Injection >>
// builder.Services.AddTransient(typeof(IGenericRepositor   y<>), typeof(GenericRepository<>));

// Adding Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        //ValidateLifetime = true, 
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});
////hangfire
//builder.Services.AddHangfire((sp, config) =>
//{

//    var connectionstring = sp.GetRequiredService<IConfiguration>().GetConnectionString("dbcs");
//    config.UseSqlServerStorage(connectionstring);
//});

//builder.Services.AddHangfireServer();

builder.Services.AddEndpointsApiExplorer();

// Add Swagger
// builder.Services.AddSwaggerGen();
// add auth attribute in swagger
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "County API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

//Add Config for Required Email //** temprary email confirmation off for testing purpose
builder.Services.Configure<IdentityOptions>(opts => opts.SignIn.RequireConfirmedEmail = false);

// Path to the wkhtmltox DLL file
//var wkHtmlToPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wkhtmltox", "libwkhtmltox.dll");

// Load the unmanaged library
//CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
//context.LoadUnmanagedLibrary(wkHtmlToPdfPath);

// Add DinkToPdf service
//builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

// Serving Static Files
//// removed temprary 
//app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors();

app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//           Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
//    RequestPath = "/Uploads"
//});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapHangfireDashboard();

app.Run();
