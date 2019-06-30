using DatabaseCasinoModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel.Commands
{
    public class CommitChangesCommand : ICommand
    {
        private bool _canExecuteVar;
        public bool CanExecuteVar
        {
            get { return this._canExecuteVar; }
            set
            {
                this._canExecuteVar = value;
                CanExecuteChanged?.Invoke(this, new PropertyChangedEventArgs("CanExecuteVar"));
            }
        }

        public event EventHandler CanExecuteChanged;

        private ViewModel ViewModel { get; set; }

        public CommitChangesCommand(ViewModel v)
        {
            this._canExecuteVar = true;
            this.ViewModel = v;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteVar;
        }

        public void Execute(object parameter)
        {
            updateClients();
        }

        public async void updateClients()
        {

            CanExecuteVar = false;
            ViewModel.WaitingString = "Executing SQL Query...";
            DateTime start = DateTime.Now;

            await Task.Run(() =>
            {
                DatabaseCasinoRepository.ChangeClients(ViewModel.ClientsCollection);
            });

            CanExecuteVar = true;
            DateTime end = DateTime.Now;
            TimeSpan span = end - start;
            ViewModel.WaitingString = "Query executed in " + (int)span.TotalMilliseconds + "ms";

        }
    }
}
