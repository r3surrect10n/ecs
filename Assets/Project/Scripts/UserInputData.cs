using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData<InputData>(entity, new InputData());
        dstManager.AddComponentData<MoveData>(entity, new MoveData
        {
            Speed = speed / 100
        });
    }
}

public struct InputData: IComponentData
{
    public float2 Move;
}

public struct MoveData: IComponentData
{
    public float Speed;
}
