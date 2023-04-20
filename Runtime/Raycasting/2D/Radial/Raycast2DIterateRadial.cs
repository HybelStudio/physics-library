using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{

    public partial class Raycast2D : RaycastAPI
    {
        public static IEnumerable<RaycastHit2D> IterateRadial(Ray2D ray, float angle, int numberOfRays, Order order) =>
            IterateRadial(ray.origin, ray.direction, angle, numberOfRays, order);

        public static IEnumerable<RaycastHit2D> IterateRadial(Ray2D ray, float angle, int numberOfRays, Order order, float distance) =>
            IterateRadial(ray.origin, ray.direction, angle, numberOfRays, order, distance);

        public static IEnumerable<RaycastHit2D> IterateRadial(Ray2D ray, float angle, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateRadial(ray.origin, ray.direction, angle, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastHit2D> IterateRadial(Ray2D ray, float angle, int numberOfRays, Order order, float distance, int layerMask, float minDepth) =>
            IterateRadial(ray.origin, ray.direction, angle, numberOfRays, order, distance, layerMask, minDepth);

        public static IEnumerable<RaycastHit2D> IterateRadial(Ray2D ray, float angle, int numberOfRays, Order order, float distance, int layerMask, float minDepth, float maxDepth) =>
            IterateRadial(ray.origin, ray.direction, angle, numberOfRays, order, distance, layerMask, minDepth, maxDepth);


        public static IEnumerable<RaycastHit2D> IterateRadial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order)
        {
            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);
            
            return rays is null ? null : IterateRadial(rays);
        }

        public static IEnumerable<RaycastHit2D> IterateRadial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, float distance)
        {
            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            return rays is null ? null : IterateRadial(rays, distance);
        }

        public static IEnumerable<RaycastHit2D> IterateRadial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, float distance, int layerMask)
        {
            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            return rays is null ? null : IterateRadial(rays, distance, layerMask);
        }

        public static IEnumerable<RaycastHit2D> IterateRadial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, float distance, int layerMask, float minDepth)
        {
            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            return rays is null ? null : IterateRadial(rays, distance, layerMask, minDepth);
        }

        public static IEnumerable<RaycastHit2D> IterateRadial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order order, float distance, int layerMask, float minDepth, float maxDepth)
        {
            var rays = GetEnumerableRadialRays(origin, direction, angle, numberOfRays, order);

            return rays is null ? null : IterateRadial(rays, distance, layerMask, minDepth, maxDepth);
        }


        public static IEnumerable<RaycastHit2D> IterateRadial(IEnumerable<Ray2D> rays)
        {
            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit2D> IterateRadial(IEnumerable<Ray2D> rays, float distance)
        {
            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit2D> IterateRadial(IEnumerable<Ray2D> rays, float distance, int layerMask)
        {
            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit2D> IterateRadial(IEnumerable<Ray2D> rays, float distance, int layerMask, float minDepth)
        {
            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit2D> IterateRadial(IEnumerable<Ray2D> rays, float distance, int layerMask, float minDepth, float maxDepth)
        {
            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth, out RaycastHit2D hit))
                    yield return hit;
        }

        public static IEnumerable<Ray2D> GetEnumerableRadialRays(Vector2 origin, Vector2 direction, float angle, int numberOfRays, Order? order)
        {
            if (numberOfRays <= 0)
                return null;

            direction.Normalize();
            RadialSetup(direction, angle, ref numberOfRays, out float halfAngle, out float angleIncrement, out Vector2 right);

            if (angle == 0f)
                return SingleRay(origin, direction);

            return order switch
            {
                Order.RightToLeft => OrderRightToLeft(numberOfRays, halfAngle, angleIncrement, direction, right, origin),
                Order.CenterOutLeftFirst => OrderCenterOutLeft(numberOfRays, angleIncrement, direction, right, origin),
                Order.CenterOutRightFirst => OrderCenterOutRight(numberOfRays, angleIncrement, direction, right, origin),
                Order.PingPongLeftFirst => OrderPingPongLeftFirst(numberOfRays, angleIncrement, direction, right, origin),
                Order.PingPongRightFirst => OrderPingPongRightFirst(numberOfRays, angleIncrement, direction, right, origin),
                _ => OrderLeftToRight(numberOfRays, halfAngle, angleIncrement, direction, right, origin),
            };

            static void RadialSetup(Vector2 direction, float angle, ref int numberOfRays, out float halfAngle, out float angleIncrement, out Vector2 right)
            {
                halfAngle = angle * .5f;
                bool angleIsMultipleOf360 = (angle % 360 == 0);

                if (angleIsMultipleOf360)
                    numberOfRays--;

                angleIncrement = angle / (numberOfRays - (angleIsMultipleOf360 ? 0 : 1));
                right = -Vector2.Perpendicular(direction);
            }

            static IEnumerable<Ray2D> SingleRay(Vector2 origin, Vector2 direction)
            {
                yield return new Ray2D(origin, direction);
            }

            static IEnumerable<Ray2D> OrderLeftToRight(int numberOfRays, float halfAngle, float angleIncrement, Vector2 direction, Vector2 right, Vector2 origin)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    float currentAngle = halfAngle - angleIncrement * i + 90f; // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector2 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray2D ray = new Ray2D(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray2D> OrderRightToLeft(int numberOfRays, float halfAngle, float angleIncrement, Vector2 direction, Vector2 right, Vector2 origin)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    float currentAngle = -halfAngle + angleIncrement * i + 90f; // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector2 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray2D ray = new Ray2D(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray2D> OrderCenterOutLeft(int numberOfRays, float angleIncrement, Vector2 direction, Vector2 right, Vector2 origin)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? -1 : 1);
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float currentAngle = angleIncrement * multiplier + 90f - (evenAmountOfRays ? angleIncrement * .5f * sign : 0f); // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector2 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray2D ray = new Ray2D(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray2D> OrderCenterOutRight(int numberOfRays, float angleIncrement, Vector2 direction, Vector2 right, Vector2 origin)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? 1 : -1); // Sign flipped here to reverse the order
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float currentAngle = angleIncrement * multiplier + 90f - (evenAmountOfRays ? angleIncrement * .5f * sign : 0f); // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector2 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray2D ray = new Ray2D(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray2D> OrderPingPongLeftFirst(int numberOfRays, float angleIncrement, Vector2 direction, Vector2 right, Vector2 origin)
            {
                for (int i = numberOfRays - 1; i >= 0; i--)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? 1 : -1); // sign is flipped here to compensate for reversing the loop
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float currentAngle = angleIncrement * multiplier + 90f - (evenAmountOfRays ? angleIncrement * .5f * sign : 0f); // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector2 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray2D ray = new Ray2D(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray2D> OrderPingPongRightFirst(int numberOfRays, float angleIncrement, Vector2 direction, Vector2 right, Vector2 origin)
            {
                for (int i = numberOfRays - 1; i >= 0; i--)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? -1 : 1); // sign not flipped since the reversed loop already does so
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float currentAngle = angleIncrement * multiplier + 90f - (evenAmountOfRays ? angleIncrement * .5f * sign : 0f); // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector2 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray2D ray = new Ray2D(origin, newDirection);

                    yield return ray;
                }
            }
        }
    }
}
