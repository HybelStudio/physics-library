using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays) =>
            IterateParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays);

        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance) =>
            IterateParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance);

        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, int layerMask) =>
            IterateParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, layerMask);

        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask) =>
            IterateParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask);

        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays) =>
            IterateOutParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays);

        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance) =>
            IterateOutParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance);

        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, int layerMask) =>
            IterateOutParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, layerMask);

        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask) =>
            IterateOutParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask);

        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateOutParallelRadialThrough(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, queryTriggerInteraction);



        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask, queryTriggerInteraction);
                yield return hits;
            }
        }


        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray);
                yield return new RaycastInfos(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance);
                yield return new RaycastInfos(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, layerMask);
                yield return new RaycastInfos(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask);
                yield return new RaycastInfos(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos> IterateOutParallelRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask, queryTriggerInteraction);
                yield return new RaycastInfos(hits, ray);
            }
        }
    }
}
