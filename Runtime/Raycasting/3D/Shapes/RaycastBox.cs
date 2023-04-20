using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static bool Box(Ray ray, Vector3 halfExtents) =>
            Box(ray.origin, halfExtents, ray.direction);

        public static bool Box(Ray ray, Vector3 halfExtents, Quaternion orientation) =>
            Box(ray.origin, halfExtents, ray.direction, orientation);

        public static bool Box(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance);

        public static bool Box(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance, int layerMask) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask);

        public static bool Box(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask, queryTriggerInteraction);


        public static bool Box(Ray ray, Vector3 halfExtents, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, out hitInfo);

        public static bool Box(Ray ray, Vector3 halfExtents, Quaternion orientation, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, out hitInfo);

        public static bool Box(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, out hitInfo);

        public static bool Box(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance, int layerMask, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask, out hitInfo);

        public static bool Box(Ray ray, Vector3 halfExtents, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask, queryTriggerInteraction, out hitInfo);



        public static bool Box(Ray ray, Vector3 halfExtents, Vector3 orientation) =>
            Box(ray.origin, halfExtents, ray.direction, orientation);

        public static bool Box(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance);

        public static bool Box(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance, int layerMask) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask);

        public static bool Box(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask, queryTriggerInteraction);


        public static bool Box(Ray ray, Vector3 halfExtents, Vector3 orientation, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, out hitInfo);

        public static bool Box(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, out hitInfo);

        public static bool Box(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance, int layerMask, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask, out hitInfo);

        public static bool Box(Ray ray, Vector3 halfExtents, Vector3 orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Box(ray.origin, halfExtents, ray.direction, orientation, maxDistance, layerMask, queryTriggerInteraction, out hitInfo);




        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction) =>
            Physics.BoxCast(center, halfExtents, direction);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation) =>
            Physics.BoxCast(center, halfExtents, direction, orientation);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance) =>
            Physics.BoxCast(center, halfExtents, direction, orientation, maxDistance);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask) =>
            Physics.BoxCast(center, halfExtents, direction, orientation, maxDistance, layerMask);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.BoxCast(center, halfExtents, direction, orientation, maxDistance, layerMask, queryTriggerInteraction);


        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo, orientation);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo, orientation, maxDistance, layerMask, queryTriggerInteraction);



        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation) =>
            Physics.BoxCast(center, halfExtents, direction, Quaternion.Euler(orientation));

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance) =>
            Physics.BoxCast(center, halfExtents, direction, Quaternion.Euler(orientation), maxDistance);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance, int layerMask) =>
            Physics.BoxCast(center, halfExtents, direction, Quaternion.Euler(orientation), maxDistance, layerMask);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.BoxCast(center, halfExtents, direction, Quaternion.Euler(orientation), maxDistance, layerMask, queryTriggerInteraction);


        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo, Quaternion.Euler(orientation));

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo, Quaternion.Euler(orientation), maxDistance);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance, int layerMask, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo, Quaternion.Euler(orientation), maxDistance, layerMask);

        public static bool Box(Vector3 center, Vector3 halfExtents, Vector3 direction, Vector3 orientation, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Physics.BoxCast(center, halfExtents, direction, out hitInfo, Quaternion.Euler(orientation), maxDistance, layerMask, queryTriggerInteraction);
    }
}