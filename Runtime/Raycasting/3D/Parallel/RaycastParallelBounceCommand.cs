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
        public static RaycastHit[][] ParallelBounceCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces) =>
            ParallelBounceCommand(ray.origin, ray.direction, normal, width, numberOfRays, bounces);

        public static RaycastHit[][] ParallelBounceCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, float distance) =>
            ParallelBounceCommand(ray.origin, ray.direction, normal, width, numberOfRays, bounces, distance);

        public static RaycastHit[][] ParallelBounceCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, int layerMask) =>
            ParallelBounceCommand(ray.origin, ray.direction, normal, width, numberOfRays, bounces, layerMask);

        public static RaycastHit[][] ParallelBounceCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, float distance, int layerMask) =>
            ParallelBounceCommand(ray.origin, ray.direction, normal, width, numberOfRays, bounces, distance, layerMask);


        public static RaycastHit[][] ParallelBounceCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, out RayLine[][] rayLines) =>
            ParallelBounceCommand(ray.origin, ray.direction, normal, width, numberOfRays, bounces, out rayLines);

        public static RaycastHit[][] ParallelBounceCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, float distance, out RayLine[][] rayLines) =>
            ParallelBounceCommand(ray.origin, ray.direction, normal, width, numberOfRays, bounces, distance, out rayLines);

        public static RaycastHit[][] ParallelBounceCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, int layerMask, out RayLine[][] rayLines) =>
            ParallelBounceCommand(ray.origin, ray.direction, normal, width, numberOfRays, bounces, layerMask, out rayLines);

        public static RaycastHit[][] ParallelBounceCommand(Ray ray, Vector3 normal, float width, int numberOfRays, int bounces, float distance, int layerMask, out RayLine[][] rayLines) =>
            ParallelBounceCommand(ray.origin, ray.direction, normal, width, numberOfRays, bounces, distance, layerMask, out rayLines);



        public static RaycastHit[][] ParallelBounceCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit[]>();

            var numberOfParallelRaycasts = bounces + 1;
            RaycastHit[][] hitsArray = new RaycastHit[numberOfParallelRaycasts][];
            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            const float OFFSET_ALONG_DIRECTION = 0.001f;

            for (int i = 0; i < numberOfParallelRaycasts; i++)
            {
                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    commands[j] = new RaycastCommand(ray.origin + ray.direction * OFFSET_ALONG_DIRECTION, ray.direction);
                }

                JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
                jobHandle.Complete();

                RaycastHit[] raycastHits = results.ToArray();
                hitsArray[i] = raycastHits;

                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    RaycastHit hit = raycastHits[j];

                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                    rays[j] = ray;
                }
            }

            commands.Dispose();
            results.Dispose();
            return hitsArray;
        }

        public static RaycastHit[][] ParallelBounceCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, float distance)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit[]>();

            var numberOfParallelRaycasts = bounces + 1;
            RaycastHit[][] hitsArray = new RaycastHit[numberOfParallelRaycasts][];
            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            const float OFFSET_ALONG_DIRECTION = 0.001f;

            for (int i = 0; i < numberOfParallelRaycasts; i++)
            {
                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    commands[j] = new RaycastCommand(ray.origin + ray.direction * OFFSET_ALONG_DIRECTION, ray.direction, distance);
                }

                JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
                jobHandle.Complete();

                RaycastHit[] raycastHits = results.ToArray();
                hitsArray[i] = raycastHits;

                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    RaycastHit hit = raycastHits[j];

                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                    rays[j] = ray;
                }
            }

            commands.Dispose();
            results.Dispose();
            return hitsArray;
        }

        public static RaycastHit[][] ParallelBounceCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, int layerMask)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit[]>();

            var numberOfParallelRaycasts = bounces + 1;
            RaycastHit[][] hitsArray = new RaycastHit[numberOfParallelRaycasts][];
            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            const float OFFSET_ALONG_DIRECTION = 0.001f;

            for (int i = 0; i < numberOfParallelRaycasts; i++)
            {
                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    commands[j] = new RaycastCommand(ray.origin + ray.direction * OFFSET_ALONG_DIRECTION, ray.direction, layerMask: layerMask);
                }

                JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
                jobHandle.Complete();

                RaycastHit[] raycastHits = results.ToArray();
                hitsArray[i] = raycastHits;

                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    RaycastHit hit = raycastHits[j];

                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                    rays[j] = ray;
                }
            }

            commands.Dispose();
            results.Dispose();
            return hitsArray;
        }

        public static RaycastHit[][] ParallelBounceCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, float distance, int layerMask)
        {
            if (numberOfRays < 0)
                return Array.Empty<RaycastHit[]>();

            var numberOfParallelRaycasts = bounces + 1;
            RaycastHit[][] hitsArray = new RaycastHit[numberOfParallelRaycasts][];
            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);

            const float OFFSET_ALONG_DIRECTION = 0.001f;

            for (int i = 0; i < numberOfParallelRaycasts; i++)
            {
                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    commands[j] = new RaycastCommand(ray.origin + ray.direction * OFFSET_ALONG_DIRECTION, ray.direction, distance, layerMask);
                }

                JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
                jobHandle.Complete();

                RaycastHit[] raycastHits = results.ToArray();
                hitsArray[i] = raycastHits;

                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    RaycastHit hit = raycastHits[j];

                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                    rays[j] = ray;
                }
            }

            commands.Dispose();
            results.Dispose();
            return hitsArray;
        }


        public static RaycastHit[][] ParallelBounceCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, out RayLine[][] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine[]>();
                return Array.Empty<RaycastHit[]>();
            }

            var numberOfParallelRaycasts = bounces + 1;
            RaycastHit[][] hitsArray = new RaycastHit[numberOfParallelRaycasts][];
            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);
            rayLines = new RayLine[numberOfParallelRaycasts][];

            const float OFFSET_ALONG_DIRECTION = 0.001f;

            for (int i = 0; i < numberOfParallelRaycasts; i++)
            {
                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    commands[j] = new RaycastCommand(ray.origin + ray.direction * OFFSET_ALONG_DIRECTION, ray.direction);
                }

                JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
                jobHandle.Complete();

                RaycastHit[] raycastHits = results.ToArray();
                hitsArray[i] = raycastHits;

                rayLines[i] = new RayLine[numberOfRays];

                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    RaycastHit hit = raycastHits[j];
                    rayLines[i][j] = new RayLine(ray, hit);

                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                    rays[j] = ray;
                }
            }

            commands.Dispose();
            results.Dispose();
            return hitsArray;
        }

        public static RaycastHit[][] ParallelBounceCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, float distance, out RayLine[][] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine[]>();
                return Array.Empty<RaycastHit[]>();
            }

            var numberOfParallelRaycasts = bounces + 1;
            RaycastHit[][] hitsArray = new RaycastHit[numberOfParallelRaycasts][];
            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);
            rayLines = new RayLine[numberOfParallelRaycasts][];

            const float OFFSET_ALONG_DIRECTION = 0.001f;

            for (int i = 0; i < numberOfParallelRaycasts; i++)
            {
                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    commands[j] = new RaycastCommand(ray.origin + ray.direction * OFFSET_ALONG_DIRECTION, ray.direction, distance);
                }

                JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
                jobHandle.Complete();

                RaycastHit[] raycastHits = results.ToArray();
                hitsArray[i] = raycastHits;

                rayLines[i] = new RayLine[numberOfRays];

                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    RaycastHit hit = raycastHits[j];
                    rayLines[i][j] = new RayLine(ray, hit);

                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                    rays[j] = ray;
                }
            }

            commands.Dispose();
            results.Dispose();
            return hitsArray;
        }

        public static RaycastHit[][] ParallelBounceCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, int layerMask, out RayLine[][] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine[]>();
                return Array.Empty<RaycastHit[]>();
            }

            var numberOfParallelRaycasts = bounces + 1;
            RaycastHit[][] hitsArray = new RaycastHit[numberOfParallelRaycasts][];
            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);
            rayLines = new RayLine[numberOfParallelRaycasts][];

            const float OFFSET_ALONG_DIRECTION = 0.001f;

            for (int i = 0; i < numberOfParallelRaycasts; i++)
            {
                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    commands[j] = new RaycastCommand(ray.origin + ray.direction * OFFSET_ALONG_DIRECTION, ray.direction, layerMask: layerMask);
                }

                JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
                jobHandle.Complete();

                RaycastHit[] raycastHits = results.ToArray();
                hitsArray[i] = raycastHits;

                rayLines[i] = new RayLine[numberOfRays];

                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    RaycastHit hit = raycastHits[j];
                    rayLines[i][j] = new RayLine(ray, hit);

                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                    rays[j] = ray;
                }
            }

            commands.Dispose();
            results.Dispose();
            return hitsArray;
        }

        public static RaycastHit[][] ParallelBounceCommand(Vector3 origin, Vector3 direction, Vector3 normal, float width, int numberOfRays, int bounces, float distance, int layerMask, out RayLine[][] rayLines)
        {
            if (numberOfRays < 0)
            {
                rayLines = Array.Empty<RayLine[]>();
                return Array.Empty<RaycastHit[]>();
            }

            var numberOfParallelRaycasts = bounces + 1;
            RaycastHit[][] hitsArray = new RaycastHit[numberOfParallelRaycasts][];
            Ray[] rays = GetParallelRaysCommand(origin, direction, normal, width, numberOfRays);

            var commands = new NativeArray<RaycastCommand>(numberOfRays, Allocator.TempJob);
            var results = new NativeArray<RaycastHit>(numberOfRays, Allocator.TempJob);
            rayLines = new RayLine[numberOfParallelRaycasts][];

            const float OFFSET_ALONG_DIRECTION = 0.001f;

            for (int i = 0; i < numberOfParallelRaycasts; i++)
            {
                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    commands[j] = new RaycastCommand(ray.origin + ray.direction * OFFSET_ALONG_DIRECTION, ray.direction, distance, layerMask);
                }

                JobHandle jobHandle = RaycastCommand.ScheduleBatch(commands, results, 1);
                jobHandle.Complete();

                RaycastHit[] raycastHits = results.ToArray();
                hitsArray[i] = raycastHits;

                rayLines[i] = new RayLine[numberOfRays];

                for (int j = 0; j < numberOfRays; j++)
                {
                    Ray ray = rays[j];
                    RaycastHit hit = raycastHits[j];
                    rayLines[i][j] = new RayLine(ray, hit);

                    ray.origin = hit.point;
                    ray.direction = Vector3.Reflect(ray.direction, hit.normal);
                    rays[j] = ray;
                }
            }

            commands.Dispose();
            results.Dispose();
            return hitsArray;
        }
    }
}
