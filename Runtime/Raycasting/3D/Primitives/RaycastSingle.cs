using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static bool Single(Ray ray) =>
            Physics.Raycast(ray);

        public static bool Single(Ray ray, float maxDistance) =>
            Physics.Raycast(ray, maxDistance);

        public static bool Single(Ray ray, int layerMask) =>
            Physics.Raycast(ray, Mathf.Infinity, layerMask);

        public static bool Single(Ray ray, float maxDistance, int layerMask) =>
            Physics.Raycast(ray, maxDistance, layerMask);

        public static bool Single(Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.Raycast(ray, maxDistance, layerMask, queryTriggerInteraction);


        public static bool Single(Ray ray, out RaycastHit hitInfo) =>
            Physics.Raycast(ray, out hitInfo);

        public static bool Single(Ray ray, float maxDistance, out RaycastHit hitInfo) =>
            Physics.Raycast(ray, out hitInfo, maxDistance);

        public static bool Single(Ray ray, int layerMask, out RaycastHit hitInfo) =>
            Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask);

        public static bool Single(Ray ray, float maxDistance, int layerMask, out RaycastHit hitInfo) =>
            Physics.Raycast(ray, out hitInfo, maxDistance, layerMask);

        public static bool Single(Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Physics.Raycast(ray, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);



        public static bool Single(Vector3 origin, Vector3 direction) =>
            Physics.Raycast(origin, direction);

        public static bool Single(Vector3 origin, Vector3 direction, float distance) =>
            Physics.Raycast(origin, direction, distance);

        public static bool Single(Vector3 origin, Vector3 direction, int layerMask) =>
            Physics.Raycast(origin, direction, Mathf.Infinity, layerMask);

        public static bool Single(Vector3 origin, Vector3 direction, float distance, int layerMask) =>
            Physics.Raycast(origin, direction, distance, layerMask);

        public static bool Single(Vector3 origin, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.Raycast(origin, direction, distance, layerMask, queryTriggerInteraction);


        public static bool Single(Vector3 origin, Vector3 direction, out RaycastHit hitInfo) =>
            Physics.Raycast(origin, direction, out hitInfo);

        public static bool Single(Vector3 origin, Vector3 direction, float distance, out RaycastHit hitInfo) =>
            Physics.Raycast(origin, direction, out hitInfo, distance);

        public static bool Single(Vector3 origin, Vector3 direction, int layerMask, out RaycastHit hitInfo) =>
            Physics.Raycast(origin, direction, out hitInfo, Mathf.Infinity, layerMask);

        public static bool Single(Vector3 origin, Vector3 direction, float distance, int layerMask, out RaycastHit hitInfo) =>
            Physics.Raycast(origin, direction, out hitInfo, distance, layerMask);

        public static bool Single(Vector3 origin, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Physics.Raycast(origin, direction, out hitInfo, distance, layerMask, queryTriggerInteraction);
    }
}
