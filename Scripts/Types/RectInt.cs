using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Types
{
    /// <summary>
    /// Rect with int fields.
    /// </summary>
    [System.Serializable]
    public struct RectInt
    {
        private int _xMin;
        private int _yMin;
        private int _width;
        private int _height;

        public int X
        {
            get
            {
                return _xMin;
            }
            set
            {
                _xMin = value;
            }
        }

        public int Y
        {
            get
            {
                return this._yMin;
            }
            set
            {
                this._yMin = value;
            }
        }

        public Vector2Int Position
        {
            get
            {
                return new Vector2Int(_xMin, _yMin);
            }
            set
            {
                _xMin = value.x;               
                _yMin = value.y;
            }
        }

        public Vector2Int Center
        {
            get
            {
                return new Vector2Int(_xMin + _width / 2, _yMin + _height / 2);
            }
            set
            {
                _xMin = value.x - _width / 2;
                _yMin = value.y - _height / 2;
            }
        }

        public Vector2Int Min
        {
            get
            {
                return new Vector2Int(XMin, YMin);
            }
            set
            {
                XMin = value.x;
                YMin = value.y;
            }
        }

        public Vector2Int Max
        {
            get
            {
                return new Vector2Int(XMax, YMax);
            }
            set
            {
                XMax = value.x;
                YMax = value.y;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public Vector2Int Size
        {
            get
            {
                return new Vector2Int(_width, _height);
            }
            set
            {
                _width = value.x;
                _height = value.y;
            }
        }

        public int XMin
        {
            get
            {
                return _xMin;
            }
            set
            {
                int xMax = XMax;
                _xMin = value;
                _width = xMax - _xMin;
            }
        }

        public int YMin
        {
            get
            {
                return _yMin;
            }
            set
            {
                int yMax = YMax;
                _yMin = value;
                _height = yMax - _yMin;
            }
        }

        public int XMax
        {
            get
            {
                return _width + _xMin;
            }
            set
            {
                _width = value - _xMin;
            }
        }

        public int YMax
        {
            get
            {
                return _height + _yMin;
            }
            set
            {
                _height = value - _yMin;
            }
        }

        public override string ToString()
        {
            return string.Format("(x:{0:F2}, y:{1:F2}, width:{2:F2}, height:{3:F2})", new object[]
            {
                X,
                X,
                Width,
                Height
            });
        }
    }
}