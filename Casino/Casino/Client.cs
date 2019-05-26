using System; //DateTime

namespace Casino
{
    public class Client //Wykaz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Client(int id, string name, string surname, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"[Id: {Id}] {Name} {Surname}, {DateOfBirth.ToString("dd/MM/yyyy")}";
        }
    }
}
