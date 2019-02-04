using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SnakeGame
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// Window of the application 
        /// </summary>
        private Window window;
        #endregion
        #region Public Properties
        /// <summary>
        /// Currently displayed page in the main window
        /// </summary>
        public ApplicationPage CurrentPage { get; set; }
        #endregion
        #region Commands
        /// <summary>
        /// Closes the application
        /// </summary>
        public ICommand CloseCommand { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window">MainWindow of the application</param>
        public WindowViewModel(Window window)
        {
            this.window = window;

            CurrentPage = ApplicationPage.StartPage;

            // Creates commands
            CloseCommand = new RelayCommand(() => window.Close());
        }
        #endregion
    }
}
