using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] SphereThrough(Vector3 origin, int numberOfRays, bool distinctHits = false) =>
            SphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, distinctHits);

        public static RaycastHit[][] SphereThrough(Vector3 origin, int numberOfRays, float distance, bool distinctHits = false) =>
            SphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, distinctHits);

        public static RaycastHit[][] SphereThrough(Vector3 origin, int numberOfRays, int layerMask, bool distinctHits = false) =>
            SphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, layerMask, distinctHits);

        public static RaycastHit[][] SphereThrough(Vector3 origin, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            SphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit[][] SphereThrough(Vector3 origin, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            SphereThrough(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] SphereThrough(Vector3 origin, float turnFraction, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] SphereThrough(Vector3 origin, float turnFraction, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] SphereThrough(Vector3 origin, float turnFraction, int numberOfRays, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] SphereThrough(Vector3 origin, float turnFraction, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] SphereThrough(Vector3 origin, float turnFraction, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hits = Through(ray, distance, layerMask, queryTriggerInteraction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }
    }
}
