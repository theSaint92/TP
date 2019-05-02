using System; //DateTime & TimeSpan

namespace Casino
{
    class Participation //Zdarzenie
    {
        public Client Participator { get; set; }
        public PlayGame PlayedGame { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Profit { get; set; }

        public Participation(Client participator, PlayGame playedGame, DateTime startTime, TimeSpan duration, double profit)
        {
            this.Participator = participator;
            this.PlayedGame = playedGame;
            this.StartTime = startTime;
            this.Duration = duration;
            this.Profit = profit;
        }

        public override string ToString()
        {
            //TODO write proper toString() text
            return $"Later will do";
        }
    }
}
