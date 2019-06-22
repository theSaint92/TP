using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class DatabaseCasinoRepository : ICasinoRepository
    {
        public void AddClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void AddParticipation(Participation participation)
        {
            throw new NotImplementedException();
        }

        public void AddPlayGame(PlayGame playGame)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteParticipation(int participationId)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlayGame(int playGameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<int, Game>> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participation> GetAllParticipations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayGame> GetAllPlayGames()
        {
            throw new NotImplementedException();
        }

        public Client GetClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public Game GetGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public Participation GetParticipation(int participationId)
        {
            throw new NotImplementedException();
        }

        public PlayGame GetPlayGame(int playGameId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public bool UpdateParticipation(Participation participation)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePlayGame(PlayGame playGame)
        {
            throw new NotImplementedException();
        }
    }
}
