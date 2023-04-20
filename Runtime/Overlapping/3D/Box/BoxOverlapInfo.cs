using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public struct BoxOverlapInfo
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
