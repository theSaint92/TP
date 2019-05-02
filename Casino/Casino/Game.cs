namespace Casino
{
    public class Game //Katalog
    {
        public int Id { get; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }

        public Game(int id, string gameName, string gameDescription)
        {
            this.Id = id;
            this.GameName = gameName;
            this.GameDescription = gameDescription;
        }

        public override string ToString()
        {
            return $"{Id}. {GameName} - {GameDescription}";
        }
    }
}
