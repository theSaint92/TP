using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino;

namespace UnitTestProject
{

    [TestClass]
    public class CasinoRepositoryTest
    {
        ICasinoRepository testRepository = new CasinoRepository(new WstrzykiwanieStalych());

        //AddTests

        [TestMethod]
        public void AddClientTest()
        {
            Client client = new Client(12, "Maciej", "Moś", new DateTime(1995, 09, 06));
            testRepository.AddClient(client);
            Client tester = testRepository.GetClient(5);
            Assert.AreEqual(client, tester);

        }

        [TestMethod]
        public void AddGameTest()
        {
            Game game = new Game(7, "Automaty", "..");
            testRepository.AddGame(game);
            Game tester = testRepository.GetGame(7);
            Assert.AreEqual(game, tester);
        }

        [TestMethod]
        public void AddParticipationTest()
        {
            Participation participation = new Participation(testRepository.GetClient(1), testRepository.GetPlayGame(1), new DateTime(2019, 05, 02, 12, 15, 16), new TimeSpan(2, 15, 18), 400.00);
            testRepository.AddParticipation(participation);
            Participation tester = testRepository.GetParticipation(5);
            Assert.AreEqual(participation, tester);
        }

        [TestMethod]
        public void AddPlayGameTest()
        {
            PlayGame playGame = new PlayGame(10, testRepository.GetGame(0), new DateTime(2019, 05, 02, 12, 16, 19), new TimeSpan(2, 15, 04), 50.00, 5.00);
            testRepository.AddPlayGame(playGame);
            PlayGame tester = testRepository.GetPlayGame(7);
            Assert.AreEqual(playGame, tester);
        }

        //ReadTest

        [TestMethod]
        public void ReadClientTest()
        {
            Client client = testRepository.GetClient(0);
            Assert.AreEqual("Marcin", client.Name);
            Assert.AreEqual("Kowalski", client.Surname);
            Assert.AreEqual(new DateTime(1975, 05, 12), client.DateOfBirth);
        }

        [TestMethod]
        public void ReadGameTest()
        {
            Game game = testRepository.GetGame(0);
            Assert.AreEqual("Poker", game.GameName);
            Assert.AreEqual("Karciana gra psychologiczno-strategiczna. Dostępne dwie odmiany - Texas Holdem i Omaha", game.GameDescription);
        }

        [TestMethod]
        public void ReadPlayGameTest()
        {
            PlayGame playGame = testRepository.GetPlayGame(0);
            Assert.AreEqual(new DateTime(2019, 04, 12, 20, 12, 15), playGame.StartTime);
            Assert.AreEqual(new TimeSpan(2, 15, 28), playGame.Duration);
            Assert.AreEqual(50.00, playGame.MinimumDeposit);
            Assert.AreEqual(5.00, playGame.EntryFee);
        }


        [TestMethod]
        public void ReadParticipationTest()
        {
            Participation participation = testRepository.GetParticipation(0);
            Assert.AreEqual(0, participation.Participator.Id);
            Assert.AreEqual("Marcin", participation.Participator.Name);
            Assert.AreEqual("Kowalski", participation.Participator.Surname);
            Assert.AreEqual(0, participation.PlayedGame.Id);
            Assert.AreEqual(new DateTime(2019, 04, 12, 20, 12, 15), participation.StartTime);
            Assert.AreEqual(new TimeSpan(2, 15, 28), participation.Duration);
        }



        [TestMethod]
        public void ReadAllClientTest()
        {
            IEnumerable<Client> clients = testRepository.GetAllClient();
            Assert.AreEqual(5, clients.Count());
            Assert.AreEqual("Aldona", clients.ElementAt(1).Name);
            Assert.AreEqual("Milczarek", clients.ElementAt(1).Surname);
            Assert.AreEqual(new DateTime(1982, 03, 25), clients.ElementAt(1).DateOfBirth);
        }


        [TestMethod]
        public void ReadAllGameTest()
        {
            IEnumerable<KeyValuePair<int, Game>> games = testRepository.GetAllGame();
            Assert.AreEqual(3, games.Count());
            Assert.AreEqual(0, games.ElementAt(0).Value.Id);
            Assert.AreEqual("Poker", games.ElementAt(0).Value.GameName);
            Assert.AreEqual("Karciana gra psychologiczno-strategiczna. Dostępne dwie odmiany - Texas Holdem i Omaha", games.ElementAt(0).Value.GameDescription);
        }


