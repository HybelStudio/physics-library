using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Ray2D ray, float angle, int numberOfRays, Order order) =>
            IterateRadialThrough(ray.origin, ray.direction, angle, numberOfRays, order);

        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Ray2D ray, float angle, int numberOfRays, Order order, float distance) =>
            IterateRadialThrough(ray.origin, ray.direction, angle, numberOfRays, order, distance);

        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Ray2D ray, float angle, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateRadialThrough(ray.origin, ray.direction, angle, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Ray2D ray, float angle, int numberOfRays, Order order, float distance, int layerMask, float minDepth) =>
            IterateRadialThrough(ray.origin, ray.direction, angle, numberOfRays, order, distance, layerMask, minDepth);

        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Ray2D ray, float angle, int numberOfRays, Order order, float distance, int layerMask, float minDepth, float maxDepth) =>
            IterateRadialThrough(ray.origin, ray.direction, angle, numberOfRays, order, distance, layerMask, minDepth, maxDepth);


        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction);
                    yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance);
                    yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance, layerMask);
                    yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, float distance, int layerMask, float minDepth)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance, layerMask, minDepth);
                    yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateRadialThrough(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, float distance, int layerMask, float minDepth, float maxDepth)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth);
                    yield return hits;
            }
        }
    }
}
