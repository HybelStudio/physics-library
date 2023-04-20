using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D Circle(Ray2D ray, float radius) =>
            Circle(ray.origin, ray.direction, radius);

        public static RaycastHit2D Circle(Ray2D ray, float radius, float distance) =>
            Circle(ray.origin, ray.direction, radius, distance);

        public static RaycastHit2D Circle(Ray2D ray, float radius, float distance, int layerMask) =>
            Circle(ray.origin, ray.direction, radius, distance, layerMask);

        public static RaycastHit2D Circle(Ray2D ray, float radius, float distance, int layerMask, float minDepth) =>
            Circle(ray.origin, ray.direction, radius, distance, layerMask, minDepth);

        public static RaycastHit2D Circle(Ray2D ray, float radius, float distance, int layerMask, float minDepth, float maxDepth) =>
            Circle(ray.origin, ray.direction, radius, distance, layerMask, minDepth, maxDepth);


        public static RaycastHit2D Circle(Vector2 origin, Vector2 direction, float radius) =>
            Physics2D.CircleCast(origin, radius, direction);

        public static RaycastHit2D Circle(Vector2 origin, Vector2 direction, float radius, float distance) =>
            Physics2D.CircleCast(origin, radius, direction, distance);

        public static RaycastHit2D Circle(Vector2 origin, Vector2 direction, float radius, float distance, int layerMask) =>
            Physics2D.CircleCast(origin, radius, direction, distance, layerMask);

        public static RaycastHit2D Circle(Vector2 origin, Vector2 direction, float radius, float distance, int layerMask, float minDepth) =>
            Physics2D.CircleCast(origin, radius, direction, distance, layerMask, minDepth);

        public static RaycastHit2D Circle(Vector2 origin, Vector2 direction, float radius, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.CircleCast(origin, radius, direction, distance, layerMask, minDepth, maxDepth);
    }
}
