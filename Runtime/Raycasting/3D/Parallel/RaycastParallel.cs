using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, distinctHits);

        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, distance, distinctHits);

        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, int layerMask, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, layerMask, distinctHits);

        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, out RayLine[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, out rayLines, distinctHits);

        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, out RayLine[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, distance, out rayLines, distinctHits);

        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, layerMask, out rayLines, distinctHits);

        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[] Parallel(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);



        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }

        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0];

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, (h1, h2) => h1.collider == h2.collider);

            return hits.ToArray();
        }


        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);
            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);
            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);
            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);
            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] Parallel(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0];
            }

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, queryTriggerInteraction, out RaycastHit hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, newRayLines, new RayLine(ray, hit), (h1, h2) => h1.collider == h2.collider);

            rayLines = newRayLines.ToArray();
            return hits.ToArray();
        }


        public static Ray[] GetParallelRays(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays)
        {
            direction.Normalize();
            ParallelSetup(direction, normal, width, out Vector3 perpDirection, out Vector3 halfPerpDirection);

            List<Ray> rays = new List<Ray>();

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector3 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                rays.Add(new Ray(newOrigin, direction));
            }

            return rays.ToArray();

            static void ParallelSetup(Vector3 direction, Vector3 normal, float width, out Vector3 perpDirection, out Vector3 halfPerpDirection)
            {
                perpDirection = direction.Cross(normal).SetMagnitude(width);
                halfPerpDirection = perpDirection / 2;
            }
        }
    }
}
