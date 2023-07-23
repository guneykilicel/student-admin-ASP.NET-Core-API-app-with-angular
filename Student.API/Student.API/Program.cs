using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Student.API.DataModels; // StudentAdminContext' in namespace'i burada ekliyoruz
using Student.API.Repositories;
using System.IO;

namespace Student.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var env = builder.Environment; // env deðiþkenini burada tanýmlayýn

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext eklemek için AddDbContext kullanýn
            builder.Services.AddDbContext<StudentAdminContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb"));
            });

            builder.Services.AddScoped<IStudentRepository, SqlStudentRepository>();
            builder.Services.AddScoped<IImageRepository, LocalStorageImageRepository>();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Resources")),
                RequestPath = "/Resources"
            });
            app.UseCors("MyPolicy");

            app.Run();
        }
    }
}