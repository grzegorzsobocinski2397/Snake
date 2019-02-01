using System.Windows.Input;

namespace SnakeGame
{
    public class StartGameViewModel : BaseViewModel
    {
        #region Commands
        /// <summary>
        /// Executed after used pressed ENTER. Changes the page to <see cref="BoardPage"/>
        /// </summary>
        public ICommand StartGameCommand { get; set; }
        #endregion
        #region Constructor
        public StartGameViewModel()
        {
            // Creates commands
            StartGameCommand = new RelayCommand(() => ChangePage(ApplicationPage.GamePage));
        }
        #endregion
        
    }
}
