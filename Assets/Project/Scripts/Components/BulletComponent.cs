using Unity.Entities;
using UnityEngine;

public class BulletComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public float bulletSpeed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData<BulletFlight>(entity, new BulletFlight
        {
            BulletSpeed = bulletSpeed 
        });
    }

}
public struct BulletFlight: IComponentData
{
    public float BulletSpeed;
}
