using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team { Team1 = 1, Team2 = 2 }

public class CharacterAgent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField, Header("References")] private WeaponInstance _weapon;
    [SerializeField, Header("Agent Variables")] private float _health;
    [SerializeField] private float _movementForce = 10f;
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private Team _currentTeam = Team.Team1;

    public WeaponInstance Weapon => _weapon;

    private void Start()
    {
        _weapon.InitializeWeapon(_currentTeam);
    }

    public void MoveAgent(Vector2 direction)
    {
        _rb.AddForce(direction.normalized * _movementForce);
    }

    public void RotateAgent(Vector2 direction)
    {
        //float rotationDirection = angleDifference > 0f ? 1f : -1f;
        //float absClampValue = Mathf.Abs(angleDifference);
        //transform.Rotate(new Vector3(0f, 0f, 1 * Mathf.Clamp(rotationDirection * 180f * Time.fixedDeltaTime, -absClampValue, absClampValue)));
        //_rb.MoveRotation(degrees);
        // Called in FixedUpdate. Rotates towards angle using a rotation speed.
        float angleDifference = Vector2.SignedAngle(transform.up, direction);
        float rotationDirection = angleDifference > 0f ? 1f : -1f;
        float absClampValue = Mathf.Abs(angleDifference);
        float degreesToRotate = Mathf.Clamp(rotationDirection * _rotationSpeed * Time.fixedDeltaTime, -absClampValue, absClampValue);
        transform.rotation *= Quaternion.AngleAxis(degreesToRotate, Vector3.forward);
    }

    public void UseWeapon()
    {
        //
    }

    private void ResetTarget()
    {
        //
    }

    public void ReceiveDamage(float receivedDamage)
    {
        _health = Mathf.Clamp(_health - receivedDamage, 0f, Mathf.Infinity);
        if (_health == 0) KillCharacter();
    }

    public void KillCharacter()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Projectile hitProjectile = collision.transform.GetComponent<Projectile>();
        if (hitProjectile)
        {
            ReceiveDamage(hitProjectile.Damage);
        }
    }
}
