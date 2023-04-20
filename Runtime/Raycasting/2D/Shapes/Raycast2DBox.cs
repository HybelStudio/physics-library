using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D Box(Ray2D ray, Vector2 size, float angle) =>
            Box(ray.origin, ray.direction, size, angle);

        public static RaycastHit2D Box(Ray2D ray, Vector2 size, float angle, float distance) =>
            Box(ray.origin, ray.direction, size, angle, distance);

        public static RaycastHit2D Box(Ray2D ray, Vector2 size, float angle, float distance, int layerMask) =>
            Box(ray.origin, ray.direction, size, angle, distance, layerMask);

        public static RaycastHit2D Box(Ray2D ray, Vector2 size, float angle, float distance, int layerMask, float minDepth) =>
            Box(ray.origin, ray.direction, size, angle, distance, layerMask, minDepth);

        public static RaycastHit2D Box(Ray2D ray, Vector2 size, float angle, float distance, int layerMask, float minDepth, float maxDepth) =>
            Box(ray.origin, ray.direction, size, angle, distance, layerMask, minDepth, maxDepth);


        public static RaycastHit2D Box(Vector2 origin, Vector2 direction, Vector2 size, float angle) =>
            Physics2D.BoxCast(origin, size, angle, direction);

        public static RaycastHit2D Box(Vector2 origin, Vector2 direction, Vector2 size, float angle, float distance) =>
            Physics2D.BoxCast(origin, size, angle, direction, distance);

        public static RaycastHit2D Box(Vector2 origin, Vector2 direction, Vector2 size, float angle, float distance, int layerMask) =>
            Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask);

        public static RaycastHit2D Box(Vector2 origin, Vector2 direction, Vector2 size, float angle, float distance, int layerMask, float minDepth) =>
            Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask, minDepth);

        public static RaycastHit2D Box(Vector2 origin, Vector2 direction, Vector2 size, float angle, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);
    }
}
