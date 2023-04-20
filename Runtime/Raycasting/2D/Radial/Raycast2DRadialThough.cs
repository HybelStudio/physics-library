using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[][] RadialThrough(Ray2D ray, float angle, int numberOfRays, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, angle, numberOfRays, distinctHits);

        public static RaycastHit2D[][] RadialThrough(Ray2D ray, float angle, int numberOfRays, float distance, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, angle, numberOfRays, distance, distinctHits);

        public static RaycastHit2D[][] RadialThrough(Ray2D ray, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, angle, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit2D[][] RadialThrough(Ray2D ray, float angle, int numberOfRays, float distance, int layerMask, float minDepth, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, angle, numberOfRays, distance, layerMask, minDepth, distinctHits);

        public static RaycastHit2D[][] RadialThrough(Ray2D ray, float angle, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, angle, numberOfRays, distance, layerMask, minDepth, maxDepth, distinctHits);


        public static RaycastHit2D[][] RadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];


            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];
            
            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];
            
            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, float distance, int layerMask, float minDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];
            
            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask, minDepth);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] RadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];
            
            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }
    }
}