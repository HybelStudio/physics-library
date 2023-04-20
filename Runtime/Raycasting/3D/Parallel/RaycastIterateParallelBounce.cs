using Hybel.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order) =>
            IterateParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order);

        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance) =>
            IterateParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order, distance);

        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order, int layerMask) =>
            IterateParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order, layerMask);

        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance, int layerMask) =>
            IterateParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order, distance, layerMask);

        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order) =>
            IterateOutParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order);

        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance) =>
            IterateOutParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order, distance);

        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order, int layerMask) =>
            IterateOutParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order, layerMask);

        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance, int layerMask) =>
            IterateOutParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order, distance, layerMask);

        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateOutParallelBounce(ray.origin, ray.direction, normal, width, numberOfRays, bounces, order, distance, layerMask, queryTriggerInteraction);



        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance, layerMask, queryTriggerInteraction);
                yield return hits;
            }
        }


        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }

        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }

        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, layerMask);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }

        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance, layerMask);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }

        public static IEnumerable<RaycastInfo[]> IterateOutParallelBounce(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
            {
                var hits = Bounce(ray.origin, ray.direction, bounces, distance, layerMask, queryTriggerInteraction);
                yield return hits.Select(hit => new RaycastInfo(hit, ray)).ToArray();
            }
        }
    }
}
