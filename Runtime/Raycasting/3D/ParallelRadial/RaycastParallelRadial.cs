using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distinctHits);

        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, distinctHits);

        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, int layerMask, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerMask, distinctHits);

        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, out rayLines, distinctHits);

        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, out rayLines, distinctHits);

        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerMask, out rayLines, distinctHits);

        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[] ParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, distance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);



        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, distance, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }


        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }
            
            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);

            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray, distance, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);

            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }
            
            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);

            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }
            
            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);

            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] ParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }

            var rays = GetParallelRadialRays(origin, direction, normal, radius, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);

            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }


        public static Ray[] GetParallelRadialRays(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays)
        {
            ParallelRadialSetup(direction, normal, numberOfRays, out Vector3 right, out float angleIncrement);

            List<Ray> rays = new List<Ray>();

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentRadian = angleIncrement * i * Mathf.Deg2Rad;
                Vector3 newOrigin = origin + ((normal * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian)) * radius);
                rays.Add(new Ray(newOrigin, direction));
            }

            return rays.ToArray();

            static void ParallelRadialSetup(Vector3 direction, Vector3 normal, int numberOfRays, out Vector3 right, out float angleIncrement)
            {
                right = direction.Cross(normal);
                angleIncrement = 360f / numberOfRays;
            }
        }
    }
}
