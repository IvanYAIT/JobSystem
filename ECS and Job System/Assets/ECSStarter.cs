using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class ECSStarter : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int delay;
    [SerializeField] private int speed;
    [SerializeField] private int objectsCount;
    private EntityManager _entityManager;

    private void Awake()
    {
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

        Entity prefabEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab, settings);


        for(int i = 0; i < objectsCount; i++)
        {
            Entity prefabInstance = _entityManager.Instantiate(prefabEntity);
            float3 posVector = new float3(UnityEngine.Random.Range(-100, 100), 0, UnityEngine.Random.Range(-100, 100));
            Vector3 pos = transform.TransformPoint(posVector);

            _entityManager.SetComponentData(prefabInstance, new Translation { Value = pos });
            _entityManager.SetComponentData(prefabInstance, new Rotation { Value = new quaternion(0, 0, 0, 0) });
            _entityManager.AddComponentData(prefabInstance, new PrefabData { Speed = speed, DeltaTime = Time.deltaTime, Num = UnityEngine.Random.Range(0, 101)});
            _entityManager.AddComponentData(prefabInstance, new PrefabTimer { Delay = delay, Timer = 0});
        }
    }
}
