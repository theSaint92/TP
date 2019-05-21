using System;
using System.Collections.ObjectModel; //ObservableCollection

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    interface ICasinoService //IDataService
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
        int AddPlayGame( int gameId, DateTime startTime, TimeSpan duration, double minimumDeposit, double entryFee);
        void AddParticipation(int clientId, int playGameId, DateTime startTime, TimeSpan duration, double profit);

        /**
         * Changeing client data in case we need. Maybe he changed name, surname or gender... dunno bro
         */ 
        void ChangeClientData(int client, string newName, string newSurname, DateTime dateOfBirth);

        /**
         * Returning list of participations of specified player
         */ 
        List<Participation> SelectClientParticipations(int client);

        /**
         * Returning list of PlayGames for selected game.
         */ 
        List<PlayGame> SelectGamePlayGames(int gameId);

        /**
         * Returing most profitable game from Casino point of view.
         */
        Game SelectMostProfitableGame();
        
        /**
         * Returing least profitable game from Casino point of view.
         */
        Game SelectLeastProfitableGame();
        
        /**
         * Selecting Games that client played.
         */
        List<Game> SelectClientGames(int client);
        
        /**
         * Selecting PlayGames that client participated in.
         */
        List<PlayGame> SelectClientPlayGames(int client);
    }
}
