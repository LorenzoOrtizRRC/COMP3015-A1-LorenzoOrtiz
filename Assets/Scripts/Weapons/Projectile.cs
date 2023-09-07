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
        // despawn after lifetime expires.
        _elapsedLifetime += Time.deltaTime;
        if (_elapsedLifetime >= _projectileLifetime) DestroyProjectile();
    }

    private void InitializeProjectile(CharacterStats projectileOwner, float damage, float lifetime, float speed)
    {
        // assign variables from WeaponData that spawned it.
        // The projectile script doesn't hold these variables because they're only in charge of art and collisions. Actual behavior is in WeaponData. Subject to change.
        _projectileOwner = projectileOwner;
        _damage = damage;
        _projectileLifetime = lifetime;
        _projectileSpeed = speed;
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }

    private void DamageTarget(CharacterAgent targetHit)
    {
        targetHit.OnHitTaken?.Invoke(_damage);
        DestroyProjectile();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterAgent targetHit))
            DamageTarget(targetHit);
    }
}
