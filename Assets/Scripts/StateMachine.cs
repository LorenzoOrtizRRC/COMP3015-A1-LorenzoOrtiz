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
    // list of ScriptableObjects to implement logic and behavior
    // behavior modules need a database to use and manipulate data with (i.e. to find and reference targets, weapons, etc.)
    
    // TRANSITIONS
    // Transitions between states are done using the StateMachine's OnStateEnd Action.
    // OnStateEnd is called by behavior nodes that have been completed, and by conditional nodes that may forcibly end an interruptible behavior node, if the behavior node can be interrupted.

    // NODE CHARACTERISTICS
    // The behavior tree will be based around modular nodes (ScriptableObjects) grouped into Traits.
    // Traits are subtrees of state nodes.

    [Header("States are executed from first to last.")]
    [SerializeField] private List<State> _behaviorStates = new List<State>();

    private State _currentState;

    public void InitializeStateMachine()
    {
        SetState(_behaviorStates[0]);
    }

    public void Tick()
    {
        // evaluate states, check conditions, do transitions, executes states.
        // check states
    }

    private void SetState(State newState) => _currentState = newState;

    // private bool EvaluateCondition() => test.Condition();
}
