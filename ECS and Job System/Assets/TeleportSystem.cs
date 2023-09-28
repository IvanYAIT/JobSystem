using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

class TeleportSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        JobHandle jobHandle = Entities
            .WithName("TeleportSystem")
            .ForEach((ref Translation translation, ref Rotation rotation, ref PrefabData data) =>
            {
                if (translation.Value.z >= 30)
                    translation.Value = new float3(translation.Value.x, translation.Value.y, 0);
            }).Schedule(inputDeps);
        return jobHandle;
    }
}
