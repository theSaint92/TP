using System;
using WarstwaUslug;

namespace TestData
{
    public class WstrzykiwanieDanych : IWstrzykiwanieDanych
    {
        public void WypelnijCasinoDataBaseContext(ref DataBaseDataContext context)
        {
            Clients client0 = new Clients()
            {
                Id = 0,
                Name = "Marcin",
                Surname = "Rogalski",
                DataOfBirth = new DateTime(1991, 2, 12)
            };

            Clients client1 = new Clients()
            {
                Id = 1,
                Name = "Malwina",
                Surname = "Niewiadomska",
                DataOfBirth = new DateTime(1992, 4, 16)
            };

            Clients client2 = new Clients()
            {
                Id = 2,
                Name = "Tomasz",
                Surname = "Kowalski",
                DataOfBirth = new DateTime(1984, 3, 8)
            };


            Games game0 = new Games()
            {
                Id = 0,
                GameName = "Poker",
                GameDescription = "Karciana gra psychologiczno-strategiczna. Dostępne dwie odmiany - Texas Holdem i Omaha",
            };


            Games game1 = new Games()
            {
                Id = 0,
                GameName = "Ruletka",
                GameDescription = "Pseudolosowa gra hazardowa. Dostępne dwa systemy - europejski i amerykański",
            };

        }


    }
}
