using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[] BoxThrough(Ray2D ray, Vector2 size, float angle) =>
            BoxThrough(ray.origin, ray.direction, size, angle);

        public static RaycastHit2D[] BoxThrough(Ray2D ray, Vector2 size, float angle, float distance) =>
            BoxThrough(ray.origin, ray.direction, size, angle, distance);

        public static RaycastHit2D[] BoxThrough(Ray2D ray, Vector2 size, float angle, float distance, int layerMask) =>
            BoxThrough(ray.origin, ray.direction, size, angle, distance, layerMask);

        public static RaycastHit2D[] BoxThrough(Ray2D ray, Vector2 size, float angle, float distance, int layerMask, float minDepth) =>
            BoxThrough(ray.origin, ray.direction, size, angle, distance, layerMask, minDepth);

        public static RaycastHit2D[] BoxThrough(Ray2D ray, Vector2 size, float angle, float distance, int layerMask, float minDepth, float maxDepth) =>
            BoxThrough(ray.origin, ray.direction, size, angle, distance, layerMask, minDepth, maxDepth);


        public static RaycastHit2D[] BoxThrough(Vector2 origin, Vector2 direction, Vector2 size, float angle) =>
            Physics2D.BoxCastAll(origin, size, angle, direction);

        public static RaycastHit2D[] BoxThrough(Vector2 origin, Vector2 direction, Vector2 size, float angle, float distance) =>
            Physics2D.BoxCastAll(origin, size, angle, direction, distance);

        public static RaycastHit2D[] BoxThrough(Vector2 origin, Vector2 direction, Vector2 size, float angle, float distance, int layerMask) =>
            Physics2D.BoxCastAll(origin, size, angle, direction, distance, layerMask);

        public static RaycastHit2D[] BoxThrough(Vector2 origin, Vector2 direction, Vector2 size, float angle, float distance, int layerMask, float minDepth) =>
            Physics2D.BoxCastAll(origin, size, angle, direction, distance, layerMask, minDepth);

        public static RaycastHit2D[] BoxThrough(Vector2 origin, Vector2 direction, Vector2 size, float angle, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.BoxCastAll(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);
    }
}
