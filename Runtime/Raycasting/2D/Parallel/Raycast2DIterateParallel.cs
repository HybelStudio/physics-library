using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static IEnumerable<RaycastHit2D> IterateParallel(Ray2D ray, float width, int numberOfRays, Order order) =>
            IterateParallel(ray.origin, ray.direction, width, numberOfRays, order);

        public static IEnumerable<RaycastHit2D> IterateParallel(Ray2D ray, float width, int numberOfRays, Order order, float distance) =>
            IterateParallel(ray.origin, ray.direction, width, numberOfRays, order, distance);

        public static IEnumerable<RaycastHit2D> IterateParallel(Ray2D ray, float width, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateParallel(ray.origin, ray.direction, width, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastHit2D> IterateParallel(Ray2D ray, float width, int numberOfRays, Order order, float distance, int layerMask, float minDepth) =>
            IterateParallel(ray.origin, ray.direction, width, numberOfRays, order, distance, layerMask, minDepth);

        public static IEnumerable<RaycastHit2D> IterateParallel(Ray2D ray, float width, int numberOfRays, Order order, float distance, int layerMask, float minDepth, float maxDepth) =>
            IterateParallel(ray.origin, ray.direction, width, numberOfRays, order, distance, layerMask, minDepth, maxDepth);


        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Ray2D ray, float width, int numberOfRays, Order order) =>
            IterateOutParallel(ray.origin, ray.direction, width, numberOfRays, order);

        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Ray2D ray, float width, int numberOfRays, Order order, float distance) =>
            IterateOutParallel(ray.origin, ray.direction, width, numberOfRays, order, distance);

        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Ray2D ray, float width, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateOutParallel(ray.origin, ray.direction, width, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Ray2D ray, float width, int numberOfRays, Order order, float distance, int layerMask, float minDepth) =>
            IterateOutParallel(ray.origin, ray.direction, width, numberOfRays, order, distance, layerMask, minDepth);

        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Ray2D ray, float width, int numberOfRays, Order order, float distance, int layerMask, float minDepth, float maxDepth) =>
            IterateOutParallel(ray.origin, ray.direction, width, numberOfRays, order, distance, layerMask, minDepth, maxDepth);



        public static IEnumerable<RaycastHit2D> IterateParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit2D> IterateParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit2D> IterateParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit2D> IterateParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float distance, int layerMask, float minDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit2D> IterateParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float distance, int layerMask, float minDepth, float maxDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth, out RaycastHit2D hit))
                    yield return hit;
        }


        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit2D hit))
                    yield return new RaycastInfo2D(hit, ray);
        }

        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit2D hit))
                    yield return new RaycastInfo2D(hit, ray);
        }

        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit2D hit))
                    yield return new RaycastInfo2D(hit, ray);
        }

        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float distance, int layerMask, float minDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, out RaycastHit2D hit))
                    yield return new RaycastInfo2D(hit, ray);
        }

        public static IEnumerable<RaycastInfo2D> IterateOutParallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order, float distance, int layerMask, float minDepth, float maxDepth)
        {
            if (numberOfRays < 0)
                yield break;

            var rays = GetEnumerableParallelRays(origin, direction, width, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth, out RaycastHit2D hit))
                    yield return new RaycastInfo2D(hit, ray);
        }


        public static IEnumerable<Ray2D> GetEnumerableParallelRays(Vector2 origin, Vector2 direction, float width, int numberOfRays, Order order)
        {
            direction.Normalize();
            ParallelSetup(direction, width, out Vector2 perpDirection, out Vector2 halfPerpDirection);

            if (width == 0f)
                return SingleRay(origin, direction);

            return order switch
            {
                Order.RightToLeft => OrderRightToLeft(numberOfRays, origin, halfPerpDirection, perpDirection, direction),
                Order.CenterOutLeftFirst => OrderCenterOutLeftFirst(width, numberOfRays, origin, halfPerpDirection, direction),
                Order.CenterOutRightFirst => OrderCenterOutRightFirst(width, numberOfRays, origin, halfPerpDirection, direction),
                Order.PingPongLeftFirst => OrderPingPongLeftFirst(width, numberOfRays, origin, halfPerpDirection, direction),
                Order.PingPongRightFirst => OrderPingPongRightFirst(width, numberOfRays, origin, halfPerpDirection, direction),
                _ => OrderLeftToRight(numberOfRays, origin, halfPerpDirection, perpDirection, direction),
            };

            static void ParallelSetup(Vector2 direction, float width, out Vector2 perpDirection, out Vector2 halfPerpDirection)
            {

                perpDirection = Vector2.Perpendicular(direction).normalized * width;
                halfPerpDirection = perpDirection / 2;
            }

            static IEnumerable<Ray2D> SingleRay(Vector2 origin, Vector2 direction)
            {
                yield return new Ray2D(origin, direction);
            }

            static IEnumerable<Ray2D> OrderLeftToRight(int numberOfRays, Vector2 origin, Vector2 halfPerpDirection, Vector2 perpDirection, Vector2 direction)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                    yield return new Ray2D(newOrigin, direction);
                }
            }

            static IEnumerable<Ray2D> OrderRightToLeft(int numberOfRays, Vector2 origin, Vector2 halfPerpDirection, Vector2 perpDirection, Vector2 direction)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    Vector2 newOrigin = origin + (halfPerpDirection - (perpDirection / (numberOfRays - 1)) * i);
                    yield return new Ray2D(newOrigin, direction);
                }
            }

            static IEnumerable<Ray2D> OrderCenterOutLeftFirst(float width, int numberOfRays, Vector2 origin, Vector2 halfPerpDirection, Vector2 direction)
            {
                float increment = width / (numberOfRays - 1);
                for (int i = 0; i < numberOfRays; i++)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? 1 : -1);
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float magnitude = (increment * multiplier) - (evenAmountOfRays ? increment * .5f * sign : 0f);
                    Vector2 newOrigin = origin + halfPerpDirection.normalized * magnitude;
                    yield return new Ray2D(newOrigin, direction);
                }
            }

            static IEnumerable<Ray2D> OrderCenterOutRightFirst(float width, int numberOfRays, Vector2 origin, Vector2 halfPerpDirection, Vector2 direction)
            {
                float increment = width / (numberOfRays - 1);
                for (int i = 0; i < numberOfRays; i++)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? -1 : 1); // sign is flipped here to reverse the order
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float magnitude = increment * multiplier - (evenAmountOfRays ? increment * .5f * sign : 0f);
                    Vector2 newOrigin = origin + halfPerpDirection.normalized * magnitude;
                    yield return new Ray2D(newOrigin, direction);
                }
            }

            static IEnumerable<Ray2D> OrderPingPongLeftFirst(float width, int numberOfRays, Vector2 origin, Vector2 halfPerpDirection, Vector2 direction)
            {
                float increment = width / (numberOfRays - 1);
                for (int i = numberOfRays - 1; i >= 0; i--)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? -1 : 1); // sign is flipped here to compensate for reversing the loop
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float magnitude = (increment * multiplier - (evenAmountOfRays ? increment * .5f * sign : 0f));
                    Vector2 newOrigin = origin + halfPerpDirection.normalized * magnitude;
                    yield return new Ray2D(newOrigin, direction);
                }
            }

            static IEnumerable<Ray2D> OrderPingPongRightFirst(float width, int numberOfRays, Vector2 origin, Vector2 halfPerpDirection, Vector2 direction)
            {
                float increment = width / (numberOfRays - 1);
                for (int i = numberOfRays - 1; i >= 0; i--)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? 1 : -1); // sign not flipped since the reversed loop already does so
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float magnitude = (increment * multiplier - (evenAmountOfRays ? increment * .5f * sign : 0f));
                    Vector2 newOrigin = origin + halfPerpDirection.normalized * magnitude;
                    yield return new Ray2D(newOrigin, direction);
                }
            }
        }
    }
}