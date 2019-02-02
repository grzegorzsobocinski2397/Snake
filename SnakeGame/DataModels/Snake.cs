using System.ComponentModel;

namespace SnakeGame
{
    /// <summary>
    /// This is the player.
    /// </summary>
    public class Snake : INotifyPropertyChanged
    {

        #region Private Members
        /// <summary>
        /// X coordinate position of the snake on the canvas.
        /// </summary>
        private int x;
        /// <summary>
        /// Y coordinate position of the snake on the canvas.
        /// </summary>
        private int y;
        /// <summary>
        /// How fast does the snake move on the canvas in the X axis.
        /// </summary>
        private int xspeed;
        /// <summary>
        /// How fast does the snake move on the canvas in the X axis.
        /// </summary>
        private int ySpeed;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Public Properties
        public SnakeMovement CurrentMovement { get; set; }
        /// <summary>
        /// X coordinate position of the snake on the canvas.
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        /// <summary>
        /// Y coordinate position of the snake on the canvas.
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        /// <summary>
        /// How fast does the snake move on the canvas in the X axis.
        /// </summary>
        public int XSpeed
        {
            get { return xspeed; }
            set { xspeed = value; }
        }
        /// <summary>
        /// How fast does the snake move on the canvas in the Y axis.
        /// </summary>
        public int YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }
       
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Snake()
        {
            X = 200;
            Y = 40;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Changes the direction of the snake.
        /// </summary>
        /// <param name="movement"></param>
        public void ChangeMovement(SnakeMovement movement)
        {
            
            switch (movement)
            {
                case SnakeMovement.Up:
                    if (CurrentMovement != SnakeMovement.Down && CurrentMovement != SnakeMovement.Up)
                    {
                        XSpeed = 0;
                        YSpeed = -10;
                    }
                    break;
                case SnakeMovement.Down:
                    if (CurrentMovement != SnakeMovement.Down && CurrentMovement != SnakeMovement.Up)
                    {

                        XSpeed = 0;
                        YSpeed = 10;
                    }
                    break;
                case SnakeMovement.Right:
                    if (CurrentMovement != SnakeMovement.Right && CurrentMovement != SnakeMovement.Left)
                    {
                        XSpeed = 10;
                        YSpeed = 0;
                    }
                    break;
                case SnakeMovement.Left:
                    if (CurrentMovement != SnakeMovement.Right && CurrentMovement != SnakeMovement.Left)
                    {
                        XSpeed = -10;
                        YSpeed = 0;
                    } 
                    break;
                case SnakeMovement.Stop:
                    XSpeed = 0;
                    YSpeed = 0;
                    break;
            }
            CurrentMovement = movement;

        }

        #endregion
    }
}
