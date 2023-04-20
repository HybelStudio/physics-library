using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static bool Area(Vector2 pointA, Vector2 pointB) =>
            Physics2D.OverlapArea(pointA, pointB);

        public static bool Area(Vector2 pointA, Vector2 pointB, int layerMask) =>
            Physics2D.OverlapArea(pointA, pointB, layerMask);

        public static bool Area(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth) =>
            Physics2D.OverlapArea(pointA, pointB, layerMask, minDepth);

        public static bool Area(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapArea(pointA, pointB, layerMask, minDepth, maxDepth);


        public static bool Area(Vector2 pointA, Vector2 pointB, out Collider2D[] results)
        {
            results = Physics2D.OverlapAreaAll(pointA, pointB);
            return results.Length > 0;
        }

        public static bool Area(Vector2 pointA, Vector2 pointB, int layerMask, out Collider2D[] results)
        {
            results = Physics2D.OverlapAreaAll(pointA, pointB, layerMask);
            return results.Length > 0;
        }

        public static bool Area(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapAreaAll(pointA, pointB, layerMask, minDepth);
            return results.Length > 0;
        }

        public static bool Area(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth, out Collider2D[] results)
        {
            results = Physics2D.OverlapAreaAll(pointA, pointB, layerMask, minDepth, maxDepth);
            return results.Length > 0;
        }


        public static int AreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results) =>
            Physics2D.OverlapAreaNonAlloc(pointA, pointB, results);

        public static int AreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask) =>
            Physics2D.OverlapAreaNonAlloc(pointA, pointB, results, layerMask);

        public static int AreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth) =>
            Physics2D.OverlapAreaNonAlloc(pointA, pointB, results, layerMask, minDepth);

        public static int AreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.OverlapAreaNonAlloc(pointA, pointB, results, layerMask, minDepth, maxDepth);
    }
}