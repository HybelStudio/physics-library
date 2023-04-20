using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distinctHits);

        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, distinctHits);

        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, int layerMask, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, layerMask, distinctHits);

        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);



        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask, queryTriggerInteraction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }


        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hits = Through(ray);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, new RayLine(ray, hits[hits.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, new RayLine(ray, hits[hits.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, new RayLine(ray, hits[hits.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, new RayLine(ray, hits[hits.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask, queryTriggerInteraction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, new RayLine(ray, hits[hits.Length -1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }
    }
}
