using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static bool Box(Vector3 center, Vector3 halfExtents) =>
            Physics.CheckBox(center, halfExtents);

        public static bool Box(Vector3 center, Vector3 halfExtents, Quaternion orientation) =>
            Physics.CheckBox(center, halfExtents, orientation);

        public static bool Box(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask) =>
            Physics.CheckBox(center, halfExtents, orientation, layerMask);

        public static bool Box(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.CheckBox(center, halfExtents, orientation, layerMask, queryTriggerInteraction);


        public static bool Box(Vector3 center, Vector3 halfExtents, out Collider[] results)
        {
            results = Physics.OverlapBox(center, halfExtents);
            return results.Length > 0;
        }

        public static bool Box(Vector3 center, Vector3 halfExtents, Quaternion orientation, out Collider[] results)
        {
            results = Physics.OverlapBox(center, halfExtents, orientation);
            return results.Length > 0;
        }

        public static bool Box(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask, out Collider[] results)
        {
            results = Physics.OverlapBox(center, halfExtents, orientation, layerMask);
            return results.Length > 0;
        }

        public static bool Box(Vector3 center, Vector3 halfExtents, Quaternion orientation, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out Collider[] results)
        {
            results = Physics.OverlapBox(center, halfExtents, orientation, layerMask, queryTriggerInteraction);
            return results.Length > 0;
        }


        public static int BoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results) =>
            Physics.OverlapBoxNonAlloc(center, halfExtents, results);

        public static int BoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation) =>
            Physics.OverlapBoxNonAlloc(center, halfExtents, results, orientation);

        public static int BoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, int layerMask) =>
            Physics.OverlapBoxNonAlloc(center, halfExtents, results, orientation, layerMask);

        public static int BoxNonAlloc(Vector3 center, Vector3 halfExtents, Collider[] results, Quaternion orientation, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.OverlapBoxNonAlloc(center, halfExtents, results, orientation, layerMask, queryTriggerInteraction);
    }
}
