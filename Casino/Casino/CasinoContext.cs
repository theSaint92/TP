using System;
using System.Collections.Generic; //List & Dictionary
using System.Collections.ObjectModel; //ObservableCollection
using System.Collections.Specialized;

namespace Casino
{
    public class CasinoContext //DataContext
    {
        public List<Client> ClientList;
        public Dictionary<int, Game> GameList;
        public ObservableCollection<PlayGame> PlayGameList;
        public ObservableCollection<Participation> ParticipationList;

        public CasinoContext()
        {
            ClientList = new List<Client>();
            GameList = new Dictionary<int, Game>();
            PlayGameList = new ObservableCollection<PlayGame>();
            ParticipationList = new ObservableCollection<Participation>();

            //Adding subscribers
            PlayGameList.CollectionChanged += this.OnPlayGameCollectionChanged;
            ParticipationList.CollectionChanged += this.OnParticipationCollectionChanged;
        }

        /**
         * Subscriber to PlayGameList OnCollectionChanged
         */ 
        public void OnPlayGameCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach(PlayGame p in e.NewItems)
                    Console.WriteLine("Added PlayGame element with id " + p.Id + " into DataContext.");
                
            if (e.Action == NotifyCollectionChangedAction.Remove)
                foreach (PlayGame p in e.OldItems)
                    Console.WriteLine("Removed PlayGame element with id " + p.Id + " from DataContext.");
        }

        /**
         * Subscriber to ParticipationList OnCollectionChanged
         */
        public void OnParticipationCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (Participation p in e.NewItems)
                    Console.WriteLine("Added Participation element with id " + p.Id + " into DataContext.");

            if (e.Action == NotifyCollectionChangedAction.Remove)
                foreach (Participation p in e.OldItems)
                    Console.WriteLine("Removed Participation element with id " + p.Id + " from DataContext.");
        }
    }
}
