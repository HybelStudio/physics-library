using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        private const float TURN_FRACTION_DEFAULT = 0.618f;

        public static RaycastHit[] Sphere(Vector3 origin, int numberOfRays, bool distinctHits = false) =>
            Sphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, distinctHits);

        public static RaycastHit[] Sphere(Vector3 origin, int numberOfRays, float distance, bool distinctHits = false) =>
            Sphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, distinctHits);

        public static RaycastHit[] Sphere(Vector3 origin, int numberOfRays, int layerMask, bool distinctHits = false) =>
            Sphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, layerMask, distinctHits);

        public static RaycastHit[] Sphere(Vector3 origin, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            Sphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit[] Sphere(Vector3 origin, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            Sphere(origin, TURN_FRACTION_DEFAULT, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[] Sphere(Vector3 origin, float turnFraction, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] Sphere(Vector3 origin, float turnFraction, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, distance, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] Sphere(Vector3 origin, float turnFraction, int numberOfRays, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] Sphere(Vector3 origin, float turnFraction, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] Sphere(Vector3 origin, float turnFraction, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetSphereRays(origin, turnFraction, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static Ray[] GetSphereRays(Vector3 origin, float turnFraction, int numberOfRays)
        {
            List<Ray> rays = new List<Ray>();

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

                rays.Add(new Ray(origin, direction));
            }

            return rays.ToArray();
        }
    }
}
