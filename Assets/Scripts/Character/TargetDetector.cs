using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetDetector : MonoBehaviour
{
    public Action<CharacterAgent> OnPotentialTargetAcquired;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterAgent agent = collision.GetComponent<CharacterAgent>();
        if (agent) OnPotentialTargetAcquired?.Invoke(agent);
    }
}
