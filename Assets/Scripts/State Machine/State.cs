using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    // has type of states for evaluation??? (i.e. passive states always checking conditions, vs. active states where only 1 active at a time)
    
    // start condition
    // end condition
    // public Func<bool> Condition;
    public List<StateCondition> Conditions { get { return _conditions; } }
    [SerializeField] private List<StateCondition> _conditions = new List<StateCondition>();

    public bool StateStatus { get; private set; } = false;

    public void Initialize() => StateStatus = false;

    public abstract bool CheckCondition();  // return true when condition is met. if true, StateMachine ticks DoState

    // return true when logic ends.
    public virtual bool DoState()
    {
        // only do state when all conditions are met
        foreach (StateCondition condition in _conditions)
            if (!condition.Evaluate()) return true;
        return false;
        // state executes logic either once or until a condition is met (i.e. while, do while)
        // using an Action instead to check if states are finished
    }
}
