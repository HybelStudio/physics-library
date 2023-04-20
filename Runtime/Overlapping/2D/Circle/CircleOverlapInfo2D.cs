using UnityEngine;

namespace Hybel
{
    public struct CircleOverlapInfo2D
    {
        public readonly Collider2D[] Colliders;
        public readonly CircleOverlap2D Overlap;

        public CircleOverlapInfo2D(Collider2D[] colliders, CircleOverlap2D overlap)
        {
            Colliders = colliders;
            Overlap = overlap;
        }
    }
}
