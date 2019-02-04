using System;
using System.ComponentModel;

namespace SnakeGame
{
    /// <summary>
    /// Red dot on the canvas. 
    /// </summary>
    public class Apple : INotifyPropertyChanged
    {
        #region Private Members
        private Random random = new Random();
        private int[] XAxis = new int[27];
        private int[] YAxis = new int[27];
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
            // Populates the arrays 
            for (int i = 1; i < 27; i++)
            {
                XAxis[i] = i * 10;
                YAxis[i] = i * 10;
            }
            // Spawns new apple 
            SpawnApple();
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Spawns new apple on the canvas.
        /// </summary>
        public void SpawnApple()
        {
            X = XAxis[random.Next(0, 27)];
            Y = YAxis[random.Next(0, 27)];
        }
        #endregion
    }
}
