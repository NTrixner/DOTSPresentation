using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial class MoverSystem : SystemBase
{
    [BurstCompile]
    protected override void OnUpdate()
    {
        Camera cam = Camera.main;
        float deltaTime = UnityEngine.Time.deltaTime;

        foreach ((RefRW<MoverComponent> comp, RefRW<LocalTransform> transform) in
                 SystemAPI
                     .Query<RefRW<MoverComponent>, RefRW<LocalTransform>>())
        {
            float3 transformPosition = transform.ValueRO.Position;
            transformPosition.y += comp.ValueRO.speed * deltaTime * 10f;
            transform.ValueRW.Position = transformPosition;

            if (cam.WorldToScreenPoint(transform.ValueRO.Position).y <= 0 ||
                cam.WorldToScreenPoint(transform.ValueRO.Position).y >= Screen.height)
            {
                comp.ValueRW.speed *= -1;
            }
        }
    }
}