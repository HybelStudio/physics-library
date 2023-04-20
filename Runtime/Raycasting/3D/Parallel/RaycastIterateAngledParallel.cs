using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder) =>
            IterateAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance) =>
            IterateAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder, distance);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, int layerMask) =>
            IterateAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder, layerMask);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance, int layerMask) =>
            IterateAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder, distance, layerMask);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder) =>
            IterateOutAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder);

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance) =>
            IterateOutAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder, distance);

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, int layerMask) =>
            IterateOutAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder, layerMask);

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance, int layerMask) =>
            IterateOutAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder, distance, layerMask);

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateOutAngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, angledOrder, parallelOrder, distance, layerMask, queryTriggerInteraction);



        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastHit> Cast(Ray ray) => IterateParallel(ray, up, width, numberOfRays, (Order)parallelOrder);
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastHit> Cast(Ray ray) => IterateParallel(ray, up, width, numberOfRays, (Order)parallelOrder, distance);
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastHit> Cast(Ray ray) => IterateParallel(ray, up, width, numberOfRays, (Order)parallelOrder, layerMask);
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastHit> Cast(Ray ray) => IterateParallel(ray, up, width, numberOfRays, (Order)parallelOrder, distance, layerMask);
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastHit> Cast(Ray ray) => IterateParallel(ray, up, width, numberOfRays, (Order)parallelOrder, distance, layerMask, queryTriggerInteraction);
        }


        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastInfo> Cast(Ray ray) => IterateOutParallel(ray, up, width, numberOfRays, (Order)parallelOrder);
        }

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastInfo> Cast(Ray ray) => IterateOutParallel(ray, up, width, numberOfRays, (Order)parallelOrder, distance);
        }

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastInfo> Cast(Ray ray) => IterateOutParallel(ray, up, width, numberOfRays, (Order)parallelOrder, layerMask);
        }

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastInfo> Cast(Ray ray) => IterateOutParallel(ray, up, width, numberOfRays, (Order)parallelOrder, distance, layerMask);
        }

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutAngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, VerticalOrder angledOrder, HorizontalOrder parallelOrder, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var rays = GetEnumerableRadialRays(origin, direction, right, angle, numberOfRays, (Order)angledOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var ray in rays)
                yield return Cast(ray);

            IEnumerable<RaycastInfo> Cast(Ray ray) => IterateOutParallel(ray, up, width, numberOfRays, (Order)parallelOrder, distance, layerMask, queryTriggerInteraction);
        }
    }
}
