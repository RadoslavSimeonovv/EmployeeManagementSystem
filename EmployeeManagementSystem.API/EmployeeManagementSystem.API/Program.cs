using EmployeeManagementSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Services.Employee.GetEmployees;
using EmployeeManagementSystem.DataAccess.Repositories.Employee;
using EmployeeManagementSystem.DataAccess.Repositories.Shift;
using EmployeeManagementSystem.API.Controllers;
using EmployeeManagementSystem.DataAccess.Repositories.Role;
using EmployeeManagementSystem.API.Common;
using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using EmployeeManagementSystem.API.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmployeeManagementDbContext>(options =>
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                       sqlOptions => sqlOptions.CommandTimeout(3600))
        .UseSeeding((context, _) =>
        {
            Seeder.SeedData(context);
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            Seeder.SeedDataAsync(context, cancellationToken);
        }));

builder.Services.AddScoped<IEmployeeManagementDbContext>(provider => provider.GetService<EmployeeManagementDbContext>()!);
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IShiftRepository, ShiftRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddAutoMapper(new[]
{
    typeof(GetEmployeesQueryHandler).Assembly,
    typeof(EmployeeController).Assembly
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetEmployeesQuery).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(GetEmployeesQuery).Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var applicationDbContext = scope.ServiceProvider.GetRequiredService<EmployeeManagementDbContext>();
    applicationDbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config =>
{
    config.WithOrigins("https://localhost:4200")
           .AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(config =>
{
    config.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is ValidationException validationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                Errors = validationException.Errors.Select(e => e.ErrorMessage)
            });
        }
    });
});

app.Run();
