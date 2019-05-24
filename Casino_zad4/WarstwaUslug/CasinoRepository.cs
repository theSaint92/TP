using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarstwaUslug
{
    public class CasinoRepository
    {
        private static DataBaseDataContext DataBaseContext;


        public static DataBaseDataContext Context
        {
            get => DataBaseContext;
            set => DataBaseContext = value;

        }

        //create
        public static void AddClient(Clients client)
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

        public static void AddGame(Games game)
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


        public static void AddPlayedGame(PlayGames playGame)
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


        public static void AddParticipation(Participations participation)
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
        public static void DeleteClient(int clientId)
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

        public static void DeleteGame(int gameId)
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
        public static void DeleteParticipation(int participationId)
        {
            Participations participation = (from participations in DataBaseContext.Participations
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

        public static void DeletePlayGame(int playGameId)
        {
            PlayGames playGame = (from playGames in DataBaseContext.PlayGames
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
        public static IEnumerable<Clients> GetAllClients()
        {
            List<Clients> allClients = (from clients in DataBaseContext.Clients
                                        select clients).ToList();

            return allClients;
        }

        public static IEnumerable<Games> GetAllGames()
        {
            List<Games> allGames = (from games in DataBaseContext.Games
                                    select games).ToList();

            return allGames;
        }

        public static IEnumerable<Participations> GetAllParticipations()
        {
            List<Participations> allPatricipations = (from patricipations in DataBaseContext.Participations
                                                      select patricipations).ToList();

            return allPatricipations;
        }


        public static IEnumerable<PlayGames> GetAllPlayGames()
        {
            List<PlayGames> allPlayGames = (from playGames in DataBaseContext.PlayGames
                                            select playGames).ToList();

            return allPlayGames;
        }


        public static Clients GetClient(int clientId)
        {
            Clients client = (from clients in DataBaseContext.Clients
                              where clients.Id == clientId
                              select clients).First();

            return client;
        }

        public static Games GetGame(int gameId)
        {
            Games game = (from games in DataBaseContext.Games
                          where games.Id == gameId
                          select games).First();

            return game;
        }

        public static Participations GetPatricipation(int participationId)
        {
            Participations participation = (from participations in DataBaseContext.Participations
                                            where participations.Id == participationId
                                            select participations).First();

            return participation;
        }

        public static PlayGames GetPlayGame(int playGameId)
        {
            PlayGames playGame = (from playGames in DataBaseContext.PlayGames
                                  where playGames.Id == playGameId
                                  select playGames).First();

            return playGame;
        }


        //update
        public static void UpdateClient(Clients client)
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

        public static void UpdateGame(Games game)
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

        public static void UpdatePlayGame(PlayGames playGame)
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

        public static void UpdateParticipation(Participations participation)
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

        //czyszczenie bazy

        public static void DeleteAllClient(int numberOfClients)
        {
            for(int i=0; i < numberOfClients; i++)
            {
                CasinoRepository.DeleteClient(i);
            }
        }

        public static void DeleteAllGames(int numberOfGames)
        {
            for (int i = 0; i < numberOfGames; i++)
            {
                CasinoRepository.DeleteGame(i);
            }
        }

        public static void DeleteAllPlayGames(int numberOfPlayGames)
        {
            for (int i = 0; i < numberOfPlayGames; i++)
            {
                CasinoRepository.DeletePlayGame(i);
            }
        }


        public static void DeleteAllParticipations(int numberOfParticipations)
        {
            for (int i = 0; i < numberOfParticipations; i++)
            {
                CasinoRepository.DeleteParticipation(i);
            }
        }



        //WstrzykiwanieDanych

        public static void WstrzykiwanieDanych(int numberOfClient, int numberOfGames, int numberOfPlayedGames, int numberOfParticipation)
        {

            //wstrzykiwanie klientów

            int number1 = CasinoRepository.GetAllClients().Count();

            for(int i = number1 ; i < number1 + numberOfClient - 1 ; i++)
            {
                Clients client = new Clients()
                {
                    Id = i,
                    Name = string.Concat("Imie", i),
                    Surname = string.Concat("Nazwisko", i),
                    DataOfBirth = new DateTime((2000 + i / 365) % 5000, i % 12 + 1, i % 28 + 1),
                };

                CasinoRepository.AddClient(client);
            }


            //wstrzykiwanie gier

            int number2 = CasinoRepository.GetAllGames().Count();

            for (int i = number2; i < number2 + numberOfGames - 1; i++)
            {
                Games game = new Games()
                {
                    Id = i,
                    GameName = string.Concat("Gra", i),
                    GameDescription = string.Concat("Opis", i),
                };

                CasinoRepository.AddGame(game);
            }

           
            
            //wstrzykiwanie rozegranychGier

            int number3 = CasinoRepository.GetAllPlayGames().Count();

            for (int i = number3; i < number3 + numberOfPlayedGames - 1; i++)
            {
                PlayGames playGame = new PlayGames()
                {
                    Id = i,
                    Game = i,
                    StartTime = new DateTime((2000 + i / 365) % 5000, i % 12 + 1, i % 28 + 1),
                    Duration = new TimeSpan(i % 24, i % 60, i % 59 + 1),
                    MinimumDeposit = i + 10,
                    EntryFee = i + 20,
                };

                CasinoRepository.AddPlayedGame(playGame);
            }

            
            //wstrzykiwanie zdarzeń

            int number4 = CasinoRepository.GetAllParticipations().Count();

            for (int i = number4; i < number4 + numberOfPlayedGames - 1 ; i++)
            {

                Participations participation = new Participations()
                {
                    Id = i,
                    Client = i,
                    PlayedGames = i,
                    StartTime = new DateTime((2000 + i / 365) % 5000, i % 12 + 1, i % 28 + 1),
                    Duration = new TimeSpan(i % 24, i % 60, i % 59 + 1),
                    Profit = i + 120,
                };

                CasinoRepository.AddParticipation(participation);
            }




        }

    }
}

