using System.Collections.Generic;
using UnityEngine;

public class ApplyHeal : MonoBehaviour, IAbilityTarget
{
    public int HealPoints = 25;

    protected List<Collider> _collisions => _collisionAbility.Colliders;
    private CollisionAbility _collisionAbility;

    public List<GameObject> Targets { get; set; }

    public void Execute()
    {        
        foreach (var collision in _collisions)
        {
            if (collision != null && collision.TryGetComponent<ITakeHeal>(out var health))
            {
                health.Heal(HealPoints);
                Destroy(gameObject);
            }
        }
    }

    public void Init(CollisionAbility parent)
    {
        _collisionAbility = parent;
    }
}
