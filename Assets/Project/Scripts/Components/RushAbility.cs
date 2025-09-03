using UnityEngine;

public class RushAbility : MonoBehaviour, IAbility
{ 
    public float rushDistance;
    public float rushCooldown;

    private float _rushTime = float.MinValue;

    public void Execute()
    { 
        if (Time.time < _rushTime + rushCooldown)
            return;

        _rushTime = Time.time;

        transform.position += transform.forward * rushDistance;
    }    
}
