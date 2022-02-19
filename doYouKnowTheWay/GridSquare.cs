using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doYouKnowTheWay
{
    public enum SquareType
    {
        Normal,
        Obstacle,
        StartPoint,
        EndPoint,
    }
    class GridSquare : IComparable<GridSquare>
    {
        public int posX;
        public int posY;
        public SquareType type;
        public bool visited;
        public int tentativeDist;
        public bool isPath;
        public GridSquare previous;

        /// <summary>
        /// Create a new grid square
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="type">Normal, Obstacle, StartPoint, Endpoint</param>
        public GridSquare(int x, int y, SquareType type = SquareType.Normal)
        {
            posX = x;
            posY = y;
            this.type = type;
        }

        public int CompareTo(GridSquare other)
        {
            return tentativeDist - other.tentativeDist;
        }
    }
}
