using CampBookingApi.Data;
using CampBookingApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICampService, CampService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

app.MapControllers();

app.Run();
