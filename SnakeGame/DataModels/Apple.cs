using System;
using System.ComponentModel;

namespace SnakeGame
{
    public class Apple : INotifyPropertyChanged
    {
        #region Private Members
        private Random random = new Random();

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Public Properties
        /// <summary>
        /// X coordinate position of the apple on the canvas.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y coordinate position of the apple on the canvas.
        /// </summary>
        public int Y { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Apple()
        {
            X = random.Next(1, 334);
            Y = random.Next(1, 334);
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Spawns new apple on the canvas.
        /// </summary>
        public void SpawnApple()
        {
            X = random.Next(1, 334);
            Y = random.Next(1, 334);
        }
        #endregion
    }
}
