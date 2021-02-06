
using UnityEngine;

public class ObjectInScene : MonoBehaviour
{
    [SerializeField] ObjectSO thisObject;
    public Quest quest;

    public ObjectSO GetObjectAbst { get { return thisObject; } }
    private void Awake() {
        if (quest.questSO != null) {
            quest.questSO.handlingScript = quest;
            thisObject.interactQuest = quest;
        }
    }


    public void GotClicked(ObjectSO selectedObject) 
        => thisObject.WorldInteraction(gameObject, selectedObject);
}
