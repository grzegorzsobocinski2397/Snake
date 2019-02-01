using System.ComponentModel;

namespace SnakeGame
{
    /// <summary>
    /// This is the player.
    /// </summary>
    public class Snake : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
        #endregion
        #region Public Properties
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
        public void MoveUp()
        {
            XSpeed = 0;
            YSpeed = -5;
        }
        public void MoveDown()
        {
            XSpeed = 0;
            YSpeed = 5;
        }
        public void MoveRight()
        {
            XSpeed = 5;
            YSpeed = 0;
        }
        public void MoveLeft()
        {
            XSpeed = -5;
            YSpeed = 0;

        }
        public void Stop()
        {
            XSpeed = 0;
            YSpeed = 0;
        }
        #endregion
    }
}
