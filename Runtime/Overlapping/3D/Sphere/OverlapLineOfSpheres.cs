using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static Collider[][] LineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);
                if (Sphere(newPosition, radius, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        public static Collider[][] LineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Sphere(newPosition, radius, layerMask, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        public static Collider[][] LineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Sphere(newPosition, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }


        public static Collider[][] LineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, out SphereOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);
            List<SphereOverlap> sphereOverlapList = new List<SphereOverlap>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);
                var didHit = Sphere(newPosition, radius, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider[][] LineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, out SphereOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);
            List<SphereOverlap> sphereOverlapList = new List<SphereOverlap>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);
                var didHit = Sphere(newPosition, radius, layerMask, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider[][] LineOfSpheres(Vector3 position, float radius, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out SphereOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);
            List<SphereOverlap> sphereOverlapList = new List<SphereOverlap>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);
                var didHit = Sphere(newPosition, radius, layerMask, queryTriggerInteraction, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }



        public static Collider[][] LineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);
                if (Sphere(newPosition, radiusPerOverlap(i), out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        public static Collider[][] LineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Sphere(newPosition, radiusPerOverlap(i), layerMask, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        public static Collider[][] LineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Sphere(newPosition, radiusPerOverlap(i), layerMask, queryTriggerInteraction, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }


        public static Collider[][] LineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, out SphereOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);
            List<SphereOverlap> sphereOverlapList = new List<SphereOverlap>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);
                var radius = radiusPerOverlap(i);
                var didHit = Sphere(newPosition, radius, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider[][] LineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, out SphereOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);
            List<SphereOverlap> sphereOverlapList = new List<SphereOverlap>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);
                var radius = radiusPerOverlap(i);
                var didHit = Sphere(newPosition, radius, layerMask, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider[][] LineOfSpheres(Vector3 position, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfSpheres, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out SphereOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfSpheres - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            List<Collider[]> colliders = new List<Collider[]>(numberOfSpheres);
            List<SphereOverlap> sphereOverlapList = new List<SphereOverlap>(numberOfSpheres);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                var newPosition = position + (positionIncrement * i);
                var radius = radiusPerOverlap(i);
                var didHit = Sphere(newPosition, radius, layerMask, queryTriggerInteraction, out Collider[] overlap);

                 if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new SphereOverlap(newPosition, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }
    }
}