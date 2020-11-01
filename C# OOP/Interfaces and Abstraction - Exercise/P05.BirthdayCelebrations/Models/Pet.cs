
namespace P05.BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.BirthDate = birthdate;
        }
        public string Name { get; private set; }
        public string BirthDate { get; private set; }
    }
}
