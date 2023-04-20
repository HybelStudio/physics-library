using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Ray2D ray, float angle, int numberOfRays, Order order, int bounces) =>
            IterateRadialBounce(ray.origin, ray.direction, angle, numberOfRays, order, bounces);

        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Ray2D ray, float angle, int numberOfRays, Order order, int bounces, float distance) =>
            IterateRadialBounce(ray.origin, ray.direction, angle, numberOfRays, order, bounces, distance);

        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Ray2D ray, float angle, int numberOfRays, Order order, int bounces, float distance, int layerMask) =>
            IterateRadialBounce(ray.origin, ray.direction, angle, numberOfRays, order, bounces, distance, layerMask);

        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Ray2D ray, float angle, int numberOfRays, Order order, int bounces, float distance, int layerMask, float minDepth) =>
            IterateRadialBounce(ray.origin, ray.direction, angle, numberOfRays, order, bounces, distance, layerMask, minDepth);

        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Ray2D ray, float angle, int numberOfRays, Order order, int bounces, float distance, int layerMask, float minDepth, float maxDepth) =>
            IterateRadialBounce(ray.origin, ray.direction, angle, numberOfRays, order, bounces, distance, layerMask, minDepth, maxDepth);


        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, int bounces)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces);
                    yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, int bounces, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance);
                    yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, int bounces, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance, layerMask);
                    yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, int bounces, float distance, int layerMask, float minDepth)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance, layerMask, minDepth);
                    yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateRadialBounce(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, int bounces, float distance, int layerMask, float minDepth, float maxDepth)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance, layerMask, minDepth, maxDepth);
                    yield return hits;
            }
        }
    }
}
