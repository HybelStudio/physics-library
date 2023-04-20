using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] RadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, distinctHits);

        public static RaycastHit[][] RadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, float distance, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, distance, distinctHits);

        public static RaycastHit[][] RadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, int layerMask, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, layerMask, distinctHits);

        public static RaycastHit[][] RadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit[][] RadialThrough(Ray ray, Vector3 normal, float angle, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            RadialThrough(ray.origin, ray.direction, normal, angle, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] RadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return new RaycastHit[0][];
            
            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (angle <= 0f)
            {
                Cast(origin, direction);
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hitArrays.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                var hitArray = Through(origin, direction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] RadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return new RaycastHit[0][];
            
            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (angle <= 0f)
            {
                Cast(origin, direction);
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hitArrays.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
{
                var hitArray = Through(origin, direction, distance);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] RadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return new RaycastHit[0][];
            
            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (angle <= 0f)
            {
                Cast(origin, direction);
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hitArrays.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                var hitArray = Through(origin, direction, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] RadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return new RaycastHit[0][];
            
            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (angle <= 0f)
            {
                Cast(origin, direction);
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hitArrays.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                var hitArray = Through(origin, direction, distance, layerMask);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] RadialThrough(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return new RaycastHit[0][];
            
            var rays = GetRadialRays(origin, direction, normal, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (angle <= 0f)
            {
                Cast(origin, direction);
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray.origin, ray.direction);

            return hitArrays.ToArray();

            void Cast(Vector3 origin, Vector3 direction)
            {
                var hitArray = Through(origin, direction, distance, layerMask, queryTriggerInteraction);
                CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }
        }
    }
}
