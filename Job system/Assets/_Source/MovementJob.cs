using UnityEngine;
using UnityEngine.Jobs;

public struct MovementJob : IJobParallelForTransform
{
    public float Speed;
    public float Angel;
    public int Radius;
    public float DeltaTime;

    public void Execute(int index, TransformAccess transform)
    {
        float radius = Vector3.Distance(Vector3.forward, transform.position);
        float angle = Mathf.Atan2(transform.position.z - Vector3.forward.z, transform.position.x - Vector3.forward.x) + Speed * DeltaTime;
        transform.position = new Vector3(Vector3.forward.x + radius * Mathf.Cos(angle), 0, Vector3.forward.z + radius * Mathf.Sin(angle));
    }
}
