using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static bool Sphere(Vector3 position, float radius) =>
               Physics.CheckSphere(position, radius);

        public static bool Sphere(Vector3 position, float radius, int layerMask) =>
            Physics.CheckSphere(position, radius, layerMask);

        public static bool Sphere(Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.CheckSphere(position, radius, layerMask, queryTriggerInteraction);


        public static bool Sphere(Vector3 position, float radius, out Collider[] results)
        {
            results = Physics.OverlapSphere(position, radius);
            return results.Length > 0;
        }

        public static bool Sphere(Vector3 position, float radius, int layerMask, out Collider[] results)
        {
            results = Physics.OverlapSphere(position, radius, layerMask);
            return results.Length > 0;
        }

        public static bool Sphere(Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out Collider[] results)
        {
            results = Physics.OverlapSphere(position, radius, layerMask, queryTriggerInteraction);
            return results.Length > 0;
        }


        public static int SphereNonAlloc(Vector3 position, float radius, Collider[] results) =>
            Physics.OverlapSphereNonAlloc(position, radius, results);

        public static int SphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask) =>
            Physics.OverlapSphereNonAlloc(position, radius, results, layerMask);

        public static int SphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.OverlapSphereNonAlloc(position, radius, results, layerMask, queryTriggerInteraction);
    }
}