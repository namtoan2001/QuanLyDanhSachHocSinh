using Microsoft.EntityFrameworkCore;
using QuanLyDanhSachSinhVien.Interface;
using QuanLyDanhSachSinhVien.Models;
using QuanLyDanhSachSinhVien.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<StudentContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("StudentContextConnection"),
                  sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));
builder.Services.AddControllers();
//Add DI
builder.Services.AddTransient<IStudentService, StudentService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options
                .WithOrigins("https://localhost:44319", "http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
