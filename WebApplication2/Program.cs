using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication2.Views;

namespace WebApplication2
{
    public class Program
    {
        ///<summary>
        ///Продукт
        ///</summary>
        ///<returns>Статус пост запроса</returns>
        ///<param name="args">Любой текст</param>
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

            List<Fruit> fruits =new List<Fruit>() 
            {
                new Fruit("Яблоко",34.9f,2),
                new Fruit("Груша", 76,1.5f),
                new Fruit("Виноград",498,4)
            };

            string fruitsSerialJSON = JsonSerializer.Serialize(fruits, options);
            const string path = $"fruits.json";
            File.WriteAllText(path, fruitsSerialJSON);

            string jsonFromFile = File.ReadAllText(path);
            List<Fruit> fruitsDeserializationJson = JsonSerializer.Deserialize<List<Fruit>>(jsonFromFile, options);
            var frut = "";
            foreach (var fruct in fruitsDeserializationJson)
            {
                frut += "<li>" + fruct.Name + " - " + fruct.Prise + " - " + fruct.Weigth + "</li> \n";
            }

            var html = "<!DOCTYPE html>\r\n" +
                "<html>\r\n" +
                "<head>\r\n" +
                "<meta charset=\"utf-8\" />\r\n" +
                "<title>Фрукты</title>\r\n" +
                "</head>\r\n" +
                "<body>\r\n" +
                "<h1>Фрукты</h1>\r\n" +
                "<ul>\r\n" +
                $"{frut}\r\n" +
                "</ul>\r\n" +
                "</body>\r\n" +
                "</html>\r\n";
            app.MapGet("/h", () => 
            {
                return Results.Content(html, "text/html");
            });

            app.MapPost("/submit-form", async (HttpContext context) =>
            {
                // Чтение данных из формы
                IFormCollection form = await context.Request.ReadFormAsync();
                // Получение значений полей формы
                string name = form["name"];
                string email = form["email"];
                string message = form["message"];
                // Простейшая обработка данных
                return Results.Ok($"Форма успешно отправлена! Имя: {name}, Email:{ email},Сообщение: { message}");
            });

            app.MapGet("/user", () =>
            {
                return Results.Content(File.ReadAllText("Views\\Restouranes\\RegistrationFormUser.html"), "text/html");
            });


            app.MapPost("/user", async (HttpContext context) =>
            {
                IFormCollection form = await context.Request.ReadFormAsync();
                UserModel formData = new UserModel();
                formData.Name = form["name"];
                formData.Email = form["email"];
                formData.Password = form["password"];
                formData.ReqvestPassword = form["ReqvestPassword"];
                formData.Age = Convert.ToInt32(form["age"]);
                formData.PhoneNumber = form["phoneNumber"];
                formData.Add = form["add"];

                // Список для хранения ошибок
                List<ValidationResult> validationResults = new List<ValidationResult>();
                ValidationContext validationContext = new ValidationContext(formData);

                // Валидация объекта
                if (!Validator.TryValidateObject(formData, validationContext,
                validationResults, true))
                {
                    return Results.BadRequest(validationResults);
                }

                return Results.Content($"Форма успешно отправлена! \r\nИмя: {formData.Name}, Email: {formData.Email}, Пароль: {formData.Password}, Повтор пароля: {formData.ReqvestPassword}, Возраст: {formData.Age}, Номер телефона: {formData.PhoneNumber}, Реклама: {formData.Add} ", statusCode:200, contentType:"text/json");
            });


            app.Run();
        }
    }
}
