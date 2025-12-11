
using System.Net;

namespace WebApplicationWether
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddOpenApiDocument(options => 
            {
                options.Title = "Title";
                options.Version = "V1";
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
           // builder.Configuration.
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
                    await context.Response.WriteAsync( error + " Bad Request - НЕ дано");
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



            app.Run();
        }
    }
}