        [TestMethod]
        public void ReadAllPlayGameTest()
        {
            IEnumerable<PlayGame> playGames = testRepository.GetAllPlayGame();
            Assert.AreEqual(7, playGames.Count());
            Assert.AreEqual(1, playGames.ElementAt(1).Id);
            Assert.AreEqual(new DateTime(2019, 05, 01, 19, 20, 30), playGames.ElementAt(1).StartTime);
            Assert.AreEqual(100.00, playGames.ElementAt(3).MinimumDeposit);
        }

        [TestMethod]
        public void ReadAllParticipationTest()
        {
            IEnumerable<Participation> participations = testRepository.GetAllParticipations();
            Assert.AreEqual(5, participations.Count());
            Assert.AreEqual("Marcin", participations.ElementAt(0).Participator.Name);
            Assert.AreEqual("Bodziuch", participations.ElementAt(3).Participator.Surname);
            Assert.AreEqual(new DateTime(2019, 04, 12, 20, 12, 15), participations.ElementAt(0).StartTime);
            Assert.AreEqual(new TimeSpan(2, 15, 28), participations.ElementAt(1).Duration);
            Assert.AreEqual(320.00, participations.ElementAt(3).Profit);
        }

        //updateTest

        [TestMethod]
        public void UpdateClientTest()
        {
            Client client = new Client(5,"Anna","Maciąg",new DateTime(1992,05,07));
            testRepository.UpdateClient(3, client);
            Client tester = testRepository.GetClient(3);
            Assert.AreEqual(client, tester);
        }

        [TestMethod]
        public void UpdateGameTest()
        {
            Game game = new Game(3,"Automaty","...");
            testRepository.UpdateGame(game);
            Game tester = testRepository.GetGame(3);
            Assert.AreEqual(game, tester);

        }

        [TestMethod]
        public void UpdatePlayGameTest()
        {

            PlayGame playGame = new PlayGame(3,testRepository.GetGame(1), new DateTime(2019, 04, 15, 18, 30, 17), new TimeSpan(3, 40, 14), 70.00, 10.00);
            testRepository.UpdatePlayGame(1,playGame);
            PlayGame tester = testRepository.GetPlayGame(1);
            Assert.AreEqual(playGame, tester);

        }

        [TestMethod]
        public void UpdateParticipationTest()
        {

            Participation participation = new Participation(testRepository.GetClient(0), testRepository.GetPlayGame(0), new DateTime(2019, 04, 12, 20, 12, 15), new TimeSpan(2, 15, 28), 120.00);
            testRepository.UpdateParticipation(2, participation);
            Participation tester = testRepository.GetParticipation(2);
            Assert.AreEqual(tester, participation);

        }

        //deleteTest

        [TestMethod]
        public void DeleteClientTest()
        {
            Assert.AreEqual(5, testRepository.GetAllClient().Count());
            Client tester = testRepository.GetClient(2);
            testRepository.DeleteClient(1);
            Assert.AreEqual(4, testRepository.GetAllClient().Count());
            Assert.AreEqual(tester, testRepository.GetClient(1));
        }


        [TestMethod]
        public void DeleteGameTest()
        {
            IEnumerable<KeyValuePair<int, Game>> games = testRepository.GetAllGame();
            Assert.AreEqual(3, games.Count());
            testRepository.DeleteGame(2);
            games = testRepository.GetAllGame();
            Assert.AreEqual(2, games.Count());
        }

        [TestMethod]
        public void DeletePlayGameTest()
        {
            Assert.AreEqual(7, testRepository.GetAllPlayGame().Count());
            PlayGame playGame = testRepository.GetPlayGame(2);
            testRepository.DeletePlayGame(1);
            Assert.AreEqual(6, testRepository.GetAllPlayGame().Count());
            Assert.AreEqual(playGame, testRepository.GetPlayGame(1));
        }

        [TestMethod]
        public void DeleteParticipationTest()
        {
            Assert.AreEqual(5, testRepository.GetAllParticipations().Count());
            Participation participation = testRepository.GetParticipation(2);
            testRepository.DeleteParticipation(1);
            Assert.AreEqual(4, testRepository.GetAllParticipations().Count());
            Assert.AreEqual(participation, testRepository.GetParticipation(1));
        }




    }
}
