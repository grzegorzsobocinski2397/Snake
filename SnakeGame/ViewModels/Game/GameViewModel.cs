using System.Linq;
using System.Timers;
using System.Windows.Input;
namespace SnakeGame
{

    public class GameViewModel : BaseViewModel
    {
        #region Helper Classes
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
        /// <summary>
        /// Asynchronous Observable Collection of snake body parts. 
        /// </summary>
        public AsyncObservableCollection<SnakeSquare> SnakeBodyParts { get; set; }
        /// <summary>
        /// Red rectangle on the canvas.
        /// </summary>
        public Apple Apple { get; set; }
        /// <summary>
        /// How many apples had user picked up.
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
        /// True if user hit wall or himself.
        /// </summary>
        public bool IsGameOver { get; set; }
        /// <summary>
        /// True if the game is paused.
        /// </summary>
        public bool IsGamePaused { get; set; }
        #endregion
        #region Commands
        /// <summary>
        /// Arrow key has been pressed and player moves into a different direction.
        /// </summary>
        public ICommand KeyPressedCommand { get; set; }
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

            // Invoke Move() after interval time
            Timer.Elapsed += new ElapsedEventHandler(CheckMove);
            Timer.Enabled = true;

            // Create command
            KeyPressedCommand = new RelayParameterCommand((parameter) => KeyPressed(parameter));
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Do something based on the key pressed by the user.
        /// </summary>
        /// <param name="parameter">String informing of the key pressed</param>
        private void KeyPressed(object parameter)
        {
            var key = (string)parameter;
            switch (key)
            {
                case "Up":
                    Snake.ChangeMovement(SnakeMovement.Up);
                    break;
                case "Down":
                    Snake.ChangeMovement(SnakeMovement.Down);
                    break;
                case "Right":
                    Snake.ChangeMovement(SnakeMovement.Right);
                    break;
                case "Left":
                    Snake.ChangeMovement(SnakeMovement.Left);
                    break;
                case "Pause":
                    PauseGame();
                    break;
                case "Reset":
                    ResetGame();
                    break;
            }

        }
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


            // If snake hits himself then game is over 
            for (int i = Score - 1; i >= 0; i--)
            {
                if (Snake.X + Snake.XSpeed == SnakeBodyParts[i].X &&
                    Snake.X + Snake.XSpeed == SnakeBodyParts[i].X &&
                    Snake.Y + Snake.YSpeed == SnakeBodyParts[i].Y &&
                    Snake.Y + Snake.YSpeed == SnakeBodyParts[i].Y)
                    GameOver();
            }

            Check();
        }

        /// <summary>
        /// If user didn't hit anything than he and his body parts can move
        /// </summary>
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
            if (Snake.X > Apple.X - 10 &&
                Snake.X < Apple.X + 10 &&
                Snake.Y > Apple.Y - 10 &&
                Snake.Y < Apple.Y + 10)
            {
                // Creates new body part
                SnakeSquare square = new SnakeSquare();

                // If this is the first body part to be created then use snake's coordinates 
                if (Score == 0)
                {
                    square = create.CreateSquare(Snake, square);

                    SnakeBodyParts.Add(square);
                }
                // else use last snake body part 
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
            SnakeBodyParts.Clear();
            Snake = new Snake();
            Apple = new Apple();
            Score = 0;
            Timer.Start();
            IsGameOver = false;
        }
        /// <summary>
        /// Stops the snake movement and timer
        /// </summary>
        private void GameOver()
        {
            Snake.ChangeMovement(SnakeMovement.Stop);
            Timer.Stop();
            IsGameOver = true;
        }
        /// <summary>
        /// Pauses/unpauses the game.
        /// </summary>
        private void PauseGame()
        {
            // User can't pause/unpause if he already lost 
            if (IsGameOver == false)
            {
                // Pause/unpause
                if (IsGamePaused)
                {
                    IsGamePaused = false;
                    Timer.Start();
                }
                else
                {
                    IsGamePaused = true;
                    Timer.Stop();
                }
            }

        }
        #endregion
    }
}

