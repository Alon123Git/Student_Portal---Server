using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Student_Admin_Portal.API.Data;
using Student_Admin_Portal.API.Profiles;
using Student_Admin_Portal.API.Repositories;
using Student_Admin_Portal.API.Repositories.IRepositories;
using Student_Admin_Portal.API.Repositorues.IRepositories;
using Student_Admin_Portal.API.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<startup>());

builder.Services.AddValidatorsFromAssembly(typeof(AddStudentRequestValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(UpdateStudentRequestValidator).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<StudentAdminContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<IStudentRepository, StudentRepsitory>();
builder.Services.AddScoped<IStudentRepository, StudentRepsitory>();

builder.Services.AddHttpClient<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var host = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var env = app.Services.GetRequiredService<IWebHostEnvironment>();

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Resources")),
    RequestPath = "/Resources"
});


app.UseCors("angularApplication");

app.UseAuthorization();

app.MapControllers();

app.Run();