using System; //DateTime & TimeSpan
using System.ComponentModel;

namespace Casino
{
    public class PlayGame : INotifyPropertyChanged //OpisStanu
    {
        private int _id;
        private Game _game;
        private DateTime _startTime;
        private TimeSpan _duration;
        private double _minimumDeposit;
        private double _entryFee;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public Game Game
        {
            get { return _game; }
            set
            {
                _game = value;
                OnPropertyChanged("Game");
            }
        }
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged("Duration");
            }
        }
        public double MinimumDeposit
        {
            get { return _minimumDeposit; }
            set
            {
                _minimumDeposit = value;
                OnPropertyChanged("MinimumDeposit");
            }
        }
        public double EntryFee
        {
            get { return _entryFee; }
            set
            {
                _entryFee = value;
                OnPropertyChanged("EntryFee");
            }
        }

        public PlayGame(int id, Game game, DateTime startTime, TimeSpan duration, double minimumDeposit, double entryFee)
        {
            this.Id = id;
            this.Game = game;
            this.StartTime = startTime;
            this.Duration = duration;
            this.MinimumDeposit = minimumDeposit;
            this.EntryFee = entryFee;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return $"{Id}. [{Game.GameName}] Started: {StartTime.ToString("dd/MM/yyyy")}, Duration: {Duration.ToString()}, Minimum Deposit: {MinimumDeposit}, Entry fee: {EntryFee}";
        }
    }
}
