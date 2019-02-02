namespace SnakeGame
{
    public class MoveSquareHelper
    {
        #region Constructor
        public MoveSquareHelper()
        {

        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Move the body part according to the posiiton of the previous square
        /// </summary>
        /// <param name="previousSquare">Square before</param>
        /// <param name="thisSquare">This square</param>
        /// <returns></returns>
        
        public SnakeSquare MoveSquare(SnakeSquare previousSquare, SnakeSquare thisSquare)
        {
            if (previousSquare.CurrentMovement == SnakeMovement.Up)
            {
                thisSquare.ChangeMovement(SnakeMovement.Up);

                thisSquare.Y = previousSquare.Y;
                thisSquare.X = previousSquare.X;
            }
            else if (previousSquare.CurrentMovement == SnakeMovement.Down)
            {
                thisSquare.ChangeMovement(SnakeMovement.Down);

                thisSquare.Y = previousSquare.Y;
                thisSquare.X = previousSquare.X;
            }
            else if (previousSquare.CurrentMovement == SnakeMovement.Right)
            {
                thisSquare.ChangeMovement(SnakeMovement.Right);


                thisSquare.Y = previousSquare.Y;
                thisSquare.X = previousSquare.X;
            }
            else if (previousSquare.CurrentMovement == SnakeMovement.Left)
            {
                thisSquare.ChangeMovement(SnakeMovement.Left);


                thisSquare.Y = previousSquare.Y;
                thisSquare.X = previousSquare.X;
            }
            return thisSquare;

        }
        /// <summary>
        /// If there are no other squares then move the square according to the snake
        /// </summary>
        /// <param name="snake">Player</param>
        /// <param name="thisSquare">This square</param>
        /// <returns></returns>
        public SnakeSquare MoveSquare(Snake snake, SnakeSquare thisSquare)
        {
            var previousSquare = new SnakeSquare()
            {
                X = snake.X - snake.XSpeed,
                Y = snake.Y - snake.YSpeed,
                CurrentMovement = snake.CurrentMovement
            };

            return MoveSquare(previousSquare, thisSquare);
        }
        #endregion
    }
}
