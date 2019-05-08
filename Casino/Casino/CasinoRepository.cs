using System.Collections.Generic;

namespace Casino
{
    public class CasinoRepository : ICasinoRepository //DataRepository
    {
        private CasinoContext Context;

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
        public void DeleteClient(int id)
        {
            Context.ClientList.RemoveAt(id);
        }

        public void DeleteGame(int id)
        {
            Context.GameList.Remove(id);
        }

        public void DeleteParticipation(int id)
        {
            Context.ParticipationList.RemoveAt(id);
        }

        public void DeletePlayGame(int id)
        {
            Context.PlayGameList.RemoveAt(id);
        }


        //read
        public IEnumerable<Client> GetAllClient()
        {
            return Context.ClientList;
        }

        public IEnumerable<KeyValuePair<int, Game>> GetAllGame()
        {
            return Context.GameList;
        }

        public IEnumerable<Participation> GetAllParticipations()
        {
            return Context.ParticipationList;
        }

        public IEnumerable<PlayGame> GetAllPlayGame()
        {
            return Context.PlayGameList;
        }

        public Client GetClient(int id)
        {
            return Context.ClientList[id];
        }

        public Game GetGame(int id)
        {
            return Context.GameList[id];
        }

        public Participation GetParticipation(int id)
        {
            return Context.ParticipationList[id];
        }

        public PlayGame GetPlayGame(int id)
        {
            return Context.PlayGameList[id];
        }


        //update
        public void UpdateClient(int id, Client client)
        {
            Context.ClientList[id] = client;
        }

        public void UpdateGame(Game game)
        {
            Context.GameList[game.Id] = game;
        }

        public void UpdateParticipation(int id, Participation participation)
        {
            Context.ParticipationList[id] = participation;
        }

        public void UpdatePlayGame(int id, PlayGame playGame)
        {
            Context.PlayGameList[id] = playGame;
        }
    }
}
