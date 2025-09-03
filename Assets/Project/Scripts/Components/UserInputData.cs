using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour ShootAction;
    public MonoBehaviour RushAction;

    public float speed;    

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData<InputData>(entity, new InputData());
        dstManager.AddComponentData<MoveData>(entity, new MoveData
        {
            Speed = speed / 100
        });

        if (ShootAction != null && ShootAction is IAbility)
        {
            dstManager.AddComponentData<ShootData>(entity, new ShootData());
        }

        if (RushAction != null && RushAction is IAbility)
        {
            dstManager.AddComponentData<RushData>(entity, new RushData());
        }
    } 
}

public struct InputData: IComponentData
{
    public float2 Move;
    public float Shoot;
    public float Rush;
}

public struct MoveData: IComponentData
{
    public float Speed;    
}

public struct ShootData: IComponentData
{

}

public struct RushData: IComponentData
{
    
}
