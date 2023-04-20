using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public struct SphereOverlap : IEquatable<SphereOverlap>
    {
        public readonly Vector3 Position;
        public readonly float Radius;

        public SphereOverlap(Vector3 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public override string ToString() => $"{nameof(Position)}: {Position} | {nameof(Radius)}: {Radius}";

        public bool Equals(SphereOverlap other) => Position.Equals(other.Position) && Radius == other.Radius;
        public override bool Equals(object obj) => obj is SphereOverlap overlap && Equals(overlap);

        public override int GetHashCode()
        {
            var hashCode = 556031629;
            hashCode = hashCode * -1521134295 + Position.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SphereOverlap left, SphereOverlap right) => left.Equals(right);
        public static bool operator !=(SphereOverlap left, SphereOverlap right) => !(left == right);
    }
}