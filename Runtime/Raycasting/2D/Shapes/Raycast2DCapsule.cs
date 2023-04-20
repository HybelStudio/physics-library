using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D Capsule(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle) =>
            Capsule(ray.origin, ray.direction, size, capsuleDirection, angle);

        public static RaycastHit2D Capsule(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance) =>
            Capsule(ray.origin, ray.direction, size, capsuleDirection, angle, distance);

        public static RaycastHit2D Capsule(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask) =>
            Capsule(ray.origin, ray.direction, size, capsuleDirection, angle, distance, layerMask);

        public static RaycastHit2D Capsule(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask, float minDepth) =>
            Capsule(ray.origin, ray.direction, size, capsuleDirection, angle, distance, layerMask, minDepth);

        public static RaycastHit2D Capsule(Ray2D ray, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask, float minDepth, float maxDepth) =>
            Capsule(ray.origin, ray.direction, size, capsuleDirection, angle, distance, layerMask, minDepth, maxDepth);


        public static RaycastHit2D Capsule(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle) =>
            Physics2D.CapsuleCast(origin, size, capsuleDirection, angle, direction);

        public static RaycastHit2D Capsule(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance) =>
            Physics2D.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance);

        public static RaycastHit2D Capsule(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask) =>
            Physics2D.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, layerMask);

        public static RaycastHit2D Capsule(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask, float minDepth) =>
            Physics2D.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, layerMask, minDepth);

        public static RaycastHit2D Capsule(Vector2 origin, Vector2 direction, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, float distance, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.CapsuleCast(origin, size, capsuleDirection, angle, direction, distance, layerMask, minDepth, maxDepth);
    }
}
