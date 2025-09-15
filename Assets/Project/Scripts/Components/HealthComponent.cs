using UnityEngine;

public class HealthComponent : MonoBehaviour, ITakeDamage
{
    public float Health = 100f;

    public void Damage(float damage)
    {
        Health -= damage;
    }
}
