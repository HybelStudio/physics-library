using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] LayeredRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, out RayLine[] rayLines, bool distinctHits = false) =>
            LayeredRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredWidth, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, out RayLine[] rayLines, bool distinctHits = false) =>
            LayeredRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredWidth, distance, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            LayeredRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredWidth, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false) =>
            LayeredRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredWidth, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit[][] LayeredRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false) =>
            LayeredRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredWidth, distance, layerMask, queryTriggerInteraction, out rayLines, distinctHits);


        public static RaycastHit[][] LayeredRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

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
                var hits = Radial(ray, normal, angle, numberOfRays, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, RayLine.Create(ray.origin, hits), (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

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
                var hits = Radial(ray, normal, angle, numberOfRays, distance, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, RayLine.Create(ray.origin, hits), (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

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
                var hits = Radial(ray, normal, angle, numberOfRays, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, RayLine.Create(ray.origin, hits), (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, int layerMask, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

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
                var hits = Radial(ray, normal, angle, numberOfRays, distance, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, RayLine.Create(ray.origin, hits), (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] LayeredRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredWidth, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] rayLines, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
            {
                rayLines = new RayLine[0];
                return new RaycastHit[0][];
            }

            var right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, angle, numberOfRays);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();
            List<RayLine> newRayLines = new List<RayLine>();

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
                var hits = Radial(ray, normal, angle, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, newRayLines, RayLine.Create(ray.origin, hits), (h1, h2) => h1.collider == h2.collider);
            }
        }
    }
}
