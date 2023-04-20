using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, distinctHits);

        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, distance, distinctHits);

        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, int layerMask, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, layerMask, distinctHits);

        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, distance, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] ParallelThrough(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false) =>
            ParallelThrough(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);



        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit[0][];
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask, queryTriggerInteraction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }

            return hitArrays.ToArray();
        }


        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }

        public static RaycastHit[][] ParallelThrough(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }
            
            var rays = GetParallelRays(origin, direction, normal, width, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

            foreach (var ray in rays)
            {
                var hitArray = Through(ray.origin, ray.direction, distance, layerMask, queryTriggerInteraction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, newRayLines, new RayLine(ray, hitArray[hitArray.Length - 1]), (h1, h2) => h1.collider == h2.collider);
            }

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();
        }
    }
}
