using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnakeGame
{
    public class RelayCommand : ICommand
    {
        private Action action;
        /// <summary>
        /// Sender parameter is the instance of the object which raised the event.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #region Constructor
        public RelayCommand(Action action)
        {
            this.action = action;
        }
        #endregion

        /// <summary>
        /// Command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
