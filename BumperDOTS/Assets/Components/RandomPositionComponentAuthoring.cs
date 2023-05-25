using Unity.Entities;
using UnityEngine;

public struct RandomPositionComponent : IComponentData
{
}

public class RandomPositionComponentAuthoring : MonoBehaviour
{
}

public class RandomPositionComponentBaker : Baker<RandomPositionComponentAuthoring>
{
    public override void Bake(RandomPositionComponentAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new RandomPositionComponent { });
    }
}