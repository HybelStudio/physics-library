using Hybel.ExtensionMethods;
using System;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using Unity.Mathematics;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] ParallelThroughCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int maxHits) =>
            ParallelThroughCommand(ray.origin, ray.direction, normal, width, numberOfRays, maxHits);

        public static RaycastHit[] ParallelThroughCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int maxHits, float distance) =>
            ParallelThroughCommand(ray.origin, ray.direction, normal, width, numberOfRays, maxHits, distance);

        public static RaycastHit[] ParallelThroughCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int maxHits, int layerMask) =>
            ParallelThroughCommand(ray.origin, ray.direction, normal, width, numberOfRays, maxHits, layerMask);

        public static RaycastHit[] ParallelThroughCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int maxHits, float distance, int layerMask) =>
            ParallelThroughCommand(ray.origin, ray.direction, normal, width, numberOfRays, maxHits, distance, layerMask);

        public static RaycastHit[] ParallelThroughCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int maxHits, out RayLine[] rayLines) =>
            ParallelThroughCommand(ray.origin, ray.direction, normal, width, numberOfRays, maxHits, out rayLines);

        public static RaycastHit[] ParallelThroughCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int maxHits, float distance, out RayLine[] rayLines) =>
            ParallelThroughCommand(ray.origin, ray.direction, normal, width, numberOfRays, maxHits, distance, out rayLines);

        public static RaycastHit[] ParallelThroughCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int maxHits, int layerMask, out RayLine[] rayLines) =>
            ParallelThroughCommand(ray.origin, ray.direction, normal, width, numberOfRays, maxHits, layerMask, out rayLines);

        public static RaycastHit[] ParallelThroughCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int maxHits, float distance, int layerMask, out RayLine[] rayLines) =>
            ParallelThroughCommand(ray.origin, ray.direction, normal, width, numberOfRays, maxHits, distance, layerMask, out rayLines);

        public static RaycastHit[] ParallelThroughCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int maxHits)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit>();

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            maxHits = math.max(maxHits, 1);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, maxHits: maxHits);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelThroughCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int maxHits, float distance)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit>();

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            maxHits = math.max(maxHits, 1);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, distance, maxHits: maxHits);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelThroughCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int maxHits, int layerMask)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit>();

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            maxHits = math.max(maxHits, 1);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, layerMask: layerMask, maxHits: maxHits);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelThroughCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int maxHits, float distance, int layerMask)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit>();

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            maxHits = math.max(maxHits, 1);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, distance, layerMask, maxHits);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }


        public static RaycastHit[] ParallelThroughCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int maxHits, out RayLine[] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine>();
                return Array.Empty<RaycastHit>();
            }

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            maxHits = math.max(maxHits, 1);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, maxHits: maxHits);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            rayLines = new RayLine[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
                rayLines[i] = new RayLine(rays[i], results[i]);

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelThroughCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int maxHits, float distance, out RayLine[] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine>();
                return Array.Empty<RaycastHit>();
            }

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            maxHits = math.max(maxHits, 1);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, distance, maxHits: maxHits);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            rayLines = new RayLine[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
                rayLines[i] = new RayLine(rays[i], results[i]);

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelThroughCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int maxHits, int layerMask, out RayLine[] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine>();
                return Array.Empty<RaycastHit>();
            }

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            maxHits = math.max(maxHits, 1);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, layerMask: layerMask, maxHits: maxHits);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            rayLines = new RayLine[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
                rayLines[i] = new RayLine(rays[i], results[i]);

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelThroughCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int maxHits, float distance, int layerMask, out RayLine[] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine>();
                return Array.Empty<RaycastHit>();
            }

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            maxHits = math.max(maxHits, 1);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, distance, layerMask, maxHits);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            rayLines = new RayLine[numberOfRays];

            for (int i = 0; i < numberOfRays; i++)
                rayLines[i] = new RayLine(rays[i], results[i]);

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }
    }
}
