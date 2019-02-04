using System.Windows.Controls;
using System.Windows.Input;

namespace SnakeGame 

{
    /// <summary>
    /// Base page for all the pages.
    /// </summary>
    /// <typeparam name="VM">View Model of that page</typeparam>
    public class BasePage<VM> : Page
        where VM: BaseViewModel, new() 
    {
        #region Private Members
        /// <summary>
        /// Page view model.
        /// </summary>
        private VM viewModel;
        #endregion
        #region Public Properties
        /// <summary>
        /// Page view model.
        /// </summary>
        public VM ViewModel
        {
            get
            {
                return viewModel;
            }
            set
            {
                // Checks if anything changed
                if (viewModel == value)
                    return;
                // Update the value if something changed 
                viewModel = value;
                // Set the data context for the page
                this.DataContext = viewModel;
                // Set the keyboard focus on this page 
                this.Loaded += BasePage_Loaded;
            }

        }

        private void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Focusable = true;
            Keyboard.Focus(this);
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BasePage()
        {
            ViewModel = new VM();
        }
        #endregion


    }
}
