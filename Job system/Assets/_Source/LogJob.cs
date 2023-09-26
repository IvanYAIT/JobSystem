using Unity.Jobs;
using UnityEngine;

public struct LogJob : IJob
{
    public int Num;

    public void Execute()
    {
        Debug.Log(Mathf.Log(Num));
    }
}