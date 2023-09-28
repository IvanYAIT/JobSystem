using System;
using Unity.Entities;

[Serializable]
public struct PrefabData : IComponentData
{
    public int Speed;
    public float DeltaTime;
    public int Num;
}
