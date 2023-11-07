using System;
using System.Windows.Input;

namespace CastleLegacy.ViewModel
{
    public class RelayCommand : ICommand
    {

        //Fields
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExcecute;

        //Constructors 
        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
            _canExcecute = null;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExcecute)
        {
            _execute = execute;
            _canExcecute = canExcecute;
        }

        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        //Methods
        public bool CanExecute(object parameter)
        {
            return _canExcecute==null || _canExcecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
