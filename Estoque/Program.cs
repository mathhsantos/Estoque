using Estoque.Data;
using Estoque.Interfaces;
using Estoque.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Estoque {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EstoqueDbContext>(options => {
                options.UseMySql(Environment.GetEnvironmentVariable("StringConnectorMySQL", EnvironmentVariableTarget.User), new
                    MySqlServerVersion(new Version(8, 0, 36)));
            });
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IItEquipmentRepository, ItEquipmentRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
