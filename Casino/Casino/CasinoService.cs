using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class CasinoService : ICasinoService
    {
        private ICasinoRepository Repository;
        private int CurrentMaxClientId = 0;
        private int CurrentMaxGameId = 0;
        private int CurrentMaxPlayGameId = 0;
        private int CurrentMaxParticipationId = 0;

        /**
         * Constructors
         */
        public CasinoService(ICasinoRepository r)
        {
            Repository = r;
            
            // To efficiently add elements to repository without iterating
            // through it every time.
            foreach (Client c in r.GetAllClients())
                if (c.Id > CurrentMaxClientId) CurrentMaxClientId = c.Id;
            foreach (KeyValuePair<int, Game> g in r.GetAllGames())
                if (g.Key > CurrentMaxGameId) CurrentMaxGameId = g.Key;
            foreach (PlayGame p in r.GetAllPlayGames())
                if (p.Id > CurrentMaxPlayGameId) CurrentMaxPlayGameId = p.Id;
            foreach (Participation p in r.GetAllParticipations())
                if (p.Id > CurrentMaxParticipationId) CurrentMaxParticipationId = p.Id;
        }

        public int AddClient(string name, string surname, DateTime dateOfBirth)
        {
            Repository.AddClient(new Client(++CurrentMaxClientId, name, surname, dateOfBirth));
            return CurrentMaxClientId;
        }

        public int AddGame(string gameName, string gameDescription)
        {
            Repository.AddGame(new Game(++CurrentMaxGameId, gameName, gameDescription));
            return CurrentMaxGameId;
        }

        public int AddParticipation(Client participator, PlayGame playedGame, DateTime startTime, TimeSpan duration, double profit)
        {
            Repository.AddParticipation(new Participation(++CurrentMaxParticipationId, participator, playedGame, startTime, duration, profit));
            return CurrentMaxParticipationId;
        }

        public int AddPlayGame(Game game, DateTime startTime, TimeSpan duration, double minimumDeposit, double entryFee)
        {
            Repository.AddPlayGame(new PlayGame(++CurrentMaxPlayGameId, game, startTime, duration, minimumDeposit, entryFee));
            return CurrentMaxPlayGameId;
        }

        public void ChangeClientData(int clientId, string newName, string newSurname, DateTime dateOfBirth)
        {
            Repository.UpdateClient(new Client(clientId, newName, newSurname, dateOfBirth));
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

        public IEnumerable<Game> SelectClientGames(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participation> SelectClientParticipations(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayGame> SelectClientPlayGames(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayGame> SelectGamePlayGames(Game game)
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
