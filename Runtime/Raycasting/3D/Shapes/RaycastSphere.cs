using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static bool Sphere(Ray ray, float radius) =>
            Physics.SphereCast(ray, radius);

        public static bool Sphere(Ray ray, float radius, float maxDistance) =>
            Physics.SphereCast(ray, radius, maxDistance);

        public static bool Sphere(Ray ray, float radius, float maxDistance, int layerMask) =>
            Physics.SphereCast(ray, radius, maxDistance, layerMask);

        public static bool Sphere(Ray ray, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.SphereCast(ray, radius, maxDistance, layerMask, queryTriggerInteraction);


        public static bool Sphere(Ray ray, float radius, out RaycastHit hitInfo) =>
            Physics.SphereCast(ray, radius, out hitInfo);

        public static bool Sphere(Ray ray, float radius, float maxDistance, out RaycastHit hitInfo) =>
            Physics.SphereCast(ray, radius, out hitInfo, maxDistance);

        public static bool Sphere(Ray ray, float radius, float maxDistance, int layerMask, out RaycastHit hitInfo) =>
            Physics.SphereCast(ray, radius, out hitInfo, maxDistance, layerMask);

        public static bool Sphere(Ray ray, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Physics.SphereCast(ray, radius, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);



        public static bool Sphere(Vector3 origin, Vector3 direction, float radius) =>
            Physics.SphereCast(origin, radius, direction, out _);

        public static bool Sphere(Vector3 origin, Vector3 direction, float radius, float maxDistance) =>
            Physics.SphereCast(origin, radius, direction, out _, maxDistance);

        public static bool Sphere(Vector3 origin, Vector3 direction, float radius, float maxDistance, int layerMask) =>
            Physics.SphereCast(origin, radius, direction, out _, maxDistance, layerMask);

        public static bool Sphere(Vector3 origin, Vector3 direction, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.SphereCast(origin, radius, direction, out _, maxDistance, layerMask, queryTriggerInteraction);


        public static bool Sphere(Vector3 origin, Vector3 direction, float radius, out RaycastHit hitInfo) =>
            Physics.SphereCast(origin, radius, direction, out hitInfo);

        public static bool Sphere(Vector3 origin, Vector3 direction, float radius, float maxDistance, out RaycastHit hitInfo) =>
            Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance);

        public static bool Sphere(Vector3 origin, Vector3 direction, float radius, float maxDistance, int layerMask, out RaycastHit hitInfo) =>
            Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask);

        public static bool Sphere(Vector3 origin, Vector3 direction, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);

        
    }
}
