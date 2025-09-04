using Unity.Entities;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public float health;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData<HealthData>(entity, new HealthData());
    }
}

public struct HealthData: IComponentData
{
    public float Health;
}
