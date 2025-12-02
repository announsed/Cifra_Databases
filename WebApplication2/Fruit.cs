namespace WebApplication2
{
    public class Fruit
    {

        public string Name {  get; set; }
        public float Prise {  get; set; }
        public float Weigth {  get; set; }

        public Fruit(string name, float prise, float weigth)
        {
            Name = name;
            Prise = prise;
            Weigth = weigth;
        }
    }
}
