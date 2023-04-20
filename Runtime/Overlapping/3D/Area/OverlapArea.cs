using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static bool Area(Vector3 pointA, Vector3 pointB)
        {
            AreaToBox(pointA, pointB, out Vector3 center, out Vector3 size);
            return Box(center, size, Quaternion.identity);
        }

        public static bool Area(Vector3 pointA, Vector3 pointB, int layerMask)
        {
            Vector3 center = (pointA + pointB) * .5f;
            Vector3 size = new Vector3(Mathf.Abs(pointA.x - pointB.x), Mathf.Abs(pointA.y - pointB.y), Mathf.Abs(pointA.z - pointB.z));
            return Box(center, size, Quaternion.identity, layerMask);
        }

        public static bool Area(Vector3 pointA, Vector3 pointB, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            Vector3 center = (pointA + pointB) * .5f;
            Vector3 size = new Vector3(Mathf.Abs(pointA.x - pointB.x), Mathf.Abs(pointA.y - pointB.y), Mathf.Abs(pointA.z - pointB.z));
            return Box(center, size, Quaternion.identity, layerMask, queryTriggerInteraction);
        }


        public static bool Area(Vector3 pointA, Vector3 pointB, out Collider[] results)
        {
            AreaToBox(pointA, pointB, out Vector3 center, out Vector3 size);
            return Box(center, size, Quaternion.identity, out results);
        }

        public static bool Area(Vector3 pointA, Vector3 pointB, int layerMask, out Collider[] results)
        {
            AreaToBox(pointA, pointB, out Vector3 center, out Vector3 size);
            return Box(center, size, Quaternion.identity, layerMask, out results);
        }

        public static bool Area(Vector3 pointA, Vector3 pointB, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out Collider[] results)
        {
            AreaToBox(pointA, pointB, out Vector3 center, out Vector3 size);
            return Box(center, size, Quaternion.identity, layerMask, queryTriggerInteraction, out results);
        }


        public static int AreaNonAlloc(Vector3 pointA, Vector3 pointB, Collider[] results)
        {
            AreaToBox(pointA, pointB, out Vector3 center, out Vector3 size);
            return BoxNonAlloc(center, size, results, Quaternion.identity);
        }

        public static int AreaNonAlloc(Vector3 pointA, Vector3 pointB, Collider[] results, int layerMask)
        {
            AreaToBox(pointA, pointB, out Vector3 center, out Vector3 size);
            return BoxNonAlloc(center, size, results, Quaternion.identity, layerMask);
        }

        public static int AreaNonAlloc(Vector3 pointA, Vector3 pointB, Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            AreaToBox(pointA, pointB, out Vector3 center, out Vector3 size);
            return BoxNonAlloc(center, size, results, Quaternion.identity, layerMask, queryTriggerInteraction);
        }


        private static void AreaToBox(Vector3 pointA, Vector3 pointB, out Vector3 center, out Vector3 size)
        {
            center = (pointA + pointB) * .5f;
            size = new Vector3(Mathf.Abs(pointA.x - pointB.x), Mathf.Abs(pointA.y - pointB.y), Mathf.Abs(pointA.z - pointB.z));
        }
    }
}