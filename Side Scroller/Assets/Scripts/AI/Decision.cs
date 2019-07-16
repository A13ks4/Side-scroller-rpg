using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract class Deciosion for deciding between states
[CreateAssetMenu (menuName = "PlugableAi/Decision")]
public abstract class Decision : ScriptableObject {

    public State newState;
    public State falseState;

    public abstract bool Decide(EnemyMovment em);
}
