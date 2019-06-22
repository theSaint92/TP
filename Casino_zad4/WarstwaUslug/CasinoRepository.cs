using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarstwaUslug
{
    public class CasinoRepository : ICasinoRepository
    {
        private DataBaseDataContext DataBaseContext;

        public CasinoRepository()
        {
            DataBaseContext = new DataBaseDataContext();
        }


        public  DataBaseDataContext Context
        {
            get => DataBaseContext;
            set => DataBaseContext = value;

        }

        //create
        public void AddClient(Client client)
        {
            DataBaseContext.Clients.InsertOnSubmit(client);

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }


        }

        public void AddGame(Game game)
        {
            DataBaseContext.Games.InsertOnSubmit(game);


            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }


        public void AddPlayedGame(PlayGame playGame)
        {
            DataBaseContext.PlayGames.InsertOnSubmit(playGame);

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }


        public void AddParticipation(Participation participation)
        {
            DataBaseContext.Participations.InsertOnSubmit(participation);

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        //delete
        public void DeleteClient(int clientId)
        {
            Clients client = (from clients in DataBaseContext.Clients
                              where clients.Id == clientId
                              select clients).First();

            if (client != null)
            {
                DataBaseContext.Clients.DeleteOnSubmit(client);
            }

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }

        }

        public void DeleteGame(int gameId)
        {
            Games game = (from games in DataBaseContext.Games
                          where games.Id == gameId
                          select games).First();

            if (game != null)
            {
                DataBaseContext.Games.DeleteOnSubmit(game);
            }

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }
        public void DeleteParticipation(int participationId)
        {
            Participation participation = (from participations in DataBaseContext.Participations
                                            where participations.Id == participationId
                                            select participations).First();

            if (participation != null)
            {
                DataBaseContext.Participations.DeleteOnSubmit(participation);
            }

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public void DeletePlayGame(int playGameId)
        {
            PlayGame playGame = (from playGames in DataBaseContext.PlayGames
                                  where playGames.Id == playGameId
                                  select playGames).First();

            if (playGame != null)
            {
                DataBaseContext.PlayGames.DeleteOnSubmit(playGame);
            }

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }


        //read
        public IEnumerable<Clients> GetAllClients()
        {
            List<Clients> allClients = (from clients in DataBaseContext.Clients
                                        select clients).ToList();

            return allClients;
        }

        public IEnumerable<Games> GetAllGames()
        {
            List<Games> allGames = (from games in DataBaseContext.Games
                                    select games).ToList();

            return allGames;
        }

        public IEnumerable<Participations> GetAllParticipations()
        {
            List<Participations> allPatricipations = (from patricipations in DataBaseContext.Participations
                                                      select patricipations).ToList();

            return allPatricipations;
        }


        public IEnumerable<PlayGames> GetAllPlayGames()
        {
            List<PlayGames> allPlayGames = (from playGames in DataBaseContext.PlayGames
                                            select playGames).ToList();

            return allPlayGames;
        }


        public Clients GetClient(int clientId)
        {
            Clients client = (from clients in DataBaseContext.Clients
                              where clients.Id == clientId
                              select clients).First();

            return client;
        }

        public Games GetGame(int gameId)
        {
            Games game = (from games in DataBaseContext.Games
                          where games.Id == gameId
                          select games).First();

            return game;
        }

        public Participations GetPatricipation(int participationId)
        {
            Participations participation = (from participations in DataBaseContext.Participations
                                            where participations.Id == participationId
                                            select participations).First();

            return participation;
        }

        public PlayGames GetPlayGame(int playGameId)
        {
            PlayGames playGame = (from playGames in DataBaseContext.PlayGames
                                  where playGames.Id == playGameId
                                  select playGames).First();

            return playGame;
        }


        //update
        public void UpdateClient(Clients client)
        {
            Clients updateClient = DataBaseContext.Clients.Single(p => p.Id == client.Id);

            updateClient.Name = client.Name;
            updateClient.Surname = client.Surname;
            updateClient.DataOfBirth = client.DataOfBirth;

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }

        }

        public void UpdateGame(Games game)
        {
            Games updateGame = DataBaseContext.Games.Single(p => p.Id == game.Id);

            updateGame.GameName = game.GameName;
            updateGame.GameDescription = game.GameDescription;

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }

        }

        public void UpdatePlayGame(PlayGames playGame)
        {
            PlayGames updatePlayGame = DataBaseContext.PlayGames.Single(p => p.Id == playGame.Id);

            updatePlayGame.Game = playGame.Game;
            updatePlayGame.StartTime = playGame.StartTime;
            updatePlayGame.Duration = playGame.Duration;
            updatePlayGame.MinimumDeposit = playGame.MinimumDeposit;
            updatePlayGame.EntryFee = playGame.EntryFee;

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }

        }

        public void UpdateParticipation(Participations participation)
        {
            Participations updateParticipation = DataBaseContext.Participations.Single(p => p.Id == participation.Id);

            updateParticipation.Client = participation.Client;
            updateParticipation.PlayGames = participation.PlayGames;
            updateParticipation.StartTime = participation.StartTime;
            updateParticipation.Duration = participation.Duration;
            updateParticipation.Profit = participation.Profit;

            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }

        }

       

    }
}

