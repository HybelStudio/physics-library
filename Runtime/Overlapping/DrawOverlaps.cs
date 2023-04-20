using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public static class DrawOverlaps
    {
        // 2D
        #region Circle

        public static void Circle2D(CircleOverlap2D overlap, float duration = .5f, Color? color = null, int segments = 16)
        {
            var position = overlap.Position;
            var radius = overlap.Radius;

            DrawWireSphere();

            var top = position + Vector2.up * radius;
            var bottom = position + Vector2.down * radius;
            var left = position + Vector2.left * radius;
            var right = position + Vector2.right * radius;

            DrawLine(top, bottom, duration, color);
            DrawLine(left, right, duration, color);

            void DrawWireSphere()
            {
                for (int i = 0; i < segments; i++)
                {
                    float currentStartAngle = 360f / segments * i;
                    float currentEndAngle = 360f / segments * (i + 1);

                    float currentStartRadian = currentStartAngle * Mathf.Deg2Rad;
                    float currentEndRadian = currentEndAngle * Mathf.Deg2Rad;

                    Vector2 startDirection = Vector3.up * Mathf.Sin(currentStartRadian) + Vector3.right * Mathf.Cos(currentStartRadian);
                    Vector2 start = position + startDirection.normalized * radius;

                    Vector2 endDirection = Vector3.up * Mathf.Sin(currentEndRadian) + Vector3.right * Mathf.Cos(currentEndRadian);
                    Vector2 end = position + endDirection.normalized * radius;

                    Debug.DrawLine(start, end, color ?? Color.red, duration);
                }
            }

            static void DrawLine(Vector2 start, Vector2 end, float duration, Color? color) => Debug.DrawLine(start, end, color ?? Color.red, duration);
        }

        public static void Circles2D(IEnumerable<CircleOverlap2D> overlaps, float duration = .5f, Color? color = null, int segments = 16)
        {
            foreach (var overlap in overlaps)
                Circle2D(overlap, duration, color, segments);
        }

        #endregion

        #region Box

        public static void Box2D(BoxOverlap2D overlap, float duration = .5f, Color? color = null)
        {
            var center = overlap.Center;
            var halfExtents = overlap.HalfExtents;
            var angle = overlap.Angle;

            Quaternion orientation = Quaternion.Euler(0f, 0f, angle);

            var left = -halfExtents.x;
            var right = halfExtents.x;
            var bottom = -halfExtents.y;
            var top = halfExtents.y;

            var bottomLeftV3 = orientation * new Vector2(left, bottom);
            var topLeftV3 = orientation * new Vector2(left, top);
            var topRightV3 = orientation * new Vector2(right, top);
            var bottomRightV3 = orientation * new Vector2(right, bottom);

            var bottomLeft = new Vector2(bottomLeftV3.x, bottomLeftV3.y) + center;
            var topLeft = new Vector2(topLeftV3.x, topLeftV3.y) + center;
            var topRight = new Vector2(topRightV3.x, topRightV3.y) + center;
            var bottomRight = new Vector2(bottomRightV3.x, bottomRightV3.y) + center;

            Debug.DrawLine(bottomLeft, topLeft, color ?? Color.red, duration);
            Debug.DrawLine(topLeft, topRight, color ?? Color.red, duration);
            Debug.DrawLine(topRight, bottomRight, color ?? Color.red, duration);
            Debug.DrawLine(bottomRight, bottomLeft, color ?? Color.red, duration);
        }

        public static void Boxes2D(IEnumerable<BoxOverlap2D> overlaps, float duration = .5f, Color? color = null)
        {
            foreach (var overlap in overlaps)
                Box2D(overlap, duration, color);
        }

        #endregion

        // 3D
        #region Sphere

        public static void Sphere(SphereOverlap overlap, float duration = .5f, Color? color = null, int segments = 16)
        {
            var position = overlap.Position;
            var radius = overlap.Radius;

            DrawWireSphere(Vector3.forward, Vector3.up); // Around X
            DrawWireSphere(Vector3.forward, Vector3.right); // Around Y
            DrawWireSphere(Vector3.up, Vector3.right); // Around Z

            void DrawWireSphere(Vector3 forward, Vector3 right)
            {
                for (int i = 0; i < segments; i++)
                {
                    float currentStartAngle = 360f / segments * i;
                    float currentEndAngle = 360f / segments * (i + 1);

                    float currentStartRadian = currentStartAngle * Mathf.Deg2Rad;
                    float currentEndRadian = currentEndAngle * Mathf.Deg2Rad;

                    Vector3 startDirection = forward * Mathf.Sin(currentStartRadian) + right * Mathf.Cos(currentStartRadian);
                    Vector3 start = position + startDirection.normalized * radius;

                    Vector3 endDirection = forward * Mathf.Sin(currentEndRadian) + right * Mathf.Cos(currentEndRadian);
                    Vector3 end = position + endDirection.normalized * radius;

                    Debug.DrawLine(start, end, color ?? Color.red, duration);
                }
            }
        }

        public static void Spheres(IEnumerable<SphereOverlap> overlaps, float duration = .5f, Color? color = null, int segments = 16)
        {
            foreach (var overlap in overlaps)
                Sphere(overlap, duration, color ?? Color.red, segments);
        }

        public static void Sphere(SphereOverlapInfo overlapInfo, float duration = .5f, Color? color = null, int segments = 16) =>
            Sphere(overlapInfo.Overlap, duration, color, segments);

        public static void Spheres(IEnumerable<SphereOverlapInfo> overlapInfos, float duration = .5f, Color? color = null, int segments = 16)
        {
            foreach (var overlap in overlapInfos)
                Sphere(overlap, duration, color ?? Color.red, segments);
        }

        #endregion

        #region Box

        public static void Box(BoxOverlap overlap, float duration = .5f, Color? color = null)
        {
            var center = overlap.Center;
            var halfExtents = overlap.HalfExtents;
            var orientation = overlap.Orientation;

            var left = -halfExtents.x;
            var right = halfExtents.x;
            var bottom = -halfExtents.y;
            var top = halfExtents.y;
            var back = -halfExtents.z;
            var front = halfExtents.z;

            var bottomLeftFront = orientation * new Vector3(left, bottom, front);
            var bottomLeftBack = orientation * new Vector3(left, bottom, back);
            var bottomRightFront = orientation * new Vector3(right, bottom, front);
            var bottomRightBack = orientation * new Vector3(right, bottom, back);
            var topLeftFront = orientation * new Vector3(left, top, front);
            var topLeftBack = orientation * new Vector3(left, top, back);
            var topRightFront = orientation * new Vector3(right, top, front);
            var topRightBack = orientation * new Vector3(right, top, back);

            bottomLeftFront += center;
            bottomLeftBack += center;
            bottomRightFront += center;
            bottomRightBack += center;
            topLeftFront += center;
            topLeftBack += center;
            topRightFront += center;
            topRightBack += center;

            Debug.DrawLine(bottomLeftFront, bottomLeftBack, color ?? Color.red, duration);
            Debug.DrawLine(bottomLeftFront, bottomRightFront, color ?? Color.red, duration);
            Debug.DrawLine(bottomLeftFront, topLeftFront, color ?? Color.red, duration);

            Debug.DrawLine(topRightFront, topLeftFront, color ?? Color.red, duration);
            Debug.DrawLine(topRightFront, bottomRightFront, color ?? Color.red, duration);
            Debug.DrawLine(topRightFront, topRightBack, color ?? Color.red, duration);

            Debug.DrawLine(bottomRightBack, bottomRightFront, color ?? Color.red, duration);
            Debug.DrawLine(bottomRightBack, topRightBack, color ?? Color.red, duration);
            Debug.DrawLine(bottomRightBack, bottomLeftBack, color ?? Color.red, duration);

            Debug.DrawLine(topLeftBack, topLeftFront, color ?? Color.red, duration);
            Debug.DrawLine(topLeftBack, bottomLeftBack, color ?? Color.red, duration);
            Debug.DrawLine(topLeftBack, topRightBack, color ?? Color.red, duration);
        }

        public static void Box(BoxOverlapInfo overlapInfo, float duration = .5f, Color? color = null) =>
            Box(overlapInfo.Overlap, duration, color ?? Color.red);

        public static void Boxes(IEnumerable<BoxOverlap> overlaps, float duration = .5f, Color? color = null)
        {
            foreach (var overlap in overlaps)
                Box(overlap, duration, color ?? Color.red);
        }

        public static void Boxes(IEnumerable<BoxOverlapInfo> overlapInfos, float duration = .5f, Color? color = null)
        {
            foreach (var overlapInfo in overlapInfos)
                Box(overlapInfo, duration, color ?? Color.red);
        }

        #endregion
    }
}
