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
        public static RaycastHit[] ParallelCommand(Ray ray, Vector3 normal, float width, int numberOfRays) =>
            ParallelCommand(ray.origin, ray.direction, normal, width, numberOfRays);

        public static RaycastHit[] ParallelCommand(Ray ray, Vector3 normal, float width, int numberOfRays, float distance) =>
            ParallelCommand(ray.origin, ray.direction, normal, width, numberOfRays, distance);

        public static RaycastHit[] ParallelCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int layerMask) =>
            ParallelCommand(ray.origin, ray.direction, normal, width, numberOfRays, layerMask);

        public static RaycastHit[] ParallelCommand(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask) =>
            ParallelCommand(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask);


        public static RaycastHit[] ParallelCommand(Ray ray, Vector3 normal, float width, int numberOfRays, out RayLine[] rayLines) =>
            ParallelCommand(ray.origin, ray.direction, normal, width, numberOfRays, out rayLines);

        public static RaycastHit[] ParallelCommand(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, out RayLine[] rayLines) =>
            ParallelCommand(ray.origin, ray.direction, normal, width, numberOfRays, distance, out rayLines);

        public static RaycastHit[] ParallelCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int layerMask, out RayLine[] rayLines) =>
            ParallelCommand(ray.origin, ray.direction, normal, width, numberOfRays, layerMask, out rayLines);

        public static RaycastHit[] ParallelCommand(Ray ray, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines) =>
            ParallelCommand(ray.origin, ray.direction, normal, width, numberOfRays, distance, layerMask, out rayLines);



        public static RaycastHit[] ParallelCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit>();

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit>();

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, distance);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int layerMask)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit>();

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, layerMask: layerMask);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }

        public static RaycastHit[] ParallelCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit>();

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, distance, layerMask);
            }

            JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
            jobHandle.Complete();

            RaycastHit[] raycastHits = results.ToArray();
            commands.Dispose();
            results.Dispose();
            return raycastHits;
        }


        public static RaycastHit[] ParallelCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, out RayLine[] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine>();
                return Array.Empty<RaycastHit>();
            }

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction);
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

        public static RaycastHit[] ParallelCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, out RayLine[] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine>();
                return Array.Empty<RaycastHit>();
            }

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, distance);
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

        public static RaycastHit[] ParallelCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int layerMask, out RayLine[] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine>();
                return Array.Empty<RaycastHit>();
            }

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, layerMask: layerMask);
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

        public static RaycastHit[] ParallelCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, float distance, int layerMask, out RayLine[] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine>();
                return Array.Empty<RaycastHit>();
            }

            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            for (int i = 0; i < numberOfRays; i++)
            {
                Ray ray = rays[i];
                commands[i] = new RaycastCommand(ray.origin, ray.direction, distance, layerMask);
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

        public static Ray[] GetParallelRaysCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays)
        {
            direction.Normalize();
            ParallelSetup(direction, normal, width, out Vector3 perpDirection, out Vector3 halfPerpDirection);

            var getParallelRaysJob = new GetParallelRaysJob(origin, direction, halfPerpDirection, perpDirection, numberOfRays);

            JobHandle jobHandle = getParallelRaysJob.Schedule(numberOfRays, 32);
            jobHandle.Complete();

            Ray[] rays = getParallelRaysJob.RaysBuffer;
            getParallelRaysJob.Dispose();
            return rays;

            static void ParallelSetup(Vector3 direction, Vector3 normal, float width, out Vector3 perpDirection, out Vector3 halfPerpDirection)
            {
                perpDirection = direction.Cross(normal).SetMagnitude(width);
                halfPerpDirection = perpDirection / 2;
            }
        }

        private struct GetParallelRaysJob : IJobParallelFor, IDisposable
        {
            private readonly float3 _origin;
            private readonly float3 _direction;
            private readonly float3 _halfPerpDirection;
            private readonly float3 _perpDirection;
            private readonly int _numberOfRays;

            private NativeArray<Ray> _rays;

            public GetParallelRaysJob(float3 origin, float3 direction, float3 halfPerpDirection, float3 perpDirection, int numberOfRays)
            {
                _origin = origin;
                _direction = direction;
                _halfPerpDirection = halfPerpDirection;
                _perpDirection = perpDirection;
                _numberOfRays = numberOfRays;

                _rays = new NativeArray<Ray>(numberOfRays, Allocator.TempJob);
            }

            public Ray[] RaysBuffer => _rays.ToArray();
            
            public void Execute(int index)
            {
                float3 newOrigin = _origin + (-_halfPerpDirection + (_perpDirection / (_numberOfRays - 1)) * index);
                _rays[index] = new Ray(newOrigin, _direction);
            }

            public void Dispose() => _rays.Dispose();
        }
    }
}
