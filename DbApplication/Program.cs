using DbApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();


app.MapGet("/employees", async (AppDbContext db) =>
    await db.Employees.ToListAsync());

app.MapPost("/employees", async (Employees employee, AppDbContext db) =>
{
    db.Employees.Add(employee);
    await db.SaveChangesAsync();

    return Results.Created($"/employees/{employee.Id}", employee);
});

app.MapGet("/departments", async (AppDbContext db) =>
{
    var departments = await db.Departments.ToListAsync();
    return departments;
});

app.MapPost("/departments", async (Departments department, AppDbContext db) =>
{
    db.Departments.Add(department);
    await db.SaveChangesAsync();
    return Results.Created($"/departments/{department.Id}", department);
});


app.Run();
