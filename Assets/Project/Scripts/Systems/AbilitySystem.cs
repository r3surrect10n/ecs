using Unity.Entities;

public class AbilitySystem : ComponentSystem
{
    private EntityQuery _shootQuery;
    private EntityQuery _rushQuery;

    protected override void OnCreate()
    {
        _shootQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<ShootData>(),
            ComponentType.ReadOnly<UserInputData>());

        _rushQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<RushData>(),
            ComponentType.ReadOnly<UserInputData>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_shootQuery).ForEach(
            (Entity entity, UserInputData inputData, ref InputData input) =>
            {
            if (input.Shoot > 0f && inputData.ShootAction != null && inputData.ShootAction is IAbility shootAbility) 
                {                    
                    shootAbility.Execute();
                }
            });

        Entities.With(_rushQuery).ForEach(
            (Entity entity, UserInputData inputData, ref InputData input) =>
            {
                if (input.Rush > 0f && inputData.RushAction != null && inputData.RushAction is IAbility rushAbility)
                {
                    rushAbility.Execute();
                }
            });
    }
}
