using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class LogSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        JobHandle jobHandle = Entities
            .WithName("LogSystem")
            .ForEach((ref PrefabData data, ref PrefabTimer timer) =>
            {
                if (timer.Timer <= 0)
                {
                    float res = Mathf.Log(data.Num);
                    Debug.Log($"{res}");
                    timer.Timer = timer.Delay;
                }
                else
                    timer.Timer -= data.DeltaTime;
            }).Schedule(inputDeps);

        return jobHandle;
    }
}