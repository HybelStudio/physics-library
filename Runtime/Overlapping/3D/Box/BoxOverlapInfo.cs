using UnityEngine;

namespace Hybel
{
    public readonly struct BoxOverlapInfo
    {
        public readonly Collider[] Colliders;
        public readonly BoxOverlap Overlap;

        public BoxOverlapInfo(Collider[] colliders, BoxOverlap overlap)
        {
            Colliders = colliders;
            Overlap = overlap;
        }
    }
}
