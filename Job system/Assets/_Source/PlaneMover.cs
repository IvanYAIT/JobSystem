using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class PlaneMover : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float speed;
    [SerializeField] private float angle;
    [SerializeField] private int radius;
    [SerializeField] private int countObj;
    [SerializeField] private int delay;

    private float timer;
    private Transform[] _sceneObjects;
    private TransformAccessArray _transformsOnScene;
    private MovementJob _movementJob;
    private LogJob _logJob;
    private JobHandle _movementJobHandle;
    private JobHandle _logJobHandle;
    

    void Start()
    {
        _sceneObjects = new Transform[countObj];

        for (int i = 0; i < countObj; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-500, 500), 0, Random.Range(-300, -100));
            GameObject instance = Instantiate(prefab, pos, Quaternion.identity);
            _sceneObjects[i] = instance.transform;
        }

        _transformsOnScene = new TransformAccessArray(_sceneObjects);
    }

    void Update()
    {
        _movementJob = new MovementJob()
        {
            Speed = speed,
            DeltaTime = Time.deltaTime
        };

        _logJob = new LogJob()
        {
            Num = Random.Range(1, 101),
            Delay = delay,
            DeltaTime = Time.deltaTime,
            Timer = 0
        };

        _movementJobHandle = _movementJob.Schedule(_transformsOnScene);
        _logJobHandle = _logJob.Schedule(_movementJobHandle);

        
    }

    private void LateUpdate()
    {
        _movementJobHandle.Complete();
        _logJobHandle.Complete();
    }

    private void OnDisable()
    {
        _transformsOnScene.Dispose();
    }
}
