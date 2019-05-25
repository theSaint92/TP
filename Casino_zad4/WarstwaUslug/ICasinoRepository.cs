using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarstwaUslug
{
    public interface ICasinoRepository
    {

        void AddClient(Clients client);
        void AddGame(Games game);
        void AddPlayedGame(PlayGames playGame);
        void AddParticipation(Participations participation);

        //delete
        void DeleteClient(int clientId);

        void DeleteGame(int gameId);
        void DeleteParticipation(int participationId);

        void DeletePlayGame(int playGameId);


        //read
        IEnumerable<Clients> GetAllClients();

        IEnumerable<Games> GetAllGames();

        IEnumerable<Participations> GetAllParticipations();

        IEnumerable<PlayGames> GetAllPlayGames();


        Clients GetClient(int clientId);

        Games GetGame(int gameId);

        Participations GetPatricipation(int participationId);

        PlayGames GetPlayGame(int playGameId);


        //update
        void UpdateClient(Clients client);

        void UpdateGame(Games game);

        void UpdatePlayGame(PlayGames playGame);


        void UpdateParticipation(Participations participation);





    }
}
