using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces) =>
            Bounce(ray.origin, ray.direction, bounces);

        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, float maxDistance) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance);

        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, float maxDistance, int layerMask) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask);

        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, float maxDistance, int layerMask, float minDepth) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, minDepth);

        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, minDepth, maxDepth);


        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, out RayLine2D[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, out raylines);

        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, float maxDistance, out RayLine2D[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, out raylines);

        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, float maxDistance, int layerMask, out RayLine2D[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, out raylines);

        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, float maxDistance, int layerMask, float minDepth, out RayLine2D[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, minDepth, out raylines);

        public static RaycastHit2D[] Bounce(Ray2D ray, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth, out RayLine2D[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, minDepth, maxDepth, out raylines);



        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            int retries = 0;
            const int MAX_RETRIES = 10;
            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;
                retries = 0;
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, float maxDistance)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                remainingDistance -= Vector2.Distance(origin, hit.point);

                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, float maxDistance, int layerMask)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                remainingDistance -= Vector2.Distance(origin, hit.point);

                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, float maxDistance, int layerMask, float minDepth)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, minDepth, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                remainingDistance -= Vector2.Distance(origin, hit.point);

                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            return hits.ToArray();
        }

        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, minDepth, maxDepth, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                remainingDistance -= Vector2.Distance(origin, hit.point);

                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            return hits.ToArray();
        }


        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, out RayLine2D[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            List<RayLine2D> newRayHits = new List<RayLine2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            int retries = 0;
            const int MAX_RETRIES = 10;
            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                newRayHits.Add(new RayLine2D(origin, hit));
                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;
                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, float maxDistance, out RayLine2D[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            List<RayLine2D> newRayHits = new List<RayLine2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                remainingDistance -= Vector2.Distance(origin, hit.point);

                newRayHits.Add(new RayLine2D(origin, hit));
                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, float maxDistance, int layerMask, out RayLine2D[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            List<RayLine2D> newRayHits = new List<RayLine2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                remainingDistance -= Vector2.Distance(origin, hit.point);

                newRayHits.Add(new RayLine2D(origin, hit));
                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, float maxDistance, int layerMask, float minDepth, out RayLine2D[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            List<RayLine2D> newRayHits = new List<RayLine2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, minDepth, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                remainingDistance -= Vector2.Distance(origin, hit.point);

                newRayHits.Add(new RayLine2D(origin, hit));
                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit2D[] Bounce(Vector2 origin, Vector2 direction, int bounces, float maxDistance, int layerMask, float minDepth, float maxDepth, out RayLine2D[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            List<RayLine2D> newRayHits = new List<RayLine2D>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, minDepth, maxDepth, out RaycastHit2D hit) is false)
                    break;

                if (hit.point == origin)
                {
                    if (retries >= MAX_RETRIES)
                    {
#if CLOGGER
                        global::Clogger.Log(typeof(Raycast2D), "Raycasting", "Too many reties when bouncing, exiting loop to avoid infinite.");
#else
                        Debug.Log("Raycasting | Too many reties when bouncing, exiting loop to avoid infinite.");
#endif                        
                        break;
                    }

                    i--;
                    origin += direction * OFFSET_ALONG_DIRECTION;
                    retries++;
                    continue;
                }

                remainingDistance -= Vector2.Distance(origin, hit.point);

                newRayHits.Add(new RayLine2D(origin, hit));
                hits.Add(hit);

                direction = Vector2.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }
    }
}
