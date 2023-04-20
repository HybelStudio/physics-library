using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distinctHits);

        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance, distinctHits);

        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, int layerMask, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, layerMask, distinctHits);

        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance, layerMask, distinctHits);

        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, int layerMask, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredParallelRadial(Ray ray, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallelRadial(ray.origin, ray.direction, normal, radius, numberOfRays, layerWidth, numberOfLayers, distance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);



        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, int layerMask, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, HitComparer);
            }

            return hitArrays.ToArray();
        }


        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, out RayLine[] newRayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance, out RayLine[] newRayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, int layerMask, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, layerMask, out RayLine[] newRayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance, layerMask, out RayLine[] newRayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] LayeredParallelRadial(Vector3 origin, Vector3 direction, Vector3 normal, float radius, int numberOfRays, float layerWidth, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            List<float> radiuses = new List<float>();
            for (int i = 0; i < numberOfLayers; i++)
                radiuses.Add(radius + layerWidth * i);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> rayLineArrays = new List<RayLine[]>();

            foreach (var newRadius in radiuses)
            {
                var hits = ParallelRadial(origin, direction, normal, newRadius, numberOfRays, distance, layerMask, queryTriggerInteraction, out RayLine[] newRayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, rayLineArrays, newRayLines, HitComparer);
            }

            rayLines = rayLineArrays.ToArray();
            return hitArrays.ToArray();
        }
    }
}