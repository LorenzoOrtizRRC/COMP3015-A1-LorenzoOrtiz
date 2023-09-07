using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAgent : MonoBehaviour
{
    // This script is responsible for keeping track of a character's live data whilst in-game.
    public Action<float> OnDamageTaken; // when health is reduced (damage taken has been calculated)
    public Action<float> OnHitTaken;    // when a hostile projectile hits this character. Takes in pre-mitigated/raw damage.
    public Action OnDeath;  // when character dies

    public CharacterStats Stats => _stats;
    public WeaponData Weapon => _weapon;
    [SerializeField] private CharacterStats _stats;
    [SerializeField] private WeaponData _weapon;

    // variables for live tracking in-game
    private float _currentHealth;
    private float _weaponTimer = 0f;    // timer for weapon cooldowns (based on weapon's rate of fire)

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = Stats.MaxHealth;
        OnHitTaken += DamageCharacter;
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
    }
}
