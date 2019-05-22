using System;
using System.Collections.ObjectModel; //ObservableCollection

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public interface ICasinoService //IDataService
    {

        /**
         * Functions returning DataContext elements as string.
         */ 
        string ClientsToString();
        string GamesToString();
        string PlayGamesToString();
        string ParticipationsToString();

        /**
         * Function returning whole repository as a pretty string
         */
        string RepositoryToString();

        /**
         * Adding elements to repository
         */ 
        int AddClient( string name , string surname , DateTime dateOfBirth );
        int AddGame( string gameName , string gameDescription );
        int AddPlayGame( Game game, DateTime startTime, TimeSpan duration, double minimumDeposit, double entryFee);
        int AddParticipation(Client participator, PlayGame playedGame, DateTime startTime, TimeSpan duration, double profit);

        /**
         * Changeing client data in case we need. Maybe he changed name, surname or gender... dunno bro
         */ 
        void ChangeClientData(int client, string newName, string newSurname, DateTime dateOfBirth);

        /**
         * Returning list of participations of specified player
         */ 
        IEnumerable<Participation> SelectClientParticipations(Client client);

        /**
         * Returning list of PlayGames for selected game.
         */
        IEnumerable<PlayGame> SelectGamePlayGames(Game game);

        /**
         * Selecting Games that client played.
         */
        IEnumerable<Game> SelectClientGames(Client client);

        /**
         * Selecting PlayGames that client participated in.
         */
        IEnumerable<PlayGame> SelectClientPlayGames(Client client);

        /**
         * Returing most profitable game from Casino point of view.
         */
        Game SelectMostProfitableGame();
        
        /**
         * Returing least profitable game from Casino point of view.
         */
        Game SelectLeastProfitableGame();

    }
}
