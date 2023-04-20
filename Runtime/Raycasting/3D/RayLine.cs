using System;
using System.Collections.Generic;
using UnityEngine;

public struct RayLine : IEquatable<RayLine>
{
    public readonly Vector3 Origin;
    public readonly Vector3 HitPoint;

    public RayLine(Vector3 origin, Vector3 hitPoint)
    {
        Origin = origin;
        HitPoint = hitPoint;
    }

    public RayLine(Vector3 origin, RaycastHit hit) : this(origin, hit.point) { }
    public RayLine(Ray ray, Vector3 hitPoint) : this(ray.origin, hitPoint) { }
    public RayLine(Ray ray, RaycastHit hit) : this(ray.origin, hit.point) { }

    public static RayLine[] Create(Vector3 origin, Vector3[] hitPoints)
    {
        RayLine[] rayHits = new RayLine[hitPoints.Length];

        for (int i = 0; i < hitPoints.Length; i++)
            rayHits[i] = new RayLine(origin, hitPoints[i]);

        return rayHits;
    }

    public static RayLine[] Create(Vector3[] origins, Vector3[] hitPoints)
    {
        if (hitPoints.Length != origins.Length)
            throw new ArgumentException($"Arrays must have the same length");

        RayLine[] rayHits = new RayLine[origins.Length];

        for (int i = 0; i < origins.Length; i++)
            rayHits[i] = new RayLine(origins[i], hitPoints[i]);

        return rayHits;
    }

    public static RayLine[] Create(Vector3 origin, RaycastHit[] raycastHits)
    {
        RayLine[] rayHits = new RayLine[raycastHits.Length];

        for (int i = 0; i < raycastHits.Length; i++)
            rayHits[i] = new RayLine(origin, raycastHits[i]);

        return rayHits;
    }

    public static RayLine[] Create(Vector3[] origins, RaycastHit[] raycastHits)
    {
        if (raycastHits.Length != origins.Length)
            throw new ArgumentException($"Arrays must have the same length");

        RayLine[] rayHits = new RayLine[raycastHits.Length];

        for (int i = 0; i < raycastHits.Length; i++)
            rayHits[i] = new RayLine(origins[i], raycastHits[i]);

        return rayHits;
    }


    public static IEnumerable<RayLine> Create(Vector3 origin, IEnumerable<Vector3> hitPoints)
    {
        foreach (var hit in hitPoints)
            yield return new RayLine(origin, hit);
    }

    public static IEnumerable<RayLine> Create(IEnumerable<Vector3> origins, IEnumerable<Vector3> hitPoints)
    {
        var iterator = origins.GetEnumerator();
        foreach (var hit in hitPoints)
        {
            if (!iterator.MoveNext())
                yield break;

            yield return new RayLine(iterator.Current, hit);
        }
    }

    public static IEnumerable<RayLine> Create(Vector3 origin, IEnumerable<RaycastHit> raycastHits)
    {
        foreach (var hit in raycastHits)
            yield return new RayLine(origin, hit);
    }

    public static IEnumerable<RayLine> Create(IEnumerable<Vector3> origins, IEnumerable<RaycastHit> raycastHits)
    {
        var iterator = origins.GetEnumerator();
        foreach (var hit in raycastHits)
        {
            if (!iterator.MoveNext())
                yield break;

            yield return new RayLine(iterator.Current, hit);
        }
    }

    public override string ToString() => $"{nameof(Origin)}: {Origin} | {nameof(HitPoint)}: {HitPoint}";

    public bool Equals(RayLine other) => Origin.Equals(other.Origin) && HitPoint.Equals(other.HitPoint);
    public override bool Equals(object obj) => obj is RayLine line && Equals(line);

    public override int GetHashCode()
    {
        int hashCode = -560725800;
        hashCode = hashCode * -1521134295 + Origin.GetHashCode();
        hashCode = hashCode * -1521134295 + HitPoint.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(RayLine left, RayLine right) => left.Equals(right);
    public static bool operator !=(RayLine left, RayLine right) => !(left == right);

    public static implicit operator Ray(RayLine rayHit) => new Ray(rayHit.Origin, (rayHit.HitPoint - rayHit.Origin).normalized);
}