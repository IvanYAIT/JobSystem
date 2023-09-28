using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct PrefabTimer : IComponentData
{
    public float Timer;
    public int Delay;
}
