using System.Timers;
using System.Windows.Input;

namespace SnakeGame
{


    public class GameViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// White rectangle on the canvas. This is the player.
        /// </summary>
        public Snake Snake { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Timer Timer { get; set; }
        #endregion
        #region Commands
        public ICommand UpKeyCommand { get; set; }
        public ICommand DownKeyCommand { get; set; }
        public ICommand RightKeyCommand { get; set; }
        public ICommand LeftKeyCommand { get; set; }
        #endregion
        #region Constructor

        #endregion
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameViewModel()
        {
            Snake = new Snake();
            Timer = new Timer(1000);
            Timer.Elapsed += new ElapsedEventHandler(Move);
            Timer.Interval = 100;
            Timer.Enabled = true;

            // Create commands
            UpKeyCommand = new RelayCommand(() => Snake.MoveUp());
            DownKeyCommand = new RelayCommand(() => Snake.MoveDown());
            RightKeyCommand = new RelayCommand(() => Snake.MoveRight());
            LeftKeyCommand = new RelayCommand(() => Snake.MoveLeft());

            StartGame();
        }

        private async void StartGame()
        {


        }
        private void Move(object source, ElapsedEventArgs e)
        {
            X += Snake.XSpeed;
            Y += Snake.YSpeed;
        }
    }
}
