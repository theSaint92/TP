﻿using Casino;
using DatabaseCasinoModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCasinoModel
{
    public class DatabaseCasinoRepository
    { 
        private static CasinoDataContext DataBaseContext;

        public static CasinoDataContext Context
        {
            get => DataBaseContext;
            set => DataBaseContext = value;

        }

        //SaveChanges
        public static void SaveChanges()
        {
            try
            {
                DataBaseContext.SubmitChanges();
            }
            catch (Exception e)
            {
            }

        }


        //create
        public static void AddClient(Clients client)
        {
            DataBaseContext.Clients.InsertOnSubmit(client);
            SaveChanges();
        }


        public static void AddGame(Games game)
        {
            DataBaseContext.Games.InsertOnSubmit(game);
            SaveChanges();
        }

        public static void AddParticipation(Participations participation)
        {
            DataBaseContext.Participations.InsertOnSubmit(participation);
            SaveChanges();
        }

        public static void AddPlayGame(PlayGames playGame)
        {
            DataBaseContext.PlayGames.InsertOnSubmit(playGame);
            SaveChanges();
        }

        public static void DeleteClient(int id)
        {
            Clients client = (from clients in DataBaseContext.Clients
                              where clients.Id == id
                              select clients).First();

            if (client != null)
            {
                DataBaseContext.Clients.DeleteOnSubmit(client);
            }

            SaveChanges();
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

            SaveChanges();
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

            SaveChanges();
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

            SaveChanges();
        }

        public static ObservableCollection<Clients> GetAllClients()
        {
            List<Clients> allClients = (from clients in DataBaseContext.Clients
                                        select clients).ToList();

            //Convert to observable collection
            ObservableCollection<Clients> result = new ObservableCollection<Clients>();
            foreach (Clients c in allClients)
                result.Add(c);

            return result;
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

        public static void UpdateClient(Clients client)
        {
            Clients updateClient = DataBaseContext.Clients.Single(p => p.Id == client.Id);

            updateClient.Name = client.Name;
            updateClient.Surname = client.Surname;
            updateClient.DateOfBirth = client.DateOfBirth;

            SaveChanges();
        }

        public static void UpdateGame(Games game)
        {
            Games updateGame = DataBaseContext.Games.Single(p => p.Id == game.Id);

            updateGame.GameName = game.GameName;
            updateGame.GameDescription = game.GameDescription;

            SaveChanges();

        }

        public static void UpdatePlayGame(PlayGames playGame)
        {
            PlayGames updatePlayGame = DataBaseContext.PlayGames.Single(p => p.Id == playGame.Id);

            updatePlayGame.Game = playGame.Game;
            updatePlayGame.StartTime = playGame.StartTime;
            updatePlayGame.Duration = playGame.Duration;
            updatePlayGame.MinimumDeposit = playGame.MinimumDeposit;
            updatePlayGame.EntryFee = playGame.EntryFee;


            SaveChanges();
        }

        public static void UpdateParticipation(Participations participation)
        {
            Participations updateParticipation = DataBaseContext.Participations.Single(p => p.Id == participation.Id);

            updateParticipation.Clients = participation.Clients;
            updateParticipation.PlayGames = participation.PlayGames;
            updateParticipation.StartTime = participation.StartTime;
            updateParticipation.Duration = participation.Duration;
            updateParticipation.Profit = participation.Profit;

            SaveChanges();
        }
    }
}
