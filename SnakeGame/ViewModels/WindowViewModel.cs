using System.Threading.Tasks;
using System.Windows;

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

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window">MainWindow of the application</param>
        public WindowViewModel(Window window)
        {
            this.window = window;

            CurrentPage = ApplicationPage.StartPage;
        }
        #endregion
    }
}
