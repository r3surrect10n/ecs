using UnityEngine;

public class ShootAbility : MonoBehaviour, IAbility
{
    public GameObject bullet;

    public float shootCooldown;

    private float _shootTime = float.MinValue;

    public void Execute()
    { 
        if (Time.time < _shootTime + shootCooldown)
            return;

        _shootTime = Time.time;

        if (bullet != null)
        {
            var t = transform;
            var newBullet = Instantiate(bullet, t.position, t.rotation);
        }
        else        
            Debug.LogError("[SHOOT ABILITY] No bullet prefab link!");        
    }    
}
