using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Object", menuName = "Object/Generic")]
public class ObjectAbst : ScriptableObject
{
    internal GameObject gameObject;
    public string name;
    public bool isSelectAble;
    public bool canInteract;
    public bool isPickUp;
    public string emptySentence;
    public void ToPickUp()
    {


        if (!isPickUp)
            return;
    Inventory._instance.AddToInventory(this);
        
    }


    public virtual void WorldInteraction(ObjectAbst objectAbst)
    {
        if (!canInteract)
        {
            return;
        }
            

        if (objectAbst == null)
        {
            //noraml interaction
            Debug.Log(emptySentence);
            ToPickUp();
        }
        else
        {
            //unlockQuest
           
            // QuestManager._instance.CheckInteraction(this , objectAabst);
        }


    }

    public virtual void UseObject() { }
}


[CreateAssetMenu(fileName = "Object Note", menuName = "Object/Note")]
public class ObjectNote : ObjectAbst
{
    [SerializeField] string ReadContent;


    // this function is used only when pressed a button 1-9 from inventory
    public override void UseObject() {
        //gameObject.SetActive(false);
        Debug.Log(ReadContent);
        gameObject.GetComponentInChildren<TextMesh>().text = ReadContent;
        
    }
  

}
public class ElectricitySwitch : ObjectAbst
{
    [SerializeField] string ReadContent = "You Turned The Light To";
   public bool isLightOn = false;
    public bool GetSetLightSwitchState {
        get { return isLightOn; }
        set {
            isLightOn = value;

            if (!isLightOn)
            {
                // QuestManager._instance.UnFinishQuest(this)
            }
            else
            {
                // QuestManager._instance.FinishQuest(this)
            }

        }
    
    }


    public override void WorldInteraction(ObjectAbst objectAabst)
    {
        if (!canInteract)
          return;
        
        if (objectAabst == null)
        {
            GetSetLightSwitchState = !GetSetLightSwitchState;
            UseObject();
        }
    }

    public override void UseObject() { Debug.Log(ReadContent +" "+ isLightOn); }
}
public class ElectricDoor : ObjectAbst
{
    [SerializeField] string ReadContent = "The Door Is Locked!";
   
    public override void UseObject() { Debug.Log(ReadContent); }
}
public class ACS: ObjectAbst //access control system - קודן
{
    [SerializeField] string ReadContent = "You Turned The Light To";
    
  //  public override void UseObject() { Debug.Log(ReadContent + " " + isLightOn); }
}
