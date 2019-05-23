using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Casino;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class CasinoServiceTest
    {
        private static ICasinoRepository repository = new CasinoRepository(new WstrzykiwanieStalych());
        private static ICasinoService service = new CasinoService(repository);

        [TestMethod]
        public void ClientsToStringTest()
        {
            string result = null;
            result = service.ClientsToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void GamesToStringTest()
        {
            string result = null;
            result = service.GamesToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void PlayGamesToStringTest()
        {
            string result = null;
            result = service.PlayGamesToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void ParticipationsToStringTest()
        {
            string result = null;
            result = service.ParticipationsToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void RepositoryToStringTest()
        {
            string result = null;
            result = service.RepositoryToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void AddClientTest()
        {
            int result = service.AddClient("Kamil", "Wokulski", new DateTime(2000, 01, 01));
            IEnumerable<Client> clients = repository.GetAllClients();
            Assert.AreEqual(6, clients.Count());
            Assert.AreEqual("Kamil", repository.GetClient(result).Name);

        }

        [TestMethod]
        public void AddGameTest()
        {
            int result = service.AddGame("Trzy Karty", "...");
            IEnumerable<KeyValuePair<int,Game>> games = repository.GetAllGames();
            Assert.AreEqual(4, games.Count());
            Assert.AreEqual("Trzy Karty", repository.GetGame(result).GameName);
        }

        [TestMethod]
        public void AddPlayGameTest()
        {
            int result = service.AddPlayGame(repository.GetGame(1), new DateTime(2019, 05, 22), new TimeSpan(1, 0, 0), 100, 10);
            IEnumerable<PlayGame> playGames = repository.GetAllPlayGames();
            Assert.AreEqual(8, playGames.Count());
            Assert.AreEqual("Ruletka", repository.GetPlayGame(result).Game.GameName);
        }

        [TestMethod]
        public void AddParticipationTest()
        {
            int result = service.AddParticipation(repository.GetClient(1), repository.GetPlayGame(1), new DateTime(2015, 03, 22), new TimeSpan(0, 30, 0), 0);
            IEnumerable<Participation> participations = repository.GetAllParticipations();
            Assert.AreEqual(6, participations.Count());
            Assert.AreEqual("Aldona", repository.GetParticipation(result).Participator.Name);
            Assert.AreEqual("Poker", repository.GetParticipation(result).PlayedGame.Game.GameName);
        }

        [TestMethod]
        public void ChangeClientDataTest()
        {
            Client c = repository.GetClient(2);
            Assert.AreEqual("Krystian", c.Name);
            Assert.AreEqual("Niewiadomski", c.Surname);
            Assert.AreEqual(new DateTime(1990, 11, 24), c.DateOfBirth);
 
            service.ChangeClientData(2, "Aleksander", "Bolczak", new DateTime(1992, 12, 24));
            c = repository.GetClient(2);
            Assert.AreEqual("Aleksander", c.Name);
            Assert.AreEqual("Bolczak", c.Surname);
            Assert.AreEqual(new DateTime(1992, 12, 24), c.DateOfBirth);
        }

        [TestMethod]
        public void SelectClientParticipationsTest()
        {
            IEnumerable<Participation> participationsOfClient0 = service.SelectClientParticipations(repository.GetClient(0));
            Assert.AreEqual(2, participationsOfClient0.Count());
        }

        [TestMethod]
        public void SelectGamePlayGamesTest()
        {
            IEnumerable<PlayGame> playGamesOfGame0 = service.SelectGamePlayGames(repository.GetGame(0));
            Assert.AreEqual(3, playGamesOfGame0.Count());
        }

        [TestMethod]
        public void SelectClientGamesTest()
        {
            IEnumerable<Game> gamesOfClient0 = service.SelectClientGames(repository.GetClient(0));
            Assert.AreEqual(2, gamesOfClient0.Count());
        }

        [TestMethod]
        public void SelectClientPlayGamesTest()
        {
            IEnumerable<PlayGame> playGamesOfClient0 = service.SelectClientPlayGames(repository.GetClient(0));
            Assert.AreEqual(2, playGamesOfClient0.Count());
        }

        [TestMethod]
        public void SelectMostProfitableGameTest()
        {
            Tuple<double, Game> result = service.SelectMostProfitableGame();
            Game expected = repository.GetGame(0);
            Assert.AreEqual(expected, result.Item2);
            Assert.AreEqual(190, result.Item1, 0.001);
        }

        [TestMethod]
        public void SelectLeastProfitableGameTest()
        {
            Tuple<double,Game> result = service.SelectLeastProfitableGame();
            Game expected = repository.GetGame(1);
            Assert.AreEqual(expected, result.Item2);
            Assert.AreEqual(-400, result.Item1, 0.001 );
        }
    }
}
