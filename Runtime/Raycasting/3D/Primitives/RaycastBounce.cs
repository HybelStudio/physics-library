using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] Bounce(Ray ray, int bounces) =>
            Bounce(ray.origin, ray.direction, bounces);

        public static RaycastHit[] Bounce(Ray ray, int bounces, float maxDistance) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance);

        public static RaycastHit[] Bounce(Ray ray, int bounces, int layerMask) =>
            Bounce(ray.origin, ray.direction, bounces, layerMask);

        public static RaycastHit[] Bounce(Ray ray, int bounces, float maxDistance, int layerMask) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask);

        public static RaycastHit[] Bounce(Ray ray, int bounces, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, queryTriggerInteraction);


        public static RaycastHit[] Bounce(Ray ray, int bounces, out RayLine[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, out raylines);

        public static RaycastHit[] Bounce(Ray ray, int bounces, float maxDistance, out RayLine[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, out raylines);

        public static RaycastHit[] Bounce(Ray ray, int bounces, int layerMask, out RayLine[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, layerMask, out raylines);

        public static RaycastHit[] Bounce(Ray ray, int bounces, float maxDistance, int layerMask, out RayLine[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, out raylines);

        public static RaycastHit[] Bounce(Ray ray, int bounces, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] raylines) =>
            Bounce(ray.origin, ray.direction, bounces, maxDistance, layerMask, queryTriggerInteraction, out raylines);



        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            int retries = 0;
            const int MAX_RETRIES = 10;
            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, out RaycastHit hit) is false)
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

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;
                retries = 0;
            }

            return hits.ToArray();
        }

        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, float maxDistance)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, out RaycastHit hit) is false)
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

                remainingDistance -= Vector3.Distance(origin, hit.point);

                hits.Add(hit);

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            return hits.ToArray();
        }

        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, int layerMask)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, layerMask, out RaycastHit hit) is false)
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

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            return hits.ToArray();
        }

        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, float maxDistance, int layerMask)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, out RaycastHit hit) is false)
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

                remainingDistance -= Vector3.Distance(origin, hit.point);

                hits.Add(hit);

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            return hits.ToArray();
        }

        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, queryTriggerInteraction, out RaycastHit hit) is false)
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

                remainingDistance -= Vector3.Distance(origin, hit.point);

                hits.Add(hit);

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            return hits.ToArray();
        }


        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, out RayLine[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayHits = new List<RayLine>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            int retries = 0;
            const int MAX_RETRIES = 10;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, out RaycastHit hit) is false)
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

                newRayHits.Add(new RayLine(origin, hit));
                hits.Add(hit);

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;
                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, float maxDistance, out RayLine[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayHits = new List<RayLine>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, out RaycastHit hit) is false)
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

                remainingDistance -= Vector3.Distance(origin, hit.point);

                newRayHits.Add(new RayLine(origin, hit));
                hits.Add(hit);

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, int layerMask, out RayLine[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayHits = new List<RayLine>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, layerMask, out RaycastHit hit) is false)
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

                newRayHits.Add(new RayLine(origin, hit));
                hits.Add(hit);

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, float maxDistance, int layerMask, out RayLine[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayHits = new List<RayLine>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, out RaycastHit hit) is false)
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

                remainingDistance -= Vector3.Distance(origin, hit.point);

                newRayHits.Add(new RayLine(origin, hit));
                hits.Add(hit);

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }

        public static RaycastHit[] Bounce(Vector3 origin, Vector3 direction, int bounces, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RayLine[] raylines)
        {
            bounces = Mathf.Max(bounces, 0);

            List<RaycastHit> hits = new List<RaycastHit>();
            List<RayLine> newRayHits = new List<RayLine>();

            const float OFFSET_ALONG_DIRECTION = 0.0001f;
            const int MAX_RETRIES = 10;
            int retries = 0;

            float remainingDistance = maxDistance;

            for (int i = 0; i <= bounces; i++)
            {
                if (Single(origin, direction, remainingDistance, layerMask, queryTriggerInteraction, out RaycastHit hit) is false)
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

                remainingDistance -= Vector3.Distance(origin, hit.point);

                newRayHits.Add(new RayLine(origin, hit));
                hits.Add(hit);

                direction = Vector3.Reflect(direction, hit.normal);
                origin = hit.point + direction * OFFSET_ALONG_DIRECTION;

                retries = 0;
            }

            raylines = newRayHits.ToArray();
            return hits.ToArray();
        }
    }
}