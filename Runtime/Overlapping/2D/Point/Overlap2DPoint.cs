using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static bool Point(Vector2 point) =>
            Physics2D.OverlapPoint(point);

        public static bool Point(Vector2 point, int layerMask) =>
            Physics2D.OverlapPoint(point, layerMask);

        public static bool Point(Vector2 point, int layerMask, float minDepth) =>
            Physics2D.OverlapPoint(point, layerMask, minDepth);

        public static bool Point(Vector2 point, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapPoint(point, layerMask, minDepth, maxDepth);


        public static bool Point(Vector2 point, out Collider2D[] results)
        {
            results = Physics2D.OverlapPointAll(point);
            return results.Length > 0;
        }

        public static bool Point(Vector2 point, int layerMask, out Collider2D[] results)
        {
            results = Physics2D.OverlapPointAll(point, layerMask);
            return results.Length > 0;
        }

        public static bool Point(Vector2 point, int layerMask, float minDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapPointAll(point, layerMask, minDepth);
            return results.Length > 0;
        }

        public static bool Point(Vector2 point, int layerMask, float minDepth, float maxDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapPointAll(point, layerMask, minDepth, maxDepth);
            return results.Length > 0;
        }


        public static int PointNonAlloc(Vector2 point, Collider2D[] results) =>
            Physics2D.OverlapPointNonAlloc(point, results);

        public static int PointNonAlloc(Vector2 point, Collider2D[] results, int layerMask) =>
            Physics2D.OverlapPointNonAlloc(point, results, layerMask);

        public static int PointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth) =>
            Physics2D.OverlapPointNonAlloc(point, results, layerMask, minDepth);

        public static int PointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapPointNonAlloc(point, results, layerMask, minDepth, maxDepth);
    }
}