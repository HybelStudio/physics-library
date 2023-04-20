using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit> IterateParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order) =>
            IterateParallel(ray.origin, ray.direction, normal, width, numberOfRays, order);

        public static IEnumerable<RaycastHit> IterateParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance) =>
            IterateParallel(ray.origin, ray.direction, normal, width, numberOfRays, order, distance);

        public static IEnumerable<RaycastHit> IterateParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, int layerMask) =>
            IterateParallel(ray.origin, ray.direction, normal, width, numberOfRays, order, layerMask);

        public static IEnumerable<RaycastHit> IterateParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateParallel(ray.origin, ray.direction, normal, width, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastHit> IterateParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateParallel(ray.origin, ray.direction, normal, width, numberOfRays, order, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastInfo> IterateOutParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order) =>
            IterateOutParallel(ray.origin, ray.direction, normal, width, numberOfRays, order);

        public static IEnumerable<RaycastInfo> IterateOutParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance) =>
            IterateOutParallel(ray.origin, ray.direction, normal, width, numberOfRays, order, distance);

        public static IEnumerable<RaycastInfo> IterateOutParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, int layerMask) =>
            IterateOutParallel(ray.origin, ray.direction, normal, width, numberOfRays, order, layerMask);

        public static IEnumerable<RaycastInfo> IterateOutParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateOutParallel(ray.origin, ray.direction, normal, width, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastInfo> IterateOutParallel(Ray ray, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateOutParallel(ray.origin, ray.direction, normal, width, numberOfRays, order, distance, layerMask, queryTriggerInteraction);



        public static IEnumerable<RaycastHit> IterateParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, layerMask, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    yield return hit;
        }


        public static IEnumerable<RaycastInfo> IterateOutParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }

        public static IEnumerable<RaycastInfo> IterateOutParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }

        public static IEnumerable<RaycastInfo> IterateOutParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, layerMask, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }

        public static IEnumerable<RaycastInfo> IterateOutParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }

        public static IEnumerable<RaycastInfo> IterateOutParallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, normal, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    yield return new RaycastInfo(hit, ray);
        }


        public static IEnumerable<Ray> GetEnumerableParallelRays(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, Order order)
        {
            direction.Normalize();
            ParallelSetup(direction, normal, width, out Vector3 perpDirection, out Vector3 halfPerpDirection);

            if (width == 0f)
                return SingleRay(origin, direction);

            return order switch
            {
                Order.RightToLeft => OrderRightTotleft(numberOfRays, origin, halfPerpDirection, perpDirection, direction),
                Order.CenterOutLeftFirst => OrderCenterOutLeft(width, numberOfRays, origin, halfPerpDirection, direction),
                Order.CenterOutRightFirst => OrderCenterOutRight(width, numberOfRays, origin, halfPerpDirection, direction),
                Order.PingPongLeftFirst => OrderPingPongLeft(width, numberOfRays, origin, halfPerpDirection, direction),
                Order.PingPongRightFirst => OrderPingPongRight(width, numberOfRays, origin, halfPerpDirection, direction),
                _ => OrderLeftToRight(numberOfRays, origin, halfPerpDirection, perpDirection, direction),
            };

            static void ParallelSetup(Vector3 direction, Vector3 normal, float width, out Vector3 perpDirection, out Vector3 halfPerpDirection)
            {
                perpDirection = direction.Cross(normal).SetMagnitude(width);
                halfPerpDirection = perpDirection / 2;
            }

            static IEnumerable<Ray> SingleRay(Vector3 origin, Vector3 direction)
            {
                yield return new Ray(origin, direction);
            }

            static IEnumerable<Ray> OrderLeftToRight(int numberOfRays, Vector3 origin, Vector3 halfPerpDirection, Vector3 perpDirection, Vector3 direction)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    Vector3 newOrigin = origin + (halfPerpDirection - (perpDirection / (numberOfRays - 1)) * i);
                    yield return new Ray(newOrigin, direction);
                }
            }

            static IEnumerable<Ray> OrderRightTotleft(int numberOfRays, Vector3 origin, Vector3 halfPerpDirection, Vector3 perpDirection, Vector3 direction)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    Vector3 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                    yield return new Ray(newOrigin, direction);
                }
            }

            static IEnumerable<Ray> OrderCenterOutLeft(float width, int numberOfRays, Vector3 origin, Vector3 halfPerpDirection, Vector3 direction)
            {
                float increment = width / (numberOfRays - 1);
                for (int i = 0; i < numberOfRays; i++)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? -1 : 1);
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float magnitude = (increment * multiplier) - (evenAmountOfRays ? increment * .5f * sign : 0f);
                    Vector3 newOrigin = origin + halfPerpDirection.normalized * magnitude;
                    yield return new Ray(newOrigin, direction);
                }
            }

            static IEnumerable<Ray> OrderCenterOutRight(float width, int numberOfRays, Vector3 origin, Vector3 halfPerpDirection, Vector3 direction)
            {
                float increment = width / (numberOfRays - 1);
                for (int i = 0; i < numberOfRays; i++)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? 1 : -1); // sign is flipped here to reverse the order
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float magnitude = (increment * multiplier) - (evenAmountOfRays ? increment * .5f * sign : 0f);
                    Vector3 newOrigin = origin + halfPerpDirection.normalized * magnitude;
                    yield return new Ray(newOrigin, direction);
                }
            }

            static IEnumerable<Ray> OrderPingPongLeft(float width, int numberOfRays, Vector3 origin, Vector3 halfPerpDirection, Vector3 direction)
            {
                float increment = width / (numberOfRays - 1);
                for (int i = numberOfRays - 1; i >= 0; i--)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? 1 : -1); // sign is flipped here to compoensate for reversign the loop
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float magnitude = (increment * multiplier) - (evenAmountOfRays ? increment * .5f * sign : 0f);
                    Vector3 newOrigin = origin + halfPerpDirection.normalized * magnitude;
                    yield return new Ray(newOrigin, direction);
                }
            }

            static IEnumerable<Ray> OrderPingPongRight(float width, int numberOfRays, Vector3 origin, Vector3 halfPerpDirection, Vector3 direction)
            {
                float increment = width / (numberOfRays - 1);
                for (int i = numberOfRays - 1; i >= 0; i--)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? -1 : 1); // sign is not flipped here since the lopp already does so
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float magnitude = (increment * multiplier) - (evenAmountOfRays ? increment * .5f * sign : 0f);
                    Vector3 newOrigin = origin + halfPerpDirection.normalized * magnitude;
                    yield return new Ray(newOrigin, direction);
                }
            }
        }
    }
}
