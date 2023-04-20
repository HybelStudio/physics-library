using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static bool Capsule(Vector3 point1, Vector3 point2, float radius, Vector3 direction) =>
            Physics.CapsuleCast(point1, point2, radius, direction);

        public static bool Capsule(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance) =>
            Physics.CapsuleCast(point1, point2, radius, direction, maxDistance);

        public static bool Capsule(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask) =>
            Physics.CapsuleCast(point1, point2, radius, direction, maxDistance, layerMask);

        public static bool Capsule(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.CapsuleCast(point1, point2, radius, direction, maxDistance, layerMask, queryTriggerInteraction);


        public static bool Capsule(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo) =>
            Physics.CapsuleCast(point1, point2, radius, direction, out hitInfo);

        public static bool Capsule(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, out RaycastHit hitInfo) =>
            Physics.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance);
        public static bool Capsule(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask, out RaycastHit hitInfo) =>
            Physics.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask);

        public static bool Capsule(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Physics.CapsuleCast(point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
    }
}
