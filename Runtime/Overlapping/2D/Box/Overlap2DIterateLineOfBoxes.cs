using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, Vector2 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, 0f, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, angle, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, angle, layerMask, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, angle, layerMask, minDepth, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, float maxDepth)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, angle, layerMask, minDepth, maxDepth, out Collider2D[] results))
                    yield return results;
            }
        }


        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, Vector2 direction, int numberOfBoxes, float totalDistance, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, 0f, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, 0f));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }

        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, angle, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, angle));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }

        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, angle, layerMask, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, angle));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }

        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, angle, layerMask, minDepth, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, angle));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }

        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, float maxDepth, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, angle, layerMask, minDepth, maxDepth, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, angle));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }



        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, Vector2 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), 0f, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), angle, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), angle, layerMask, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), angle, layerMask, minDepth, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, float maxDepth)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), angle, layerMask, minDepth, maxDepth, out Collider2D[] results))
                    yield return results;
            }
        }


        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, Vector2 direction, int numberOfBoxes, float totalDistance, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, 0f, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, 0f));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }

        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, angle, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, angle));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }

        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, angle, layerMask, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, angle));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }

        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, angle, layerMask, minDepth, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, angle));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }

        public static IEnumerable<BoxOverlapInfo2D> IterateLineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, float maxDepth, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, angle, layerMask, minDepth, maxDepth, out Collider2D[] results);

                if (didHit)
                    yield return new BoxOverlapInfo2D(results, new BoxOverlap2D(newCenter, halfExtents, angle));
                else if (!hitsOnly)
                    yield return new BoxOverlapInfo2D(null, new BoxOverlap2D(newCenter, halfExtents, 0f));
            }
        }
    }
}