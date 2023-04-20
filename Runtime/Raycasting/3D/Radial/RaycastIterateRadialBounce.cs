using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Ray ray, Vector3 normal, float angle, int numberOfRays, int bounces, Order order) =>
            IterateRadialBounce(ray.origin, ray.direction, normal, angle, numberOfRays, bounces, order);

        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Ray ray, Vector3 normal, float angle, int numberOfRays, int bounces, Order order, float distance) =>
            IterateRadialBounce(ray.origin, ray.direction, normal, angle, numberOfRays, bounces, order, distance);

        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Ray ray, Vector3 normal, float angle, int numberOfRays, int bounces, Order order, int layerMask) =>
            IterateRadialBounce(ray.origin, ray.direction, normal, angle, numberOfRays, bounces, order, layerMask);

        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Ray ray, Vector3 normal, float angle, int numberOfRays, int bounces, Order order, float distance, int layerMask) =>
            IterateRadialBounce(ray.origin, ray.direction, normal, angle, numberOfRays, bounces, order, distance, layerMask);

        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Ray ray, Vector3 normal, float angle, int numberOfRays, int bounces, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateRadialBounce(ray.origin, ray.direction, normal, angle, numberOfRays, bounces, order, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int bounces, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int bounces, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int bounces, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int bounces, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateRadialBounce(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int bounces, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray, bounces, distance, layerMask, queryTriggerInteraction);
                yield return hits;
            }
        }
    }
}
