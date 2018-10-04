using Fjord.Common.Extensions;
using UnityEngine;

namespace Fjord.Common.Types
{
    public class OrientedBounds
    {
        [SerializeField]
        private Vector3 _center;

        [SerializeField]
        private Vector3 _extents;

        [SerializeField]
        private Quaternion _orientation;

        private Matrix4x4 _matrix4X4;

        public Vector3 Center
        {
            get { return _center; }
            set
            {
                _center = value;
                _matrix4X4.SetTRS(_center, _orientation, Vector3.one);
            }
        }

        public Vector3 Size
        {
            get { return _extents * 2f; }
        }
        
        public Vector3 Extents
        {
            get { return _extents; }
        }

        public Quaternion Orientation
        {
            get { return _orientation; }
        }
        
        public Vector3 GlobalMin
        {
            get
            {
                return  _matrix4X4.MultiplyPoint(-_extents);
            }
        }
        
        public Vector3 GlobalMax
        {
            get
            {
                return  _matrix4X4.MultiplyPoint(_extents);
            }
        }

        public OrientedBounds()
        {
            _center = Vector3.zero;
            _extents = Vector3.zero;
            _orientation = Quaternion.identity;
            _matrix4X4 = Matrix4x4.identity;
        }

        public OrientedBounds(Vector3 center, Vector3 extents, Quaternion orientation)
        {
            _center = center;
            _extents = extents;
            _orientation = orientation;
            _matrix4X4 = Matrix4x4.identity;
            _matrix4X4.SetTRS(_center, _orientation, Vector3.one);
        }

        public void Encapsulate(Vector3 point)
        {
            Vector3 localPoint = Matrix4x4.Inverse(_matrix4X4).MultiplyPoint(point);
            SetMinMax(Vector3.Min(-_extents, localPoint), Vector3.Max(_extents, localPoint));
        }
        
        public void Encapsulate(OrientedBounds bounds)
        {
            Encapsulate(bounds.GlobalMax);
            Encapsulate(bounds.GlobalMin);
        }
        
        private void SetMinMax(Vector3 localMin, Vector3 localMax)
        {
            Vector3 globalMin = _matrix4X4.MultiplyPoint(localMin);
            Vector3 globalMax = _matrix4X4.MultiplyPoint(localMax);
            
            _extents = (localMax - localMin) * .5f;
            _center = (globalMax + globalMin) / 2f;
            
            _matrix4X4.SetTRS(_center, _orientation, Vector3.one);
        }
    }
}