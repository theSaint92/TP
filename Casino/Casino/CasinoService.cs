using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class CasinoService : ICasinoService
    {
        /**
         * Private Fields
         */
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

        /**
         * Functions returning DataContext elements as string.
         */
        public string ClientsToString()
        {
            StringBuilder str = new StringBuilder("ClientsList:\n");
            foreach (Client c in Repository.GetAllClients())
            {
                str.AppendLine("\t" + c.ToString());
            }
            return str.ToString();
        }

        public string GamesToString()
        {
            StringBuilder str = new StringBuilder("GamesList:\n");
            foreach (KeyValuePair<int, Game> g in Repository.GetAllGames())
            {
                str.AppendLine("\t" + g.Value.ToString());
            }
            return str.ToString();
        }

        public string PlayGamesToString()
        {
            StringBuilder str = new StringBuilder("PlayGamesList:\n");
            foreach (PlayGame p in Repository.GetAllPlayGames())
            {
                str.AppendLine("\t" + p.ToString());
            }
            return str.ToString();
        }

        public string ParticipationsToString()
        {
            StringBuilder str = new StringBuilder("ParticipationsList:\n");
            foreach (Participation p in Repository.GetAllParticipations())
            {
                str.AppendLine("\tClient:" + p.ToString());
            }
            return str.ToString();
        }

        /**
         * Function returning whole repository as a pretty string
         */
        public string RepositoryToString()
        {
            StringBuilder str = new StringBuilder("Repository:\n");
            foreach (Client c in Repository.GetAllClients())
            {
                str.AppendLine(c.ToString());
                foreach (Participation p in SelectClientParticipations(c))
                {
                    str.AppendLine("\tParticipation: " + p.ToString());
                }

            }
            return str.ToString();
        }

        /**
         * Adding elements to repository
         */
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

        public int AddPlayGame(Game game, DateTime startTime, TimeSpan duration, double minimumDeposit, double entryFee)
        {
            Repository.AddPlayGame(new PlayGame(++CurrentMaxPlayGameId, game, startTime, duration, minimumDeposit, entryFee));
            return CurrentMaxPlayGameId;
        }

        public int AddParticipation(Client participator, PlayGame playedGame, DateTime startTime, TimeSpan duration, double profit)
        {
            Repository.AddParticipation(new Participation(++CurrentMaxParticipationId, participator, playedGame, startTime, duration, profit));
            return CurrentMaxParticipationId;
        }

        /**
         * Changeing client data in case we need. Maybe he changed name, surname or gender... dunno bro
         */
        public void ChangeClientData(int clientId, string newName, string newSurname, DateTime dateOfBirth)
        {
            Repository.UpdateClient(new Client(clientId, newName, newSurname, dateOfBirth));
        }

        /**
         * Returning list of participations of specified player
         */
        public IEnumerable<Participation> SelectClientParticipations(Client client)
        {
            List<Participation> result = new List<Participation>();
            foreach (Participation p in Repository.GetAllParticipations())
            {
                if (p.Participator.Id == client.Id) result.Add(p);
            }
            return result;
        }

        /**
         * Returning list of PlayGames for selected game.
         */
        public IEnumerable<PlayGame> SelectGamePlayGames(Game game)
        {
            List<PlayGame> result = new List<PlayGame>();
            foreach (PlayGame p in Repository.GetAllPlayGames())
            {
                if (p.Game.Id == game.Id) result.Add(p);
            }
            return result;
        }

        /**
         * Selecting Games that client played.
         */
        public IEnumerable<Game> SelectClientGames(Client client)
        {
            List<Game> result = new List<Game>();
            foreach (Participation p in SelectClientParticipations(client))
            {
                if (!result.Contains(p.PlayedGame.Game)) result.Add(p.PlayedGame.Game);
            }
            return result;
        }

        /**
         * Selecting PlayGames that client participated in.
         */
        public IEnumerable<PlayGame> SelectClientPlayGames(Client client)
        {
            List<PlayGame> result = new List<PlayGame>();
            foreach (Participation p in SelectClientParticipations(client))
            {
                if (!result.Contains(p.PlayedGame)) result.Add(p.PlayedGame);
            }
            return result;
        }

        /**
         * Returing most profitable game from Casino point of view.
         */
        public Game SelectMostProfitableGame()
        {
            Game mostProfitable = null;
            double profit = Double.MinValue;
            foreach (KeyValuePair<int, Game> g in Repository.GetAllGames())
            {
                double sum = 0;
                foreach (Participation p in Repository.GetAllParticipations())
                {
                    if (p.PlayedGame.Game.Id == g.Value.Id) sum -= p.Profit;
                }
                if (sum > profit)
                {
                    profit = sum;
                    mostProfitable = g.Value;
                }
            }
            return mostProfitable;
        }

        /**
         * Returing least profitable game from Casino point of view.
         */
        public Game SelectLeastProfitableGame()
        {
            Game leastProfitable = null;
            double profit = Double.MinValue;
            foreach (KeyValuePair<int, Game> g in Repository.GetAllGames())
            {
                double sum = 0;
                foreach (Participation p in Repository.GetAllParticipations())
                {
                    if (p.PlayedGame.Game.Id == g.Value.Id) sum += p.Profit;
                }
                if (sum > profit)
                {
                    profit = sum;
                    leastProfitable = g.Value;
                }
            }
            return leastProfitable;
        }
    }
}
