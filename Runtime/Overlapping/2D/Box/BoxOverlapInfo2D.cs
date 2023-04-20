using UnityEngine;

namespace Hybel
{
    public struct BoxOverlapInfo2D
    {
        public readonly Collider2D[] Colliders;
        public readonly BoxOverlap2D Overlap;

        public BoxOverlapInfo2D(Collider2D[] colliders, BoxOverlap2D overlap)
        {
            Colliders = colliders;
            Overlap = overlap;
        }
    }
}
