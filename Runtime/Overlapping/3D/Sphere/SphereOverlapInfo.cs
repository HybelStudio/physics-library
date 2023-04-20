using UnityEngine;

namespace Hybel
{
    public struct SphereOverlapInfo
    {
        public readonly Collider[] Colliders;
        public readonly SphereOverlap Overlap;

        public SphereOverlapInfo(Collider[] colliders, SphereOverlap overlap)
        {
            Colliders = colliders;
            Overlap = overlap;
        }
    }
}
