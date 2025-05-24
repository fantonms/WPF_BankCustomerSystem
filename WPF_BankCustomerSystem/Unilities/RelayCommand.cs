using System;
using System.Windows.Input;

namespace WPF_BankCustomerSystem.Unilities
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private readonly Action<object> execute;

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
