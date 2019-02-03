using System.Linq;
using System.Timers;
using System.Windows.Input;
namespace SnakeGame
{
    
    public class GameViewModel : BaseViewModel
    {
        #region Helpers Members
        /// <summary>
        /// Helper class that creates the body parts.
        /// </summary>
        private readonly CreateSquareHelper create = new CreateSquareHelper();
        /// <summary>
        /// Helper class that moves the body parts.
        /// </summary>
        private MoveSquareHelper move = new MoveSquareHelper();
        #endregion
        #region Public Properties
        public AsyncObservableCollection<SnakeSquare> SnakeBodyParts { get; set; }
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

            // Initialize collection
            SnakeBodyParts = new AsyncObservableCollection<SnakeSquare>();

            // Create new timer 
            Timer = new Timer(100);
            Timer.Interval = 100;
            // Invoke Move() after interval time
            Timer.Elapsed += new ElapsedEventHandler(CheckMove);
            Timer.Enabled = true;

            // Create commands
            UpKeyCommand = new RelayCommand(() => Snake.ChangeMovement(SnakeMovement.Up));
            DownKeyCommand = new RelayCommand(() => Snake.ChangeMovement(SnakeMovement.Down));
            RightKeyCommand = new RelayCommand(() => Snake.ChangeMovement(SnakeMovement.Right));
            LeftKeyCommand = new RelayCommand(() => Snake.ChangeMovement(SnakeMovement.Left));
            ResetGameCommand = new RelayCommand(() => ResetGame());
        }
        #endregion


        #region Private Methods
        /// <summary>
        /// Method that is called by the <see cref="Timer"/>
        /// Check for collisions and then continue with the moves.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void CheckMove(object source, ElapsedEventArgs e)
        {
            // If snake hits wall then game is over 
            if (Snake.X + Snake.XSpeed < 0 ||
                Snake.X + Snake.XSpeed > 260 ||
                Snake.Y + Snake.YSpeed < 0 ||
                Snake.Y + Snake.YSpeed > 260)
                GameOver();
            else
                Check();

            // If snake hits himself then game is over 
            for (int i = Score - 1; i >= 0; i--)
            {
                if (Snake.X + Snake.XSpeed > SnakeBodyParts[i].X - 10 &&
                    Snake.X + Snake.XSpeed < SnakeBodyParts[i].X + 10 &&
                    Snake.Y + Snake.YSpeed > SnakeBodyParts[i].Y - 10 &&
                    Snake.Y + Snake.YSpeed < SnakeBodyParts[i].Y + 10)
                    GameOver();
            }
        }

       
        private void Check()
        {
            // Move the snake 
            Snake.X += Snake.XSpeed;
            Snake.Y += Snake.YSpeed;
            
            // Moves the body parts of a snake. 
            for (int i = Score - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    SnakeBodyParts[i] = move.MoveSquare(Snake, SnakeBodyParts[i]);
                }
                else
                {
                    SnakeBodyParts[i] = move.MoveSquare(SnakeBodyParts[i - 1], SnakeBodyParts[i]);
                }
            }
            
            // Player eats the apple if he gets close
            if (Snake.X > Apple.X - 10 && Snake.X < Apple.X + 10 && Snake.Y > Apple.Y - 10 && Snake.Y < Apple.Y + 10)
            {
                // Creates new body part
                SnakeSquare square = new SnakeSquare();
                
                if (Score == 0)
                {
                    square = create.CreateSquare(Snake, square);

                    SnakeBodyParts.Add(square);
                }
                else
                {
                    // Search for last snake body part 
                    var lastBodyPart = SnakeBodyParts.ElementAt(Score - 1);

                    square = create.CreateSquare(SnakeBodyParts[Score - 1], square);

                    SnakeBodyParts.Add(square);
                }
                Score++;

                // Create new apple 
                Apple.SpawnApple();

            }
           

        }
        /// <summary>
        /// Changes the values to default
        /// </summary>
        private void ResetGame()
        {
            Timer.Start();
            Score = 0;
            Snake = new Snake();
            Apple = new Apple();
            IsGameOver = false;
            SnakeBodyParts.Clear();
        }
        /// <summary>
        /// Stops the snake movement and timer
        /// </summary>
        private void GameOver()
        {
            Snake.ChangeMovement(SnakeMovement.Stop);
            IsGameOver = true;
            Timer.Stop();
        }
        #endregion
    }
}

