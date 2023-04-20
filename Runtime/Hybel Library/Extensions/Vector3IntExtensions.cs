using UnityEngine;

namespace Hybel.ExtensionMethods
{
    /// <summary>
    /// Extension Methods used on Vector3Ints.
    /// </summary>
    public static class Vector3IntExtensions
    {
        /// <summary>
        /// Set x and/or y to any value.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="x">Value to set x to. (Optional)</param>
        /// <param name="y">Value to set y to. (Optional)</param>
        /// <param name="z">Value to set z to. (Optional)</param>
        /// <returns>Vector3Int with changed values.</returns>
        public static Vector3Int With(this Vector3Int vector, int? x = null, int? y = null, int? z = null) =>
            new Vector3Int(x ?? vector.x, y ?? vector.y, z ?? vector.z);

        /// <summary>
        /// Add two vectors together.
        /// </summary>
        /// /// <param name="x">Value to add to x. (Optional)</param>
        /// <param name="y">Value to add to y. (Optional)</param>
        /// <param name="z">Value to add to z. (Optional)</param>
        public static Vector3Int Add(this Vector3Int vector, int? x = null, int? y = null, int? z = null) =>
            new Vector3Int(vector.x + x ?? vector.x, vector.y + y ?? vector.y, vector.z + z ?? vector.z);

        /// <summary>
        /// Subtract any value from x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <param name="z">Value to subtract from z. (Optional)</param>
        /// <returns>Vector2 with subtracted values.</returns>
        public static Vector3Int Subtract(this Vector3Int vector, int? x = null, int? y = null, int? z = null) =>
            new Vector3Int(vector.x - x ?? vector.x, vector.y - y ?? vector.y, vector.z - z ?? vector.z);

        /// <summary>
        /// Subtract any value from x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <param name="z">Value to subtract from z. (Optional)</param>
        /// <returns>Vector3Int with subtracted values.</returns>
        public static Vector3Int Multiply(this Vector3Int vector, int? x = null, int? y = null, int? z = null) =>
            new Vector3Int(vector.x * x ?? vector.x, vector.y * y ?? vector.y, vector.z * z ?? vector.z);

        /// <summary>
        /// Devide any value with x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to devide with x. (Optional)</param>
        /// <param name="y">Value to devide with y. (Optional)</param>
        /// <param name="z">Value to devide with z. (Optional)</param>
        /// <returns>Vector3Int with devided values.</returns>
        public static Vector3Int Divide(this Vector3Int vector, int? x = null, int? y = null, int? z = null) =>
            new Vector3Int(vector.x / x ?? vector.x, vector.y / y ?? vector.y, vector.z / z ?? vector.z);

        /// <summary>
        /// Convert from Vector3Int to Vector3.
        /// </summary>
        public static Vector3Int ToVector3(this Vector3Int vector) =>
            new Vector3Int(vector.x, vector.y, vector.z);

        /// <summary>
        /// Convert from Vector3Int to Vector2Int.
        /// </summary>
        public static Vector2Int ToVector2IntXY(this Vector3Int vector) =>
            new Vector2Int(vector.x, vector.y);

        /// <summary>
        /// Convert from Vector3Int to Vector2Int.
        /// </summary>
        public static Vector2Int ToVector2IntXZ(this Vector3Int vector) =>
            new Vector2Int(vector.x, vector.z);

        /// <summary>
        /// Convert from Vector3Int to Vector2Int.
        /// </summary>
        public static Vector2Int ToVector2IntYZ(this Vector3Int vector) =>
            new Vector2Int(vector.y, vector.z);

        /// <summary>
        /// Convert from Vector3Int to Vector2.
        /// </summary>
        public static Vector2 ToVector2XY(this Vector3Int vector) =>
            new Vector2(vector.x, vector.y);

        /// <summary>
        /// Convert from Vector3Int to Vector2.
        /// </summary>
        public static Vector2 ToVector2XZ(this Vector3Int vector) =>
            new Vector2(vector.x, vector.z);

        /// <summary>
        /// Convert from Vector3Int to Vector2.
        /// </summary>
        public static Vector2 ToVector2YZ(this Vector3Int vector) =>
            new Vector2(vector.y, vector.z);

        /// <summary>
        /// Set a vectors min and max values.
        /// </summary>
        public static Vector3Int Clamp(this Vector3Int vector, int? minX = null, int? minY = null, int? minZ = null, int? maxX = null, int? maxY = null, int? maxZ = null) =>
            vector.With(vector.x.Clamp(minX, maxX), vector.y.Clamp(minY, maxY), vector.z.Clamp(minZ, maxZ));
    }
}