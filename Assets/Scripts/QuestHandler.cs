using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    [SerializeField]
    QuestAbstSO quest;
    [Header("Swaps the objects state on quest finish")]
    [SerializeField]
    GameObject[] objectsToSwap;
    // Start is called before the first frame update
    void Start()
    {
        quest.handlingScript = this;
    }
    public void SwapObjects() {
        foreach (GameObject obj in objectsToSwap) {
            obj.SetActive(!obj.activeSelf);
        }
    }
}
