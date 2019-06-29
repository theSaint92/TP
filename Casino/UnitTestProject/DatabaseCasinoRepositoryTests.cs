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
            int iloscGraczyPrzed = DatabaseCasinoRepository.GetAllClients().Count();

            Clients gracz = DatabaseCasinoRepository.GetAllClients().Last();

            DatabaseCasinoRepository.DeleteClient(gracz.Id);

            int iloscGraczyPo = DatabaseCasinoRepository.GetAllClients().Count();

            Assert.AreEqual(iloscGraczyPrzed - 1, iloscGraczyPo);
        }

        [TestMethod()]
        public void DeleteGameTest()
        {
            
            int iloscGierPrzed = DatabaseCasinoRepository.GetAllGames().Count();

            Games gra = DatabaseCasinoRepository.GetAllGames().Last();

            DatabaseCasinoRepository.DeleteGame(gra.Id);

            int iloscGierPo = DatabaseCasinoRepository.GetAllGames().Count();

            Assert.AreEqual(iloscGierPrzed - 1, iloscGierPo);
        }

        [TestMethod()]
        public void DeleteParticipationTest()
        {
           
            int iloscZdarzenPrzed = DatabaseCasinoRepository.GetAllParticipations().Count();

            Participations zdarzenie = DatabaseCasinoRepository.GetAllParticipations().Last();

            DatabaseCasinoRepository.DeleteParticipation(zdarzenie.Id);

            int iloscZdarzenPo = DatabaseCasinoRepository.GetAllParticipations().Count();

            Assert.AreEqual(iloscZdarzenPrzed - 1, iloscZdarzenPo);
        }



        [TestMethod()]
        public void UpdateClientTest()
        {
            Clients gracz = DatabaseCasinoRepository.GetClient(0);
            gracz.Surname = "nowenazwisko";

            DatabaseCasinoRepository.UpdateClient(gracz);

            Clients tester = DatabaseCasinoRepository.GetClient(0);
            Assert.AreEqual("nowenazwisko", tester.Surname);
        }

        [TestMethod()]
        public void UpdateGameTest()
        {
            Games gra = DatabaseCasinoRepository.GetGame(0);
            gra.GameName = "Nowa nazwa";

            DatabaseCasinoRepository.UpdateGame(gra);

            Games tester = DatabaseCasinoRepository.GetGame(0);
            Assert.AreEqual("Nowa nazwa", tester.GameName);
        }

        [TestMethod()]
        public void UpdateParticipationTest()
        {
            Participations zdarzenie = DatabaseCasinoRepository.GetPatricipation(0);
            zdarzenie.Participator = 1;

            DatabaseCasinoRepository.UpdateParticipation(zdarzenie);

            Participations tester = DatabaseCasinoRepository.GetPatricipation(0);
            Assert.AreEqual(1, tester.Participator);
        }

        [TestMethod()]
        public void UpdatePlayGameTest()
        {
            PlayGames rozegranaGra = DatabaseCasinoRepository.GetPlayGame(0);
            rozegranaGra.MinimumDeposit = 666;

            DatabaseCasinoRepository.UpdatePlayGame(rozegranaGra);

            PlayGames tester = DatabaseCasinoRepository.GetPlayGame(0);
            Assert.AreEqual(666, tester.MinimumDeposit);
        }
    }
}