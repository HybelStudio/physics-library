using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static bool Single(Ray2D ray) =>
            Single(ray.origin, ray.direction);

        public static bool Single(Ray2D ray, float distance) =>
            Single(ray.origin, ray.direction, distance);

        public static bool Single(Ray2D ray, float distance, int layerMask) =>
            Single(ray.origin, ray.direction, distance, layerMask);

        public static bool Single(Ray2D ray, float distance, int layerMask, float minDepth) =>
            Single(ray.origin, ray.direction, distance, layerMask, minDepth);

        public static bool Single(Ray2D ray, float distance, int layerMask, float minDepth, float maxDepth) =>
            Single(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth);


        public static bool Single(Ray2D ray, out RaycastHit2D hit) =>
            Single(ray.origin, ray.direction, out hit);

        public static bool Single(Ray2D ray, float distance, out RaycastHit2D hit) =>
            Single(ray.origin, ray.direction, distance, out hit);

        public static bool Single(Ray2D ray, float distance, int layerMask, out RaycastHit2D hit) =>
            Single(ray.origin, ray.direction, distance, layerMask, out hit);

        public static bool Single(Ray2D ray, float distance, int layerMask, float minDepth, out RaycastHit2D hit) =>
            Single(ray.origin, ray.direction, distance, layerMask, minDepth, out hit);

        public static bool Single(Ray2D ray, float distance, int layerMask, float minDepth, float maxDepth, out RaycastHit2D hit) =>
            Single(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth, out hit);



        public static bool Single(Vector2 origin, Vector2 direction) =>
            Physics2D.Raycast(origin, direction);

        public static bool Single(Vector2 origin, Vector2 direction, float distance) =>
            Physics2D.Raycast(origin, direction, distance);

        public static bool Single(Vector2 origin, Vector2 direction, float distance, int layerMask) =>
            Physics2D.Raycast(origin, direction, distance, layerMask);

        public static bool Single(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth) =>
            Physics2D.Raycast(origin, direction, distance, layerMask, minDepth);

        public static bool Single(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.Raycast(origin, direction, distance, layerMask, minDepth, maxDepth);


        public static bool Single(Vector2 origin, Vector2 direction, out RaycastHit2D hit) =>
            hit = Physics2D.Raycast(origin, direction);

        public static bool Single(Vector2 origin, Vector2 direction, float distance, out RaycastHit2D hit) =>
            hit = Physics2D.Raycast(origin, direction, distance);

        public static bool Single(Vector2 origin, Vector2 direction, float distance, int layerMask, out RaycastHit2D hit) =>
            hit = Physics2D.Raycast(origin, direction, distance, layerMask);

        public static bool Single(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, out RaycastHit2D hit) =>
            hit = Physics2D.Raycast(origin, direction, distance, layerMask, minDepth);

        public static bool Single(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth, out RaycastHit2D hit) =>
            hit = Physics2D.Raycast(origin, direction, distance, layerMask, minDepth, maxDepth);
    }
}