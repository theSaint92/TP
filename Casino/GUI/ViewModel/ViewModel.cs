﻿using System;
using System.ComponentModel;
using GUI.ViewModel.Commands;
using System.Collections.ObjectModel;
using DatabaseCasinoModel;

namespace GUI.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public Clients _clientToAdd;
        public Clients ClientToAdd
        {
            get { return this._clientToAdd; }
            set
            {
                this._clientToAdd = value;
                OnPropertyChanged("ClientToAdd");
            }
        }
        public int currentID;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Clients> _clientsCollection;
        public ObservableCollection<Clients> ClientsCollection
        {
            get { return this._clientsCollection; }
            set
            {
                this._clientsCollection = value;
                OnPropertyChanged("Clients");
            }
        }
        public AddClientCommand AddClientCommandButton { get; set; }
        public CommitChangesCommand CommitChangesCommandButton { get; set; }

        private string _waitingString;
        public string WaitingString
        {
            get { return this._waitingString; }
            set
            {
                this._waitingString = value;
                OnPropertyChanged("WaitingString");
            }
        }

        // TODO : Uncomment this later
        //public ViewModel(ICasinoRepository casinoRepository)
        //{
        //    CasinoRepository = casinoRepository;
        //    AddClientCommand = new AddClientCommand(this);
        //    //clients = CasinoRepository.GetAllClients();
        //    
        //}

        public ViewModel()
        {
            DatabaseCasinoRepository.Context = new CasinoDataContext();
            ClientsCollection = DatabaseCasinoRepository.GetAllClients();

            currentID = 0;
            foreach (Clients c in ClientsCollection) {
                if (c.Id >= currentID) currentID = c.Id + 1;
            }
            ClientToAdd = new Clients
            {
                Id = currentID++,
                DateOfBirth = new DateTime(1990, 1, 1)
            };
            AddClientCommandButton = new AddClientCommand(this);
            CommitChangesCommandButton = new CommitChangesCommand(this);

            Console.WriteLine("Clients count: " + ClientsCollection.Count);
        }

        public void OnPropertyChanged(string param)
        {
            /** 
             * Ten kod oznacza dokładnie to samo co to:
             * 
             *   if (PropertyChanged != null)
             *   {
             *       PropertyChanged(this, new PropertyChangedEventArgs(param));
             *   }
             */
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
        }
    }
}
