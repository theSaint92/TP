using System.Collections.Generic; //List & Dictionary
using System.Collections.ObjectModel; //ObservableCollection

namespace Casino
{
    class CasinoContext //DataContext
    {
        public List<Client> ClientList;
        public Dictionary<int, Game> GameList;
        public ObservableCollection<PlayGame> PlayGameList;
        public ObservableCollection<Participation> ParticipationList;

        public CasinoContext(List<Client> clientList, Dictionary<int, Game> gameList, ObservableCollection<PlayGame> playGameList, ObservableCollection<Participation> participationList)
        {
            this.ClientList = clientList;
            this.GameList = gameList;
            this.PlayGameList = playGameList;
            this.ParticipationList = participationList;
        }
    }
}
