using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction);

        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents, Quaternion orientation) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, orientation);

        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, orientation, maxDistance);

        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance, int layerMask) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask);

        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask, queryTriggerInteraction);



        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents, Vector3 orientation) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, Quaternion.Euler(orientation));

        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, Quaternion.Euler(orientation), maxDistance);

        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance, int layerMask) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, Quaternion.Euler(orientation), maxDistance, layerMask);

        public static RaycastHit[] BoxThrough(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, Quaternion.Euler(orientation), maxDistance, layerMask, queryTriggerInteraction);




        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction) =>
            Physics.BoxCastAll(center, halfExtents, direction);

        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation) =>
            Physics.BoxCastAll(center, halfExtents, direction, orientation);

        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance) =>
            Physics.BoxCastAll(center, halfExtents, direction, orientation, maxDistance);

        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask) =>
            Physics.BoxCastAll(center, halfExtents, direction, orientation, maxDistance, layerMask);

        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.BoxCastAll(center, halfExtents, direction, orientation, maxDistance, layerMask, queryTriggerInteraction);



        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation) =>
            Physics.BoxCastAll(center, halfExtents, direction, Quaternion.Euler(orientation));

        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance) =>
            Physics.BoxCastAll(center, halfExtents, direction, Quaternion.Euler(orientation), maxDistance);

        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance, int layerMask) =>
            Physics.BoxCastAll(center, halfExtents, direction, Quaternion.Euler(orientation), maxDistance, layerMask);

        public static RaycastHit[] BoxThrough(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.BoxCastAll(center, halfExtents, direction, Quaternion.Euler(orientation), maxDistance, layerMask, queryTriggerInteraction);
    }
}
