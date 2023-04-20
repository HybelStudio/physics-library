using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces) =>
            IterateParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces);

        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces, float maxDistance) =>
            IterateParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces, maxDistance);

        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask) =>
            IterateParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces, maxDistance, layerMask);

        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask, float minDepth) =>
            IterateParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces, maxDistance, layerMask, minDepth);

        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth) =>
            IterateParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces, maxDistance, layerMask, minDepth, maxDepth);


        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces) =>
            IterateOutParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces);
        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces, float maxDistance) =>
            IterateOutParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces, maxDistance);

        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask) =>
            IterateOutParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces, maxDistance, layerMask);

        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask, float minDepth) =>
            IterateOutParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces, maxDistance, layerMask, minDepth);

        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Ray2D ray, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth) =>
            IterateOutParallelBounce(ray.origin, ray.direction, width, numberOfRays, order, bounces, maxDistance, layerMask, minDepth, maxDepth);



        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces, float maxDistance)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, maxDistance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask, float minDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, minDepth);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, minDepth, maxDepth);
                yield return hits;
            }
        }


        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, out RayLine2D[] rayLines);
                yield return RaycastInfo2D.Create(hits, rayLines);
            }
        }

        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces, float maxDistance)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, maxDistance, out RayLine2D[] rayLines);
                yield return RaycastInfo2D.Create(hits, rayLines);
            }
        }

        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, out RayLine2D[] rayLines);
                yield return RaycastInfo2D.Create(hits, rayLines);
            }
        }

        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask, float minDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, minDepth, out RayLine2D[] rayLines);
                yield return RaycastInfo2D.Create(hits, rayLines);
            }
        }

        public static IEnumerable<RaycastInfo2D[]> IterateOutParallelBounce(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, minDepth, maxDepth, out RayLine2D[] rayLines);
                yield return RaycastInfo2D.Create(hits, rayLines);
            }
        }
    }
}