using Assets.Quests;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    List<QuestAbstSO> unfinishedQuests = new List<QuestAbstSO>();
    List<QuestAbstSO> finishedQuests = new List<QuestAbstSO>();

    public void FinishQuest(ObjectAbst object1, ObjectAbst object2) {

    }
    public void FinishQuest(ObjectAbst object1) {
    }

    public void unfinishQuest(ObjectAbst object1, ObjectAbst object2) {

    }
    public void unfinishQuest(ObjectAbst object1) {

    }

}
