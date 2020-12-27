using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object/Generic")]
public class ObjectAbst : ScriptableObject
{
    internal GameObject gameObject;
    public string objName;
    public bool isSelectAble; // can i select it when its in my inventory
    public bool canInteract; // can i use it on scene
    public bool isPickUp; // pick it up
    public void ToPickUp() {
        gameObject.SetActive(!gameObject.activeSelf);
        Inventory._instance.AddToInventory(this);

    }


    public virtual void WorldInteraction(ObjectAbst objectAbst) {
        if (!canInteract) {
            return;
        }


        if (objectAbst == null && isPickUp) {
            //noraml interaction
            ToPickUp();
            return;
        }
        else {
            QuestManager._instance.ChangeQuestState(this, objectAbst, true);
        }
            
        


        


    }

    public virtual void UseObject() { }
}


[CreateAssetMenu(fileName = "Object Note", menuName = "Object/Note")]
public class ObjectNote : ObjectAbst
{
    // this function is used only when pressed a button 1-9 from inventory
    public override void UseObject() {
        QuestManager._instance.ChangeQuestState(this, true);
    }



}


[CreateAssetMenu(fileName = "Object ElectricitySwitch", menuName = "Object/ElectricitySwitch")]
public class ElectricitySwitch : ObjectAbst
{


    public override void WorldInteraction(ObjectAbst objectAbst) {
        if (!canInteract)
            return;

        if (objectAbst == null) {
            QuestManager._instance.SwapQuestState(this);
        }
    }
}
public class ElectricDoor : ObjectAbst
{
    [SerializeField] string ReadContent = "The Door Is Locked!";

    public override void UseObject() { Debug.Log(ReadContent); }
}
public class ACS : ObjectAbst //access control system - קודן
{
    [SerializeField] string ReadContent = "You Turned The Light To";

    //  public override void UseObject() { Debug.Log(ReadContent + " " + isLightOn); }
}
