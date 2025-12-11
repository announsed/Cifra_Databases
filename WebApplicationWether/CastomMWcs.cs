namespace WebApplicationWether
{
    public class CastomMWcs
    {
        private readonly RequestDelegate _next;
        public CastomMWcs(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;
            var url = context.Request.Host.Value;
            var time = DateTime.Now;
            Console.WriteLine($"[INFO] Входящий запрос: {method} {url}  Время: {time}");
            await _next(context); // Передача управления следующему компоненту

            Console.WriteLine("Запрос успешно обработан!");
        }
    }


    public class CastomMW2cs
    {
        private readonly RequestDelegate _next;
        public CastomMW2cs(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var статус = context.Response.StatusCode;
            var время = DateTime.Now;
            Console.WriteLine($"[INFO] Ответ: {статус} Время завершения: {время}");
        }
    }
}
