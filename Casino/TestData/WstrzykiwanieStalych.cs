using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class WstrzykiwanieStalych : IWstrzykiwanieDanych
    {
            public void WypelnijCasinoContext(ref CasinoContext context)
            {
                context.ClientList.Add(new Client(0, "Marcin", "Kowalski", new DateTime(1975, 05, 12)));
                context.ClientList.Add(new Client(1, "Aldona", "Milczarek", new DateTime(1982, 03, 25)));
                context.ClientList.Add(new Client(2, "Krystian", "Niewiadomski", new DateTime(1990, 11, 24)));
                context.ClientList.Add(new Client(3, "Aleksander", "Bodziuch", new DateTime(1980, 05, 01)));
                context.ClientList.Add(new Client(4, "Dominika", "Moczulska", new DateTime(1991, 09, 18)));

                Game game1 = new Game(0, "Poker", "Karciana gra psychologiczno-strategiczna. Dostępne dwie odmiany - Texas Holdem i Omaha");
                Game game2 = new Game(1, "Ruletka", "Pseudolosowa gra hazardowa. Dostępne dwa systemy - europejski i amerykański");
                Game game3 = new Game(2, "Blackjack", "Karciana gra, której celem jest uzyskanie sumy najbliższej 21 punktów, nie przekraczając tej liczby.");
                context.GameList.Add(game1.Id, game1);
                context.GameList.Add(game2.Id, game2);
                context.GameList.Add(game3.Id, game3);

                context.PlayGameList.Add(new PlayGame(0, game1, new DateTime(2019, 04, 12, 20, 12, 15), new TimeSpan(2, 15, 28), 50.00, 5.00));
                context.PlayGameList.Add(new PlayGame(1, game1, new DateTime(2019, 05, 01, 19, 20, 30), new TimeSpan(3, 28, 10), 50.00, 5.00));
                context.PlayGameList.Add(new PlayGame(2, game1, new DateTime(2019, 04, 20, 22, 08, 12), new TimeSpan(1, 48, 10), 100.00, 10.00));
                context.PlayGameList.Add(new PlayGame(3, game2, new DateTime(2019, 04, 28, 21, 20, 15), new TimeSpan(5, 30, 30), 100.00, 30.00));
                context.PlayGameList.Add(new PlayGame(4, game2, new DateTime(2019, 05, 05, 20, 19, 14), new TimeSpan(4, 20, 18), 100.00, 5.00));
                context.PlayGameList.Add(new PlayGame(5, game3, new DateTime(2019, 04, 30, 17, 15, 18), new TimeSpan(2, 40, 45), 70.00, 10.00));
                context.PlayGameList.Add(new PlayGame(6, game3, new DateTime(2019, 04, 15, 18, 30, 17), new TimeSpan(3, 40, 14), 70.00, 10.00));

                context.ParticipationList.Add(new Participation(context.ClientList[0], context.PlayGameList[0], new DateTime(2019, 04, 12, 20, 12, 15), new TimeSpan(2, 15, 28), 120.00));
                context.ParticipationList.Add(new Participation(context.ClientList[1], context.PlayGameList[0], new DateTime(2019, 04, 12, 20, 12, 15), new TimeSpan(2, 15, 28), 0.00));
                context.ParticipationList.Add(new Participation(context.ClientList[2], context.PlayGameList[0], new DateTime(2019, 04, 12, 20, 20, 15), new TimeSpan(2, 00, 34), 70.00));
                context.ParticipationList.Add(new Participation(context.ClientList[3], context.PlayGameList[1], new DateTime(2019, 05, 01, 19, 20, 30), new TimeSpan(3, 28, 10), 320.00));
                context.ParticipationList.Add(new Participation(context.ClientList[4], context.PlayGameList[1], new DateTime(2019, 05, 01, 19, 20, 30), new TimeSpan(3, 28, 10), 80.00));
            }
    }
}
