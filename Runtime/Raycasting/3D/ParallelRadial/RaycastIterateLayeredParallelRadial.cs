using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers) =>
            IterateLayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance) =>
            IterateLayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, int layerMask) =>
            IterateLayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, layerMask);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask) =>
            IterateLayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance, layerMask);

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateLayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers)
        {
            if (numberOfLayers <= 0)
                yield break;

            var raduises = Radiuses(radius, layerWidth, numberOfLayers);

            foreach (var newRadius in raduises)
                yield return ParallelRadial(origin, direction, normal, newRadius, numberOfRays);

            static IEnumerable<float> Radiuses(float radius, float layerWidth, int numberOfLayers)
            {
                for (int i = 0; i < numberOfLayers; i++)
                    yield return radius + layerWidth * i;
            }
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance)
        {
            if (numberOfLayers <= 0)
                yield break;

            var raduises = Radiuses(radius, layerWidth, numberOfLayers);

            foreach (var newRadius in raduises)
                yield return ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance);

            static IEnumerable<float> Radiuses(float radius, float layerWidth, int numberOfLayers)
            {
                for (int i = 0; i < numberOfLayers; i++)
                    yield return radius + layerWidth * i;
            }
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var raduises = Radiuses(radius, layerWidth, numberOfLayers);

            foreach (var newRadius in raduises)
                yield return ParallelRadial(origin, direction, normal, newRadius, numberOfRays, layerMask);

            static IEnumerable<float> Radiuses(float radius, float layerWidth, int numberOfLayers)
            {
                for (int i = 0; i < numberOfLayers; i++)
                    yield return radius + layerWidth * i;
            }
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask)
        {
            if (numberOfLayers <= 0)
                yield break;

            var raduises = Radiuses(radius, layerWidth, numberOfLayers);

            foreach (var newRadius in raduises)
                yield return ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance, layerMask);

            static IEnumerable<float> Radiuses(float radius, float layerWidth, int numberOfLayers)
            {
                for (int i = 0; i < numberOfLayers; i++)
                    yield return radius + layerWidth * i;
            }
        }

        public static IEnumerable<IEnumerable<RaycastHit>> IterateLayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfLayers <= 0)
                yield break;

            var raduises = Radiuses(radius, layerWidth, numberOfLayers);

            foreach (var newRadius in raduises)
                yield return ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance, layerMask, queryTriggerInteraction);

            static IEnumerable<float> Radiuses(float radius, float layerWidth, int numberOfLayers)
            {
                for (int i = 0; i < numberOfLayers; i++)
                    yield return radius + layerWidth * i;
            }
        }
    }
}