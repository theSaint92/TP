using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel.Commands
{
    public class CommitChangesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ViewModel ViewModel { get; set; }

        public CommitChangesCommand(ViewModel v)
        {
            this.ViewModel = v;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
