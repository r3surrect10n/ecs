using UnityEngine;

public class HealthComponent : MonoBehaviour, ITakeDamage, ITakeHeal
{
    public float Health = 100f;

    public void Damage(float damage)
    {
        Health -= damage;
    }

    public void Heal(float heal)
    {
        Health += heal;
    }
}
