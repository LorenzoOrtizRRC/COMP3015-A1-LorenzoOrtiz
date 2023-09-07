using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorTrait : ScriptableObject
{
    // Overrides parts of the logic of behavior nodes. Divided into Movement and Combat traits, which is further divided into "Action" and "Conditional" traits.
    // Traits will override each other based on the following:
    // - If modifying the same variable(s), the trait last used will override the other similar traits (i.e. the trait at the last of the list of similar traits).

    public string TraitName { get => _traitName; }
    private string _traitName;

    // Apply trait's logic to referenced owner state.
    public abstract void DoTrait(State behaviorToModify);
}
