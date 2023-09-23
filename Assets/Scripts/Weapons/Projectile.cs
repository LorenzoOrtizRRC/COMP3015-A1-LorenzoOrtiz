using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _lifetime = 1f;

    private Team _currentTeam = Team.Team1;
    private float _lifeTimer = 0f;

    public float Damage => _damage;
    public Team CurrentTeam => _currentTeam;

    public void InitializeProjectile(Team newTeam)
    {
        _currentTeam = newTeam;
    }

    private void Start()
    {
        _rb.AddForce(transform.up * _speed, ForceMode2D.Impulse);
        _lifeTimer = Time.time + _lifetime;
    }

    private void Update()
    {
        if (Time.time >= _lifeTimer) Destroy(gameObject);
    }
}
