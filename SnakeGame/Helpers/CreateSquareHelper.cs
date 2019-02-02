namespace SnakeGame
{
    /// <summary>
    /// Helper class that creates new snake body parts.
    /// </summary>
    public class CreateSquareHelper
    {
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CreateSquareHelper()
        {

        }
        #endregion
        #region Public Methods
        /// <summary>
        /// If there are already body parts than create new based on the localization of the last one. 
        /// </summary>
        /// <param name="previousSquare">Last snake body part</param>
        /// <param name="thisSquare">New body part</param>
        /// <returns></returns>
        public SnakeSquare CreateSquare(SnakeSquare previousSquare, SnakeSquare thisSquare)
        {
            if (previousSquare.CurrentMovement == SnakeMovement.Up)
            {
                thisSquare.ChangeMovement(SnakeMovement.Up);

                thisSquare.Y = previousSquare.Y + 10;
                thisSquare.X = previousSquare.X;
            }
            else if (previousSquare.CurrentMovement == SnakeMovement.Down)
            {
                thisSquare.ChangeMovement(SnakeMovement.Down);

                thisSquare.Y = previousSquare.Y - 10;
                thisSquare.X = previousSquare.X;
            }
            else if (previousSquare.CurrentMovement == SnakeMovement.Right)
            {
                thisSquare.ChangeMovement(SnakeMovement.Right);


                thisSquare.Y = previousSquare.Y;
                thisSquare.X = previousSquare.X - 10;
            }
            else if (previousSquare.CurrentMovement == SnakeMovement.Left)
            {
                thisSquare.ChangeMovement(SnakeMovement.Left);


                thisSquare.Y = previousSquare.Y;
                thisSquare.X = previousSquare.X + 10;
            }
            return thisSquare;
        }
        /// <summary>
        /// If there are no other body parts than create a new one based on the localization of the snake 
        /// </summary>
        /// <param name="snake">Player</param>
        /// <param name="thisSquare">New body part</param>
        /// <returns></returns>
        public SnakeSquare CreateSquare(Snake snake, SnakeSquare thisSquare)
        {
            var previousSquare = new SnakeSquare()
            {
                X = snake.X,
                Y = snake.Y,
                CurrentMovement = snake.CurrentMovement
            };

            return CreateSquare(previousSquare, thisSquare);
        }
        #endregion
    }
}
