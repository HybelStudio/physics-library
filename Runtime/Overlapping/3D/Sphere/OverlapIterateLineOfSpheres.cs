using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static IEnumerable<Collider[]> IterateLineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                if (Sphere(newPosition, radius, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                if (Sphere(newPosition, radius, layerMask, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                if (Sphere(newPosition, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    yield return overlap;
            }
        }


        public static IEnumerable<Collider[]> IterateLineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                if (Sphere(newPosition, radiusPerOverlap(i), out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                if (Sphere(newPosition, radiusPerOverlap(i), layerMask, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                if (Sphere(newPosition, radiusPerOverlap(i), layerMask, queryTriggerInteraction, out Collider[] overlap))
                    yield return overlap;
            }
        }



        public static IEnumerable<SphereOverlapInfo> IterateOutLineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                bool didHit = Sphere(newPosition, radius, out Collider[] colliders);

                if (didHit)
                    yield return new SphereOverlapInfo(colliders, new SphereOverlap(newPosition, radius));
                else if (!hitsOnly)
                    yield return new SphereOverlapInfo(null, new SphereOverlap(newPosition, radius));
            }
        }

        public static IEnumerable<SphereOverlapInfo> IterateOutLineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                bool didHit = Sphere(newPosition, radius, layerMask, out Collider[] colliders);
                
                if (didHit)
                    yield return new SphereOverlapInfo(colliders, new SphereOverlap(newPosition, radius));
                else if (!hitsOnly)
                    yield return new SphereOverlapInfo(null, new SphereOverlap(newPosition, radius));
            }
        }

        public static IEnumerable<SphereOverlapInfo> IterateOutLineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                bool didHit = Sphere(newPosition, radius, layerMask, queryTriggerInteraction, out Collider[] colliders);
                
                if (didHit)
                    yield return new SphereOverlapInfo(colliders, new SphereOverlap(newPosition, radius));
                else if (!hitsOnly)
                    yield return new SphereOverlapInfo(null, new SphereOverlap(newPosition, radius));
            }
        }


        public static IEnumerable<SphereOverlapInfo> IterateOutLineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                float radius = radiusPerOverlap(i);
                bool didHit = Sphere(newPosition, radius, out Collider[] colliders);
                
                if (didHit)
                    yield return new SphereOverlapInfo(colliders, new SphereOverlap(newPosition, radius));
                else if (!hitsOnly)
                    yield return new SphereOverlapInfo(null, new SphereOverlap(newPosition, radius));
            }
        }

        public static IEnumerable<SphereOverlapInfo> IterateOutLineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                float radius = radiusPerOverlap(i);
                bool didHit = Sphere(newPosition, radius, layerMask, out Collider[] colliders);
                
                if (didHit)
                    yield return new SphereOverlapInfo(colliders, new SphereOverlap(newPosition, radius));
                else if (!hitsOnly)
                    yield return new SphereOverlapInfo(null, new SphereOverlap(newPosition, radius));
            }
        }

        public static IEnumerable<SphereOverlapInfo> IterateOutLineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / numberOfSpheres;
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfSpheres; i++)
            {
                Vector3 newPosition = position + (positionIncrement * i);
                float radius = radiusPerOverlap(i);
                bool didHit = Sphere(newPosition, radius, layerMask, queryTriggerInteraction, out Collider[] colliders);
                
                if (didHit)
                    yield return new SphereOverlapInfo(colliders, new SphereOverlap(newPosition, radius));
                else if (!hitsOnly)
                    yield return new SphereOverlapInfo(null, new SphereOverlap(newPosition, radius));
            }
        }
    }
}