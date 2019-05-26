using System;
using System.ComponentModel;
using GUI.ViewModel.Commands;
using Casino;

namespace GUI.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ICasinoRepository CasinoRepository;
        public AddClientCommand AddClientCommand { get; set; }

        public ViewModel()
        {
            CasinoRepository = new CasinoRepository(new WstrzykiwanieStalych());
            AddClientCommand = new AddClientCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SimpleMethod()
        {
            Console.WriteLine("does it work?");
        }
    }
}
