using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseCasinoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCasinoModel.Tests
{
    [TestClass()]
    public class DatabaseCasinoRepositoryTests
    {


        [TestInitialize]
        public void TestInitialize()
        {
            DatabaseCasinoRepository.Context = new CasinoDataContext();
        }


        [TestMethod()]
        public void AddClientTest()
        {
            int iloscGraczyPrzed = DatabaseCasinoRepository.GetAllClients().Count();

            Clients gracz = new Clients()
            {
                Id = iloscGraczyPrzed,
                Name = string.Concat("Stefan", iloscGraczyPrzed),
                Surname = "Ząbek",
                DateOfBirth = new DateTime(1983, 2, 4)
            };

            DatabaseCasinoRepository.AddClient(gracz);

            int iloscGraczyPo = DatabaseCasinoRepository.GetAllClients().Count();

            Assert.AreEqual(iloscGraczyPrzed + 1, iloscGraczyPo);

        }

        [TestMethod()]
        public void AddGameTest()
        {
            int iloscGierPrzed = DatabaseCasinoRepository.GetAllGames().Count();

            Games gra = new Games()
            {
                Id = iloscGierPrzed,
                GameName = string.Concat("Super gra", iloscGierPrzed),
                GameDescription = string.Concat("Opis super gry", iloscGierPrzed)
            };

            DatabaseCasinoRepository.AddGame(gra);

            int iloscGierPo = DatabaseCasinoRepository.GetAllGames().Count();

            Assert.AreEqual(iloscGierPrzed + 1, iloscGierPo);
        }

        [TestMethod()]
        public void AddParticipationTest()
        {
            int iloscZdarzenPrzed = DatabaseCasinoRepository.GetAllParticipations().Count();

            Participations zdarzenie = new Participations()
            {
                Id = iloscZdarzenPrzed,
                Participator = 1,
                PlayedGame = 1,
                StartTime = new DateTime(2019, 12, 22),
                Duration = new TimeSpan(1, 1, 1),
                Profit = 100
            };

            DatabaseCasinoRepository.AddParticipation(zdarzenie);

            int iloscZdarzenPo = DatabaseCasinoRepository.GetAllParticipations().Count();

            Assert.AreEqual(iloscZdarzenPrzed + 1, iloscZdarzenPo);
        }

        [TestMethod()]
        public void AddPlayGameTest()
        {
            int iloscRozegranychGierPrzed = DatabaseCasinoRepository.GetAllPlayGames().Count();

            PlayGames rozegranaGra = new PlayGames()
            {
                Id = iloscRozegranychGierPrzed,
                Game = 0,
                StartTime = new DateTime(2019, 12, 22),
                Duration = new TimeSpan(1, 1, 1),
                MinimumDeposit = 100,
                EntryFee = 50,
            };

            DatabaseCasinoRepository.AddPlayGame(rozegranaGra);

            int iloscRozegranychGierPo = DatabaseCasinoRepository.GetAllPlayGames().Count();

            Assert.AreEqual(iloscRozegranychGierPrzed + 1, iloscRozegranychGierPo);
        }

        [TestMethod()]
        public void DeleteClientTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteGameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteParticipationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeletePlayGameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllClientsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllGamesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllParticipationsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllPlayGamesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetClientTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetGameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetParticipationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPlayGameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateClientTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateGameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateParticipationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdatePlayGameTest()
        {
            Assert.Fail();
        }
    }
}