using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAgent : MonoBehaviour
{
    // This script is responsible for keeping track of a character's live data whilst in-game.
    public Action<float> OnDamageTaken; // when health is reduced (damage taken has been calculated)
    public Action<float> OnHitTaken;    // when a hostile projectile hits this character
    public Action OnDeath;  // when character dies

    public CharacterStats Stats => _stats;
    public WeaponData Weapon => _weapon;
    [SerializeField] private CharacterStats _stats;
    [SerializeField] private WeaponData _weapon;

    // variables for live tracking in-game
    private float _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = Stats.MaxHealth;
        OnHitTaken += DamageCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageCharacter(float incomingDamage)
    {
        float damageTaken = Mathf.Clamp(incomingDamage - Stats.Armor, 1f, Mathf.Infinity);  // current damage formula
        if ((_currentHealth -= damageTaken) <= 0f) KillCharacter();
    }

    private void KillCharacter()
    {
        OnDeath?.Invoke();
        gameObject.SetActive(false);
    }
}
