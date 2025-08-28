using Unity.Entities;

public class DogBaker: Baker<DogAuthoring>
{
    public override void Bake(DogAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new DogComponent
        {
            MoveSpeed = authoring.MoveSpeed,
        });
    }
}

public struct DogComponent : IComponentData
{
    public float MoveSpeed;
}
