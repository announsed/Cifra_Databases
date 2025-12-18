
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationWether
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite("DataSource=myDatabase.db");
            });
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddOpenApiDocument(options =>
            {
                options.Title = "Title";
                options.Version = "V1";
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            //builder.Services.AddSingleton();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.MapGet("/library/{authorId}/{bookId}", async (int authorId, int bookId, HttpContext context) =>
            {
                var error = context.Response.StatusCode = StatusCodes.Status400BadRequest;

                if (authorId <= 0 || bookId <= 0)
                {
                    await context.Response.WriteAsync(error + " Bad Request - НЕ дано");
                }

                var query = context.Request.Query;
                string? sort = query["format"];
                string? filter = query["language"];
                if (sort == null)
                {
                    await context.Response.WriteAsync("Параметр format не был передан");
                }
                if (filter == null)
                {
                    await context.Response.WriteAsync("Параметр filter не был передан");
                }
                await context.Response.WriteAsync($"author id - {authorId}\nbook id - {bookId}\nformat - {sort}\nlanguage - {filter}\n{error}");

            });

            app.UseOpenApi();
            app.UseSwaggerUi(c =>
            {
                c.DocExpansion = "c";
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();



            //app.UseMiddleware<CastomMWcs>();
            //app.UseMiddleware<CastomMW2cs>();


            app.MapControllers();


            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Второй Middleware: Обработка запроса");
            //    await next();
            //});
            //app.Run(async context =>
            //{
            //    Console.WriteLine("Третий Middleware: Финальный обработчик");
            //    await context.Response.WriteAsync("Hello from ASP.NET Core!");
            //});




            // Регистрация сервисов

            app.MapGet("/products", async (IProductService productService) =>
            {
                var products = productService.GetAllProducts();
                return Results.Ok(products); // Возвращаем все продукты
            });

            app.MapGet("/products/{id}", async (int id, IProductService productService) =>
            {
                var product = productService.GetProductById(id);
                // Возвращаем продукт по ID
                return product != null ? Results.Ok(product) : Results.NotFound();
            });

            app.MapGet("/products/{name:minlength(2):maxlength(20)}/{min:decimal:min(1)}/{max:decimal:max(2000000)}", async (string name, decimal min, decimal max, IProductService productService) =>
            {
                var product = productService.Filtracia(name, min, max);
            return product != null ? Results.Ok(product) : Results.NotFound();
            });

            app.MapGet("/productsadd/{name:minlength(2):maxlength(20)}/{prise:decimal:min(1):max(200000)}", async (string name, decimal prise, IProductService productService) =>
            {
                var product = new Product() {Name = name, Price = prise };
                productService.AddProduct(product, out string? ffalse);

                return product;
            });

            app.Run();
        }
    }
}
