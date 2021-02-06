
using TMPro;
using UnityEngine;

public class Inventory
{
    private static Inventory _instance;

    ObjectSO[] inventory;

    public static Inventory GetInstance {

        get {

            if (_instance == null)
                _instance = new Inventory();
            
            return _instance;        
        }
    
    }

    Inventory() {
        ResetInventory();
    }
    private void ResetInventory() {

        inventory = new ObjectSO[5];

        for (int i = 0; i < inventory.Length; i++)
            inventory[i] = null;
        
    }



    public ObjectSO[] GetInventory { get {
            if (inventory == null)
                inventory = new ObjectSO[5];
            
            return inventory; 
        }
    }



    public void AddToInventory(ObjectSO item)
    {
 

        for (int i = 0; i < inventory.Length; i++)
        {

            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.objName + " Was added to slot number " + (i+1) + ".");
                break;
            }
        }

        UIManager.GetInstance.UpdateUIInventory();
    }
    //public void RemoveFromInventory(ObjectAbst item)
    //{
    //    if (item == null)
    //        return;


    //    for (int i = 0; i < inventory.Length; i++)
    //    {

    //        if (inventory[i].objName == item.objName)
    //        {
    //            inventory[i] = null;

    //            break;
    //        }
    //    }
    //}

    public bool CheckIfObjectIsSelectable(int x)
    {
        if (inventory[x] == null)
            return false; ;




            inventory[x].UseObject();


            if (inventory[x].inventoryInteraction == InventoryInteraction.Select)
            {
                InputManager._instance.SetUseObject(inventory[x]);
                Debug.Log("Now Holding a " + inventory[x].objName + " Object.");
            }


        return true;
    }

    public void GetObjectFromInventory(int x) {
        InputManager._instance.SetUseObject(inventory[x]);
    }
}
