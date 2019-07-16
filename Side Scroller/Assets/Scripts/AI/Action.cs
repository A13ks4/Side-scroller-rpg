using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abastract class Action for actions to be executed
public abstract class Action : ScriptableObject
{

    public abstract void Act(EnemyMovment em);
} 


