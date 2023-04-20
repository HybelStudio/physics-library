using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, int numberOfRays) =>
            IterateSphere(origin, TURN_FRACTION_DEFAULT, numberOfRays);

        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, int numberOfRays, float distance) =>
            IterateSphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance);

        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, int numberOfRays, int layerMask) =>
            IterateSphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, layerMask);

        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, int numberOfRays, float distance, int layerMask) =>
            IterateSphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, layerMask);

        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateSphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, float turnFraction, int numberOfRays)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, float turnFraction, int numberOfRays, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, float turnFraction, int numberOfRays, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, layerMask, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, float turnFraction, int numberOfRays, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<RaycastHit> IterateSphere(Vector3 origin, float turnFraction, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    yield return hit;
        }

        public static IEnumerable<Ray> GetEnumerableSphereRays(Vector3 origin, float turnFraction, int numberOfRays)
        {
            for (int i = 0; i < numberOfRays; i++)
            {
                float t = i / (numberOfRays - 1f);
                float inclination = Mathf.Acos(1 - 2 * t);
                float azimuth = 2 * Mathf.PI * turnFraction * i;

                float x = Mathf.Sin(inclination) * Mathf.Cos(azimuth);
                float y = Mathf.Sin(inclination) * Mathf.Sin(azimuth);
                float z = Mathf.Cos(inclination);

                var point = new Vector3(x, y, z);
                var direction = origin.DirectionTo(origin + point);

                yield return new Ray(origin, direction);
            }
        }
    }
}
