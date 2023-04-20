using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static bool Capsule(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle) =>
            Physics2D.OverlapCapsule(point, size, capsuleDirection, angle);

        public static bool Capsule(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, int layerMask) =>
            Physics2D.OverlapCapsule(point, size, capsuleDirection, angle, layerMask);

        public static bool Capsule(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, int layerMask, float minDepth) =>
            Physics2D.OverlapCapsule(point, size, capsuleDirection, angle, layerMask, minDepth);

        public static bool Capsule(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapCapsule(point, size, capsuleDirection, angle, layerMask, minDepth, maxDepth);


        public static bool Capsule(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, out Collider2D[] results)
        {
            results = Physics2D.OverlapCapsuleAll(point, size, capsuleDirection, angle);
            return results.Length > 0;
        }

        public static bool Capsule(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, int layerMask, out Collider2D[] results)
        {
            results = Physics2D.OverlapCapsuleAll(point, size, capsuleDirection, angle, layerMask);
            return results.Length > 0;
        }

        public static bool Capsule(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, int layerMask, float minDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapCapsuleAll(point, size, capsuleDirection, angle, layerMask, minDepth);
            return results.Length > 0;
        }

        public static bool Capsule(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, int layerMask, float minDepth, float maxDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapCapsuleAll(point, size, capsuleDirection, angle, layerMask, minDepth, maxDepth);
            return results.Length > 0;
        }


        public static int CapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Collider2D[] results)
        {
            return Physics2D.OverlapCapsuleNonAlloc(point, size, capsuleDirection, angle, results);
        }

        public static int CapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Collider2D[] results, int layerMask)
        {
            return Physics2D.OverlapCapsuleNonAlloc(point, size, capsuleDirection, angle, results, layerMask);
        }

        public static int CapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Collider2D[] results, int layerMask, float minDepth)
        {
            return Physics2D.OverlapCapsuleNonAlloc(point, size, capsuleDirection, angle, results, layerMask, minDepth);
        }

        public static int CapsuleNonAlloc(Vector2 point, Vector2 size, CapsuleDirection2D capsuleDirection, float angle, Collider2D[] results, int layerMask, float minDepth, float maxDepth)
        {
            return Physics2D.OverlapCapsuleNonAlloc(point, size, capsuleDirection, angle, results, layerMask, minDepth, maxDepth);
        }
    }
}