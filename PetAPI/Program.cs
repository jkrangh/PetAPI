
using Microsoft.EntityFrameworkCore;
using PetAPI.Data;
using PetAPI.Generated;

namespace PetAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<PetAPIContext>(options =>
                options.UseInMemoryDatabase(("PetDb") ?? throw new InvalidOperationException("Error in InMemoryDatabase")));
            builder.Services.AddTransient<IDog, DogRepository>();
            builder.Services.AddTransient<ICat, CatRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PetAPIContext>();
                var seeder = new DataSeeder(context);
                seeder.SeedData();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapDogEndpoints();
            app.MapCatEndpoints();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}
