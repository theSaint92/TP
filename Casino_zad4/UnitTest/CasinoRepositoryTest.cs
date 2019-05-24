using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarstwaUslug;


namespace UnitTest
{
    [TestClass]
    public class CasinoRepositoryTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            CasinoRepository.Context = new DataBaseDataContext();

        }

        
        //AddTest
        [TestMethod]
        public void AddClientTest()
        {
            int count = CasinoRepository.GetAllClients().Count();

            Clients client = new Clients()
            {
                Id = 0,
                Name = "Marcin",
                Surname = "Rogalski",
                DataOfBirth = new DateTime(1991, 2, 12)
            };

            CasinoRepository.AddClient(client);

            Assert.AreEqual(34, count + 1);


        }

        [TestMethod]
        public void AddGameTest()
        {

            int count = CasinoRepository.GetAllGames().Count();

            Games game = new Games()
            {
                Id = 0,
                GameName = "Gierka",
                GameDescription = "Opis gierki",
            };

            CasinoRepository.AddGame(game);
            Assert.AreEqual(18, count + 1);
        }

        [TestMethod]
        public void AddPlayedGameTest()
        {

            int count = CasinoRepository.GetAllPlayGames().Count();

            PlayGames playGame = new PlayGames()
            {
                Id = 0,
                Game = 0,
                StartTime = new DateTime(2019,12,22),
                Duration = new TimeSpan(1,1,1),
                MinimumDeposit = 100.00,
                EntryFee = 50.00,
            };

            CasinoRepository.AddPlayedGame(playGame);
            Assert.AreEqual(18, count + 1);
        }


        [TestMethod]
        public void AddParticipationTest()
        {

            int count = CasinoRepository.GetAllParticipations().Count();

            Participations participation = new Participations()
            {
                Id = 0,
                Client = 0,
                PlayedGames = 0,
                StartTime = new DateTime(2019, 12, 22),
                Duration = new TimeSpan(1, 1, 1),
                Profit = 200.00,
            };

            CasinoRepository.AddParticipation(participation);
            Assert.AreEqual(18, count + 1);
        }


        //ReadTest





    }
}
