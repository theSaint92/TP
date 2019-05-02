using System; //DateTime & TimeSpan

namespace Casino
{
    class PlayGame //OpisStanu
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
            //TODO write proper toString() text
            return $"Later will do";
        }
    }
}
