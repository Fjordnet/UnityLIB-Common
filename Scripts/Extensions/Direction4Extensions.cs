using Fjord.Common.Types;
using Fjord.Common.Enums;
using UnityEngine;

namespace Fjord.Common.Extensions
{
    static public class Direction4Extensions
    {
        static public int X(this Direction4 direction4)
        {
            switch (direction4)
            {
                case Direction4.Left:
                    return -1;
                case Direction4.Right:
                    return 1;
            }
            return 0;
        }

        static public int Y(this Direction4 direction4)
        {
            switch (direction4)
            {
                case Direction4.Up:
                    return 1;
                case Direction4.Down:
                    return -1;
            }
            return 0;
        }

        static public Vector2Int ToVector2Int(this Direction4 direction4)
        {
            switch(direction4)
            {
                case Direction4.Up:
                    return new Vector2Int(0, 1);
                case Direction4.Down:
                    return new Vector2Int(0, -1);
                case Direction4.Left:
                    return new Vector2Int(-1, 0);
                case Direction4.Right:
                    return new Vector2Int(1, 0);
            }
            return new Vector2Int();
        }
    }
}