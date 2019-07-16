using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal{

    public QuestType Qtype;

    public int requiredAmount;
    public int currentAmount;

    public bool isCompleate() {
        return (requiredAmount <= currentAmount);
    }
}

public enum QuestType {
    Kill,
    Gather
}