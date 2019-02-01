using System;
using System.Windows.Input;

namespace SnakeGame
{
    public class RelayParameterCommand : ICommand
    {
        private Action<object> action;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public RelayParameterCommand(Action<object> action)
        {
            this.action = action;
        }
        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
