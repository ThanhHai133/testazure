using Microsoft.EntityFrameworkCore;
using webAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowViteClient", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:5169")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

});

// Cấu hình DbContext, Swagger, và MVC
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("QLNH")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cấu hình pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Đảm bảo CORS được sử dụng trước các middleware khác
app.UseCors("AllowViteClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
