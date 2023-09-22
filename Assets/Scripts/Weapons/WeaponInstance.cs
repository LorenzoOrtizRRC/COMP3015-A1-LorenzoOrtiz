using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInstance : MonoBehaviour
{
    private float _weaponRange;

    public float WeaponRange => WeaponRange;
    /*
    private Action OnWeaponFiringEnd;

    private WeaponData _weapon;
    private float _cooldownTimer = 0f;
    private bool _isFiring = false;
    public float CooldownTimer => _cooldownTimer;
    public bool IsFiring => _isFiring;
    public bool IsReady => _cooldownTimer <= 0f;

    public WeaponInstance(WeaponData weaponData) => _weapon = weaponData;

    private void Start()
    {
        _cooldownTimer = 0f;
        _isFiring = false;
    }

    private void Update()
    {
        _cooldownTimer -= Time.deltaTime;
    }

    public void ActivateWeapon()
    {
        if (_isFiring) return;
        StartCoroutine(_weapon.FireWeapon(transform.position, transform.rotation, OnWeaponFiringEnd));
    }

    private void ResetWeapon()
    {
        _cooldownTimer = 1f / _weapon.WeaponSpeed;
        _isFiring = false;
    }
    */
}
