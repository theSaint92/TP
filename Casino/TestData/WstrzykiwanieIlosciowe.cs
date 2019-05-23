using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class WstrzykiwanieIlosciowe : IWstrzykiwanieDanych
    {

        private int numberOfClients;
        private int numberOfGames;
        private int numberOfPlayGames;

        public WstrzykiwanieIlosciowe(int clients, int games, int playGames)
        {
            numberOfClients = clients;
            numberOfGames = games;
            numberOfPlayGames = playGames;

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
                for (int j = 0; j < numberOfPlayGames; j++)
                {
                    PlayGame playGame = new PlayGame(i, context.GameList[i], new DateTime((2000 + i / 365), i % 12 + 1, i % 28 + 1), new TimeSpan(i + 20), i + 50, i + 20);
                    context.PlayGameList.Add(playGame);
                }
            }


            //add Participation
            for (int i = 0; i < context.PlayGameList.Count / 2; i++)
            {
                Client client = context.ClientList[i % context.ClientList.Count];
                PlayGame playGame = context.PlayGameList[i];
                Participation participation = new Participation(i + 10, client, playGame, new DateTime((2000 + i / 365) % 5000, i % 12 + 1, i % 28 + 1), new TimeSpan(i + 10), i + 100);
                context.ParticipationList.Add(participation);
            }




        }
    }
}

