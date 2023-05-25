using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public struct MoverComponent : IComponentData
{
    public float speed;
}

public class MoverComponentAuthoring : MonoBehaviour
{
}

public class MoverComponentBaker : Baker<MoverComponentAuthoring>
{
    private Camera camera;

    public override void Bake(MoverComponentAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new MoverComponent { speed = Random.Range(-1f, 1f) });
    }
}