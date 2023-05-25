using Unity.Entities;
using UnityEngine;

public struct SpawnerComponent : IComponentData
{
    public Entity Value;
    public int amount;
}

public class SpawnerComponentAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public int amount;
}

public class SpawnerComponentBaker : Baker<SpawnerComponentAuthoring>
{
    public override void Bake(SpawnerComponentAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        var entityPrefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic);
        AddComponent(entity, new SpawnerComponent { Value = entityPrefab, amount = authoring.amount });
    }
}