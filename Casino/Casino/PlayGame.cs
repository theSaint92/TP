using System; //DateTime & TimeSpan

namespace Casino
{
    public class PlayGame //OpisStanu
    {
        public int Id { set; get; }
        public Game Game { set; get; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double MinimumDeposit { get; set; }
        public double EntryFee { get; set; }

        public PlayGame(int id, Game game, DateTime startTime, TimeSpan duration, double minimumDeposit, double entryFee)
        {
            this.Id = id;
            this.Game = game;
            this.StartTime = startTime;
            this.Duration = duration;
            this.MinimumDeposit = minimumDeposit;
            this.EntryFee = entryFee;
        }

        public override string ToString()
        {
            return $"{Id}. [{Game.GameName}] Started: {StartTime.ToString("dd/MM/yyyy")}, Duration: {Duration.ToString()}, Minimum Deposit: {MinimumDeposit}, Entry fee: {EntryFee}";
        }
    }
}
