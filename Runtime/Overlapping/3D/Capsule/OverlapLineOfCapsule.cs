using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap : OverlapAPI
    {
        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 increment = positionIncrement * i;
                Vector3 newPosition1 = position1 + increment;
                Vector3 newPosition2 = position2 + increment;
                
                if (Capsule(newPosition1, newPosition2, radius, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 increment = positionIncrement * i;
                Vector3 newPosition1 = position1 + increment;
                Vector3 newPosition2 = position2 + increment;
                
                if (Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 increment = positionIncrement * i;
                Vector3 newPosition1 = position1 + increment;
                Vector3 newPosition2 = position2 + increment;
                
                if (Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }
        
        
        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);
                
                bool didHit = Capsule(newPosition1, newPosition2, radius, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);
                
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);
                
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }
        
        
        
        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                if (Capsule(newPosition1, newPosition2, radius, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }
        
        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                if (Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }
        
        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                if (Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }
        
        
        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }
        
        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }
        
        public static Collider[][] LineOfCapsules(Vector3 position1, Vector3 position2, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }
        
        
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance);
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, layerMask);
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, layerMask, queryTriggerInteraction);
        }
        
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, out sphereOverlaps, hitsOnly);
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, layerMask, out sphereOverlaps, hitsOnly);
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radius, direction, numberOfCapsules, totalDistance, layerMask, queryTriggerInteraction, out sphereOverlaps, hitsOnly);
        }
        
        
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance);
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, layerMask);
        }

        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, layerMask, queryTriggerInteraction);
        }

        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, out sphereOverlaps, hitsOnly);
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, layerMask, out sphereOverlaps, hitsOnly);
        }

        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, float distanceBetweenPositions, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            Vector3 betweenPositions = longDirection * distanceBetweenPositions * 0.5f;
            Vector3 position1 = center + betweenPositions;
            Vector3 position2 = center - betweenPositions;
            
            return LineOfCapsules(position1, position2, radiusPerOverlap, direction, numberOfCapsules, totalDistance, layerMask, queryTriggerInteraction, out sphereOverlaps, hitsOnly);
        }

        
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                if (Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }

        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                bool didHit = Capsule(newPosition1, newPosition2, radius, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, float radius, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }

        
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                if (Capsule(newPosition1, newPosition2, radius, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                if (Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                if (Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap))
                    colliders.Add(overlap);
            }

            return colliders.ToArray();
        }
        
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }
        
        public static Collider[][] LineOfCapsules(Vector3 center, Vector3 longDirection, OverlapIterationFunc<float> distanceBetweenPositionsPerOverlap, OverlapIterationFunc<float> radiusPerOverlap, Vector3 direction, int numberOfCapsules, float totalDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out CapsuleOverlap[] sphereOverlaps, bool hitsOnly = false)
        {
            longDirection.Normalize();
            
            float distanceDelta = totalDistance / (numberOfCapsules - 1);
            Vector3 positionIncrement = direction.normalized * distanceDelta;

            var colliders = new List<Collider[]>(numberOfCapsules);
            var sphereOverlapList = new List<CapsuleOverlap>(numberOfCapsules);

            for (int i = 0; i < numberOfCapsules; i++)
            {
                Vector3 betweenPositions = longDirection * distanceBetweenPositionsPerOverlap(i) * 0.5f;
                Vector3 position1 = center + betweenPositions;
                Vector3 position2 = center - betweenPositions;
                
                Vector3 newPosition1 = position1 + (positionIncrement * i);
                Vector3 newPosition2 = position2 + (positionIncrement * i);

                float radius = radiusPerOverlap(i);
                bool didHit = Capsule(newPosition1, newPosition2, radius, layerMask, queryTriggerInteraction, out Collider[] overlap);

                if (didHit)
                {
                    colliders.Add(overlap);
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
                else if (!hitsOnly)
                {
                    sphereOverlapList.Add(new CapsuleOverlap(newPosition1, newPosition2, radius));
                }
            }

            sphereOverlaps = sphereOverlapList.ToArray();
            return colliders.ToArray();
        }
    }
}