using System.Collections.Generic;
using UnityEngine;

public class ApplyHeal : MonoBehaviour, IAbilityTarget
{
    public int Heal = 25;

    public List<GameObject> Targets { get; set; }

    public void Execute()
    {        
        foreach (var target in Targets)
        {
            var health = target.GetComponent<HealthComponent>();
            if (health != null)
                health.Health += Heal;

            Destroy(gameObject);
        }
    }

    public void Init(CollisionAbility parent)
    {
        throw new System.NotImplementedException();
    }
}
