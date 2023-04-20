using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public static class DrawRays
    {
        // 2D
        public static void Ray2D(RayLine2D rayLines, float duration = .5f, Color? color = null) =>
            Debug.DrawLine(rayLines.Origin, rayLines.HitPoint, color ?? Color.red, duration);

        public static void Rays2D(RayLine2D[] rayLines, float duration = .5f, Color? color = null)
        {
            foreach (RayLine2D rayLine in rayLines)
                Ray2D(rayLine, duration, color ?? Color.red);
        }

        public static void UniqueRays(RayLine2D[] rayLiness, Func<int, RaycastHit2D> getter, float duration = .5f, Color? uniqueColor = null, Color? duplicateColor = null) =>
            UniqueRays(rayLiness, (h1, h2) => h1.collider == h2.collider, getter, duration, uniqueColor, duplicateColor);

        public static void UniqueRays<T>(RayLine2D[] rayLiness, Func<T, T, bool> comparer, Func<int, T> getter, float duration = .5f, Color? uniqueColor = null, Color? duplicateColor = null)
        {
            List<T> registeredUniqueColliders = new List<T>();

            for (int i = 0; i < rayLiness.Length; i++)
            {
                var rayLines = rayLiness[i];

                T item = getter(i);
                Vector2 origin = rayLines.Origin;

                if (!registeredUniqueColliders.TrueForAll(h => !comparer(h, item)))
                {
                    Ray2D(rayLines, duration, duplicateColor ?? Color.grey);
                }
                else
                {
                    registeredUniqueColliders.Add(item);
                    Ray2D(rayLines, duration, uniqueColor ?? Color.red);
                }
            }
        }

        // Enumerable 2D
        public static void Rays2D(IEnumerable<RayLine2D> rayLines, float duration = .5f, Color? color = null)
        {
            foreach (var rayLine in rayLines)
                Ray2D(rayLine, duration, color ?? Color.red);
        }

        // 3D
        public static void Ray(RayLine rayLines, float duration = .5f, Color? color = null) =>
            Debug.DrawLine(rayLines.Origin, rayLines.HitPoint, color ?? Color.red, duration);

        public static void Rays(RayLine[] rayLines, float duration = .5f, Color? color = null)
        {
            for (int i = 0; i < rayLines.Length; i++)
                Ray(rayLines[i], duration, color ?? Color.red);
        }

        public static void UniqueRays(RayLine[] rayLines, Func<int, RaycastHit> getter, float duration = .5f, Color? uniqueColor = null, Color? duplicateColor = null) =>
            UniqueRays(rayLines, (h1, h2) => h1.collider == h2.collider, getter, duration, uniqueColor, duplicateColor);

        public static void UniqueRays<T>(RayLine[] rayLines, Func<T, T, bool> comparer, Func<int, T> getter, float duration = .5f, Color? uniqueColor = null, Color? duplicateColor = null)
        {
            List<T> registeredUniqueColliders = new List<T>();

            for (int i = 0; i < rayLines.Length; i++)
            {
                var rayLine = rayLines[i];

                T item = getter(i);
                Vector3 origin = rayLine.Origin;

                if (!registeredUniqueColliders.TrueForAll(h => !comparer(h, item)))
                {
                    Ray(rayLine, duration, duplicateColor ?? Color.grey);
                }
                else
                {
                    registeredUniqueColliders.Add(item);
                    Ray(rayLine, duration, uniqueColor ?? Color.red);
                }
            }
        }

        // Enumerable 2D
        public static void Rays(IEnumerable<RayLine> rayLines, float duration = .5f, Color? color = null)
        {
            foreach (var rayLine in rayLines)
                Ray(rayLine, duration, color ?? Color.red);
        }
    }
}