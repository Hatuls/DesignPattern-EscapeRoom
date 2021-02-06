using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Generic Quest")]
public class QuestAbstSO : ScriptableObject
{
    [HideInInspector]
    public QuestHandler handlingScript;
    public ObjectAbst object1ToComplete;
    public ObjectAbst object2ToComplete;
    public QuestAbstSO[] questsNeeded;
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
    public bool Check(ObjectAbst object1, ObjectAbst object2) {
        if ((object1 == object1ToComplete && object2 == object2ToComplete)
            || (object1 == object2ToComplete && object2 == object1ToComplete)) {
            bool finishedAllQuests = true;
            foreach (QuestAbstSO quest in questsNeeded) {
                finishedAllQuests &= quest.handlingScript.GetSetIsCompleted;
            }
            if (finishedAllQuests) {
                return true;
            }
        }
        return false;
    }
}

