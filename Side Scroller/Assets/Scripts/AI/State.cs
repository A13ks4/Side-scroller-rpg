using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines a state for an ai
[CreateAssetMenu (menuName = "PlugableAi/State")]
public class State : ScriptableObject {

    public Action[] actions;
    public Decision decider;
    //does actions every fram, and checks if it needs to change state
    public void UpdateState(EnemyMovment em) {
        DoAction(em);
        Transition(em);
    }

    private void DoAction(EnemyMovment em) {
        for (int i = 0; i < actions.Length; ++i) {
            actions[i].Act(em);
        }
    }

    private void Transition(EnemyMovment em) {
        if (decider.Decide(em))
        {
            em.ChangeState(decider.newState);
        }
        else {
            em.ChangeState(decider.falseState);
        }
    }
	
}

