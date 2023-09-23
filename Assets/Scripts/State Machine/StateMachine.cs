using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine: MonoBehaviour
{
    [SerializeField, Header("References")] private CharacterAgent _agent;
    [SerializeField] private TargetDetector _targetDetector;
    [SerializeField] private Collider2D _wanderArea;
    [SerializeField, Header("State Machine Variables")] private float _wanderDistanceThreshold = 0.5f;
    [SerializeField] private float _chaseRange = 15f;

    private CharacterAgent _enemy;
    private Vector2 _nextWanderDestination;

    private void Start()
    {
        _nextWanderDestination = GetWanderAreaDestination();
        _targetDetector.OnPotentialTargetAcquired += EvaluateTarget;
    }

    private void Update()
    {
        if (_enemy)
        {
            Vector2 direction = (_enemy.transform.position - transform.position);
            float distanceFromEnemy = (_enemy.transform.position - transform.position).magnitude;
            if (distanceFromEnemy <= _agent.Weapon.WeaponRange
                && Vector2.SignedAngle(transform.up, direction) <= 0.2f) _agent.UseWeapon();
        }
    }

    private void FixedUpdate()
    {
        if (_enemy)
        {
            Vector2 direction = (_enemy.transform.position - transform.position);
            if (direction.magnitude >= _chaseRange)
            {
                _enemy = null;
                return;
            }
            // move hostile agent if out of range
            if (direction.magnitude > _agent.Weapon.WeaponRange) _agent.MoveAgent(direction);
            // rotate agent to face target
            float angleDifference = Vector2.SignedAngle(transform.up, direction);
            _agent.RotateAgent(direction);
        }
        else if ((_nextWanderDestination - (Vector2)transform.position).magnitude <= _wanderDistanceThreshold)      // if agent reached wander destination, move to next one
        {
            //Vector2 wanderDirection = (_nextWanderDestination - (Vector2)transform.position);
            _nextWanderDestination = GetWanderAreaDestination();
        }
        else
        {
            float angleDifference = Vector2.SignedAngle(transform.up, _nextWanderDestination);
            _agent.RotateAgent(_nextWanderDestination - (Vector2)transform.position);
            //_agent.MoveAgent(_nextWanderDestination - (Vector2)transform.position);
            _agent.MoveAgent(transform.up);
        }
    }
    public void EvaluateTarget(CharacterAgent potentialTarget)
    {
        if (potentialTarget && potentialTarget.CurrentTeam != _agent.CurrentTeam && !_enemy) _enemy = potentialTarget;
    }

    private Vector2 GetWanderAreaDestination()
    {
        float xExtent = _wanderArea.bounds.extents.x;
        float yExtent = _wanderArea.bounds.extents.y;
        return new Vector2(Random.Range(-xExtent, xExtent), Random.Range(-yExtent, yExtent)) + (Vector2)_wanderArea.transform.position;
    }

}
