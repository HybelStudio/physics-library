using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static IEnumerable<Collider[]> IterateLineOfBoxes(Vector3 center, Vector3 halfExtents, Vector3 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                if (Box(newPosition, halfExtents, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                if (Box(newPosition, halfExtents, orientation, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                if (Box(newPosition, halfExtents, orientation, layerMask, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                if (Box(newPosition, halfExtents, orientation, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    yield return overlap;
            }
        }


        public static IEnumerable<BoxOverlapInfo> IterateOutLineOfBoxes(Vector3 center, Vector3 halfExtents, Vector3 direction, int numberOfBoxes, float totalDistance, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                var didHit = Box(newPosition, halfExtents, out Collider[] colliders);

                if (didHit)
                    yield return new BoxOverlapInfo(colliders, new BoxOverlap(newPosition, halfExtents, Quaternion.identity));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo(null, new BoxOverlap(newPosition, halfExtents, Quaternion.identity));
            }
        }

        public static IEnumerable<BoxOverlapInfo> IterateOutLineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                var didHit = Box(newPosition, halfExtents, orientation, out Collider[] colliders);

                if (didHit)
                    yield return new BoxOverlapInfo(colliders, new BoxOverlap(newPosition, halfExtents, orientation));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo(null, new BoxOverlap(newPosition, halfExtents, orientation));
            }
        }

        public static IEnumerable<BoxOverlapInfo> IterateOutLineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                var didHit = Box(newPosition, halfExtents, orientation, layerMask, out Collider[] colliders);

                if (didHit)
                    yield return new BoxOverlapInfo(colliders, new BoxOverlap(newPosition, halfExtents, orientation));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo(null, new BoxOverlap(newPosition, halfExtents, orientation));

            }
        }

        public static IEnumerable<BoxOverlapInfo> IterateOutLineOfBoxes(Vector3 center, Vector3 halfExtents, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                var didHit = Box(newPosition, halfExtents, orientation, layerMask, queryTriggerInteraction, out Collider[] colliders);

                if (didHit)
                    yield return new BoxOverlapInfo(colliders, new BoxOverlap(newPosition, halfExtents, orientation));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo(null, new BoxOverlap(newPosition, halfExtents, orientation));
            }
        }



        public static IEnumerable<Collider[]> IterateLineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Vector3 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                if (Box(newPosition, halfExtentsPerOverlap(i), out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                if (Box(newPosition, halfExtentsPerOverlap(i), orientation, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                if (Box(newPosition, halfExtentsPerOverlap(i), orientation, layerMask, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                if (Box(newPosition, halfExtentsPerOverlap(i), orientation, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    yield return overlap;
            }
        }


        public static IEnumerable<BoxOverlapInfo> IterateOutLineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Vector3 direction, int numberOfBoxes, float totalDistance, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                var halfExtents = halfExtentsPerOverlap(i);
                var didHit = Box(newPosition, halfExtents, out Collider[] colliders);

                if (didHit)
                    yield return new BoxOverlapInfo(colliders, new BoxOverlap(newPosition, halfExtents, Quaternion.identity));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo(null, new BoxOverlap(newPosition, halfExtents, Quaternion.identity));
            }
        }

        public static IEnumerable<BoxOverlapInfo> IterateOutLineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                var halfExtents = halfExtentsPerOverlap(i);
                var didHit = Box(newPosition, halfExtents, orientation, out Collider[] colliders);

                if (didHit)
                    yield return new BoxOverlapInfo(colliders, new BoxOverlap(newPosition, halfExtents, orientation));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo(null, new BoxOverlap(newPosition, halfExtents, orientation));
            }
        }

        public static IEnumerable<BoxOverlapInfo> IterateOutLineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                var halfExtents = halfExtentsPerOverlap(i);
                var didHit = Box(newPosition, halfExtents, orientation, layerMask, out Collider[] colliders);

                if (didHit)
                    yield return new BoxOverlapInfo(colliders, new BoxOverlap(newPosition, halfExtents, orientation));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo(null, new BoxOverlap(newPosition, halfExtents, orientation));
            }
        }

        public static IEnumerable<BoxOverlapInfo> IterateOutLineOfBoxes(Vector3 center, OverlapIterationFunc<Vector3> halfExtentsPerOverlap, Quaternion orientation, Vector3 direction, int numberOfBoxes, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newPosition = center + (positionIncrement * i);
                var halfExtents = halfExtentsPerOverlap(i);
                var didHit = Box(newPosition, halfExtents, orientation, layerMask, queryTriggerInteraction, out Collider[] colliders);

                if (didHit)
                    yield return new BoxOverlapInfo(colliders, new BoxOverlap(newPosition, halfExtents, orientation));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo(null, new BoxOverlap(newPosition, halfExtents, orientation));
            }
        }
    }
}