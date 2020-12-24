using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    List<QuestAbstSO> unfinishedQuests = new List<QuestAbstSO>();
    List<QuestAbstSO> finishedQuests = new List<QuestAbstSO>();

    public void SwapQuestState(ObjectAbst object1, ObjectAbst object2) {
        foreach(QuestAbstSO quest in unfinishedQuests) {
            if (quest.Check(object1,object2)) {
                quest.SwapQuestState();
                break;
            }
        }
    }
    public void SwapQuestState(ObjectAbst object1) {
        SwapQuestState(object1, null);
    }
}


