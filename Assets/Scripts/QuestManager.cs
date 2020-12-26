using System.Collections.Generic;
using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager _instance;

    [SerializeField]
    QuestHandler[] quests;
    List<QuestAbstSO> unfinishedQuests = new List<QuestAbstSO>();
    List<QuestAbstSO> finishedQuests = new List<QuestAbstSO>();
    private void Awake() {
        foreach (QuestHandler questHandler in quests) {
            questHandler.quest.handlingScript = questHandler;
        }
        _instance = this;
    }

    public void ChangeQuestState(ObjectAbst object1, ObjectAbst object2, bool questState) {
        foreach(QuestAbstSO quest in unfinishedQuests) {
            if (quest.Check(object1,object2)) {
                quest.ChangeQuestState(questState);
                break;
            }
        }
    }
    public void ChangeQuestState(ObjectAbst object1, bool state) {
        ChangeQuestState(object1, null , state);
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


