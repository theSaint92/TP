using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class CasinoService : ICasinoService
    {
        private ICasinoRepository repository;

        /**
         * Constructors
         */
        public CasinoService(ICasinoRepository r)
        {
            repository = r;
        }

        public int AddClient(string name, string surname, DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public int AddGame(string gameName, string gameDescription)
        {
            throw new NotImplementedException();
        }

        public void AddParticipation(int clientId, int playGameId, DateTime startTime, TimeSpan duration, double profit)
        {
            throw new NotImplementedException();
        }

        public int AddPlayGame(int gameId, DateTime startTime, TimeSpan duration, double minimumDeposit, double entryFee)
        {
            throw new NotImplementedException();
        }

        public void ChangeClientData(int client, string newName, string newSurname, DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public string ClientsToString()
        {
            throw new NotImplementedException();
        }

        public string GamesToString()
        {
            throw new NotImplementedException();
        }

        public string ParticipationsToString()
        {
            throw new NotImplementedException();
        }

        public string PlayGamesToString()
        {
            throw new NotImplementedException();
        }

        public string RepositoryToString()
        {
            throw new NotImplementedException();
        }

        public List<Game> SelectClientGames(int client)
        {
            throw new NotImplementedException();
        }

        public List<Participation> SelectClientParticipations(int client)
        {
            throw new NotImplementedException();
        }

        public List<PlayGame> SelectClientPlayGames(int client)
        {
            throw new NotImplementedException();
        }

        public List<PlayGame> SelectGamePlayGames(int gameId)
        {
            throw new NotImplementedException();
        }

        public Game SelectLeastProfitableGame()
        {
            throw new NotImplementedException();
        }

        public Game SelectMostProfitableGame()
        {
            throw new NotImplementedException();
        }
    }
}
