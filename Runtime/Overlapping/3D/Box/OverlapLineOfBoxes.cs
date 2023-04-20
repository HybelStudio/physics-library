using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static Collider[][] LineOfBoxes(Vector3 center, Vector3 halfExtents, Vector3 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                
                if (Box(newCenter, halfExtents, out Collider[] overlap))
                    colliderArrays.Add(overlap);
            }

            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                
                if (Box(newCenter, halfExtents, orientation, out Collider[] overlap))
                    colliderArrays.Add(overlap);
            }

            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                
                if (Box(newCenter, halfExtents, orientation, layerMask, out Collider[] overlap))
                    colliderArrays.Add(overlap);
            }

            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                
                if (Box(newCenter, halfExtents, orientation, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    colliderArrays.Add(overlap);
            }

            return colliderArrays.ToArray();
        }


        public static Collider[][] LineOfBoxes(Vector3 center, Vector3 halfExtents, Vector3 direction, int numberOfBoxes, float totalDistance, out BoxOverlap[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);
            List<BoxOverlap> listOfOverlaps = new List<BoxOverlap>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                var didHit = Box(newCenter, halfExtents, out Collider[] overlap);

                if (didHit)
                {
                    colliderArrays.Add(overlap);
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, Quaternion.identity));
                }
                else if (!hitsOnly)
                {
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, Quaternion.identity));
                }
            }

            boxOverlaps = listOfOverlaps.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, out BoxOverlap[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);
            List<BoxOverlap> listOfOverlaps = new List<BoxOverlap>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                var didHit = Box(newCenter, halfExtents, orientation, out Collider[] overlap);

                if (didHit)
                {
                    colliderArrays.Add(overlap);
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
                else if (!hitsOnly)
                {
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
            }

            boxOverlaps = listOfOverlaps.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, out BoxOverlap[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);
            List<BoxOverlap> listOfOverlaps = new List<BoxOverlap>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                var didHit = Box(newCenter, halfExtents, orientation, layerMask, out Collider[] overlap);

                if (didHit)
                {
                    colliderArrays.Add(overlap);
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
                else if (!hitsOnly)
                {
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
            }

            boxOverlaps = listOfOverlaps.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out BoxOverlap[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);
            List<BoxOverlap> listOfOverlaps = new List<BoxOverlap>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                var didHit = Box(newCenter, halfExtents, orientation, layerMask, queryTriggerInteraction, out Collider[] overlap);

                if (didHit)
                {
                    colliderArrays.Add(overlap);
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
                else if (!hitsOnly)
                {
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
            }

            boxOverlaps = listOfOverlaps.ToArray();
            return colliderArrays.ToArray();
        }



        public static Collider[][] LineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Vector3 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                Vector3 halfExtents = halfExtentsPerOverlap(i);
                
                if (Box(newCenter, halfExtents, out Collider[] overlap))
                    colliderArrays.Add(overlap);
            }

            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                Vector3 halfExtents = halfExtentsPerOverlap(i);
                
                if (Box(newCenter, halfExtents, orientation, out Collider[] overlap))
                    colliderArrays.Add(overlap);
            }

            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                Vector3 halfExtents = halfExtentsPerOverlap(i);
                
                if (Box(newCenter, halfExtents, orientation, layerMask, out Collider[] overlap))
                    colliderArrays.Add(overlap);
            }

            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                Vector3 halfExtents = halfExtentsPerOverlap(i);
                
                if (Box(newCenter, halfExtents, orientation, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    colliderArrays.Add(overlap);
            }

            return colliderArrays.ToArray();
        }


        public static Collider[][] LineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Vector3 direction, int numberOfBoxes, float totalDistance, out BoxOverlap[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);
            List<BoxOverlap> listOfOverlaps = new List<BoxOverlap>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                Vector3 halfExtents = halfExtentsPerOverlap(i);
                var didHit = Box(newCenter, halfExtents, out Collider[] overlap);

                if (didHit)
                {
                    colliderArrays.Add(overlap);
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, Quaternion.identity));
                }
                else if (!hitsOnly)
                {
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, Quaternion.identity));
                }
            }

            boxOverlaps = listOfOverlaps.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, out BoxOverlap[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);
            List<BoxOverlap> listOfOverlaps = new List<BoxOverlap>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                Vector3 halfExtents = halfExtentsPerOverlap(i);
                var didHit = Box(newCenter, halfExtents, orientation, out Collider[] overlap);

                if (didHit)
                {
                    colliderArrays.Add(overlap);
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
                else if (!hitsOnly)
                {
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
            }

            boxOverlaps = listOfOverlaps.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, out BoxOverlap[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);
            List<BoxOverlap> listOfOverlaps = new List<BoxOverlap>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                Vector3 halfExtents = halfExtentsPerOverlap(i);
                var didHit = Box(newCenter, halfExtents, orientation, layerMask, out Collider[] overlap);

                if (didHit)
                {
                    colliderArrays.Add(overlap);
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
                else if (!hitsOnly)
                {
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
            }

            boxOverlaps = listOfOverlaps.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider[][] LineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out BoxOverlap[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider[]> colliderArrays = new List<Collider[]>(numberOfBoxes);
            List<BoxOverlap> listOfOverlaps = new List<BoxOverlap>(numberOfBoxes);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);
                Vector3 halfExtents = halfExtentsPerOverlap(i);
                var didHit = Box(newCenter, halfExtents, orientation, layerMask, queryTriggerInteraction, out Collider[] overlap);

                if (didHit)
                {
                    colliderArrays.Add(overlap);
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
                else if (!hitsOnly)
                {
                    listOfOverlaps.Add(new BoxOverlap(newCenter, halfExtents, orientation));
                }
            }

            boxOverlaps = listOfOverlaps.ToArray();
            return colliderArrays.ToArray();
        }


        private static void LineOfBoxesSetup(Vector3 direction, int numberOfBoxes, float totalDistance, out Vector3 positionIncrement)
        {
            float distanceDelta = totalDistance / numberOfBoxes;
            positionIncrement = direction.normalized * distanceDelta;
        }
    }
}