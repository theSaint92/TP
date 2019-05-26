using System.Collections.Generic;

namespace Casino
{
    public class CasinoRepository : ICasinoRepository //DataRepository
    {
        public CasinoContext Context;

        public CasinoRepository(IWstrzykiwanieDanych wstrzykiwanie)
        {
            Context = new CasinoContext();
            wstrzykiwanie.WypelnijCasinoContext(ref Context);
        }

        //create
        public void AddClient(Client client)
        {
            Context.ClientList.Add(client);
        }

        public void AddGame(Game game)
        {
            Context.GameList.Add(game.Id, game);
        }

        public void AddParticipation(Participation participation)
        {
            Context.ParticipationList.Add(participation);
        }

        public void AddPlayGame(PlayGame playGame)
        {
            Context.PlayGameList.Add(playGame);
        }


        //delete
        public bool DeleteClient(int clientId)
        {
            foreach (Client c in Context.ClientList)
            {
                if (c.Id == clientId)
                {
                    Context.ClientList.Remove(c);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteGame(int gameId)
        {
            if (Context.GameList.ContainsKey(gameId))
            {
                Context.GameList.Remove(gameId);
                return true;
            }
            return false;       
        }

        public bool DeleteParticipation(int participationId)
        {
            foreach (Participation p in Context.ParticipationList)
            {
                if (p.Id == participationId)
                {
                    Context.ParticipationList.Remove(p);
                    return true;
                }
            }
            return false;
        }

        public bool DeletePlayGame(int playGameId)
        {
            foreach (PlayGame p in Context.PlayGameList)
            {
                if (p.Id == playGameId)
                {
                    Context.PlayGameList.Remove(p);
                    return true;
                }
            }
            return false;
        }


        //read
        public IEnumerable<Client> GetAllClients()
        {
            return Context.ClientList;
        }

        public IEnumerable<KeyValuePair<int, Game>> GetAllGames()
        {
            return Context.GameList;
        }

        public IEnumerable<Participation> GetAllParticipations()
        {
            return Context.ParticipationList;
        }

        public IEnumerable<PlayGame> GetAllPlayGames()
        {
            return Context.PlayGameList;
        }

        public Client GetClient(int clientId)
        {
            foreach (Client c in Context.ClientList)
            {
                if (c.Id == clientId)
                    return c;
            }
            return null;
        }

        public Game GetGame(int gameId)
        {
            return Context.GameList[gameId];
        }

        public Participation GetParticipation(int participationId)
        {
            foreach (Participation p in Context.ParticipationList)
            {
                if (p.Id == participationId)
                    return p;
            }
            return null;
        }

        public PlayGame GetPlayGame(int playGameId)
        {
            foreach (PlayGame p in Context.PlayGameList)
            {
                if (p.Id == playGameId)
                    return p;
            }
            return null;
        }


        //update
        public bool UpdateClient(Client client)
        {
            foreach (Client c in Context.ClientList)
            {
                if (c.Id == client.Id)
                {
                    Context.ClientList.Remove(c);
                    Context.ClientList.Add(client);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateGame(Game game)
        {
            if (Context.GameList.ContainsKey(game.Id))
            {
                Context.GameList[game.Id] = game;
                return true;
            }
            return false;
        }

        public bool UpdateParticipation(Participation participation)
        {
            foreach (Participation p in Context.ParticipationList)
            {
                if (p.Id == participation.Id)
                {
                    Context.ParticipationList.Remove(p);
                    Context.ParticipationList.Add(participation);
                    return true;
                }
            }
            return false;
        }

        public bool UpdatePlayGame(PlayGame playGame)
        {
            foreach (PlayGame p in Context.PlayGameList)
            {
                if (p.Id == playGame.Id)
                {
                    Context.PlayGameList.Remove(p);
                    Context.PlayGameList.Add(playGame);
                    return true;
                }
            }
            return false;
        }
    }
}
