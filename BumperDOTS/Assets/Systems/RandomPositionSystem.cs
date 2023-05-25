using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

[BurstCompile]
public partial struct RandomPositionSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
        Camera camera = Camera.main;
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach ((RefRO<RandomPositionComponent> comp, Entity entity) in
                 SystemAPI
                     .Query<RefRO<RandomPositionComponent>>()
                     .WithEntityAccess())
        {
            float3 position = new float3(Random.Range(0.05f, 0.95f), Random.Range(0.05f, 0.95f), 10);
            ecb.SetComponent(entity, new LocalTransform()
            {
                Position = camera.ViewportToWorldPoint(position),
                Scale = 1
            });
            ecb.RemoveComponent(entity, typeof(RandomPositionComponent));
        }
        
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}