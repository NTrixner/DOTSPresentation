using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

[BurstCompile]
public partial struct SpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.Temp);

        // Get all Entities that have the component with the Entity reference
        foreach ((RefRO<SpawnerComponent> prefab, Entity entity) in
                 SystemAPI
                     .Query<RefRO<SpawnerComponent>>()
                     .WithEntityAccess())
        {
            // Instantiate the prefab Entity
            for (int i = 0; i < prefab.ValueRO.amount; i++)
            {
                ecb.Instantiate(prefab.ValueRO.Value);
            }


            ecb.DestroyEntity(entity);
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}