using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Collections;

public class StateMachine
{
    public Action OnStateEnd;

    [Header("References")]
    // put references here
    [Header("States")]
    [SerializeField] private State _wanderState;    // wander state is default state
    [SerializeField] private State _chaseState;
    [SerializeField] private State _attackState;
    [Header("AI Variables")]
    [SerializeField] private CharacterStats _targetCharacter;

    private State _currentState = null;

    public void InitializeStateMachine()
    {
        SetState(_wanderState);
    }

    public void Tick()
    {
        if (_currentState == null) _currentState = _wanderState;
        // check conditions and assign respective state

        // do state logic. if state finishes, reset current state.
        if (_currentState.DoState()) EndState();
    }

    private void SetState(State newState) => _currentState = newState;

    private void SwitchState(State newState) => _currentState = newState;

    private void EndState() => _currentState = null;

    private void SetTarget()
    {
        //
    }

    private void EvaluateTarget()
    {
        // check target distance and if target is still valid
    }
}
