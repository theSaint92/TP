using System;
using System.ComponentModel;
using GUI.ViewModel.Commands;
using Casino;
using System.Collections.ObjectModel;

namespace GUI.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        Client clientInAddClientField;
        private ICasinoRepository CasinoRepository;
        public ObservableCollection<Client> _clients;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Client> Clients
        {
            get { return this._clients; }
            set
            {
                this._clients = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Clients"));
                }
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
            AddClientCommandButton = new AddClientCommand(this);
            Console.WriteLine("Clients count: " + Clients.Count);
        }

        public void SimpleMethod()
        {
            Clients.Add(clientInAddClientField);
            clientInAddClientField = new Client(0, "ClientName", "ClientSurname", new DateTime(0));
        }
    }
}
