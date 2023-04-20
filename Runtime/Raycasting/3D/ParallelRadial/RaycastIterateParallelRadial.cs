using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit> IterateParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays) =>
            IterateParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays);

        public static IEnumerable<RaycastHit> IterateParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance) =>
            IterateParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance);

        public static IEnumerable<RaycastHit> IterateParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, int layerMask) =>
            IterateParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerMask);

        public static IEnumerable<RaycastHit> IterateParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask) =>
            IterateParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask);

        public static IEnumerable<RaycastHit> IterateParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays) =>
            IterateOutParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays);

        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance) =>
            IterateOutParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance);

        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, int layerMask) =>
            IterateOutParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerMask);

        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask) =>
            IterateOutParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask);

        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateOutParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, queryTriggerInteraction);



        public static IEnumerable<RaycastHit> IterateParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, layerMask, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    yield return hit;
        }


        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }

        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }

        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, layerMask, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }

        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }

        public static IEnumerable<RaycastInfo> IterateOutParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }


        public static IEnumerable<Ray> GetEnumerableParallelRadialRays(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays)
        {
            ParallelRadialSetup(direction, normal, numberOfRays, out Vector3 right, out float angleIncrement);

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentRadian = angleIncrement * i * Mathf.Deg2Rad;
                Vector3 newOrigin = origin + ((normal * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian)) * radius);
                yield return new Ray(newOrigin, direction);
            }

            static void ParallelRadialSetup(Vector3 direction, Vector3 normal, int numberOfRays, out Vector3 right, out float angleIncrement)
            {
                right = direction.Cross(normal);
                angleIncrement = 360f / numberOfRays;
            }
        }
    }
}
