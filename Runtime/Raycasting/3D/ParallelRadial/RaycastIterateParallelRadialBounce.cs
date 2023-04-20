using Hybel.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces) =>
            IterateParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces);

        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float distance) =>
            IterateParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, distance);

        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, int layerMask) =>
            IterateParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, layerMask);

        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float distance, int layerMask) =>
            IterateParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, distance, layerMask);

        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces) =>
            IterateOutParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces);

        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float distance) =>
            IterateOutParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, distance);

        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, int layerMask) =>
            IterateOutParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, layerMask);

        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float distance, int layerMask) =>
            IterateOutParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, distance, layerMask);

        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Ray ray, Vector3 normal, float radius, int numberOfRays, int bounces, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateOutParallelRadialBounce(ray.origin, ray.direction, normal, radius, numberOfRays, bounces, distance, layerMask, queryTriggerInteraction);



        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance, layerMask, queryTriggerInteraction);
                yield return hits;
            }
        }


        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }

        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }

        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, layerMask);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }

        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance, layerMask);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }

        public static IEnumerable<RaycastInfo[]> IterateOutParallelRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int bounces, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance, layerMask, queryTriggerInteraction);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }
    }
}
