using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order) =>
            IterateParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order);

        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance) =>
            IterateParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order, distance);

        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, int layerMask) =>
            IterateParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order, layerMask);

        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order) =>
            IterateOutParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order);

        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance) =>
            IterateOutParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order, distance);

        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, int layerMask) =>
            IterateOutParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order, layerMask);

        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateOutParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateOutParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, order, distance, layerMask, queryTriggerInteraction);



        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance, layerMask, queryTriggerInteraction);
                yield return hits;
            }
        }


        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction);
                yield return new RaycastInfos(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance);
                yield return new RaycastInfos(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, layerMask);
                yield return new RaycastInfos(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance, layerMask);
                yield return new RaycastInfos(hits, ray);
            }
        }

        public static IEnumerable<RaycastInfos> IterateOutParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Through(ray.origin, ray.direction, distance, layerMask, queryTriggerInteraction);
                yield return new RaycastInfos(hits, ray);
            }
        }
    }
}
