using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fjord.Common.Types;

namespace Fjord.Common.Utilities
{
    static public class GridUtility
    {
        static public Vector2Int GridIndexToCoordinate(int index, int Max)
        {
            return GridIndexToCoordinate(index, Max, Max);
        }

        static public Vector2Int GridIndexToCoordinate(int index, Vector2Int max)
        {
            return GridIndexToCoordinate(index, max.x, max.y);
        }

        static public Vector2Int GridIndexToCoordinate(int index, int xMax, int yMax)
        {
            if (index >= xMax * yMax || index < 0)
            {
                return new Vector2Int(-1, -1);
            }
            Vector2Int coordinate = new Vector2Int();
            coordinate.y = (int)(index / xMax);
            coordinate.x = index % xMax;
            return coordinate;
        }

        static public int CoordinateToGridIndex(Vector2Int coordinate, Vector2Int max)
        {
            return CoordinateToGridIndex(coordinate.x, coordinate.y, max.x, max.y);
        }

        static public int CoordinateToGridIndex(int x, int y, Vector2Int max)
        {
            return CoordinateToGridIndex(x, y, max.x, max.y);
        }

        static public int CoordinateToGridIndex(int x, int y, int xMax, int yMax)
        {
            if (x >= xMax || y >= yMax || x < 0 || y < 0)
            {
                return -1;
            }
            return ((y * xMax) + x);
        }
        
        static public int CoordinateToGridIndex(int x, int y, int Max)
        {
            return CoordinateToGridIndex(x, y, Max, Max);
        }
    }
}