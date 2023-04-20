using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] CapsuleThrough(Vector3 point1, Vector3 point2, float radius, Vector3 direction) =>
            Physics.CapsuleCastAll(point1, point2, radius, direction);

        public static RaycastHit[] CapsuleThrough(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance) =>
            Physics.CapsuleCastAll(point1, point2, radius, direction, maxDistance);

        public static RaycastHit[] CapsuleThrough(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask) =>
            Physics.CapsuleCastAll(point1, point2, radius, direction, maxDistance, layerMask);

        public static RaycastHit[] CapsuleThrough(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.CapsuleCastAll(point1, point2, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
    }
}
