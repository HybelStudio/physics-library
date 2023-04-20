using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, distinctHits);

        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, distance, distinctHits);

        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, int layerMask, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, layerMask, distinctHits);

        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, int layerMask, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, distance, layerMask, distinctHits);

        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, out RayLine[][] rayLines, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, out rayLines, distinctHits);

        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, out RayLine[][] rayLines, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, distance, out rayLines, distinctHits);

        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, int layerMask, out RayLine[][] rayLines, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, int layerMask, out RayLine[][] rayLines, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] AngledParallel(Ray ray, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[][] rayLines, bool distinctHits = false) =>
            AngledParallel(ray.origin, ray.direction, up, width, numberOfRays, angle, numberOfLayers, distance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);



        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, distance, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, int layerMask, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, distance, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }


        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));

                rayLines = newRayLines.ToArray();
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, out RayLine[] rayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, rayLines, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));

                rayLines = newRayLines.ToArray();
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, distance, out RayLine[] rayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, rayLines, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, int layerMask, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));

                rayLines = newRayLines.ToArray();
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, layerMask, out RayLine[] rayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, rayLines, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, int layerMask, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));

                rayLines = newRayLines.ToArray();
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, distance, layerMask, out RayLine[] rayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, rayLines, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, float angle, int numberOfLayers, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
            {
                Cast(new Ray(origin, direction));

                rayLines = newRayLines.ToArray();
                return hitArrays.ToArray();
            }

            foreach (var ray in rays)
                Cast(ray);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray ray)
            {
                var hits = Parallel(ray, up, width, numberOfRays, distance, layerMask, queryTriggerInteraction, out RayLine[] rayLines, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, rayLines, (h1, h2) => h1.collider == h2.collider);
            }
        }
    }
}
