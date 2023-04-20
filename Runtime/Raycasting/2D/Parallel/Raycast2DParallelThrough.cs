using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distinctHits);

        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, float distance, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distance, distinctHits);

        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, float minDepth, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, minDepth, distinctHits);

        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, minDepth, maxDepth, distinctHits);


        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, out RayLine2D[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, out rayLines, distinctHits);

        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, float distance, out RayLine2D[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distance, out rayLines, distinctHits);

        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, out RayLine2D[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, float minDepth, out RayLine2D[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, minDepth, out rayLines, distinctHits);

        public static RaycastHit2D[][] ParallelThrough(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, out RayLine2D[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, minDepth, maxDepth, out rayLines, distinctHits);



        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, float minDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask, minDepth);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0][];

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }


        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0];
                return new RaycastHit2D[0][];
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D> newRayLines = new List<RayLine2D>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine2D(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0];
                return new RaycastHit2D[0][];
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D> newRayLines = new List<RayLine2D>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine2D(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0];
                return new RaycastHit2D[0][];
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D> newRayLines = new List<RayLine2D>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine2D(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, float minDepth, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0];
                return new RaycastHit2D[0][];
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D> newRayLines = new List<RayLine2D>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask, minDepth);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine2D(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit2D[][] ParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine2D[0];
                return new RaycastHit2D[0][];
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D[]> hitArrays = new List<RaycastHit2D[]>();
            List<RayLine2D> newRayLines = new List<RayLine2D>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine2D(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }
    }
}