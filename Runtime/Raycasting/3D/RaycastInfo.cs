using UnityEngine;

namespace Hybel
{
    public struct RaycastInfo
    {
        public readonly RaycastHit Hit;
        public readonly RayLine Line;

        public RaycastInfo(RaycastHit hit, RayLine rayLine)
        {
            Hit = hit;
            Line = rayLine;
        }

        public RaycastInfo(RaycastHit hit, Ray ray)
        {
            Hit = hit;
            Line = new RayLine(ray, hit);
        }

        public RaycastInfo(RaycastHit hit, Vector2 origin)
        {
            Hit = hit;
            Line = new RayLine(origin, hit);
        }
    }

    public struct RaycastInfos
    {
        public readonly RaycastHit[] Hits;
        public readonly RayLine Line;

        public RaycastInfos(RaycastHit[] hits, RayLine rayLine)
        {
            Hits = hits;
            Line = rayLine;
        }

        public RaycastInfos(RaycastHit[] hits, Ray ray)
        {
            Hits = hits;
            Line = new RayLine(ray, hits[hits.Length - 1]);
        }

        public RaycastInfos(RaycastHit[] hits, Vector2 origin)
        {
            Hits = hits;
            Line = new RayLine(origin, hits[hits.Length - 1]);
        }
    }
}