using UnityEngine;
using static UnityEngine.UI.Image;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[] CircleThrough(Ray ray, float radius) =>
            CircleThrough(ray.origin, ray.direction, radius);

        public static RaycastHit2D[] CircleThrough(Ray ray, float radius, float distance) =>
            CircleThrough(ray.origin, ray.direction, radius, distance);

        public static RaycastHit2D[] CircleThrough(Ray ray, float radius, float distance, int layerMask) =>
            CircleThrough(ray.origin, ray.direction, radius, distance, layerMask);

        public static RaycastHit2D[] CircleThrough(Ray ray, float radius, float distance, int layerMask, float minDepth) =>
            CircleThrough(ray.origin, ray.direction, radius, distance, layerMask, minDepth);

        public static RaycastHit2D[] CircleThrough(Ray ray, float radius, float distance, int layerMask, float minDepth, float maxDepth) =>
            CircleThrough(ray.origin, ray.direction, radius, distance, layerMask, minDepth, maxDepth);


        public static RaycastHit2D[] CircleThrough(Vector2 origin, Vector2 direction, float radius) =>
            Physics2D.CircleCastAll(origin, radius, direction);

        public static RaycastHit2D[] CircleThrough(Vector2 origin, Vector2 direction, float radius, float distance) =>
            Physics2D.CircleCastAll(origin, radius, direction, distance);

        public static RaycastHit2D[] CircleThrough(Vector2 origin, Vector2 direction, float radius, float distance, int layerMask) =>
            Physics2D.CircleCastAll(origin, radius, direction, distance, layerMask);

        public static RaycastHit2D[] CircleThrough(Vector2 origin, Vector2 direction, float radius, float distance, int layerMask, float minDepth) =>
            Physics2D.CircleCastAll(origin, radius, direction, distance, layerMask, minDepth);

        public static RaycastHit2D[] CircleThrough(Vector2 origin, Vector2 direction, float radius, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.CircleCastAll(origin, radius, direction, distance, layerMask, minDepth, maxDepth);
    }
}
