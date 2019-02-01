
using System.ComponentModel;
using System.Windows;

namespace SnakeGame
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged 
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Call the <see cref="PropertyChanged"/> event if any of the properties has changed.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChangeed(string propertyName)

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseViewModel()
        {

        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Changes the current page of the main window 
        /// </summary>
        public void ChangePage(ApplicationPage page)
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = page;

        }
        #endregion
    }
}
