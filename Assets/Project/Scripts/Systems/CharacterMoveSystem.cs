using Unity.Entities;
using UnityEngine;

public class CharacterMoveSystem : ComponentSystem
{
    private EntityQuery _moveQuery;

    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), 
            ComponentType.ReadOnly<MoveData>(), 
            ComponentType.ReadOnly<Transform>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
             (Entity entity, Transform transform, ref InputData inputData, ref MoveData moveData) => 
             {
                 var pos = transform.position;
                 var rot = transform.rotation;

                 if (inputData.Move.x != 0 || inputData.Move.y != 0)
                 {
                     pos += new Vector3(inputData.Move.x * moveData.Speed, 0, inputData.Move.y * moveData.Speed);
                     rot = Quaternion.LookRotation(new Vector3(inputData.Move.x, 0, inputData.Move.y));                     
                 }                 

                 transform.position = pos;
                 transform.rotation = rot;
             });
    }
}
