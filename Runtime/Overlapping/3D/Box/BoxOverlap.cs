using System;
using UnityEngine;

namespace Hybel
{
    public struct BoxOverlap : IEquatable<BoxOverlap>
    {
        public readonly Vector3 Center;
        public readonly Vector3 HalfExtents;
        public readonly Quaternion Orientation;

        public BoxOverlap(Vector3 center, Vector3 halfExtents, Quaternion orientation)
        {
            Center = center;
            HalfExtents = halfExtents;
            Orientation = orientation;
        }

        public override string ToString() => $"{nameof(Center)}: {Center} | {nameof(HalfExtents)}: {HalfExtents} | {nameof(Orientation)}: {Orientation}";

        public bool Equals(BoxOverlap other) => Center.Equals(other.Center) && HalfExtents.Equals(other.HalfExtents) && Orientation.Equals(other.Orientation);
        public override bool Equals(object obj) => obj is BoxOverlap overlap && Equals(overlap);

        public override int GetHashCode()
        {
            var hashCode = 768016458;
            hashCode = hashCode * -1521134295 + Center.GetHashCode();
            hashCode = hashCode * -1521134295 + HalfExtents.GetHashCode();
            hashCode = hashCode * -1521134295 + Orientation.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(BoxOverlap left, BoxOverlap right) => left.Equals(right);
        public static bool operator !=(BoxOverlap left, BoxOverlap right) => !(left == right);
    }
}