//using Unity.Entities;

//public class RushSystem : ComponentSystem
//{
//    private EntityQuery _rushQuery;

//    protected override void OnCreate()
//    {
//        _rushQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
//            ComponentType.ReadOnly<RushData>(),
//            ComponentType.ReadOnly<UserInputData>());
//    }

//    protected override void OnUpdate()
//    {
//        Entities.With(_rushQuery).ForEach(
//            (Entity entity, UserInputData inputData, ref InputData input) =>
//            {
//            if (input.Rush > 0f && inputData.RushAction != null && inputData.RushAction is IAbility rushAbility) 
//                {
//                    rushAbility.Execute();
//                }
//            });
//    }
//}
