namespace WebApplication2
{
    public class Productcs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Prise {  get; set; }

        public Productcs(int id, string name, string description, string category, int prise)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Prise = prise;
        }
    }
}
