using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order) =>
            IterateRadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, order);

        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order, float distance) =>
            IterateRadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, order, distance);

        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order, int layerMask) =>
            IterateRadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, order, layerMask);

        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateRadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateRadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, order, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateRadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask, queryTriggerInteraction);
                yield return hits;
            }
        }
    }
}
