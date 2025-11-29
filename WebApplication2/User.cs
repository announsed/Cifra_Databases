namespace WebApplication2
{
    public class User
    {

        public string Name { get; set; }
        public int Age {  get; set; }
        public string Email { get; set; }
        public long NumberPhone { get; set; }
        public User(string name, int age, string email, long numberPhone)
        {
            Name = name;
            Age = age;
            Email = email;
            NumberPhone = numberPhone;
        }
    }
}
