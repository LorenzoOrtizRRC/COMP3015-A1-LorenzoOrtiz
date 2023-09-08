using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapons/New Weapon Data")]
public abstract class WeaponData : ScriptableObject
{
    [SerializeField] private GameObject _weaponProjectile;
    [SerializeField] private float _weaponDamage = 1f;
    [SerializeField] private float _weaponSpeed = 1f;   // rate of fire: bullets per second. formula used for timers: (1 / _weaponSpeed)
    [SerializeField] private float _minDistanceThreshold = 1f;  // weapon range used by AI. serves as activation condition.
    [SerializeField] private float _maxDistanceThreshold = 10f; // weapon range used by AI. serves as activation condition.
    [SerializeField] private float _projectileSpeed = 3f;
    [SerializeField] private float _projectileLifetime = 3f;
    public GameObject WeaponProjectile => _weaponProjectile;
    public float WeaponDamage => _weaponDamage;
    public float WeaponSpeed => _weaponSpeed;
    public float MinDistanceThreshold => _minDistanceThreshold;
    public float MaxDistanceThreshold => _maxDistanceThreshold;
    public float ProjectileSpeed => _projectileSpeed;
    public float ProjectileLifetime => _projectileLifetime;

    public abstract IEnumerator FireWeapon(Vector3 projectilePosition, Quaternion initialRotation, Action finishedDelegate);
}
