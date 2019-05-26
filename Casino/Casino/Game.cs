using System.ComponentModel;

namespace Casino
{
    public class Game : INotifyPropertyChanged //Katalog
    {
        private int _id;
        private string _gameName;
        private string _gameDescription;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string GameName
        {
            get { return _gameName; }
            set
            {
                _gameName = value;
                OnPropertyChanged("GameName");
            }
        }
        public string GameDescription
        {
            get { return _gameDescription; }
            set
            {
                _gameDescription = value;
                OnPropertyChanged("GameDescription");
            }
        }

        public Game(int id, string gameName, string gameDescription)
        {
            this.Id = id;
            this.GameName = gameName;
            this.GameDescription = gameDescription;
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
            return $"{Id}. {GameName} - {GameDescription}";
        }
    }
}
