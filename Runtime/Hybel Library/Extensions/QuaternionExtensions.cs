using UnityEngine;

namespace Hybel.ExtensionMethods
{
    /// <summary>
    /// Extension Methods used on Quaternions.
    /// </summary>
    public static class QuaternionExtensions
    {
        /// <summary>
        /// Manually assign each component of the <paramref name="quaternion"/>. If no value is passed it wont be changed.
        /// </summary>
        public static Quaternion With(this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null) =>
            new Quaternion(x ?? quaternion.x, y ?? quaternion.y, z ?? quaternion.z, w ?? quaternion.w);
    }
}