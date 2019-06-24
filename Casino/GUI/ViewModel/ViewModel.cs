using System;
using System.ComponentModel;
using GUI.ViewModel.Commands;
using Casino;
using System.Collections.ObjectModel;

namespace GUI.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _nameToAdd;
        private string _surnameToAdd;
        private DateTime _dateOfBirthToAdd;
        private int currentID = 5;

        public string NameToAdd
        {
            get { return this._nameToAdd; }
            set
            {
                this._nameToAdd = value;
                OnPropertyChanged("AddClientName");
            }
        }

        public string SurnameToAdd
        {
            get { return this._surnameToAdd; }
            set
            {
                this._surnameToAdd = value;
                OnPropertyChanged("AddClientSurname");
            }
        }

        public DateTime DateOfBirthToAdd
        {
            get { return this._dateOfBirthToAdd; }
            set
            {
                this._dateOfBirthToAdd = value;
                OnPropertyChanged("AddClientDateOfBirth");
            }
        }

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
            AddClientCommandButton = new AddClientCommand(this);
            Console.WriteLine("Clients count: " + Clients.Count);
        }

        public void SimpleMethod()
        {
            Clients.Add(new Client(currentID,NameToAdd,SurnameToAdd,DateOfBirthToAdd));
            currentID++;
            NameToAdd = "";
            SurnameToAdd = "";
            DateOfBirthToAdd = new DateTime();
        }

        public void OnPropertyChanged(string param)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(param));
            }
        }
    }
}
