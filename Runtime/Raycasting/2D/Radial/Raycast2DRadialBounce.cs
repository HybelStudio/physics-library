using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, distinctHits);

        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, float maxDistance, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, maxDistance, distinctHits);

        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, maxDistance, layerMask, distinctHits);

        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, float minDepth, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, maxDistance, layerMask, minDepth, distinctHits);

        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, maxDistance, layerMask, minDepth, maxDepth, distinctHits);


        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, out RayLine2D[][] rayLines, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, out rayLines, distinctHits);

        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, float maxDistance, out RayLine2D[][] rayLines, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, maxDistance, out rayLines, distinctHits);

        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, out RayLine2D[][] rayLines, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, maxDistance, layerMask, out rayLines, distinctHits);

        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, float minDepth, out RayLine2D[][] rayLines, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, maxDistance, layerMask, minDepth, out rayLines, distinctHits);

        public static RaycastHit2D[][] RadialBounce(Ray2D ray, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth, out RayLine2D[][] rayLines, bool distinctHits = false) =>
            RadialBounce(ray.origin, ray.direction, angle, numberOfRays, bounces, maxDistance, layerMask, minDepth, maxDepth, out rayLines, distinctHits);



        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, float maxDistance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
{
                var hits = Bounce(ray, bounces, maxDistance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, float minDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask, minDepth);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask, minDepth, maxDepth);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }


        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, out RayLine2D[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0][];
                return new RaycastHit2D[0][];
            }

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D[]> rayLineArrays = new List<RayLine2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, out RayLine2D[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, float maxDistance, out RayLine2D[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0][];
                return new RaycastHit2D[0][];
            }

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D[]> rayLineArrays = new List<RayLine2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, out RayLine2D[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, out RayLine2D[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0][];
                return new RaycastHit2D[0][];
            }

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D[]> rayLineArrays = new List<RayLine2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask, out RayLine2D[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, float minDepth, out RayLine2D[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0][];
                return new RaycastHit2D[0][];
            }

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D[]> rayLineArrays = new List<RayLine2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask, minDepth, out RayLine2D[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth, out RayLine2D[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0][];
                return new RaycastHit2D[0][];
            }

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D[]> rayLineArrays = new List<RayLine2D[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask, minDepth, maxDepth, out RayLine2D[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }
    }
}