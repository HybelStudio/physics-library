using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    yield return overlap;
            }
        }

        
        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                
                if (Capsule(newPosition1, newPosition2, radius, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                
                if (Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                
                if (Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    yield return overlap;
            }
        }

        
        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance);
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, layerMask);
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, layerMask, queryTriggerInteraction);
        }

        
        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance);
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, layerMask);
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, layerMask, queryTriggerInteraction);
        }

        
        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    yield return overlap;
            }
        }

        
        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);

                if (Capsule(newPosition1, newPosition2, radius, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);

                if (Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap))
                    yield return overlap;
            }
        }

        public static IEnumerable<Collider[]> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);

                if (Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    yield return overlap;
            }
        }

        
        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);
                
                bool didHit = Capsule(newPosition1, newPosition2, radius, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }
        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);
                
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }

        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);
                
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }

        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }
        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }

        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }

        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, bool hitsOnly = true)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, hitsOnly);
        }
        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, layerMask, hitsOnly);
        }

        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, layerMask, queryTriggerInteraction, hitsOnly);
        }

        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, bool hitsOnly = true)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, hitsOnly);
        }
        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, layerMask, hitsOnly);
        }

        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return IterateLineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, layerMask, queryTriggerInteraction, hitsOnly);
        }

        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, bool hitsOnly = true)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                bool didHit = Capsule(newPosition1, newPosition2, radius, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }
        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }

        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }

        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, bool hitsOnly = true)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }
        
        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, bool hitsOnly = true)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }

        public static IEnumerable<CapsuleOverlapInfo> IterateLineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool hitsOnly = true)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] colliders);

                if (didHit)
                    yield return new CapsuleOverlapInfo(colliders, new CapsuleOverlap(newPosition1, newPosition2, radius));
                else if (!hitsOnly)
                    yield return new CapsuleOverlapInfo(null, new CapsuleOverlap(newPosition1, newPosition2, radius));
            }
        }
    }
}