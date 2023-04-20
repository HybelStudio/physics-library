using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[] CapsuleThrough(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle) =>
            CapsuleThrough(ray.origin, ray.direction, size, capsuleDirection, angle);

        public static RaycastHit2D[] CapsuleThrough(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance) =>
            CapsuleThrough(ray.origin, ray.direction, size, capsuleDirection, angle, distance);

        public static RaycastHit2D[] CapsuleThrough(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask) =>
            CapsuleThrough(ray.origin, ray.direction, size, capsuleDirection, angle, distance, layerMask);

        public static RaycastHit2D[] CapsuleThrough(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask, float minDepth) =>
            CapsuleThrough(ray.origin, ray.direction, size, capsuleDirection, angle, distance, layerMask, minDepth);

        public static RaycastHit2D[] CapsuleThrough(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask, float minDepth, float maxDepth) =>
            CapsuleThrough(ray.origin, ray.direction, size, capsuleDirection, angle, distance, layerMask, minDepth, maxDepth);


        public static RaycastHit2D[] CapsuleThrough(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle) =>
            Physics2D.CapsuleCastAll(origin, size, capsuleDirection, angle, direction);

        public static RaycastHit2D[] CapsuleThrough(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance) =>
            Physics2D.CapsuleCastAll(origin, size, capsuleDirection, angle, direction, distance);

        public static RaycastHit2D[] CapsuleThrough(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask) =>
            Physics2D.CapsuleCastAll(origin, size, capsuleDirection, angle, direction, distance, layerMask);

        public static RaycastHit2D[] CapsuleThrough(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask, float minDepth) =>
            Physics2D.CapsuleCastAll(origin, size, capsuleDirection, angle, direction, distance, layerMask, minDepth);

        public static RaycastHit2D[] CapsuleThrough(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.CapsuleCastAll(origin, size, capsuleDirection, angle, direction, distance, layerMask, minDepth, maxDepth);
    }
}
