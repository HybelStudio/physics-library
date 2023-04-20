using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, int numberOfRays) =>
            IterateSphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays);

        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, int numberOfRays, float distance) =>
            IterateSphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance);

        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, int numberOfRays, int layerMask) =>
            IterateSphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, layerMask);

        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, int numberOfRays, float distance, int layerMask) =>
            IterateSphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, layerMask);

        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            IterateSphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, layerMask, queryTriggerInteraction);


        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, float turnFraction, int numberOfRays)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, float turnFraction, int numberOfRays, float distance)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, float turnFraction, int numberOfRays, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, float turnFraction, int numberOfRays, float distance, int layerMask)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask);
                yield return hits;
            }
        }

        public static IEnumerable<RaycastHit[]> IterateSphereThrough(Vector3 origin, float turnFraction, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            if (numberOfRays <= 0)
                yield break;

            var rays = GetEnumerableSphereRays(origin, turnFraction, numberOfRays);

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask, queryTriggerInteraction);
                yield return hits;
            }
        }
    }
}
