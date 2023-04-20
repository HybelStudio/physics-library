using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder) =>
            IterateLayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, layeredWidth, numberOfLayers, layeredOrder, parallelOrder);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder) =>
            IterateLayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, layeredWidth, numberOfLayers, layeredOrder, parallelOrder, distance);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, int layerMask, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder) =>
            IterateLayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, layeredWidth, numberOfLayers, layeredOrder, parallelOrder, layerMask);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, int layerMask, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder) =>
            IterateLayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, layeredWidth, numberOfLayers, layeredOrder, parallelOrder, distance, layerMask);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder) =>
            IterateLayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, layeredWidth, numberOfLayers, layeredOrder, parallelOrder, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastHit> Cast(Ray layer) => IterateParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder);
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder, float distance)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastHit> Cast(Ray layer) => IterateParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder, distance);
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastHit> Cast(Ray layer) => IterateParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder, layerMask);
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder, float distance, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastHit> Cast(Ray layer) => IterateParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder, distance, layerMask);
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastHit> Cast(Ray layer) => IterateParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder, distance, layerMask, queryTriggerInteraction);
        }


        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastInfo> Cast(Ray layer) => IterateOutParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder);
        }

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder, float distance)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastInfo> Cast(Ray layer) => IterateOutParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder, distance);
        }

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastInfo> Cast(Ray layer) => IterateOutParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder, layerMask);
        }

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder, float distance, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastInfo> Cast(Ray layer) => IterateOutParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder, distance, layerMask);
        }

        public static IEnumerable<IEnumerable<RaycastInfo>> IterateOutLayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float layeredWidth, int numberOfLayers, VerticalOrder layeredOrder, HorizontalOrder parallelOrder, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfLayers <= 0)
                yield break;

            var right = Vector3.Cross(direction, up);
            var layers = GetEnumerableParallelRays(origin, direction, right, layeredWidth, numberOfLayers, (Order)layeredOrder);

            if (numberOfLayers == 1)
            {
                yield return Cast(new Ray(origin, direction));
                yield break;
            }

            foreach (var layer in layers)
                yield return Cast(layer);

            IEnumerable<RaycastInfo> Cast(Ray layer) => IterateOutParallel(layer.origin, layer.direction, up, width, numberOfRays, (Order)parallelOrder, distance, layerMask, queryTriggerInteraction);
        }
    }
}
