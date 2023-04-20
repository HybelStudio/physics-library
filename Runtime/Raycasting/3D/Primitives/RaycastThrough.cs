using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] Through(Ray ray) =>
            Physics.RaycastAll(ray);

        public static RaycastHit[] Through(Ray ray, float distance) =>
            Physics.RaycastAll(ray, distance);

        public static RaycastHit[] Through(Ray ray, int layerMask) =>
            Physics.RaycastAll(ray, layerMask);

        public static RaycastHit[] Through(Ray ray, float distance, int layerMask) =>
            Physics.RaycastAll(ray, distance, layerMask);

        public static RaycastHit[] Through(Ray ray, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.RaycastAll(ray, distance, layerMask, queryTriggerInteraction);


        public static RaycastHit[] Through(Vector3 origin, Vector3 direction) =>
            Physics.RaycastAll(origin, direction);

        public static RaycastHit[] Through(Vector3 origin, Vector3 direction, float distance) =>
            Physics.RaycastAll(origin, direction, distance);

        public static RaycastHit[] Through(Vector3 origin, Vector3 direction, int layermask) =>
            Physics.RaycastAll(origin, direction, layermask);

        public static RaycastHit[] Through(Vector3 origin, Vector3 direction, float distance, int layerMask) =>
            Physics.RaycastAll(origin, direction, distance, layerMask);

        public static RaycastHit[] Through(Vector3 origin, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.RaycastAll(origin, direction, distance, layerMask, queryTriggerInteraction);
    }
}
