using System.Text.Json;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User("Мария", 43, "mariya.@gmail.com", 8800553535),
                new User("Александр", 27, "alex.@gmail.com", 8800553535),
                new User("Виктор", 13, "superVitya2012.@gmail.com", 8800553535)
            };

            List<Productcs> productcs = new List<Productcs>() 
            {
                new Productcs(1,"Халяль", "Халяль и этим все сказано","Товары для веры",90000),
                new Productcs(2,"Ножницы", "Простые ножницы","Товары для дома",900),
                new Productcs(3,"Мазут", "Высокое качество - выгодная цегна","Товары для строительства",7888)
            };

            List<Order> orders = new List<Order>()
            {
                new Order(1,"Выполнен",894342354),
                new Order(2,"Доставляется",34546473),
                new Order(3, "ВЫпорлнен", 769807)
            };

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Самая первая страничка");
            app.MapGet("/rundom", (int number, int number2) => 
            {
                Random random = new Random();
                var result = 0;
                if (number <= number2)
                {
                    result = random.Next(number, number2);
                }
                else
                {
                    result = random.Next(number2, number);
                }
                return result.ToString();
            });
            JsonSerializerOptions options = new JsonSerializerOptions() 
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            app.MapGet("/users", () => 
            {
                return JsonSerializer.Serialize(users, options);
            });
            app.MapGet("/products", () => 
            {
                return JsonSerializer.Serialize(productcs, options);
            });
            app.MapGet("/orders", () => 
            {
                return JsonSerializer.Serialize(orders,options);
            });
            app.MapGet("/rest", () =>
            {
                string htmlPages = File.ReadAllText("Views\\Restouranes\\restaurant.html");
                return Results.Content(htmlPages, "text/html");
            });
            app.MapGet("/behtml", ( ) => 
            {
                string htmlPages = File.ReadAllText("Views\\Restouranes\\белки.html");
                return Results.Content(htmlPages,"text/html");
            });
            app.MapGet("/bejson", () =>
            {
                string jsonPages = File.ReadAllText("Views\\Restouranes\\белки.json");
                return Results.Content(jsonPages, "text/json");
            });
            app.Run();
        }
    }
}
