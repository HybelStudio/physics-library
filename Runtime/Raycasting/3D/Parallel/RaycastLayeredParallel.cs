using System.Collections.Generic;
using UnityEngine;
using Hybel.ExtensionMethods;
using System.Linq;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, distinctHits);

        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, int numberOfLayers, float layeredWidth, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, distance, distinctHits);

        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, int layerMask, int numberOfLayers, float layeredWidth, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, layerMask, distinctHits);

        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, int layerMask, int numberOfLayers, float layeredWidth, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, distance, layerMask, distinctHits);

        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, int numberOfLayers, float layeredWidth, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, int numberOfLayers, float layeredWidth, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, distance, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, int layerMask, int numberOfLayers, float layeredWidth, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, int layerMask, int numberOfLayers, float layeredWidth, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredParallel(Ray ray, Vector3 up, float width, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, int numberOfLayers, float layeredWidth, out RayLine[][] rayLines, bool distinctHits = false) =>
            LayeredParallel(ray.origin, ray.direction, up, width, numberOfRays, numberOfLayers, layeredWidth, distance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);



        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, distance, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, int layerMask, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, distance, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }


        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, out RayLine[] raylines, distinctHits);

                List<RaycastHit> hitList = hits.ToList();
                CheckDistinctAndAdd(distinctHits, hitArrays, hitList, newRayLines, raylines, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, distance, out RayLine[] raylines, distinctHits);

                List<RaycastHit> hitList = hits.ToList();
                CheckDistinctAndAdd(distinctHits, hitArrays, hitList, newRayLines, raylines, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, int layerMask, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, layerMask, out RayLine[] raylines, distinctHits);

                List<RaycastHit> hitList = hits.ToList();
                CheckDistinctAndAdd(distinctHits, hitArrays, hitList, newRayLines, raylines, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, int layerMask, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, distance, layerMask, out RayLine[] raylines, distinctHits);

                List<RaycastHit> hitList = hits.ToList();
                CheckDistinctAndAdd(distinctHits, hitArrays, hitList, newRayLines, raylines, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredParallel(Vector3 origin, Vector3 direction, Vector3 up, float width, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[][] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0][];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, up);
            var layers = GetParallelRays(origin, direction, right, layeredWidth, numberOfLayers);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine[]> newRayLines = new List<RayLine[]>();

            if (numberOfLayers == 1)
                Cast(new Ray(origin, direction));

            foreach (var layer in layers)
                Cast(layer);

            rayLines = newRayLines.ToArray();
            return hitArrays.ToArray();

            void Cast(Ray layer)
            {
                var hits = Parallel(layer.origin, layer.direction, up, width, numberOfRays, distance, layerMask, queryTriggerInteraction, out RayLine[] raylines, distinctHits);

                List<RaycastHit> hitList = hits.ToList();
                CheckDistinctAndAdd(distinctHits, hitArrays, hitList, newRayLines, raylines, (h1, h2) => h1.collider == h2.collider);
            }
        }
    }
}
