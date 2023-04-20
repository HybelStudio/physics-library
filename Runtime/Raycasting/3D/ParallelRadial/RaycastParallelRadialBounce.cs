using Hybel.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, distinctHits);

        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, maxDistance, distinctHits);

        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, int layerMask, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, layerMask, distinctHits);

        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, int layerMask, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, maxDistance, layerMask, distinctHits);

        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, maxDistance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, out RayLine[][] rayLines, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, out RayLine[][] rayLines, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, maxDistance, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, int layerMask, out RayLine[][] rayLines, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, int layerMask, out RayLine[][] rayLines, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, maxDistance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[][] rayLines, bool distinctHits = false) =>
            ParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, maxDistance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);



        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
{
                var hits = Bounce(ray, bounces, maxDistance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask, queryTriggerInteraction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }


        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, out RayLine[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, out RayLine[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, int layerMask, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, layerMask, out RayLine[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, int layerMask, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask, out RayLine[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, maxDistance, layerMask, queryTriggerInteraction, out RayLine[] newRayLines);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }
    }
}