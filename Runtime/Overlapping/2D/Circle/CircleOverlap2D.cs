using System;
using UnityEngine;

namespace Hybel
{
    public struct CircleOverlap2D : IEquatable<CircleOverlap2D>
    {
        public readonly Vector2 Position;
        public readonly float Radius;

        public CircleOverlap2D(Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public override string ToString() => $"{nameof(Position)}: {Position} | {nameof(Radius)}: {Radius}";

        public bool Equals(CircleOverlap2D other) => Position.Equals(other.Position) && Radius == other.Radius;
        public override bool Equals(object obj) => obj is CircleOverlap2D d && Equals(d);

        public override int GetHashCode()
        {
            var hashCode = 556031629;
            hashCode = hashCode * -1521134295 + Position.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(CircleOverlap2D left, CircleOverlap2D right) => left.Equals(right);
        public static bool operator !=(CircleOverlap2D left, CircleOverlap2D right) => !(left == right);
    }
}