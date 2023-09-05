using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : ScriptableObject
{
    private string _characterName;
    private float _maxHealth;
    private float _armor;
    private float _moveSpeed;
    private float _turningSpeed;
    private List<WeaponData> _weaponList;

    public string CharacterName => _characterName;
    public float MaxHealth => _maxHealth;
    public float Armor => _armor;
    public float MoveSpeed => _moveSpeed;
    public float TurningSpeed => _turningSpeed;
    public List<WeaponData> WeaponList => _weaponList;
}
