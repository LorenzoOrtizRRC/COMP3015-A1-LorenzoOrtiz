using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInstance : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _rateOfFire = 1f;     // Projectiles per 1 real second. Formula: (1 second / projectiles per second), where assigned value is the real seconds delay between projectile spawning.

    private float _weaponRange;
    private float _timer = 0;

    public float WeaponRange => WeaponRange;
    
    public void FireProjectile()
    {
        if (Time.time >= _timer)
        {
            Instantiate(_projectilePrefab, _projectileSpawnPoint.position, transform.rotation);
            _timer = Time.time + _rateOfFire;
        }
    }
}
