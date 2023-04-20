using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] Radial(Ray ray, Vector3 normal, float angle, int numberOfRays, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, normal, angle, numberOfRays, distinctHits);

        public static RaycastHit[] Radial(Ray ray, Vector3 normal, float angle, int numberOfRays, float distance, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, normal, angle, numberOfRays, distance, distinctHits);

        public static RaycastHit[] Radial(Ray ray, Vector3 normal, float angle, int numberOfRays, int layerMask, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, normal, angle, numberOfRays, layerMask, distinctHits);

        public static RaycastHit[] Radial(Ray ray, Vector3 normal, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, normal, angle, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit[] Radial(Ray ray, Vector3 normal, float angle, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, normal, angle, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[] Radial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hits.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                if (Single(origin, direction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[] Radial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hits.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                if (Single(origin, direction, distance, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[] Radial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hits.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                if (Single(origin, direction, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[] Radial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hits.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                if (Single(origin, direction, distance, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[] Radial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hits.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                if (Single(origin, direction, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);
            }
        }


        public static Ray[] GetRadialRays(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays)
        {
            direction.Normalize();
            RadialSetup(direction, normal, angle, ref numberOfRays, out float halfAngle, out float angleIncrement, out Vector3 right);

            List<Ray> rays = new List<Ray>();

            if (angle == 0f)
            {
                rays.Add(new Ray(origin, direction));
                return rays.ToArray();
            }

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentAngle = -halfAngle + angleIncrement * i + 90f; // Reallign to match forward direction.
                float currentRadian = currentAngle * Mathf.Deg2Rad;

                Vector3 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                rays.Add(new Ray(origin, newDirection));
            }

            return rays.ToArray();

            static void RadialSetup(Vector3 direction, Vector3 normal, float angle, ref int numberOfRays, out float halfAngle, out float angleIncrement, out Vector3 right)
            {
                halfAngle = angle * .5f;
                bool angleIsMultipleOf360 = (angle % 360 == 0);

                if (angleIsMultipleOf360)
                    numberOfRays--;

                angleIncrement = angle / (numberOfRays - (angleIsMultipleOf360 ? 0 : 1));
                right = Vector3.Cross(direction, normal);
            }
        }
    }
}
