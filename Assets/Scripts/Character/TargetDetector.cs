using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetDetector : MonoBehaviour
{
    public Action<CharacterAgent> OnPotentialTargetAcquired;
    [SerializeField] private CircleCollider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterAgent agent = collision.GetComponent<CharacterAgent>();
        if (agent) OnPotentialTargetAcquired?.Invoke(agent);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _collider.radius);
    }
}
