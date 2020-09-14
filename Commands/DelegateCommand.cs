namespace CarbonEmissions.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A class for binding elements of the UI to actions in the ViewModel
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event System.EventHandler CanExecuteChanged
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

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        //public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 67
    }
}
