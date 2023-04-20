using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static bool Capsule(Vector3 point0, Vector3 point1, float radius) =>
            Physics.CheckCapsule(point0, point1, radius);

        public static bool Capsule(Vector3 point0, Vector3 point1, float radius, int layerMask) =>
            Physics.CheckCapsule(point0, point1, radius, layerMask);

        public static bool Capsule(Vector3 point0, Vector3 point1, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.CheckCapsule(point0, point1, radius, layerMask, queryTriggerInteraction);


        public static bool Capsule(Vector3 point0, Vector3 point1, float radius, out Collider[] results)
        {
            results = Physics.OverlapCapsule(point0, point1, radius);
            return results.Length > 0;
        }

        public static bool Capsule(Vector3 point0, Vector3 point1, float radius, int layerMask, out Collider[] results)
        {
            results = Physics.OverlapCapsule(point0, point1, radius, layerMask);
            return results.Length > 0;
        }

        public static bool Capsule(Vector3 point0, Vector3 point1, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out Collider[] results)
        {
            results = Physics.OverlapCapsule(point0, point1, radius, layerMask, queryTriggerInteraction);
            return results.Length > 0;
        }


        public static int CapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results) =>
            Physics.OverlapCapsuleNonAlloc(point0, point1, radius, results);

        public static int CapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, int layerMask) =>
            Physics.OverlapCapsuleNonAlloc(point0, point1, radius, results, layerMask);

        public static int CapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.OverlapCapsuleNonAlloc(point0, point1, radius, results, layerMask, queryTriggerInteraction);
    }
}