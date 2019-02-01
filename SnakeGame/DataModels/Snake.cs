namespace SnakeGame
{
    /// <summary>
    /// This is the player.
    /// </summary>
    public class Snake
    {
        #region Public Properties
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int xspeed;

        public int XSpeed
        {
            get { return xspeed; }
            set { xspeed = value; }
        }
        private int ySpeed;

        public int YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }

        /// <summary>
        /// X coordinate position of the snake on the canvas.
        /// </summary>
        /// <summary>
        /// Y coordinate position of the snake on the canvas.
        /// </summary>
        /// <summary>
        /// How fast does the snake move on the canvas in the X axis.
        /// </summary>
        /// <summary>
        /// How fast does the snake move on the canvas in the X axis.
        /// </summary>
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Snake()
        {
            X = 0;
            Y = 0;
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
        #endregion
    }
}
