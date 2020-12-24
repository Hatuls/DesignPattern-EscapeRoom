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
    bool isCompleted;
    public bool GetSetIsCompleted {
        get => isCompleted;
        set {
            switch (value) {
                case true:
                    Finish();
                    isCompleted = true;
                    break;
                case false:
                    Unfinish();
                    isCompleted = false;
                    break;
            }
        }
    }
    public virtual void Finish() {
        if (finishedQuestMessage != null) {
            Debug.Log(finishedQuestMessage);
        }
    }
    public virtual void Unfinish() {
        if (unfinishedQuestMessage != null) {
            Debug.Log(unfinishedQuestMessage);
        }
    }
    public void SwapQuestState() {
        isCompleted = !isCompleted;
        handlingScript.SwapObjects();
    }
    public bool Check(ObjectAbst object1, ObjectAbst object2) {
        if ((object1 == object1ToComplete && object2 == object2ToComplete)
            || (object1 == object2ToComplete && object2 == object1ToComplete)) {
            bool finishedAllQuests = true;
            foreach (QuestAbstSO quest in questsNeeded) {
                finishedAllQuests &= quest.GetSetIsCompleted;
            }
            if (finishedAllQuests) {
                return true;
            }
        }
        return false;
    }
}

