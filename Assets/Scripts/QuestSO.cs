using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Generic Quest")]
public class QuestSO : ScriptableObject
{
    [NonSerialized]
    public Quest handlingScript;
    public ObjectSO object1ToComplete;
    public ObjectSO object2ToComplete;
    public QuestSO[] questsNeeded;
    public string finishedQuestMessage;
    public string unfinishedQuestMessage;

    public void Finish() {
        if (finishedQuestMessage != null && finishedQuestMessage != "")
            Debug.Log(finishedQuestMessage);
    }
    public void Unfinish() {
        if (unfinishedQuestMessage != null && unfinishedQuestMessage != "")
            Debug.Log(unfinishedQuestMessage);
    }
    public bool Check(ObjectSO object1, ObjectSO object2) {
        if ((object1 == object1ToComplete && object2 == object2ToComplete)
            || (object1 == object2ToComplete && object2 == object1ToComplete)) {
            bool finishedAllQuests = true;
            foreach (QuestSO quest in questsNeeded) {
                finishedAllQuests &= quest.handlingScript.GetSetIsCompleted;
            }
            if (finishedAllQuests) {
                return true;
            }
        }
        return false;
    }
}

