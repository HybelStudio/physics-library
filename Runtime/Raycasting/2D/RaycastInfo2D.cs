using System;
using UnityEngine;

namespace Hybel
{
    public struct RaycastInfo2D
    {
        public readonly RaycastHit2D Hit;
        public readonly RayLine2D Line;

        public RaycastInfo2D(RaycastHit2D hit, RayLine2D rayLine)
        {
            Hit = hit;
            Line = rayLine;
        }

        public RaycastInfo2D(RaycastHit2D hit, Ray2D ray)
        {
            Hit = hit;
            Line = new RayLine2D(ray, hit);
        }

        public RaycastInfo2D(RaycastHit2D hit, Vector2 origin)
        {
            Hit = hit;
            Line = new RayLine2D(origin, hit);
        }

        public static RaycastInfo2D[] Create(RaycastHit2D[] hits, RayLine2D[] rayLines)
        {
            if (hits == null)
                throw new ArgumentNullException(nameof(hits));

            if (rayLines == null)
                throw new ArgumentNullException(nameof(rayLines));

            if (hits.Length != rayLines.Length)
                throw new ArgumentException("Arrays must be of equal length.");

            RaycastInfo2D[] raycastInfos = new RaycastInfo2D[hits.Length];

            for (int i = 0; i < hits.Length; i++)
                raycastInfos[i] = new RaycastInfo2D(hits[i], rayLines[i]);

            return raycastInfos;
        }

        public static RaycastInfo2D[] Create(RaycastHit2D[] hits, Ray2D[] rays)
        {
            if (hits == null)
                throw new ArgumentNullException(nameof(hits));

            if (rays == null)
                throw new ArgumentNullException(nameof(rays));

            if (hits.Length != rays.Length)
                throw new ArgumentException("Arrays must be of equal length.");

            RaycastInfo2D[] raycastInfos = new RaycastInfo2D[hits.Length];

            for (int i = 0; i < hits.Length; i++)
                raycastInfos[i] = new RaycastInfo2D(hits[i], rays[i]);

            return raycastInfos;
        }

        public static RaycastInfo2D[] Create(RaycastHit2D[] hits, Vector2[] origins)
        {
            if (hits == null)
                throw new ArgumentNullException(nameof(hits));

            if (origins == null)
                throw new ArgumentNullException(nameof(origins));

            if (hits.Length != origins.Length)
                throw new ArgumentException("Arrays must be of equal length.");

            RaycastInfo2D[] raycastInfos = new RaycastInfo2D[hits.Length];

            for (int i = 0; i < hits.Length; i++)
                raycastInfos[i] = new RaycastInfo2D(hits[i], origins[i]);

            return raycastInfos;
        }
    }

    public struct RaycastInfos2D
    {
        public readonly RaycastHit2D[] Hits;
        public readonly RayLine2D Line;

        public RaycastInfos2D(RaycastHit2D[] hits, RayLine2D rayLine)
        {
            Hits = hits;
            Line = rayLine;
        }

        public RaycastInfos2D(RaycastHit2D[] hits, Ray2D ray)
        {
            Hits = hits;
            Line = new RayLine2D(ray, hits[hits.Length - 1]);
        }

        public RaycastInfos2D(RaycastHit2D[] hits, Vector2 origin)
        {
            Hits = hits;
            Line = new RayLine2D(origin, hits[hits.Length - 1]);
        }
    }
}