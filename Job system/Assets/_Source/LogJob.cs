using Unity.Jobs;
using UnityEngine;

public struct LogJob : IJob
{
    public int Num;
    public int Delay;
    public float DeltaTime;
    public float Timer;

    public void Execute()
    {
        if (Timer <= 0)
        {
            Debug.Log(Mathf.Log(Num));
            Timer = Delay;
        }
        else
            Timer -= DeltaTime;
    }
}