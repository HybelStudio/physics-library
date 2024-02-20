using System;
using UnityEngine;

namespace Hybel
{
    public readonly struct CapsuleOverlap : IEquatable<CapsuleOverlap>
    {
        public readonly Vector3 Position1;
        public readonly Vector3 Position2;
        public readonly float Radius;

        public CapsuleOverlap(Vector3 position1, Vector3 position2, float radius)
        {
            Position1 = position1;
            Position2 = position2;
            Radius = radius;
        }

        public override string ToString() => $"{nameof(Position1)}: {Position1} | {nameof(Position2)}: {Position2} | {nameof(Radius)}: {Radius}";

        public bool Equals(CapsuleOverlap other) => Position1.Equals(other.Position1) && Position2.Equals(other.Position2) && Radius == other.Radius;
        public override bool Equals(object obj) => obj is CapsuleOverlap overlap && Equals(overlap);

        public override int GetHashCode()
        {
            var hashCode = 556031629;
            hashCode = hashCode * -1521134295 + Position1.GetHashCode();
            hashCode = hashCode * -1521134295 + Position2.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(CapsuleOverlap left, CapsuleOverlap right) => left.Equals(right);
        public static bool operator !=(CapsuleOverlap left, CapsuleOverlap right) => !(left == right);
    }
}