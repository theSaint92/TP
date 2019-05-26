using System; //DateTime & TimeSpan
using System.ComponentModel;

namespace Casino
{
    public class Participation : INotifyPropertyChanged //Zdarzenie
    {
        private int _id;
        private Client _participator;
        private PlayGame _playedGame;
        private DateTime _startTime;
        private TimeSpan _duration;
        private double _profit;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public Client Participator
        {
            get { return _participator; }
            set
            {
                _participator = value;
                OnPropertyChanged("Participator");
            }
        }
        public PlayGame PlayedGame
        {
            get { return _playedGame; }
            set
            {
                _playedGame = value;
                OnPropertyChanged("PlayedGame");
            }
        }
        public DateTime StartTime
        {
            get { return _startTime;  }
            set
            {
                _startTime = value;
                OnPropertyChanged("StarTime");
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
        public double Profit
        {
            get { return _profit; }
            set
            {
                _profit = value;
                OnPropertyChanged("Profit");
            }
        }

        public Participation(int id, Client participator, PlayGame playedGame, DateTime startTime, TimeSpan duration, double profit)
        {
            this._id = id;
            this._participator = participator;
            this._playedGame = playedGame;
            this._startTime = startTime;
            this._duration = duration;
            this._profit = profit;
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
            return $"[Id: {Id}]. {PlayedGame.Game.GameName} (PlayGameId: {PlayedGame.Id}, ParticipatorId: {Participator.Id}) Started: {StartTime.ToString("dd/MM/yyyy")}, Duration: {Duration.ToString()}, Profit: {Profit}";
        }
    }
}
