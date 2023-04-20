using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static bool Circle(Vector2 position, float radius) =>
            Physics2D.OverlapCircle(position, radius);

        public static bool Circle(Vector2 position, float radius, int layerMask) =>
            Physics2D.OverlapCircle(position, radius, layerMask);

        public static bool Circle(Vector2 position, float radius, int layerMask, float minDepth) =>
            Physics2D.OverlapCircle(position, radius, layerMask, minDepth);

        public static bool Circle(Vector2 position, float radius, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapCircle(position, radius, layerMask, minDepth, maxDepth);


        public static bool Circle(Vector2 position, float radius, out Collider2D[] results)
        {
            results = Physics2D.OverlapCircleAll(position, radius);
            return results.Length > 0;
        }

        public static bool Circle(Vector2 position, float radius, int layerMask, out Collider2D[] results)
        {
            results = Physics2D.OverlapCircleAll(position, radius, layerMask);
            return results.Length > 0;
        }

        public static bool Circle(Vector2 position, float radius, int layerMask, float minDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapCircleAll(position, radius, layerMask, minDepth);
            return results.Length > 0;
        }

        public static bool Circle(Vector2 position, float radius, int layerMask, float minDepth, float maxDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapCircleAll(position, radius, layerMask, minDepth, maxDepth);
            return results.Length > 0;
        }


        public static int CircleNonAlloc(Vector2 position, float radius, Collider2D[] results) =>
            Physics2D.OverlapCircleNonAlloc(position, radius, results);

        public static int CircleNonAlloc(Vector2 position, float radius, Collider2D[] results, int layerMask) =>
            Physics2D.OverlapCircleNonAlloc(position, radius, results, layerMask);

        public static int CircleNonAlloc(Vector2 position, float radius, Collider2D[] results, int layerMask, float minDepth) =>
            Physics2D.OverlapCircleNonAlloc(position, radius, results, layerMask, minDepth);

        public static int CircleNonAlloc(Vector2 position, float radius, Collider2D[] results, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapCircleNonAlloc(position, radius, results, layerMask, minDepth, maxDepth);
    }
}