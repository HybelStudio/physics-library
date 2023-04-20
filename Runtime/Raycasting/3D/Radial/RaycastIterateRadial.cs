using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit> IterateRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order) =>
            IterateRadial(ray.origin, ray.direction, normal, angle, numberOfRays, order);

        public static IEnumerable<RaycastHit> IterateRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order, float distance) =>
            IterateRadial(ray.origin, ray.direction, normal, angle, numberOfRays, order, distance);

        public static IEnumerable<RaycastHit> IterateRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order, int layerMask) =>
            IterateRadial(ray.origin, ray.direction, normal, angle, numberOfRays, order, layerMask);

        public static IEnumerable<RaycastHit> IterateRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order, float distance, int layerMask) =>
            IterateRadial(ray.origin, ray.direction, normal, angle, numberOfRays, order, distance, layerMask);

        public static IEnumerable<RaycastHit> IterateRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateRadial(ray.origin, ray.direction, normal, angle, numberOfRays, order, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastHit> IterateRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray, distance, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray, layerMask, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order order, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableRadialRays(origin, direction, normal, angle, numberOfRays, order);

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    yield return hit;
        }


        public static IEnumerable<Ray> GetEnumerableRadialRays(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, Order? order)
        {
            direction.Normalize();
            RadialSetup(direction, normal, angle, ref numberOfRays, out float halfAngle, out float angleIncrement, out Vector3 right);

            if (angle == 0f)
                return SingleRay(origin, direction);

            return order switch
            {
                Order.RightToLeft => OrderRightToLeft(numberOfRays, halfAngle, angleIncrement, direction, right, origin),
                Order.CenterOutLeftFirst => OrderCenterOutLeft(numberOfRays, angleIncrement, direction, right, origin),
                Order.CenterOutRightFirst => OrderCenterOutRight(numberOfRays, angleIncrement, direction, right, origin),
                Order.PingPongLeftFirst => OrderPingPongLeft(numberOfRays, angleIncrement, direction, right, origin),
                Order.PingPongRightFirst => OrderPingPongRight(numberOfRays, angleIncrement, direction, right, origin),
                _ => OrderLeftToRight(numberOfRays, halfAngle, angleIncrement, direction, right, origin),
            };

            static void RadialSetup(Vector3 direction, Vector3 normal, float angle, ref int numberOfRays, out float halfAngle, out float angleIncrement, out Vector3 right)
            {
                halfAngle = angle * .5f;
                bool angleIsMultipleOf360 = (angle % 360 == 0);

                if (angleIsMultipleOf360)
                    numberOfRays--;

                angleIncrement = angle / (numberOfRays - (angleIsMultipleOf360 ? 0 : 1));
                right = Vector3.Cross(direction, normal);
            }

            static IEnumerable<Ray> SingleRay(Vector3 origin, Vector3 direction)
            {
                yield return new Ray(origin, direction);
            }

            static IEnumerable<Ray> OrderLeftToRight(int numberOfRays, float halfAngle, float angleIncrement, Vector3 direction, Vector3 right, Vector3 origin)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    float currentAngle = halfAngle - angleIncrement * i + 90f; // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector3 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray ray = new Ray(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray> OrderRightToLeft(int numberOfRays, float halfAngle, float angleIncrement, Vector3 direction, Vector3 right, Vector3 origin)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    float currentAngle = -halfAngle + angleIncrement * i + 90f; // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector3 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    yield return new Ray(origin, newDirection);
                }
            }

            static IEnumerable<Ray> OrderCenterOutLeft(int numberOfRays, float angleIncrement, Vector3 direction, Vector3 right, Vector3 origin)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? -1 : 1);
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float currentAngle = angleIncrement * multiplier + 90f - (evenAmountOfRays ? angleIncrement * .5f * sign : 0f); // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector3 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray ray = new Ray(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray> OrderCenterOutRight(int numberOfRays, float angleIncrement, Vector3 direction, Vector3 right, Vector3 origin)
            {
                for (int i = 0; i < numberOfRays; i++)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? 1 : -1); // Sign flipped here to reverse the order
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float currentAngle = angleIncrement * multiplier + 90f - (evenAmountOfRays ? angleIncrement * .5f * sign : 0f); // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector3 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray ray = new Ray(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray> OrderPingPongLeft(int numberOfRays, float angleIncrement, Vector3 direction, Vector3 right, Vector3 origin)
            {
                for (int i = numberOfRays - 1; i >= 0; i--)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? 1 : -1); // sign is flipped here to compensate for reversing the loop
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float currentAngle = angleIncrement * multiplier + 90f - (evenAmountOfRays ? angleIncrement * .5f * sign : 0f); // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector3 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray ray = new Ray(origin, newDirection);

                    yield return ray;
                }
            }

            static IEnumerable<Ray> OrderPingPongRight(int numberOfRays, float angleIncrement, Vector3 direction, Vector3 right, Vector3 origin)
            {
                for (int i = numberOfRays - 1; i >= 0; i--)
                {
                    bool evenAmountOfRays = numberOfRays % 2 == 0;
                    int sign = (evenAmountOfRays ? -1 : 1) * (i % 2 == 0 ? -1 : 1); // sign not flipped since the reversed loop already does so
                    int multiplier = sign * (i + (evenAmountOfRays ? 2 : 1)) / 2;

                    float currentAngle = angleIncrement * multiplier + 90f - (evenAmountOfRays ? angleIncrement * .5f * sign : 0f); // Reallign to match forward direction.
                    float currentRadian = currentAngle * Mathf.Deg2Rad;

                    Vector3 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                    Ray ray = new Ray(origin, newDirection);

                    yield return ray;
                }
            }
        }
    }
}
