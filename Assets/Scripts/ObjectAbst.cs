
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object/Generic")]
public class ObjectAbst : ScriptableObject
{

    public string Name;
    public bool canInteract;
    public bool isPickUp;
    public void ToPickUp()
    {
        if (!isPickUp)
            return;


        // add to inventory
    }


    public void WorldInteraction(ObjectAbst objectAabst)
    {
        if (!canInteract)
            return;

        if (objectAabst == null)
        {
            ToPickUp();
        }
        else
        {
            // QuestManager._instance.CheckInteraction(this , objectAabst);
        }


    }

    public virtual void UseObject() { }
}


[CreateAssetMenu(fileName = "Object Note", menuName = "Object/Note")]
public class ObjectNote : ObjectAbst
{
    [SerializeField] string ReadContent;

    public override void UseObject() { Debug.Log(ReadContent); }
}