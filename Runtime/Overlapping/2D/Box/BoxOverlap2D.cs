using System;
using UnityEngine;

namespace Hybel
{
    public struct BoxOverlap2D : IEquatable<BoxOverlap2D>
    {
        public readonly Vector2 Center;
        public readonly Vector2 HalfExtents;
        public readonly float Angle;

        public BoxOverlap2D(Vector2 center, Vector2 halfExtents, float angle)
        {
            Center = center;
            HalfExtents = halfExtents;
            Angle = angle;
        }

        public override string ToString() => $"{nameof(Center)}: {Center} | {nameof(HalfExtents)}: {HalfExtents} | {nameof(Angle)}: {Angle}";

        public bool Equals(BoxOverlap2D other) => Center.Equals(other.Center) && HalfExtents.Equals(other.HalfExtents) && Angle == other.Angle;
        public override bool Equals(object obj) => obj is BoxOverlap2D d && Equals(d);

        public override int GetHashCode()
        {
            var hashCode = -1573275071;
            hashCode = hashCode * -1521134295 + Center.GetHashCode();
            hashCode = hashCode * -1521134295 + HalfExtents.GetHashCode();
            hashCode = hashCode * -1521134295 + Angle.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(BoxOverlap2D left, BoxOverlap2D right) => left.Equals(right);
        public static bool operator !=(BoxOverlap2D left, BoxOverlap2D right) => !(left == right);
    }
}