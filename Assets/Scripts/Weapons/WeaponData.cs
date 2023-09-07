using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapons/New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private float _weaponDamage = 1f;
    [SerializeField] private float _minDistanceThreshold = 1f;  // weapon range used by AI. serves as activation condition.
    [SerializeField] private float _maxDistanceThreshold = 10f; // weapon range used by AI. serves as activation condition.
    [SerializeField] private float _projectileSpeed = 3f;
    [SerializeField] private float _projectileLifetime = 3f;
    public float WeaponDamage => _weaponDamage;
    public float MinDistanceThreshold => _minDistanceThreshold;
    public float MaxDistanceThreshold => _maxDistanceThreshold;
    public float ProjectileSpeed => _projectileSpeed;
    public float ProjectileLifetime => _projectileLifetime;
}
