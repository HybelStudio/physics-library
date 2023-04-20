using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        #region HollowCone

        public static RaycastHit[][] ConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, 0, 0f, distinctHits);

        public static RaycastHit[][] ConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, float distance, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, 0, 0f, distance, distinctHits);

        public static RaycastHit[][] ConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, int layerMask, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, 0, 0f, layerMask, distinctHits);

        public static RaycastHit[][] ConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, 0, 0f, distance, layerMask, distinctHits);

        public static RaycastHit[][] ConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, 0, 0f, distance, layerMask, distinctHits);


        public static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, 0, 0f, distinctHits);

        public static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, float distance, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, 0, 0f, distance, distinctHits);

        public static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int layerMask, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, 0, 0f, layerMask, distinctHits);

        public static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, float distance, int layerMask, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, 0, 0f, distance, layerMask, distinctHits);

        public static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, 0, 0f, distance, layerMask, queryTriggerInteraction, distinctHits);

        #endregion

        #region FilledConeThrough

        public static RaycastHit[][] FilledConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, int fillIterations, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, fillIterations, 0f, distinctHits);

        public static RaycastHit[][] FilledConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, int fillIterations, float distance, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, fillIterations, 0f, distance, distinctHits);

        public static RaycastHit[][] FilledConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, int fillIterations, int layerMask, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, fillIterations, 0f, layerMask, distinctHits);

        public static RaycastHit[][] FilledConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, int fillIterations, float distance, int layerMask, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, fillIterations, 0f, distance, layerMask, distinctHits);

        public static RaycastHit[][] FilledConeThrough(Ray ray, Vector3 up, float angle, int numberOfRays, int fillIterations, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            ConeThrough(ray.origin, ray.direction, up, angle, numberOfRays, fillIterations, 0f, distance, layerMask, queryTriggerInteraction, distinctHits);


        public static RaycastHit[][] FilledConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, 0f, distinctHits);

        public static RaycastHit[][] FilledConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, float distance, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, 0f, distance, distinctHits);

        public static RaycastHit[][] FilledConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, int layerMask, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, 0f, layerMask, distinctHits);

        public static RaycastHit[][] FilledConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, float distance, int layerMask, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, 0f, distance, layerMask, distinctHits);

        public static RaycastHit[][] FilledConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false) =>
            ConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, 0f, distance, layerMask, queryTriggerInteraction, distinctHits);

        #endregion

        private static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, float rotationalOffset, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return null;

            direction.Normalize();
            ConeThroughSetup(direction, up, angle, numberOfRays, out float halfAngle, out float radianAngleIncrement, out Vector3 right);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            {
                var modulo = angle % 720;
                if (modulo == 0f || modulo == 360f)
                {
                    ConeCast(direction * (modulo == 0f ? 1f : -1f));
                    FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);
                    return hitArrays.ToArray();
                }
            }

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentRadialAngle = radianAngleIncrement * i + 90f + rotationalOffset; // Offset initial angle to point in the given up direction and rotational offset.
                float currentRadialRadian = currentRadialAngle * Mathf.Deg2Rad;
                Vector3 currentRadialVector = up * Mathf.Sin(currentRadialRadian) + right * Mathf.Cos(currentRadialRadian);

                float halfRadian = halfAngle * Mathf.Deg2Rad;

                Vector3 newDirection = currentRadialVector * Mathf.Sin(halfRadian) + direction * Mathf.Cos(halfRadian);
                ConeCast(newDirection);
            }

            FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);

            return hitArrays.ToArray();

            void ConeCast(Vector3 direction)
            {
                var hitArray = Through(origin, direction);
                foreach (var array in hitArrays)
                    CheckDistinctAndAdd(distinctHits, hitArrays, array, (h1, h2) => h1.collider == h2.collider);
            }
        }

        private static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, float rotationalOffset, float distance, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return null;

            direction.Normalize();
            ConeThroughSetup(direction, up, angle, numberOfRays, out float halfAngle, out float radianAngleIncrement, out Vector3 right);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            {
                var modulo = angle % 720;
                if (modulo == 0f || modulo == 360f)
                {
                    ConeCast(direction * (modulo == 0f ? 1f : -1f));
                    FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);
                    return hitArrays.ToArray();
                }
            }

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentRadialAngle = radianAngleIncrement * i + 90f + rotationalOffset; // Offset initial angle to point in the given up direction and rotational offset.
                float currentRadialRadian = currentRadialAngle * Mathf.Deg2Rad;
                Vector3 currentRadialVector = up * Mathf.Sin(currentRadialRadian) + right * Mathf.Cos(currentRadialRadian);

                float halfRadian = halfAngle * Mathf.Deg2Rad;

                Vector3 newDirection = currentRadialVector * Mathf.Sin(halfRadian) + direction * Mathf.Cos(halfRadian);
                ConeCast(newDirection);
            }

            FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);

            return hitArrays.ToArray();

            void ConeCast(Vector3 direction)
            {
                var hitArray = Through(origin, direction, distance);
                foreach (var array in hitArrays)
                    CheckDistinctAndAdd(distinctHits, hitArrays, array, (h1, h2) => h1.collider == h2.collider);
            }
        }

        private static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, float rotationalOffset, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return null;

            direction.Normalize();
            ConeThroughSetup(direction, up, angle, numberOfRays, out float halfAngle, out float radianAngleIncrement, out Vector3 right);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            {
                var modulo = angle % 720;
                if (modulo == 0f || modulo == 360f)
                {
                    ConeCast(direction * (modulo == 0f ? 1f : -1f));
                    FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);
                    return hitArrays.ToArray();
                }
            }

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentRadialAngle = radianAngleIncrement * i + 90f + rotationalOffset; // Offset initial angle to point in the given up direction and rotational offset.
                float currentRadialRadian = currentRadialAngle * Mathf.Deg2Rad;
                Vector3 currentRadialVector = up * Mathf.Sin(currentRadialRadian) + right * Mathf.Cos(currentRadialRadian);

                float halfRadian = halfAngle * Mathf.Deg2Rad;

                Vector3 newDirection = currentRadialVector * Mathf.Sin(halfRadian) + direction * Mathf.Cos(halfRadian);
                ConeCast(newDirection);
            }

            FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);

            return hitArrays.ToArray();

            void ConeCast(Vector3 direction)
            {
                var hitArray = Through(origin, direction, layerMask);
                foreach (var array in hitArrays)
                    CheckDistinctAndAdd(distinctHits, hitArrays, array, (h1, h2) => h1.collider == h2.collider);
            }
        }

        private static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, float rotationalOffset, float distance, int layerMask, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return null;

            direction.Normalize();
            ConeThroughSetup(direction, up, angle, numberOfRays, out float halfAngle, out float radianAngleIncrement, out Vector3 right);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            {
                var modulo = angle % 720;
                if (modulo == 0f || modulo == 360f)
                {
                    ConeCast(direction * (modulo == 0f ? 1f : -1f));
                    FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);
                    return hitArrays.ToArray();
                }
            }

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentRadialAngle = radianAngleIncrement * i + 90f + rotationalOffset; // Offset initial angle to point in the given up direction and rotational offset.
                float currentRadialRadian = currentRadialAngle * Mathf.Deg2Rad;
                Vector3 currentRadialVector = up * Mathf.Sin(currentRadialRadian) + right * Mathf.Cos(currentRadialRadian);

                float halfRadian = halfAngle * Mathf.Deg2Rad;

                Vector3 newDirection = currentRadialVector * Mathf.Sin(halfRadian) + direction * Mathf.Cos(halfRadian);
                ConeCast(newDirection);
            }

            FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);

            return hitArrays.ToArray();

            void ConeCast(Vector3 direction)
            {
                var hitArray = Through(origin, direction, distance, layerMask);
                foreach (var array in hitArrays)
                    CheckDistinctAndAdd(distinctHits, hitArrays, array, (h1, h2) => h1.collider == h2.collider);
            }
        }

        private static RaycastHit[][] ConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, float rotationalOffset, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, bool distinctHits = false)
        {
            if (numberOfRays < 0)
                return null;

            direction.Normalize();
            ConeThroughSetup(direction, up, angle, numberOfRays, out float halfAngle, out float radianAngleIncrement, out Vector3 right);

            List<RaycastHit[]> hitArrays = new List<RaycastHit[]>();

            {
                var modulo = angle % 720;
                if (modulo == 0f || modulo == 360f)
                {
                    ConeCast(direction * (modulo == 0f ? 1f : -1f));
                    FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);
                    return hitArrays.ToArray();
                }
            }

            for (int i = 0; i < numberOfRays; i++)
            {
                float currentRadialAngle = radianAngleIncrement * i + 90f + rotationalOffset; // Offset initial angle to point in the given up direction and rotational offset.
                float currentRadialRadian = currentRadialAngle * Mathf.Deg2Rad;
                Vector3 currentRadialVector = up * Mathf.Sin(currentRadialRadian) + right * Mathf.Cos(currentRadialRadian);

                float halfRadian = halfAngle * Mathf.Deg2Rad;

                Vector3 newDirection = currentRadialVector * Mathf.Sin(halfRadian) + direction * Mathf.Cos(halfRadian);
                ConeCast(newDirection);
            }

            FillConeThrough(origin, direction, up, angle, numberOfRays, fillIterations, distinctHits, radianAngleIncrement, hitArrays);

            return hitArrays.ToArray();

            void ConeCast(Vector3 direction)
            {
                var hitArray = Through(origin, direction, distance, layerMask, queryTriggerInteraction);
                foreach (var array in hitArrays)
                    CheckDistinctAndAdd(distinctHits, hitArrays, array, (h1, h2) => h1.collider == h2.collider);
            }
        }


        private static void ConeThroughSetup(Vector3 direction, Vector3 up, float angle, int numberOfRays, out float halfAngle, out float radianAngleIncrement, out Vector3 right)
        {
            halfAngle = angle * .5f;
            radianAngleIncrement = 360f / (numberOfRays);
            right = Vector3.Cross(direction, up);
        }

        private static void FillConeThrough(Vector3 origin, Vector3 direction, Vector3 up, float angle, int numberOfRays, int fillIterations, bool distinctHits, float radianAngleIncrement, List<RaycastHit[]> hitArrays)
        {
            for (int i = 1; i <= fillIterations; i++)
            {
                float angleIncrement = angle / (fillIterations + .5f);
                float newAngle = angle - (angleIncrement * i);
                newAngle = (float)System.Math.Round(newAngle, 4);

                var jaggedHitArray = ConeThrough(origin, direction, up, newAngle, numberOfRays, 0, radianAngleIncrement * .5f * i, distinctHits);

                foreach (var hitArray in jaggedHitArray)
                    CheckDistinctAndAdd(distinctHits, hitArrays, hitArray, (h1, h2) => h1.collider == h2.collider);
            }
        }
    }
}
