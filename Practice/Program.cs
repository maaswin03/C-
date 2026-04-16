using Practice.Services;
using Practice.Data;
using Microsoft.EntityFrameworkCore;

var b = WebApplication.CreateBuilder(args);

b.Services.AddControllers();

b.Services.AddSingleton<ProductService>();

b.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=products.db"));

var app = b.Build();

app.MapControllers();

app.Run();