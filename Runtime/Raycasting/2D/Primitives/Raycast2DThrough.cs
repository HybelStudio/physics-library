using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[] Through(Ray2D ray) =>
            Through(ray.origin, ray.direction);

        public static RaycastHit2D[] Through(Ray2D ray, float distance) =>
            Through(ray.origin, ray.direction, distance);

        public static RaycastHit2D[] Through(Ray2D ray, float distance, int layerMask) =>
            Through(ray.origin, ray.direction, distance, layerMask);

        public static RaycastHit2D[] Through(Ray2D ray, float distance, int layerMask, float minDepth) =>
            Through(ray.origin, ray.direction, distance, layerMask, minDepth);

        public static RaycastHit2D[] Through(Ray2D ray, float distance, int layerMask, float minDepth, float maxDepth) =>
            Through(ray.origin, ray.direction, distance, layerMask, minDepth, maxDepth);


        public static RaycastHit2D[] Through(Vector2 origin, Vector2 direction) =>
            Physics2D.RaycastAll(origin, direction);

        public static RaycastHit2D[] Through(Vector2 origin, Vector2 direction, float distance) =>
            Physics2D.RaycastAll(origin, direction, distance);

        public static RaycastHit2D[] Through(Vector2 origin, Vector2 direction, float distance, int layerMask) =>
            Physics2D.RaycastAll(origin, direction, distance, layerMask);

        public static RaycastHit2D[] Through(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth) =>
            Physics2D.RaycastAll(origin, direction, distance, layerMask, minDepth);

        public static RaycastHit2D[] Through(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.RaycastAll(origin, direction, distance, layerMask, minDepth, maxDepth);
    }
}
