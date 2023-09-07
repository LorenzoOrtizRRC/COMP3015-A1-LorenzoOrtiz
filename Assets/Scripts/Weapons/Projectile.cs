using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;

    // data from projectile owner
    private CharacterStats _projectileOwner;
    private float _damage = 1f;
    private float _projectileLifetime = 3f;
    private float _projectileSpeed = 1f;

    private float _elapsedLifetime = 0f;

    private void Start()
    {
        // Move projectile. This assumes drag = 0;
        _rb.velocity = Vector2.up * _projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedLifetime += Time.deltaTime;
        if (_elapsedLifetime >= _projectileLifetime) DestroyProjectile();
    }

    private void InitializeProjectile(CharacterStats projectileOwner, float damage, float lifetime, float speed)
    {
        _projectileOwner = projectileOwner;
        _damage = damage;
        _projectileLifetime = lifetime;
        _projectileSpeed = speed;
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }

    private void DamageTarget()
    {
        // implementation here
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterStats>().CurrentFaction != _projectileOwner.CurrentFaction)
            DamageTarget();
    }
}
