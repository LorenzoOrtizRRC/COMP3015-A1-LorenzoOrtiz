using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Collections;

public class StateMachine: MonoBehaviour
{
    [SerializeField, Header("References")] private CharacterAgent _agent;
    [SerializeField] private TargetDetector _targetDetector;

    private CharacterAgent _enemy;

    private void Update()
    {
        if (_enemy)
        {
            float distanceFromEnemy = (_enemy.transform.position - transform.position).magnitude;
            if (distanceFromEnemy <= _agent.Weapon.WeaponRange) _agent.UseWeapon();
        }
    }

    private void FixedUpdate()
    {
        if (_enemy)
        {
            Vector2 direction = (_enemy.transform.position - transform.position);
            // move hostile agent if out of range
            if (direction.magnitude > _agent.Weapon.WeaponRange) _agent.MoveAgent(direction.normalized);
            // rotate agent to face target
            float angleDifference = Vector2.SignedAngle(transform.up, direction);
            _agent.RotateAgent(angleDifference);
        }
    }
}
