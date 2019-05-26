using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class WstrzykiwanieIlosciowe : IWstrzykiwanieDanych
    {

        private readonly int numberOfClients;
        private readonly int numberOfGames;
        private readonly int numberOfPlayGames;
        private readonly int numbersOfParticipations;

        public WstrzykiwanieIlosciowe(int clients, int games, int playGames, int participations)
        {
            numberOfClients = clients;
            numberOfGames = games;
            numberOfPlayGames = playGames;
            numbersOfParticipations = participations;

        }



        public void WypelnijCasinoContext(ref CasinoContext context)
        {

            //add clients
            for (int i = 0; i < numberOfClients; i++)
            {
                int Id = i;
                string Name = Faker.Name.First();
                string Surname = Faker.Name.Last();
                DateTime DateOfBirth = new DateTime((2000 + i / 365) % 5000, i % 12 + 1, i % 28 + 1);
                context.ClientList.Add(new Client(Id, Name, Surname, DateOfBirth));
            }


            //add games
            for (int i = 0; i < numberOfGames; i++)
            {
                int Id = i;
                string GameName = string.Concat("gameName", i);
                string GameDescription = string.Concat("gameDescription", i);
                context.GameList.Add(i, new Game(Id, GameName, GameDescription));

            }


            //add playGames
            for (int i = 0; i < numberOfPlayGames; i++)
            {
                int Id = i;
                Game game = context.GameList[i];
                DateTime startTime = new DateTime((2000 + i / 365) % 5000, i % 12 + 1, i % 28 + 1);
                TimeSpan duration = new TimeSpan(i % 24, i % 60, i % 59 + 1);
                double minimumDeposit = i + 10;
                double entryFee = i + 100;

                context.PlayGameList.Add(new PlayGame(Id, game, startTime, duration, minimumDeposit, entryFee));
             }


            //add Participation
            for (int i = 0; i < numbersOfParticipations; i++)
            {
                Client client = context.ClientList[i % context.ClientList.Count];
                PlayGame playGame = context.PlayGameList[i];
                Participation participation = new Participation(i + 10, client, playGame, new DateTime((2000 + i / 365) % 5000, i % 12 + 1, i % 28 + 1), new TimeSpan(i + 10), i + 100);
                context.ParticipationList.Add(participation);
            }




        }
    }
}

