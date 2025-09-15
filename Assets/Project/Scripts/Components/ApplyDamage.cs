using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour, IAbilityTarget
{
    [SerializeField] protected float _damage = 10;

    protected List<Collider> _collisions => _collisionAbility.Colliders;
    private CollisionAbility _collisionAbility;


    public List<GameObject> Targets { get; set; }

    public void Execute()
    {         
        foreach (var collision in _collisions)
        {
            if (collision.TryGetComponent<ITakeDamage>(out var damage))
            {
                damage.Damage(_damage);
                Destroy(gameObject);
            }
        }
    }

    public void Init(CollisionAbility parent)
    {
        _collisionAbility = parent;
    }
}
