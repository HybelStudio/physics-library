using Hybel;
using System;
using System.Collections.Generic;
using UnityEngine;

public struct RayLine2D : IEquatable<RayLine2D>
{
    public readonly Vector2 Origin;
    public readonly Vector2 HitPoint;

    public RayLine2D(Vector2 origin, Vector2 hitPoint)
    {
        Origin = origin;
        HitPoint = hitPoint;
    }

    public RayLine2D(Vector2 origin, RaycastHit2D hit) : this(origin, hit.point) { }
    public RayLine2D(Ray2D ray, Vector2 hitPoint) : this(ray.origin, hitPoint) { }
    public RayLine2D(Ray2D ray, RaycastHit2D hit) : this(ray.origin, hit.point) { }

    public static RayLine2D[] Create(Vector2 origin, Vector2[] hitPoints)
    {
        RayLine2D[] rayHits = new RayLine2D[hitPoints.Length];

        for (int i = 0; i < hitPoints.Length; i++)
            rayHits[i] = new RayLine2D(origin, hitPoints[i]);

        return rayHits;
    }

    public static RayLine2D[] Create(Vector2[] origins, Vector2[] hitPoints)
    {
        if (hitPoints.Length != origins.Length)
            throw new System.ArgumentException($"Arrays must have the same length");

        RayLine2D[] rayHits = new RayLine2D[hitPoints.Length];

        for (int i = 0; i < hitPoints.Length; i++)
            rayHits[i] = new RayLine2D(origins[i], hitPoints[i]);

        return rayHits;
    }

    public static RayLine2D[] Create(Vector2 origin, RaycastHit2D[] raycastHits)
    {
        RayLine2D[] rayHits = new RayLine2D[raycastHits.Length];

        for (int i = 0; i < raycastHits.Length; i++)
            rayHits[i] = new RayLine2D(origin, raycastHits[i]);

        return rayHits;
    }

    public static RayLine2D[] Create(Vector2[] origins, RaycastHit2D[] raycastHits)
    {
        if (raycastHits.Length != origins.Length)
            throw new ArgumentException($"Arrays must have the same length");

        RayLine2D[] rayHits = new RayLine2D[raycastHits.Length];

        for (int i = 0; i < raycastHits.Length; i++)
            rayHits[i] = new RayLine2D(origins[i], raycastHits[i]);

        return rayHits;
    }


    public static IEnumerable<RayLine2D> Create(Vector2 origin, IEnumerable<Vector2> hitPoints)
    {
        foreach (var hit in hitPoints)
            yield return new RayLine2D(origin, hit);
    }

    public static IEnumerable<RayLine2D> Create(IEnumerable<Vector2> origins, IEnumerable<Vector2> hitPoints)
    {
        var iterator = origins.GetEnumerator();
        foreach (var hit in hitPoints)
        {
            if (!iterator.MoveNext())
                yield break;

            yield return new RayLine2D(iterator.Current, hit);
        }
    }

    public static IEnumerable<RayLine2D> Create(Vector2 origin, IEnumerable<RaycastHit2D> raycastHits)
    {
        foreach (var hit in raycastHits)
            yield return new RayLine2D(origin, hit);
    }

    public static IEnumerable<RayLine2D> Create(IEnumerable<Vector2> origins, IEnumerable<RaycastHit2D> raycastHits)
    {
        var iterator = origins.GetEnumerator();
        foreach (var hit in raycastHits)
        {
            if (!iterator.MoveNext())
                yield break;

            yield return new RayLine2D(iterator.Current, hit);
        }
    }

    public override string ToString() => $"Origin: {Origin} | HitPoint: {HitPoint}";

    public bool Equals(RayLine2D other) => Origin.Equals(other.Origin) && HitPoint.Equals(other.HitPoint);
    public override bool Equals(object obj) => obj is RayLine2D d && Equals(d);

    public override int GetHashCode()
    {
        int hashCode = -560725800;
        hashCode = hashCode * -1521134295 + Origin.GetHashCode();
        hashCode = hashCode * -1521134295 + HitPoint.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(RayLine2D left, RayLine2D right) => left.Equals(right);
    public static bool operator !=(RayLine2D left, RayLine2D right) => !(left == right);

    public static implicit operator Ray2D(RayLine2D rayLine) => new Ray2D(rayLine.Origin, (rayLine.HitPoint - rayLine.Origin).normalized);
}