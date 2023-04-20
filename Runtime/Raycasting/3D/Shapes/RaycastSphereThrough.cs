using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] SphereThrough(Ray ray, float radius) =>
            Physics.SphereCastAll(ray, radius);

        public static RaycastHit[] SphereThrough(Ray ray, float radius, float maxDistance) =>
            Physics.SphereCastAll(ray, radius, maxDistance);

        public static RaycastHit[] SphereThrough(Ray ray, float radius, float maxDistance, int layerMask) =>
            Physics.SphereCastAll(ray, radius, maxDistance, layerMask);

        public static RaycastHit[] SphereThrough(Ray ray, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.SphereCastAll(ray, radius, maxDistance, layerMask, queryTriggerInteraction);



        public static RaycastHit[] SphereThrough(Vector3 origin, Vector3 direction, float radius) =>
            Physics.SphereCastAll(origin, radius, direction);

        public static RaycastHit[] SphereThrough(Vector3 origin, Vector3 direction, float radius, float maxDistance) =>
            Physics.SphereCastAll(origin, radius, direction, maxDistance);

        public static RaycastHit[] SphereThrough(Vector3 origin, Vector3 direction, float radius, float maxDistance, int layerMask) =>
            Physics.SphereCastAll(origin, radius, direction, maxDistance, layerMask);

        public static RaycastHit[] SphereThrough(Vector3 origin, Vector3 direction, float radius, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.SphereCastAll(origin, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
    }
}
