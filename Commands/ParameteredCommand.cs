namespace CarbonEmissions.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A class for binding elements of the UI to actions in the ViewModel, where a parameter needs to be passed to a method.
    /// </summary>
    public class ParameteredCommand : ICommand
    {
        private readonly Action<object> _action;
        private bool _canExecute = true;
        public ParameteredCommand(Action<object> action)
        {
            _action = action;
            _canExecute = true;
        }
        public ParameteredCommand(Action<object> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
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
            return _canExecute;
        }

#pragma warning disable 67
        //public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 67
    }
}
