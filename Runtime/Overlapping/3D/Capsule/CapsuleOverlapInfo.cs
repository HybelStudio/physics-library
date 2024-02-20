using UnityEngine;

namespace Hybel
{
    public readonly struct CapsuleOverlapInfo
    {
        public readonly Collider[] Colliders;
        public readonly CapsuleOverlap Overlap;

        public CapsuleOverlapInfo(Collider[] colliders, CapsuleOverlap overlap)
        {
            Colliders = colliders;
            Overlap = overlap;
        }
    }
}
