using UnityEngine;

namespace Hybel.ExtensionMethods
{
    /// <summary>
    /// Extension Methods used on Vector2Ints.
    /// </summary>
    public static class Vector2IntExtensions
    {
        /// <summary>
        /// Set x and/or y to any value.
        /// </summary>
        /// <param name="x">Value to set x to. (Optional)</param>
        /// <param name="y">Value to set y to. (Optional)</param>
        /// <returns>Vector2Int with changed values.</returns>
        public static Vector2Int With(this Vector2Int vector, int? x = null, int? y = null) =>
            new Vector2Int(x ?? vector.x, y ?? vector.y);

        /// <summary>
        /// Add two vectors together.
        /// </summary>
        /// <param name="x">Value to add to x. (Optional)</param>
        /// <param name="y">Value to add to y. (Optional)</param>
        /// <returns>Vector2Int with changed values.</returns>
        public static Vector2Int Add(this Vector2Int vector, int? x = null, int? y = null) =>
            new Vector2Int(vector.x + x ?? vector.x, vector.y + y ?? vector.y);

        /// <summary>
        /// Subtract any value from x and/or y.
        /// </summary>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <returns>Vector2Int with subtracted values.</returns>
        public static Vector2Int Subtract(this Vector2Int vector, int? x = null, int? y = null) =>
            new Vector2Int(vector.x - x ?? vector.x, vector.y - y ?? vector.y);

        /// <summary>
        /// Subtract any value from x and/or y.
        /// </summary>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <returns>Vector2Int with subtracted values.</returns>
        public static Vector2Int Multiply(this Vector2Int vector, int? x = null, int? y = null) =>
            new Vector2Int(vector.x * x ?? vector.x, vector.y * y ?? vector.y);

        /// <summary>
        /// Devide any value with x and/or y.
        /// </summary>
        /// <param name="x">Value to devide with x. (Optional)</param>
        /// <param name="y">Value to devide with y. (Optional)</param>
        /// <returns>Vector2Int with devided values.</returns>
        public static Vector2Int Divide(this Vector2Int vector, int? x = null, int? y = null) =>
            new Vector2Int(vector.x / x ?? vector.x, vector.y / y ?? vector.y);

        /// <summary>
        /// Convert from Vector2Int to Vector2.
        /// </summary>
        public static Vector2 ToVector2(this Vector2Int vector) =>
            new Vector2(vector.x, vector.y);

        /// <summary>
        /// Convert from Vector2Int to Vector3Int.
        /// </summary>
        public static Vector3Int ToVector3IntXY(this Vector2Int vector, int z = 0) =>
            new Vector3Int(vector.x, vector.y, 0);

        /// <summary>
        /// Convert from Vector2Int to Vector3Int.
        /// </summary>
        public static Vector3Int ToVector3IntXZ(this Vector2Int vector, int y = 0) =>
            new Vector3Int(vector.x, 0, vector.y);

        /// <summary>
        /// Convert from Vector2Int to Vector3Int.
        /// </summary>
        public static Vector3Int ToVector3IntYZ(this Vector2Int vector, int x = 0) =>
            new Vector3Int(0, vector.x, vector.y);

        /// <summary>
        /// Convert from Vector2Int to Vector3.
        /// </summary>
        public static Vector3 ToVector3XY(this Vector2Int vector, float z = 0f) =>
            new Vector3(vector.x, vector.y, 0f);

        /// <summary>
        /// Convert from Vector2Int to Vector3.
        /// </summary>
        public static Vector3 ToVector3XZ(this Vector2Int vector, float y = 0f) =>
            new Vector3(vector.x, 0f, vector.y);

        /// <summary>
        /// Convert from Vector2Int to Vector3.
        /// </summary>
        public static Vector3 ToVector3YZ(this Vector2Int vector, float x = 0f) =>
            new Vector3(0f, vector.x, vector.y);

        /// <summary>
        /// Set a vectors min and max values.
        /// </summary>
        public static Vector2Int Clamp(this Vector2Int vector, int? minX = null, int? minY = null, int? maxX = null, int? maxY = null) =>
            vector.With(vector.x.Clamp(minX, maxX), vector.y.Clamp(minY, maxY));

        /// <summary>
        /// Set a vectors min and max values.
        /// </summary>
        public static Vector2Int Clamp(this Vector2Int vector, Vector2Int? min = null, Vector2Int? max = null) =>
            vector.Clamp(min?.x, min?.y, max?.x, max?.y);
    }
}