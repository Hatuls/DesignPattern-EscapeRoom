using System.Collections.Generic;
using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    QuestHandler[] quests;
    List<QuestAbstSO> unfinishedQuests = new List<QuestAbstSO>();
    List<QuestAbstSO> finishedQuests = new List<QuestAbstSO>();
    private void Awake() {
        foreach (QuestHandler questHandler in quests) {
            questHandler.quest.handlingScript = questHandler;
        }
    }

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

[Serializable]
public class QuestHandler
{
    public QuestAbstSO quest;
    [Header("Swaps the objects state on quest finish")]
    public GameObject[] objectsToSwap;

    public void SwapObjects() {
        foreach (GameObject obj in objectsToSwap) {
            obj.SetActive(!obj.activeSelf);
        }
    }
}


