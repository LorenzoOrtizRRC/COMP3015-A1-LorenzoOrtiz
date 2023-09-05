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

    // STATEMACHINE NODES
    // Default movement.
    // Weapon (referenced behavior).

    // Traits. Traits select how to execute weapon behavior and movement (e.g. Reckless trait might use long ranged weapons at close range).
    // Traits change and modify the behaviors of base behaviors (e.g. "Hunting" modifies/changes base "Chase" behavior)

    // weapon handling traits - conditions for how weapons will be used (e.g. shotguns are used close-ranged)

    // chasing traits - behavior when pursuing target(s). Chasing activates when target is outside range of short-range threshold different from Weapons' short-range threshold
    // examples:
    // Hunting (weapon action) - Fire long-range weapons off-cooldown while pursuing targets

    // battle traits - behavior while in combat (not chasing)
    // examples:
    // kiting (movement action) - unit strafes (circling) aroud target while attacking. may change directions abruptly.
    // sniper (movement condition) - strives to stay near maximum range of their long-range weapons
    // Reckless (movement condition) - stay within short range of target (max range determined by a fraction of long range weapons' distance threshold)
    // Oppressive (weapon condition) - quickly move in melee range to fire short-ranged weapons, then back away
    // Suppressive (weapon action) - fire all weapons off-cooldown
    // Hoarder (weapon action) - fire weapons scarcely

    // about traits: multiple conditions can be active, only 1 action can be active

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

        // do current state behavior
        // state behavior's logic will be overriden by traits
    }

    private void SetState(State newState) => _currentState = newState;

    // private bool EvaluateCondition() => test.Condition();
}
