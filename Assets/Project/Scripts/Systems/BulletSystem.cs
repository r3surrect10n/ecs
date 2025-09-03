using Unity.Entities;
using UnityEngine;

public class BulletFlightSystem : ComponentSystem
{
    private EntityQuery _bulletQuery;

    protected override void OnCreate()
    {
        _bulletQuery = GetEntityQuery(ComponentType.ReadOnly<Transform>(), 
            ComponentType.ReadOnly<BulletFlight>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_bulletQuery).ForEach(
            (Entity entity, Transform transform, ref BulletFlight bullet) =>
            {
                transform.position += transform.forward * bullet.BulletSpeed * Time.DeltaTime;
            });
    }
}
