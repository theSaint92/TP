using System;
using System.ComponentModel;
using GUI.ViewModel.Commands;
using Casino;
using System.Collections.ObjectModel;

namespace GUI.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public Client _clientToAdd;
        public Client ClientToAdd
        {
            get { return this._clientToAdd; }
            set
            {
                this._clientToAdd = value;
                OnPropertyChanged("ClientToAdd");
            }
        }
        private int currentID;


        private ICasinoRepository CasinoRepository;
        

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return this._clients; }
            set
            {
                this._clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public AddClientCommand AddClientCommandButton { get; set; }

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
            CasinoRepository = new CasinoRepository(new WstrzykiwanieStalych());
            Clients = new ObservableCollection<Client>(CasinoRepository.GetAllClients());
            currentID = 0;
            foreach (Client c in Clients) {
                if (c.Id >= currentID) currentID = c.Id + 1;
            }
            ClientToAdd = new Client(currentID, "", "", new DateTime(1990,1,1));
            AddClientCommandButton = new AddClientCommand(this);
            Console.WriteLine("Clients count: " + Clients.Count);
        }

        public void SimpleMethod()
        {
            Clients.Add(ClientToAdd);
            ClientToAdd = new Client(++currentID, "", "", new DateTime(1990, 1, 1));
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
