using System;
using UnityEngine;

[Serializable]
public class Quest
{
    public QuestSO questSO;
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
                    questSO.Finish();
                    CameraController._instance.SetAnchor(transform);
                    isCompleted = true;
                    break;
                case false:
                    questSO.Unfinish();
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
    public bool Check(ObjectSO object1, ObjectSO object2) => questSO.Check(object1, object2);
}


