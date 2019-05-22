using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public interface ICasinoRepository
    {
        //create
        void AddClient(Client client);
        void AddGame(Game game);
        void AddPlayGame(PlayGame playGame);
        void AddParticipation(Participation participation);

        //read
        Client GetClient(int clientId);
        Game GetGame(int gameId);
        PlayGame GetPlayGame(int playGameId);
        Participation GetParticipation(int participationId);
        IEnumerable<Client> GetAllClients();
        IEnumerable<KeyValuePair<int, Game>> GetAllGames();
        IEnumerable<PlayGame> GetAllPlayGames();
        IEnumerable<Participation> GetAllParticipations();

        //update
        bool UpdateClient(Client client);
        bool UpdateGame(Game game);
        bool UpdatePlayGame(PlayGame playGame);
        bool UpdateParticipation(Participation participation);

        //delete
        bool DeleteClient(int clientId);
        bool DeleteGame(int gameId);
        bool DeletePlayGame(int playGameId);
        bool DeleteParticipation(int participationId);


    }
}
