using System;
using System.ComponentModel;
using GUI.ViewModel.Commands;
using Casino;
using System.Collections.ObjectModel;

namespace GUI.ViewModel
{
    public class ViewModel
    {
        Client clientInAddClientField;
        private ICasinoRepository CasinoRepository;
        ObservableCollection<Client> clients;
        public AddClientCommand AddClientCommand { get; set; }

        public ViewModel()
        {
            CasinoRepository = new CasinoRepository(new WstrzykiwanieStalych());
            AddClientCommand = new AddClientCommand(this);
            //clients = CasinoRepository.GetAllClients();
            
        }

        public void SimpleMethod()
        {
            clients.Add(clientInAddClientField);
            clientInAddClientField = new Client(0, "ClientName", "ClientSurname", new DateTime(0));
        }
    }
}
