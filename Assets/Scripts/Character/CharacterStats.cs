using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Faction { Cats = 0, Dogs = 1}

[CreateAssetMenu(fileName = "New Character Stats", menuName = "Character/Character Stats")]
public class CharacterStats : ScriptableObject
{
    [SerializeField] private string _characterName = "UnitName";
    [SerializeField] private float _maxHealth = 1f;
    [SerializeField] private float _armor = 0f;
    [SerializeField] private float _moveSpeed = 1f;   // units per second
    [SerializeField] private float _turningSpeed = 90f;    // units per second
    [SerializeField] private Faction _currentFaction = 0;

    public string CharacterName => _characterName;
    public float MaxHealth => _maxHealth;
    public float Armor => _armor;
    public float MoveSpeed => _moveSpeed;
    public float TurningSpeed => _turningSpeed;
    public Faction CurrentFaction => _currentFaction;
}
