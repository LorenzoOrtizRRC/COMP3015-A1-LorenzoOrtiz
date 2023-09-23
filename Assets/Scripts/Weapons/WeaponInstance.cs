using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInstance : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _rateOfFire = 1f;     // Projectiles per 1 real second. Formula: (1 second / projectiles per second), where assigned value is the real seconds delay between projectile spawning.
    [SerializeField] private float _weaponRange = 8f;

    private Team _currentTeam = Team.Team1;
    private float _timer = 0;

    public float WeaponRange => _weaponRange;

    public void InitializeWeapon(Team newTeam)
    {
        _currentTeam = newTeam;
    }
    
    public void FireProjectile()
    {
        if (Time.time >= _timer)
        {
            Instantiate(_projectilePrefab, _projectileSpawnPoint.position, transform.rotation);
            _projectilePrefab.GetComponent<Projectile>().InitializeProjectile(_currentTeam);
            _timer = Time.time + _rateOfFire;
        }
    }
}
