using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class CharacterAgent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField, Header("References")] private WeaponInstance _weapon;
    [SerializeField, Header("Agent Variables")] private float _movementForce = 10f;
    [SerializeField] private float _rotationSpeed = 180f;

    public WeaponInstance Weapon => _weapon;

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

    public void ReceiveDamage()
    {
        //
    }

    public void KillCharacter()
    {
        Destroy(gameObject);
    }
    /*
    // This script is responsible for keeping track of a character's live data whilst in-game.
    public Action<float> OnDamageTaken; // when health is reduced (damage taken has been calculated)
    public Action<float> OnHitTaken;    // when a hostile projectile hits this character. Takes in pre-mitigated/raw damage.
    public Action OnDeath;  // when character dies

    public CharacterStats Stats => _stats;
    public WeaponData Weapon => _weapon;
    [SerializeField] private CharacterStats _stats;
    [SerializeField] private WeaponData _weapon;

    // variables for live tracking in-game
    private WeaponInstance _weaponInstance;
    private float _currentHealth;
    private float _weaponTimer = 0f;    // timer for weapon cooldowns (based on weapon's rate of fire)

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = Stats.MaxHealth;
        OnHitTaken += DamageCharacter;
        // create instances of weapons, which are used to track their live data (cooldowns, etc.)
        _weaponInstance = new WeaponInstance(_weapon);
    }

    public void UseWeapon()
    {
        _weaponInstance.ActivateWeapon();
    }

    public void DamageCharacter(float incomingDamage)
    {
        float damageTaken = Mathf.Clamp(incomingDamage - Stats.Armor, 1f, Mathf.Infinity);  // current damage formula
        if ((_currentHealth -= damageTaken) <= 0f)
        {
            OnDamageTaken(damageTaken);
            KillCharacter();
        }
    }

    private void KillCharacter()
    {
        OnDeath?.Invoke();
        gameObject.SetActive(false);
    }*/
}
