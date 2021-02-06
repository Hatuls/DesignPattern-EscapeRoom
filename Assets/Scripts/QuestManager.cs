using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager _instance;

    [SerializeField]
    QuestHandler[] quests;
    private void Awake() {
        foreach (QuestHandler questHandler in quests) {
            questHandler.quest.handlingScript = questHandler;
            //questHandler.quest.GetSetIsCompleted = false;
        }
        _instance = this;
    }

    public void ChangeQuestState(ObjectAbst object1, ObjectAbst object2, bool questState) {
        foreach (QuestHandler questHandler in quests) {
            if (questHandler.quest.Check(object1, object2)) {
                questHandler.ChangeQuestState(questState);
                break;
            }
        }
    }
    public void ChangeQuestState(ObjectAbst object1, bool state) {
        ChangeQuestState(object1, null, state);
    }

    public void SwapQuestState(ObjectAbst object1, ObjectAbst object2) {
        foreach (QuestHandler questHandler in quests) {
            if (questHandler.quest.Check(object1, object2)) {
                questHandler.SwapQuestState();
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
    public Transform transform;

    public void SwapObjects() {
        foreach (GameObject obj in objectsToSwap) {
            obj.SetActive(!obj.activeSelf);
        }
    }
    [SerializeField]
    bool isCompleted = false;
    public bool GetSetIsCompleted {
        get => isCompleted;
        set {
            switch (value) {
                case true:
                    quest.Finish();
                    CameraController._instance.SetAnchor(transform);
                    isCompleted = true;
                    break;
                case false:
                    quest.Unfinish();
                    isCompleted = false;
                    break;
            }
        }
    }
    public void ChangeQuestState(bool state) {
        if (state != GetSetIsCompleted) {
            SwapObjects();
        }
        GetSetIsCompleted = state;
    }
    public void SwapQuestState() {
        SwapObjects();
        GetSetIsCompleted = !GetSetIsCompleted;
    }
}


