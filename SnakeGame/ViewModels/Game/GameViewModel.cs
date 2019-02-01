using System.Timers;
using System.Windows.Input;

namespace SnakeGame
{


    public class GameViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// Red rectangle on the canvas.
        /// </summary>
        public Apple Apple { get; set; }
        /// <summary>
        /// How many apples had user picked up
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// White rectangle on the canvas. This is the player.
        /// </summary>
        public Snake Snake { get; set; }
        /// <summary>
        /// Timer that every x seconds calls a method <see cref="Move(object, ElapsedEventArgs)"/>
        /// </summary>
        public Timer Timer { get; set; }
        /// <summary>
        /// True if user hit wall or himself
        /// </summary>
        public bool IsGameOver { get; set; }
        #endregion
        #region Commands
        /// <summary>
        /// Up key has been pressed and player moves up.
        /// </summary>
        public ICommand UpKeyCommand { get; set; }
        /// <summary>
        /// Down key has been pressed and player moves down.
        /// </summary>
        public ICommand DownKeyCommand { get; set; }
        /// <summary>
        /// Right key has been pressed and player moves to the right.
        /// </summary>
        public ICommand RightKeyCommand { get; set; }
        /// <summary>
        /// Left key has been pressed and player moves to the left.
        /// </summary>
        public ICommand LeftKeyCommand { get; set; }
        /// <summary>
        /// Enter has been pressed and player wants to start again.
        /// </summary>
        public ICommand ResetGameCommand { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameViewModel()
        {
            // Initialize player and apple
            Snake = new Snake();
            Apple = new Apple();

            // Create new timer 
            Timer = new Timer(30);
            Timer.Interval = 30;
            // Invoke Move() after interval time
            Timer.Elapsed += new ElapsedEventHandler(Move);
            Timer.Enabled = true;

            // Create commands
            UpKeyCommand = new RelayCommand(() => Snake.MoveUp());
            DownKeyCommand = new RelayCommand(() => Snake.MoveDown());
            RightKeyCommand = new RelayCommand(() => Snake.MoveRight());
            LeftKeyCommand = new RelayCommand(() => Snake.MoveLeft());
            ResetGameCommand = new RelayCommand(() => ResetGame());
        }
        #endregion


        #region Private Methods
        private void ResetGame()
        {
            Timer.Start();
            Score = 0;
            Snake = new Snake();
            Apple = new Apple();
            IsGameOver = false;

        }
        /// <summary>
        /// Method that is called by the <see cref="Timer"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Move(object source, ElapsedEventArgs e)
        {
            // Move the snake 
            Snake.X += Snake.XSpeed;
            Snake.Y += Snake.YSpeed;

            // If snake hits wall then game is over
            if (Snake.X <= 0 || Snake.X >= 334 || Snake.Y <= 0 || Snake.Y >= 334)
            {
                Snake.Stop();
                IsGameOver = true;
                Timer.Stop();
            }
            // Player eats the apple if he gets close
            if (Snake.X >= Apple.X - 10 && Snake.X <= Apple.X + 10 && Snake.Y >= Apple.Y - 10 && Snake.Y <= Apple.Y + 10)
            {
                Score++;
                Apple.SpawnApple();
            }
            #endregion

        }
    }
}

