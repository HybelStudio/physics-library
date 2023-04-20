using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static IEnumerable<Collider2D[]> IterateLineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;


            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radius, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;


            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radius, layerMask, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;


            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radius, layerMask, minDepth, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, float maxDepth)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;


            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radius, layerMask, minDepth, maxDepth, out Collider2D[] results))
                    yield return results;
            }
        }


        public static IEnumerable<CircleOverlapInfo2D> IterateLineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var didHit = Circle(newPosition, radius, out Collider2D[] results);

                if (didHit)
                    yield return new CircleOverlapInfo2D(results, new CircleOverlap2D(newPosition, radius));
                else if (!hitsOnly)
                    yield return new CircleOverlapInfo2D(null, new CircleOverlap2D(newPosition, radius));
            }
        }

        public static IEnumerable<CircleOverlapInfo2D> IterateLineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var didHit = Circle(newPosition, radius, layerMask, out Collider2D[] results);

                if (didHit)
                    yield return new CircleOverlapInfo2D(results, new CircleOverlap2D(newPosition, radius));
                else if (!hitsOnly)
                    yield return new CircleOverlapInfo2D(null, new CircleOverlap2D(newPosition, radius));
            }
        }

        public static IEnumerable<CircleOverlapInfo2D> IterateLineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var didHit = Circle(newPosition, radius, layerMask, minDepth, out Collider2D[] results);

                if (didHit)
                    yield return new CircleOverlapInfo2D(results, new CircleOverlap2D(newPosition, radius));
                else if (!hitsOnly)
                    yield return new CircleOverlapInfo2D(null, new CircleOverlap2D(newPosition, radius));
            }
        }

        public static IEnumerable<CircleOverlapInfo2D> IterateLineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, float maxDepth, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var didHit = Circle(newPosition, radius, layerMask, minDepth, maxDepth, out Collider2D[] results);

                if (didHit)
                    yield return new CircleOverlapInfo2D(results, new CircleOverlap2D(newPosition, radius));
                else if (!hitsOnly)
                    yield return new CircleOverlapInfo2D(null, new CircleOverlap2D(newPosition, radius));
            }
        }


        public static IEnumerable<Collider2D[]> IterateLineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;


            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radiusPerOverlapFunc(i), out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;


            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radiusPerOverlapFunc(i), layerMask, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;


            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radiusPerOverlapFunc(i), layerMask, minDepth, out Collider2D[] results))
                    yield return results;
            }
        }

        public static IEnumerable<Collider2D[]> IterateLineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, float maxDepth)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;


            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radiusPerOverlapFunc(i), layerMask, minDepth, maxDepth, out Collider2D[] results))
                    yield return results;
            }
        }


        public static IEnumerable<CircleOverlapInfo2D> IterateLineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var radius = radiusPerOverlapFunc(i);
                var didHit = Circle(newPosition, radius, out Collider2D[] results);

                if (didHit)
                    yield return new CircleOverlapInfo2D(results, new CircleOverlap2D(newPosition, radius));
                else if (!hitsOnly)
                    yield return new CircleOverlapInfo2D(null, new CircleOverlap2D(newPosition, radius));
            }
        }

        public static IEnumerable<CircleOverlapInfo2D> IterateLineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var radius = radiusPerOverlapFunc(i);
                var didHit = Circle(newPosition, radius, layerMask, out Collider2D[] results);

                if (didHit)
                    yield return new CircleOverlapInfo2D(results, new CircleOverlap2D(newPosition, radius));
                else if (!hitsOnly)
                    yield return new CircleOverlapInfo2D(null, new CircleOverlap2D(newPosition, radius));
            }
        }

        public static IEnumerable<CircleOverlapInfo2D> IterateLineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var radius = radiusPerOverlapFunc(i);
                var didHit = Circle(newPosition, radius, layerMask, minDepth, out Collider2D[] results);

                if (didHit)
                    yield return new CircleOverlapInfo2D(results, new CircleOverlap2D(newPosition, radius));
                else if (!hitsOnly)
                    yield return new CircleOverlapInfo2D(null, new CircleOverlap2D(newPosition, radius));
            }
        }

        public static IEnumerable<CircleOverlapInfo2D> IterateLineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, float maxDepth, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var radius = radiusPerOverlapFunc(i);
                var didHit = Circle(newPosition, radius, layerMask, minDepth, maxDepth, out Collider2D[] results);

                if (didHit)
                    yield return new CircleOverlapInfo2D(results, new CircleOverlap2D(newPosition, radius));
                else if (!hitsOnly)
                    yield return new CircleOverlapInfo2D(null, new CircleOverlap2D(newPosition, radius));
            }
        }
    }
}