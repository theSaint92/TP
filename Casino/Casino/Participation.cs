using System; //DateTime & TimeSpan

namespace Casino
{
    public class Participation //Zdarzenie
    {
        public int Id { get; set; }
        public Client Participator { get; set; }
        public PlayGame PlayedGame { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Profit { get; set; }

        public Participation(int id, Client participator, PlayGame playedGame, DateTime startTime, TimeSpan duration, double profit)
        {
            this.Id = id;
            this.Participator = participator;
            this.PlayedGame = playedGame;
            this.StartTime = startTime;
            this.Duration = duration;
            this.Profit = profit;
        }

        public override string ToString()
        {
            return $"{Id}. [{PlayedGame.Game.GameName}] ParticipatorId: {Participator.Id}, Started: {StartTime.ToString("dd/MM/yyyy")}, Duration: {Duration.ToString()}, Profit: {Profit}";
        }
    }
}
