using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static Collider2D[][] LineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radius, out Collider2D[] results))
                    colliders.Add(results);
            }

            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radius, layerMask, out Collider2D[] results))
                    colliders.Add(results);
            }

            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radius, layerMask, minDepth, out Collider2D[] results))
                    colliders.Add(results);
            }

            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, float maxDepth)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radius, layerMask, minDepth, maxDepth, out Collider2D[] results))
                    colliders.Add(results);
            }

            return colliders.ToArray();
        }


        public static Collider2D[][] LineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, out CircleOverlap2D[] circleOverlaps, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();
            List<CircleOverlap2D> circleOverlapList = new List<CircleOverlap2D>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var didHit = Circle(newPosition, radius, out Collider2D[] results);

                if (didHit)
                {
                    colliders.Add(results);
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
            }

            circleOverlaps = circleOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, out CircleOverlap2D[] circleOverlaps, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();
            List<CircleOverlap2D> circleOverlapList = new List<CircleOverlap2D>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var didHit = Circle(newPosition, radius, layerMask, out Collider2D[] results);

                if (didHit)
                {
                    colliders.Add(results);
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
            }

            circleOverlaps = circleOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, out CircleOverlap2D[] circleOverlaps, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();
            List<CircleOverlap2D> circleOverlapList = new List<CircleOverlap2D>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var didHit = Circle(newPosition, radius, layerMask, minDepth, out Collider2D[] results);

                if (didHit)
                {
                    colliders.Add(results);
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
            }

            circleOverlaps = circleOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, float radius, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, float maxDepth, out CircleOverlap2D[] circleOverlaps, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();
            List<CircleOverlap2D> circleOverlapList = new List<CircleOverlap2D>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var didHit = Circle(newPosition, radius, layerMask, minDepth, maxDepth, out Collider2D[] results);

                if (didHit)
                {
                    colliders.Add(results);
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
            }

            circleOverlaps = circleOverlapList.ToArray();
            return colliders.ToArray();
        }


        public static Collider2D[][] LineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radiusPerOverlapFunc(i), out Collider2D[] results))
                    colliders.Add(results);
            }

            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radiusPerOverlapFunc(i), layerMask, out Collider2D[] results))
                    colliders.Add(results);
            }

            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radiusPerOverlapFunc(i), layerMask, minDepth, out Collider2D[] results))
                    colliders.Add(results);
            }

            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, float maxDepth)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                if (Circle(newPosition, radiusPerOverlapFunc(i), layerMask, minDepth, maxDepth, out Collider2D[] results))
                    colliders.Add(results);
            }

            return colliders.ToArray();
        }


        public static Collider2D[][] LineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, out CircleOverlap2D[] circleOverlaps, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();
            List<CircleOverlap2D> circleOverlapList = new List<CircleOverlap2D>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var radius = radiusPerOverlapFunc(i);
                var didHit = Circle(newPosition, radius, out Collider2D[] results);

                if (didHit)
                {
                    colliders.Add(results);
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
            }

            circleOverlaps = circleOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, out CircleOverlap2D[] circleOverlaps, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();
            List<CircleOverlap2D> circleOverlapList = new List<CircleOverlap2D>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var radius = radiusPerOverlapFunc(i);
                var didHit = Circle(newPosition, radius, layerMask, out Collider2D[] results);

                if (didHit)
                {
                    colliders.Add(results);
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
            }

            circleOverlaps = circleOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, out CircleOverlap2D[] circleOverlaps, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();
            List<CircleOverlap2D> circleOverlapList = new List<CircleOverlap2D>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var radius = radiusPerOverlapFunc(i);
                var didHit = Circle(newPosition, radius, layerMask, minDepth, out Collider2D[] results);

                if (didHit)
                {
                    colliders.Add(results);
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
            }

            circleOverlaps = circleOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider2D[][] LineOfCircles(Vector2 position, OverlapIterationFunc<float> radiusPerOverlapFunc, Vector2 direction, int numberOfCircles, float totalDistance, int layerMask, float minDepth, float maxDepth, out CircleOverlap2D[] circleOverlaps, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCircles - 1);
            Vector2 positionIncrement = direction.normalized * distanceDelta;

            List<Collider2D[]> colliders = new List<Collider2D[]>();
            List<CircleOverlap2D> circleOverlapList = new List<CircleOverlap2D>();

            for (int i = 0; i < numberOfCircles; i++)
            {
                var newPosition = position + (positionIncrement * i);

                var radius = radiusPerOverlapFunc(i);
                var didHit = Circle(newPosition, radius, layerMask, minDepth, maxDepth, out Collider2D[] results);

                if (didHit)
                {
                    colliders.Add(results);
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
                else if (!hitsOnly)
                {
                    circleOverlapList.Add(new CircleOverlap2D(newPosition, radius));
                }
            }

            circleOverlaps = circleOverlapList.ToArray();
            return colliders.ToArray();
        }
    }
}
