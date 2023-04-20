using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel.ExtensionMethods
{
    /// <summary>
    /// Extension Methods used on Vector2.
    /// </summary>
    public static class Vector2Extensions
    {
        /// <summary>
        /// Set x and/or y to any value.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="x">Value to set x to. (Optional)</param>
        /// <param name="y">Value to set y to. (Optional)</param>
        /// <returns>Vector2 with changed values.</returns>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(x ?? vector.x, y ?? vector.y);

        /// <summary>
        /// Add any value to x and/or y.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to add to x. (Optional)</param>
        /// <param name="y">Value to add to y. (Optional)</param>
        /// <returns>Vector2 with added values.</returns>
        public static Vector2 Add(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(vector.x + x ?? vector.x, vector.y + y ?? vector.y);

        /// <summary>
        /// Add two vectors together.
        /// </summary>
        public static Vector2 Add(this Vector2 vector, Vector2 addedVector) =>
            vector + addedVector;

        /// <summary>
        /// Subtract any value from x and/or y.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <returns>Vector2 with subtracted values.</returns>
        public static Vector2 Subtract(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(vector.x - x ?? vector.x, vector.y - y ?? vector.y);

        /// <summary>
        /// Subtract any value from x and/or y.
        /// </summary>
        public static Vector2 Subtract(this Vector2 vector, Vector2 subtractedVector) =>
            vector - subtractedVector;

        /// <summary>
        /// Multiplied any value with x and/or y.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to multiply with x. (Optional)</param>
        /// <param name="y">Value to multiply with y. (Optional)</param>
        /// <returns>Vector2 with multiplied values.</returns>
        public static Vector2 Multiply(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(vector.x * x ?? vector.x, vector.y * y ?? vector.y);

        /// <summary>
        /// Divide any value with x and/or y.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to divide with x. (Optional)</param>
        /// <param name="y">Value to divide with y. (Optional)</param>
        /// <returns>Vector2 with divided values.</returns>
        public static Vector2 Divide(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(vector.x / x ?? vector.x, vector.y / y ?? vector.y);

        /// <summary>
        /// Flatten the vector to a given value on the y axis.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="flatLevel">Value to set y to. (Default = 0)</param>
        /// <returns>Vector2 with y set to 0 or set flat level.</returns>
        public static Vector2 Flat(this Vector2 vector, float flatLevel = 0f) =>
            new Vector2(vector.x, flatLevel);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Vector.</param>
        /// <param name="destination">Vector to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector2.</returns>
        public static Vector2 DirectionTo(this Vector2 source, Vector2 destination) =>
            Vector3.Normalize(destination - source);

        /// <summary>
        /// Rounds each axis of the vector to a whole number.
        /// </summary>
        public static Vector2 Round(this Vector2 vector)
        {
            vector.x = Mathf.Round(vector.x);
            vector.y = Mathf.Round(vector.y);
            return vector;
        }

        /// <summary>
        /// Rounds each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector2 Round(this Vector2 vector, float multiple) =>
            (vector / multiple).Round() * multiple;

        /// <summary>
        /// Rounds each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector2 Round(this Vector2 vector, Vector2 multiple) =>
            (vector / multiple).Round() * multiple;

        /// <summary>
        /// Floors each axis of the vector to a whole number.
        /// </summary>
        public static Vector2 Floor(this Vector2 vector)
        {
            vector.x = Mathf.Floor(vector.x);
            vector.y = Mathf.Floor(vector.y);
            return vector;
        }

        /// <summary>
        /// Floors each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector2 Floor(this Vector2 vector, float multiple) =>
            (vector / multiple).Floor() * multiple;

        /// <summary>
        /// Floors each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector2 Floor(this Vector2 vector, Vector2 multiple) =>
            (vector / multiple).Floor() * multiple;

        /// <summary>
        /// Ceils each axis of the vector to a whole number.
        /// </summary>
        public static Vector2 Ceil(this Vector2 vector)
        {
            vector.x = Mathf.Ceil(vector.x);
            vector.y = Mathf.Ceil(vector.y);
            return vector;
        }

        /// <summary>
        /// Ceils each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector2 Ceil(this Vector2 vector, float multiple) =>
            (vector / multiple).Ceil() * multiple;

        /// <summary>
        /// Ceils each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector2 Ceil(this Vector2 vector, Vector2 multiple) =>
            (vector / multiple).Ceil() * multiple;

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        public static Vector3 ToVector3XY(this Vector2 vector) =>
            new Vector3(vector.x, vector.y, 0f);

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        public static Vector3 ToVector3XY(this Vector2 vector, float z) =>
            new Vector3(vector.x, vector.y, z);

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        public static Vector3 ToVector3XZ(this Vector2 vector) =>
            new Vector3(vector.x, 0f, vector.y);

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        public static Vector3 ToVector3XZ(this Vector2 vector, float y) =>
            new Vector3(vector.x, y, vector.y);

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        public static Vector3 ToVector3YZ(this Vector2 vector) =>
            new Vector3(0f, vector.x, vector.y);

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        public static Vector3 ToVector3YZ(this Vector2 vector, float x) =>
            new Vector3(x, vector.x, vector.y);

        /// <summary>
        /// Swap the <see cref="Vector2.x"/> and <see cref="Vector2.y"/> components.
        /// </summary>
        public static Vector2 Swap(this Vector2 vector) => new Vector2(vector.y, vector.x);

        /// <summary>
        /// Finds the closest Vector2 from an array of vectors.
        /// </summary>
        public static Vector2 Closest(this Vector2 target, Vector2[] vectors)
        {
            Vector2 closest = new Vector2(Mathf.Infinity, Mathf.Infinity);
            foreach (Vector2 vector in vectors)
            {
                float current = (vector - target).sqrMagnitude;
                if (current < (closest - target).sqrMagnitude)
                closest = vector;
            }
            return closest;
        }

        /// <summary>
        /// Finds the farthest Vector2 from an array of vectors.
        /// </summary>
        /// <param name="target">Vector.</param>
        /// <param name="vectors">Array of Vector2.</param>
        /// <returns>Farthest Vector2 from target.</returns>
        public static Vector2 Farthest(this Vector2 target, Vector2[] vectors)
        {
            Vector2 farthest = Vector2.zero;
            foreach (Vector2 vector in vectors)
            {
                float current = (vector - target).sqrMagnitude;
                if (current > (farthest - target).sqrMagnitude)
                    farthest = vector;
            }
            return farthest;
        }

        /// <summary>
        /// Find the average of an array of Vector2.
        /// </summary>
        /// <param name="vectors">Vector Array.</param>
        /// <returns>Average Vector2 from array.</returns>
        public static Vector2 Average(this Vector2[] vectors)
        {
            Vector2 average = Vector2.zero;
            foreach (Vector2 vector in vectors)
                average += vector;

            return average / vectors.Length;
        }

        /// <summary>
        /// Returns the vector with a set origin.
        /// </summary>
        /// <param name="vector">Vector2.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>Original Vector2 with new origin.</returns>
        public static Vector2 WithOrigin(this Vector2 vector, Vector2 origin) =>
            vector + origin;

        /// <summary>
        /// Finds the Cross Product between this vector and given vector.
        /// </summary>
        /// <param name="vector1">This Vector2</param>
        /// <param name="vector2">Given Vector2.</param>
        /// <returns>Cross Product between two Vector2.</returns>
        public static float Cross(this Vector2 vector1, Vector2 vector2) =>
            (vector1.x * vector2.y) - (vector1.y * vector2.x);

        /// <summary>
        /// Returns a Vector2 Perpendiciular to the input.
        /// </summary>
        /// <param name="vector">Vector2.</param>
        public static Vector2 Perp(this Vector2 vector) =>
            new Vector2(vector.y, -vector.x);

        /// <summary>
        /// Checks if this Vector2 is within a given distance from a given Vector2.
        /// </summary>
        /// <param name="vector">This Vector2.</param>
        /// <param name="radius">Distance.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>True if is within. False if not within.</returns>
        public static bool IsWithin(this Vector2 vector, Vector2 origin, float radius) =>
            (vector - origin).sqrMagnitude < radius * radius;

        /// <summary>
        /// Checks if this Vector2 is within a given area.
        /// </summary>
        public static bool IsWithin(this Vector2 vector, Vector2 bottomLeft, Vector2 topRight) =>
            vector.x > bottomLeft.x && vector.x < topRight.x && vector.y > bottomLeft.y && vector.y < topRight.y;

        /// <summary>
        /// Checks if this Vector2 is beyond a given distance from a given Vector2.
        /// </summary>
        /// <param name="vector">This Vector2.</param>
        /// <param name="radius">Distance.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>True if is beyond. False if not beyond.</returns>
        public static bool IsBeyond(this Vector2 vector, Vector2 origin, float radius) =>
            (vector - origin).sqrMagnitude > radius * radius;

        /// <summary>
        /// Checks if this Vector2 is beyond a given area.
        /// </summary>
        public static bool IsBeyond(this Vector2 vector, Vector2 bottomLeft, Vector2 topRight) =>
            vector.x < bottomLeft.x || vector.x > topRight.x || vector.y < bottomLeft.y || vector.y > topRight.y;

        /// <summary>
        /// Sets the magnitude of a vector.
        /// </summary>
        /// <param name="vector">Vector2.</param>
        /// <param name="magnitude">Magnitude.</param>
        /// <returns>The vector with new magnitude.</returns>
        public static Vector2 SetMagnitude(this Vector2 vector, float magnitude) =>
            vector.normalized * magnitude;

        /// <summary>
        /// Round components to closest integers and convert to Vector2Int.
        /// </summary>
        public static Vector2Int ToVector2Int(this Vector2 vector) =>
            new Vector2Int(Convert.ToInt32(vector.x.Round()), Convert.ToInt32(vector.y.Round()));

        /// <summary>
        /// Round components to closest integers and convert to Vector3Int.
        /// </summary>
        public static Vector3Int ToVector3Int(this Vector2 vector) =>
            new Vector3Int(Convert.ToInt32(vector.x.Round()), Convert.ToInt32(vector.y.Round()), 0);

        /// <summary>
        /// Set a vectors min and max values.
        /// </summary>
        public static Vector2 Clamp(this Vector2 vector, float? minX = null, float? minY = null, float? maxX = null, float? maxY = null) =>
            vector.With(vector.x.Clamp(minX, maxX), vector.y.Clamp(minY, maxY));

        /// <summary>
        /// Set a vectors min and max values.
        /// </summary>
        public static Vector2 Clamp(this Vector2 vector, Vector2? min = null, Vector2? max = null) =>
            vector.Clamp(min?.x ?? vector.x, min?.y ?? vector.y, max?.x ?? vector.x, max?.y ?? vector.y);

        /// <summary>
        /// Finds the distance from this vector to the <paramref name="target"/> vector.
        /// </summary>
        public static float DistanceFrom(this Vector2 vector, Vector2 target) => Vector2.Distance(vector, target);

        /// <summary>
        /// Finds the squared distance from this vector to the target vector.
        /// <para>This is faster than <see cref="DistanceFrom(Vector2, Vector2)"/> since it doesn't run a square root operation.</para>
        /// </summary>
        public static float SqrDistanceFrom(this Vector2 vector, Vector2 target) => (target - vector).sqrMagnitude;

        /// <summary>
        /// Find the manhattan distance from this vector to the <paramref name="target"/> vector.
        /// </summary>
        public static float ManhattanDistanceFrom(this Vector2 vector, Vector2 target) =>
            Mathf.Abs(target.x - vector.x) + Mathf.Abs(target.y - vector.y);

        /// <summary>
        /// Checks if <paramref name="position"/> is closer to <paramref name="origin"/> than <paramref name="comparedPosition"/>.
        /// </summary>
        public static bool IsCloserThan(this Vector2 position, Vector2 comparedPosition, Vector2 origin)
        {
            float positionCloseness = (position - origin).sqrMagnitude;
            float comparedPositionCloseness = (comparedPosition - origin).sqrMagnitude;

            return positionCloseness < comparedPositionCloseness;
        }

        /// <summary>
        /// Checks if <paramref name="position"/> is closer to <paramref name="origin"/> than <paramref name="comparedPosition"/>.
        /// </summary>
        /// <param name="closeness">The closeness of the closest position from <paramref name="origin"/> between <paramref name="position"/> and <paramref name="comparedPosition"/>.</param>
        public static bool IsCloserThan(this Vector2 position, Vector2 comparedPosition, Vector2 origin, out float closeness)
        {
            float positionCloseness = (position - origin).sqrMagnitude;
            float comparedPositionCloseness = (comparedPosition - origin).sqrMagnitude;

            bool isCloser = positionCloseness < comparedPositionCloseness;
            closeness = isCloser ? positionCloseness : comparedPositionCloseness;
            return isCloser;
        }

        /// <summary>
        /// Checks if <paramref name="position"/> is closer to <paramref name="origin"/> than <paramref name="comparedPosition"/>.
        /// </summary>
        /// <param name="closeness">The closeness of the closest position from <paramref name="origin"/> between <paramref name="position"/> and <paramref name="comparedPosition"/>.</param>
        public static bool IsCloserThan(this Vector2 position, Vector2 origin, float closestValue, out float closeness)
        {
            float positionCloseness = (position - origin).sqrMagnitude;

            bool isCloser = positionCloseness < closestValue;
            closeness = isCloser ? positionCloseness : closestValue;
            return isCloser;
        }

        /// <summary>
        /// Checks if <paramref name="position"/> is closer to <paramref name="origin"/> than <paramref name="comparedPosition"/>.
        /// </summary>
        /// <param name="closeness">The closeness of the closest position from <paramref name="origin"/> between <paramref name="position"/> and <paramref name="comparedPosition"/>.</param>
        public static bool IsCloserThan(this Vector2 position, Vector2 origin, ref float closestValue)
        {
            float positionCloseness = (position - origin).sqrMagnitude;

            bool isCloser = positionCloseness < closestValue;
            closestValue = isCloser ? positionCloseness : closestValue;
            return isCloser;
        }

        /// <summary>
        /// Translates a group of points.
        /// </summary>
        public static IEnumerable<Vector2> Translate(this IEnumerable<Vector2> points, Vector2 translation)
        {
            List<Vector2> result = new List<Vector2>();

            foreach (Vector2 point in points)
                result.Add(point + translation);

            return result;
        }

        /// <summary>
        /// Rotate a <paramref name="worldPosition"/> around a <paramref name="centerOfRotation"/>.
        /// </summary>
        /// <param name="worldPosition">Current world position.</param>
        /// <param name="centerOfRotation">World space position to rotate around.</param>
        /// <param name="orientation">Relative orientation.</param>
        /// <returns><paramref name="worldPosition"/> rotated around <paramref name="centerOfRotation"/> by <paramref name="orientation"/>.</returns>
        public static Vector3 Rotate(this Vector2 worldPosition, Vector2 centerOfRotation, Quaternion orientation)
        {
            Vector3 worldPosition3D = worldPosition;
            Vector3 centerOfRotation3D = centerOfRotation;

            Vector3 localPosition = worldPosition3D - centerOfRotation3D;
            localPosition = orientation * localPosition;
            worldPosition3D = localPosition + centerOfRotation3D;
            return worldPosition3D;
        }

        /// <summary>
        /// Rotate a <paramref name="worldPosition"/> around a <paramref name="centerOfRotation"/>.
        /// </summary>
        /// <param name="worldPosition">Current world position.</param>
        /// <param name="centerOfRotation">World space position to rotate around.</param>
        /// <param name="eulerAngles">Relative angles.</param>
        /// <returns><paramref name="worldPosition"/> rotated around <paramref name="centerOfRotation"/> by <paramref name="eulerAngles"/>.</returns>
        public static Vector3 Rotate(this Vector2 worldPosition, Vector2 centerOfRotation, Vector3 eulerAngles) =>
            Rotate(worldPosition, centerOfRotation, Quaternion.Euler(eulerAngles));
    }
}