using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[] Radial(Ray2D ray, float angle, int numberOfRays, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, angle, numberOfRays, distinctHits);

        public static RaycastHit2D[] Radial(Ray2D ray, float angle, int numberOfRays, float distance, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, angle, numberOfRays, distance, distinctHits);

        public static RaycastHit2D[] Radial(Ray2D ray, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, angle, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit2D[] Radial(Ray2D ray, float angle, int numberOfRays, float distance, int layerMask, float minDepth, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, angle, numberOfRays, distance, layerMask, minDepth, distinctHits);

        public static RaycastHit2D[] Radial(Ray2D ray, float angle, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false) =>
            Radial(ray.origin, ray.direction, angle, numberOfRays, distance, layerMask, minDepth, maxDepth, distinctHits);


        public static RaycastHit2D[] Radial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0];

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }

        public static RaycastHit2D[] Radial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0];

            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }

        public static RaycastHit2D[] Radial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0];
            
            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }

        public static RaycastHit2D[] Radial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, float distance, int layerMask, float minDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0];
            
            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }

        public static RaycastHit2D[] Radial(Vector2 origin, Vector2 direction, float angle, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return new RaycastHit2D[0];
            
            var rays = GetRadialRays(origin, direction, angle, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }


        public static Ray2D[] GetRadialRays(Vector2 origin, Vector2 direction, float angle, int numberOfRays)
        {
            direction.Normalize();
            RadialSetup(direction, angle, ref numberOfRays, out float halfAngle, out float angleIncrement, out Vector2 right);

            List<Ray2D> rays = new List<Ray2D>();

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentAngle = -halfAngle + angleIncrement * i + 90f; // Reallign to match forward direction.
                float currentRadian = currentAngle * Mathf.Deg2Rad;

                Vector2 newDirection = direction * Mathf.Sin(currentRadian) + right * Mathf.Cos(currentRadian);
                Ray2D ray = new Ray2D(origin, newDirection);

                rays.Add(ray);
            }

            return rays.ToArray();

            static void RadialSetup(Vector2 direction, float angle, ref int numberOfRays, out float halfAngle, out float angleIncrement, out Vector2 right)
            {
                halfAngle = angle * .5f;
                bool angleIsMultipleOf360 = (angle % 360 == 0);

                if (angleIsMultipleOf360)
                    numberOfRays--;

                angleIncrement = angle / (numberOfRays - (angleIsMultipleOf360 ? 0 : 1));
                right = -Vector2.Perpendicular(direction);
            }
        }
    }
}