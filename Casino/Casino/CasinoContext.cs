using System.Collections.Generic; //List & Dictionary
using System.Collections.ObjectModel; //ObservableCollection

namespace Casino
{
    public class CasinoContext //DataContext
    {
        public List<Client> ClientList;
        public Dictionary<int, Game> GameList;
        public ObservableCollection<PlayGame> PlayGameList;
        public ObservableCollection<Participation> ParticipationList;

        public CasinoContext()
        {
            ClientList = new List<Client>();
            GameList = new Dictionary<int, Game>();
            PlayGameList = new ObservableCollection<PlayGame>();
            ParticipationList = new ObservableCollection<Participation>();
        
        }
    }
}
