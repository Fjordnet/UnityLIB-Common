using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Fjord.Common.Types
{
    public struct CubicBezierSegment
    {
        public readonly Vector3 Start;
        public readonly Vector3 FirstHandle;
        public readonly Vector3 SecondHandle;
        public readonly Vector3 End;

        public CubicBezierSegment(Vector3 start, Vector3 firstHandle, Vector3 secondHandle, Vector3 end)
        {
            Start = start;
            FirstHandle = firstHandle;
            SecondHandle = secondHandle;
            End = end;
        }

        public Vector3 Point(float t)
        {
            return new Vector3(
                Point(Start.x, FirstHandle.x, SecondHandle.x, End.x, t),
                Point(Start.y, FirstHandle.y, SecondHandle.y, End.y, t),
                Point(Start.z, FirstHandle.z, SecondHandle.z, End.z, t));
        }

        //http://stackoverflow.com/questions/4089443/find-the-tangent-of-a-point-on-a-cubic-bezier-curve-on-an-iphone
        float Point(float a, float b, float c, float d, float t)
        {
            float C1 = (d - (3f * c) + (3f * b) - a);
            float C2 = ((3f * c) - (6f * b) + (3f * a));
            float C3 = ((3f * b) - (3f * a));
            float C4 = (a);
            return (C1 * t * t * t + C2 * t * t + C3 * t + C4);
        }

        float Tangent(float a, float b, float c, float d, float t)
        {
            float C1 = (d - (3f * c) + (3f * b) - a);
            float C2 = ((3f * c) - (6f * b) + (3f * a));
            float C3 = ((3f * b) - (3f * a));
            return (3f * C1 * t * t) + (2f * C2 * t) + C3;
        }

        public Vector3 Tangent(float t)
        {
            float x = Tangent(Start.x, FirstHandle.x, SecondHandle.x, End.x, t);
            float y = Tangent(Start.y, FirstHandle.y, SecondHandle.y, End.y, t);
            float z = Tangent(Start.z, FirstHandle.z, SecondHandle.z, End.z, t);
            return new Vector3(x, y, z).normalized;
        }

        public float Length()
        {
            const float step = .01f;
            float distance = 0;
            Vector3 priorPosition = Start;
            for (float t = 0; t < 1 + step; t += step)
            {
                Vector3 newPosition = Point(t);
                distance += Vector3.Distance(newPosition, priorPosition);
                priorPosition = newPosition;
            }
            return distance;
        }

        /// <summary>
        /// Populates PointList array with equal distance points on curve.
        /// </summary>
        /// <returns>The amount of distance left over past End.</returns>
        /// <param name="start">Distance along curve to start from.</param>
        /// <param name="spacing">Spacing of points.</param>
        /// <param name="pointList">Pointlist to populate.</param>
        public float EquiDistancePoints(float start, float spacing, List<Vertex> vertices, bool addFinal)
        {
            float length = Length();
            float pointCount = length / spacing;
            float step = 1f / pointCount;
            float t = start;
            while (t < 1f)
            {
                Vector3 tangent = Tangent(t);
                Vector3 priorTangent = Tangent(t + (step / 10f)); //this is not really correct
                Vector3 normal = Vector3.Cross(priorTangent, tangent).normalized;
                vertices.Add(new Vertex(Point(t), normal, tangent));
                t += step;
            }
            if (addFinal)
            {
                Vector3 tangent = Tangent(t);
                Vector3 priorTangent = Tangent(1 - (step / 10f)); //this is not really correct
                Vector3 normal = Vector3.Cross(priorTangent, tangent).normalized;
                vertices.Add(new Vertex(Point(1), normal, tangent));
            }
            return t - 1f;
        }

        /// <summary>
        /// Populates PointList array with equal distance points on curve.
        /// </summary>
        /// <returns>The amount of distance left over past End.</returns>
        /// <param name="start">Distance along curve to start from.</param>
        /// <param name="spacing">Spacing of points.</param>
        /// <param name="pointList">Pointlist to populate.</param>
        /// <param name = "upSegment">Segment to point normals at.</param>
        public float EquiDistancePoints(float start, float spacing, List<Vertex> vertices, CubicBezierSegment upSegment, bool addFinal)
        {
            float length = Length();
            float pointCount = length / spacing;
            float step = 1f / pointCount;
            float t = start;
            while (t < 1f)
            {
                Vector3 point = Point(t);
                Vector3 tangent = Tangent(t);
                Vector3 upPoint = upSegment.Point(t);
                vertices.Add(new Vertex(point, (upPoint - point).normalized, tangent));
                t += step;
            }
            if (addFinal)
            {
                Vector3 point = Point(1f);
                Vector3 tangent = Tangent(1f);
                Vector3 upPoint = upSegment.Point(1f);
                vertices.Add(new Vertex(point, (upPoint - point).normalized, tangent));
            }
            return t - 1f;
        }
    }
}