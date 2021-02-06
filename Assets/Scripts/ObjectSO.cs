using UnityEngine;

public enum InventoryInteraction { Select, View, ActivateQuest }
[CreateAssetMenu(fileName = "New Object", menuName = "Object/Generic")]
public class ObjectSO : ScriptableObject
{
    [System.NonSerialized]
    public Quest interactQuest;
    public string objName;
    [Tooltip("Whether I can pick it up. Will always try to pick up before interacting.")]
    public bool isPickUp;
    [Tooltip("Whether I can use it on scene. Will always try to pick up before interacting.")]
    public bool canInteract;
    [Tooltip("Whether the quest is toggleable or not.")]
    public bool questToggleable;
    [Tooltip("Whether I can select, view or use the item when it's in the inventory.")]
    public InventoryInteraction inventoryInteraction;
    [SerializeField] Sprite objectImage = null;
    public void ToPickUp(GameObject gameObject) {
        gameObject.SetActive(!gameObject.activeSelf);
        Inventory.GetInstance.AddToInventory(this);
    }


    public virtual void WorldInteraction(GameObject gameObject, ObjectSO selectedObject) {
        if (selectedObject == null && isPickUp) {
            //noraml interaction
            ToPickUp(gameObject);
            return;
        }
        else if (canInteract && interactQuest != null) {
            if (interactQuest.Check(this, selectedObject))
                if (questToggleable)
                    interactQuest.SwapQuestState();
                else
                    interactQuest.ChangeQuestState(true);
        }
    }
    public Sprite GetObjectSprite() {

        return objectImage;
    }
    public virtual void UseObject() {
        switch (inventoryInteraction) {
            case InventoryInteraction.Select:

                break;
            case InventoryInteraction.View:
                break;
            case InventoryInteraction.ActivateQuest:
                break;
        }
    }
}








