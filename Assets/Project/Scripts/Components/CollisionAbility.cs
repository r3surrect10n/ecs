using System.Collections.Generic;
using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CollisionAbility : MonoBehaviour, IAbility, IConvertGameObjectToEntity
{
    [SerializeField] private Collider _collider;
    [SerializeField] private MonoBehaviour[] _useAbilities;

    private List<IAbilityTarget> _abilities = new List<IAbilityTarget>();

    public List<Collider> Colliders = new List<Collider>();
    public Entity Entity;
    public EntityManager EntityManager;

    private void Awake()
    {
        foreach (var useAbility in _useAbilities)
        {
            if (useAbility is IAbilityTarget ability)
            {
                _abilities.Add(ability);
                ability.Init(this);
            }
        }
    }

    public void Execute()
    {
        foreach (var ability in _abilities)
        {
            ability.Execute();
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Entity = entity;
        EntityManager = dstManager;
        float3 position = transform.position;

        switch (_collider)
        {
            case BoxCollider boxCollider:
                boxCollider.ToWorldSpaceBox(out var boxCenter, out var halfExtents, out var orientation);
                dstManager.AddComponentData(entity, new ActorColliderData()
                {
                    ColliderType = ColliderType.Box,
                    Center = boxCenter - position,
                    HalfExtents = halfExtents,
                    BoxOrientation = orientation,
                    InitialTakeOff = true
                });
                break;
            case CapsuleCollider capsuleCollider:
                capsuleCollider.ToWorldSpaceCapsule(out var startPoint, out var endPoint, out var capsuleRadius);
                dstManager.AddComponentData(entity, new ActorColliderData()
                {
                    ColliderType = ColliderType.Capsule,
                    CapsuleStart = startPoint - position,
                    CapsuleEnd = endPoint - position,
                    Radius = capsuleRadius,
                    InitialTakeOff = true
                });
                break;
            case SphereCollider sphereCollider:
                sphereCollider.ToWorldSpaceSphere(out var center, out var radius);
                dstManager.AddComponentData(entity, new ActorColliderData()
                {
                    ColliderType = ColliderType.Sphere,
                    Center = center - position,
                    Radius = radius,
                    InitialTakeOff = true
                });
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(_collider));
        }
        _collider.enabled = false;
    }
    private void OnDestroy()
    {
        EntityManager.DestroyEntity(Entity);
    }
}

public struct ActorColliderData : IComponentData
{
    public ColliderType ColliderType;
    public float3 Center;
    public float Radius;
    public float3 HalfExtents;
    public float3 CapsuleStart;
    public float3 CapsuleEnd;
    public Quaternion BoxOrientation;
    public bool InitialTakeOff;
}

public enum ColliderType
{
    Sphere = 0,
    Capsule = 1,
    Box = 2
}