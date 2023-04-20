using Hybel.ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[][] AngledRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, bool distinctHits = false) =>
            AngledRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredAngle, distinctHits);

        public static RaycastHit[][] AngledRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, float distance, bool distinctHits = false) =>
            AngledRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredAngle, distance, distinctHits);

        public static RaycastHit[][] AngledRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, int layerMask, bool distinctHits = false) =>
            AngledRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredAngle, layerMask, distinctHits);

        public static RaycastHit[][] AngledRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, float distance, int layerMask, bool distinctHits = false) =>
            AngledRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredAngle, distance, layerMask, distinctHits);

        public static RaycastHit[][] AngledRadial(Ray ray, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            AngledRadial(ray.origin, ray.direction, normal, angle, numberOfRays, numberOfLayers, layeredAngle, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] AngledRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            Vector3 right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, layeredAngle, numberOfLayers);

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
                var hits = Radial(ray, normal, angle, numberOfRays, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, float distance, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            Vector3 right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, layeredAngle, numberOfLayers);

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
                var hits = Radial(ray, normal, angle, numberOfRays, distance, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, int layerMask, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            Vector3 right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, layeredAngle, numberOfLayers);

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
                var hits = Radial(ray, normal, angle, numberOfRays, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            Vector3 right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, layeredAngle, numberOfLayers);

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
                var hits = Radial(ray, normal, angle, numberOfRays, distance, layerMask, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }

        public static RaycastHit[][] AngledRadial(Vector3 origin, Vector3 direction, Vector3 normal, float angle, int numberOfRays, int numberOfLayers, float layeredAngle, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfLayers <= 0)
                return new RaycastHit[0][];

            Vector3 right = Vector3.Cross(direction, normal);
            var rays = GetRadialRays(origin, direction, right, layeredAngle, numberOfLayers);

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
                var hits = Radial(ray, normal, angle, numberOfRays, distance, layerMask, queryTriggerInteraction, distinctHits);
                CheckDistinctAndAdd(distinctHits, hitArrays, hits, (h1, h2) => h1.collider == h2.collider);
            }
        }
    }
}
