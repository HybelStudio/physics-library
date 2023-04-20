using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, Vector2 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, 0f, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, angle, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, angle, layerMask, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, angle, layerMask, minDepth, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, float maxDepth)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtents, angle, layerMask, minDepth, maxDepth, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }


        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, Vector2 direction, int numberOfBoxes, float totalDistance, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, 0f, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, 0f));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, 0f));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, angle, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, angle, layerMask, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, angle, layerMask, minDepth, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, Vector2 halfExtents, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, float maxDepth, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                var didHit = Box(newCenter, halfExtents, angle, layerMask, minDepth, maxDepth, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }



        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, Vector2 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), 0f, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), angle, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), angle, layerMask, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), angle, layerMask, minDepth, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, float maxDepth)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                if (Box(newCenter, halfExtentsPerOverlapFunc(i), angle, layerMask, minDepth, maxDepth, out Collider2D[] results))
                    colliderArrays.Add(results);
            }

            return colliderArrays.ToArray();
        }


        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, Vector2 direction, int numberOfBoxes, float totalDistance, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, 0f, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, 0f));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, 0f));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, angle, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, angle, layerMask, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, angle, layerMask, minDepth, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }

        public static Collider2D[][] LineOfBoxes(Vector2 center, OverlapIterationFunc<Vector2> halfExtentsPerOverlapFunc, float angle, Vector2 direction, int numberOfBoxes, float totalDistance, int layerMask, float minDepth, float maxDepth, out BoxOverlap2D[] boxOverlaps, bool hitsOnly = true)
        {
            LineOfBoxesSetup(direction, numberOfBoxes, totalDistance, out var positionIncrement);

            List<Collider2D[]> colliderArrays = new List<Collider2D[]>();
            List<BoxOverlap2D> boxOverlapList = new List<BoxOverlap2D>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                var newCenter = center + (positionIncrement * i);

                Vector2 halfExtents = halfExtentsPerOverlapFunc(i);
                var didHit = Box(newCenter, halfExtents, angle, layerMask, minDepth, maxDepth, out Collider2D[] results);

                if (didHit)
                {
                    colliderArrays.Add(results);
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
                else if (!hitsOnly)
                {
                    boxOverlapList.Add(new BoxOverlap2D(newCenter, halfExtents, angle));
                }
            }

            boxOverlaps = boxOverlapList.ToArray();
            return colliderArrays.ToArray();
        }


        private static void LineOfBoxesSetup(Vector2 direction, int numberOfBoxes, float totalDistance, out Vector2 positionIncrement)
        {
            float distanceDelta = totalDistance / numberOfBoxes;
            positionIncrement = direction.normalized * distanceDelta;
        }
    }
}