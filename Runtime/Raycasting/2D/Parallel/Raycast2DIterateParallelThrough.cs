using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Ray2D ray, float width, int numberOfRays, Order order) =>
            IterateParallelThrough(ray.origin, ray.direction, width, numberOfRays, order);

        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Ray2D ray, float width, int numberOfRays, Order order, float maxDistance) =>
            IterateParallelThrough(ray.origin, ray.direction, width, numberOfRays, order, maxDistance);

        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Ray2D ray, float width, int numberOfRays, Order order, float maxDistance, int layerMask) =>
            IterateParallelThrough(ray.origin, ray.direction, width, numberOfRays, order, maxDistance, layerMask);

        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Ray2D ray, float width, int numberOfRays, Order order, float maxDistance, int layerMask, float minDepth) =>
            IterateParallelThrough(ray.origin, ray.direction, width, numberOfRays, order, maxDistance, layerMask, minDepth);

        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Ray2D ray, float width, int numberOfRays, Order order, float maxDistance, int layerMask, float minDepth, float maxDepth) =>
            IterateParallelThrough(ray.origin, ray.direction, width, numberOfRays, order, maxDistance, layerMask, minDepth, maxDepth);


        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Ray2D ray, float width, int numberOfRays, Order order) =>
            IterateOutParallelThrough(ray.origin, ray.direction, width, numberOfRays, order);

        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Ray2D ray, float width, int numberOfRays, Order order, float maxDistance) =>
            IterateOutParallelThrough(ray.origin, ray.direction, width, numberOfRays, order, maxDistance);

        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Ray2D ray, float width, int numberOfRays, Order order, float maxDistance, int layerMask) =>
            IterateOutParallelThrough(ray.origin, ray.direction, width, numberOfRays, order, maxDistance, layerMask);

        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Ray2D ray, float width, int numberOfRays, Order order, float maxDistance, int layerMask, float minDepth) =>
            IterateOutParallelThrough(ray.origin, ray.direction, width, numberOfRays, order, maxDistance, layerMask, minDepth);

        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Ray2D ray, float width, int numberOfRays, Order order, float maxDistance, int layerMask, float minDepth, float maxDepth) =>
            IterateOutParallelThrough(ray.origin, ray.direction, width, numberOfRays, order, maxDistance, layerMask, minDepth, maxDepth);



        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float maxDistance)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, maxDistance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float maxDistance, int layerMask)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, maxDistance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float maxDistance, int layerMask, float minDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, maxDistance, layerMask, minDepth);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit2D[]> IterateParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float maxDistance, int layerMask, float minDepth, float maxDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, maxDistance, layerMask, minDepth, maxDepth);
                yield return hits;
            }
        }


        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction);
                yield return new RaycastInfos2D(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float maxDistance)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, maxDistance);
                yield return new RaycastInfos2D(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float maxDistance, int layerMask)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, maxDistance, layerMask);
                yield return new RaycastInfos2D(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float maxDistance, int layerMask, float minDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, maxDistance, layerMask, minDepth);
                yield return new RaycastInfos2D(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos2D> IterateOutParallelThrough(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float maxDistance, int layerMask, float minDepth, float maxDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, maxDistance, layerMask, minDepth, maxDepth);
                yield return new RaycastInfos2D(hits, ray);
            }
        }
    }
}