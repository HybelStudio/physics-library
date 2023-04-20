using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static bool Box(Vector2 point, Vector2 halfExtents) =>
            Physics2D.OverlapBox(point, halfExtents, 0f);

        public static bool Box(Vector2 point, Vector2 halfExtents, float angle) =>
            Physics2D.OverlapBox(point, halfExtents, angle);

        public static bool Box(Vector2 point, Vector2 halfExtents, float angle, int layerMask) =>
            Physics2D.OverlapBox(point, halfExtents, angle, layerMask);

        public static bool Box(Vector2 point, Vector2 halfExtents, float angle, int layerMask, float minDepth) =>
            Physics2D.OverlapBox(point, halfExtents, angle, layerMask, minDepth);

        public static bool Box(Vector2 point, Vector2 halfExtents, float angle, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapBox(point, halfExtents, angle, layerMask, minDepth, maxDepth);


        public static bool Box(Vector2 point, Vector2 halfExtents, out Collider2D[] results)
        {
            results = Physics2D.OverlapBoxAll(point, halfExtents, 0f);
            return results.Length > 0;
        }

        public static bool Box(Vector2 point, Vector2 halfExtents, float angle, out Collider2D[] results)
        {
            results = Physics2D.OverlapBoxAll(point, halfExtents, angle);
            return results.Length > 0;
        }

        public static bool Box(Vector2 point, Vector2 halfExtents, float angle, int layerMask, out Collider2D[] results)
        {
            results = Physics2D.OverlapBoxAll(point, halfExtents, angle, layerMask);
            return results.Length > 0;
        }

        public static bool Box(Vector2 point, Vector2 halfExtents, float angle, int layerMask, float minDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapBoxAll(point, halfExtents, angle, layerMask, minDepth);
            return results.Length > 0;
        }

        public static bool Box(Vector2 point, Vector2 halfExtents, float angle, int layerMask, float minDepth, float maxDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapBoxAll(point, halfExtents, angle, layerMask, minDepth, maxDepth);
            return results.Length > 0;
        }


        public static int BoxNonAlloc(Vector2 point, Vector2 halfExtents, Collider2D[] results) =>
            Physics2D.OverlapBoxNonAlloc(point, halfExtents, 0f, results);

        public static int BoxNonAlloc(Vector2 point, Vector2 halfExtents, float angle, Collider2D[] results) =>
            Physics2D.OverlapBoxNonAlloc(point, halfExtents, angle, results);

        public static int BoxNonAlloc(Vector2 point, Vector2 halfExtents, float angle, Collider2D[] results, int layerMask) =>
            Physics2D.OverlapBoxNonAlloc(point, halfExtents, angle, results, layerMask);

        public static int BoxNonAlloc(Vector2 point, Vector2 halfExtents, float angle, Collider2D[] results, int layerMask, float minDepth) =>
            Physics2D.OverlapBoxNonAlloc(point, halfExtents, angle, results, layerMask, minDepth);

        public static int BoxNonAlloc(Vector2 point, Vector2 halfExtents, float angle, Collider2D[] results, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapBoxNonAlloc(point, halfExtents, angle, results, layerMask, minDepth, maxDepth);
    }
}