using Hybel.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distinctHits);

        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, float distance, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distance, distinctHits);

        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, distinctHits);

        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, float minDepth, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, minDepth, distinctHits);

        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, minDepth, maxDepth, distinctHits);


        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, out RayLine2D[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, out rayLines, distinctHits);

        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, float distance, out RayLine2D[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distance, out rayLines, distinctHits);

        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, out RayLine2D[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, out rayLines, distinctHits);

        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, float minDepth, out RayLine2D[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, minDepth, out rayLines, distinctHits);

        public static RaycastHit2D[] Parallel(Ray2D ray, float width, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, out RayLine2D[] rayLines, bool distinctHits = false) =>
            Parallel(ray.origin, ray.direction, width, numberOfRays, distance, layerMask, minDepth, maxDepth, out rayLines, distinctHits);



        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return Array.Empty<RaycastHit2D>();

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return Array.Empty<RaycastHit2D>();

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return Array.Empty<RaycastHit2D>();

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, float minDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return Array.Empty<RaycastHit2D>();

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, bool distinctHits = false)
        {
            if (numberOfRays <= 0)
                return Array.Empty<RaycastHit2D>();

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            return hits.ToArray();
        }


        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine2D>();
                return Array.Empty<RaycastHit2D>();
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            rayLines = RayLine2D.Create(rays.Select(ray => ray.origin).ToArray(), hits.ToArray());
            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine2D>();
                return Array.Empty<RaycastHit2D>();
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            rayLines = RayLine2D.Create(rays.Select(ray => ray.origin).ToArray(), hits.ToArray());
            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine2D>();
                return Array.Empty<RaycastHit2D>();
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            rayLines = RayLine2D.Create(rays.Select(ray => ray.origin).ToArray(), hits.ToArray());
            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, float minDepth, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine2D>();
                return Array.Empty<RaycastHit2D>();
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            rayLines = RayLine2D.Create(rays.Select(ray => ray.origin).ToArray(), hits.ToArray());
            return hits.ToArray();
        }

        public static RaycastHit2D[] Parallel(Vector2 origin, Vector2 direction, float width, int numberOfRays, float distance, int layerMask, float minDepth, float maxDepth, out RayLine2D[] rayLines, bool distinctHits = false)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine2D>();
                return Array.Empty<RaycastHit2D>();
            }

            var rays = GetParallelRays(origin, direction, width, numberOfRays);

            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            foreach (var ray in rays)
                if (Single(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth, out RaycastHit2D hit))
                    CheckDistinctAndAdd(distinctHits, hits, hit, HitComparer2D);

            rayLines = RayLine2D.Create(rays.Select(ray => ray.origin).ToArray(), hits.ToArray());
            return hits.ToArray();
        }


        public static Ray2D[] GetParallelRays(Vector2 origin, Vector2 direction, float width, int numberOfRays)
        {
            direction.Normalize();
            ParallelSetup(direction, width, out Vector2 perpDirection, out Vector2 halfPerpDirection);

            List<Ray2D> rays = new List<Ray2D>();

            if (width == 0f)
            {
                rays.Add(new Ray2D(origin, direction));
                return rays.ToArray();
            }

            for (int i = 0; i < numberOfRays; i++)
            {
                Vector2 newOrigin = origin + (-halfPerpDirection + (perpDirection / (numberOfRays - 1)) * i);
                rays.Add(new Ray2D(newOrigin, direction));
            }

            return rays.ToArray();

            static void ParallelSetup(Vector2 direction, float width, out Vector2 perpDirection, out Vector2 halfPerpDirection)
            {
                perpDirection = direction.Perp().SetMagnitude(width);
                halfPerpDirection = perpDirection / 2;
            }
        }
    }
}