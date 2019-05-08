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
        Client GetClient(int id);
        Game GetGame(int id);
        PlayGame GetPlayGame(int id);
        Participation GetParticipation(int id);
        IEnumerable<Client> GetAllClient();
        IEnumerable<KeyValuePair<int, Game>> GetAllGame();
        IEnumerable<PlayGame> GetAllPlayGame();
        IEnumerable<Participation> GetAllParticipations();

        //update
        void UpdateClient(int id, Client client);
        void UpdateGame(Game game);
        void UpdatePlayGame(int id, PlayGame playGame);
        void UpdateParticipation(int id, Participation participation);

        //delete
        void DeleteClient(int id);
        void DeleteGame(int id);
        void DeletePlayGame(int id);
        void DeleteParticipation(int id);


    }
}
