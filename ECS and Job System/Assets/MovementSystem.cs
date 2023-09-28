using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class MovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        JobHandle jobHandle = Entities
            .WithName("MovementSystem")
            .ForEach((ref Translation translation, ref Rotation rotation, ref PrefabData data) =>
            {
                float radius = Vector3.Distance(Vector3.forward, translation.Value);
                float angle = Mathf.Atan2(translation.Value.z - Vector3.forward.z, translation.Value.x - Vector3.forward.x) + data.Speed * data.DeltaTime;
                translation.Value = new Vector3(Vector3.forward.x + radius * Mathf.Cos(angle), 0, Vector3.forward.z + radius * Mathf.Sin(angle));
            }).Schedule(inputDeps);
        return jobHandle;
    }
}
