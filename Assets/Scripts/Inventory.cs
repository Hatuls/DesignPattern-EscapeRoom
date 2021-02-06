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



    public ObjectSO[] GetInventory {
        get {
            if (inventory == null)
                inventory = new ObjectSO[5];

            return inventory;
        }
    }



    public void AddToInventory(ObjectSO item) {


        for (int i = 0; i < inventory.Length; i++) {

            if (inventory[i] == null) {
                inventory[i] = item;
                Debug.Log(item.objName + " Was added to slot number " + (i + 1) + ".");
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

    public bool CheckIfItemtIsSelectable(int ID)
        => CheckIfItemtIsSelectable(inventory[ID]);
    public bool CheckIfItemtIsSelectable(ObjectSO item) {
        if (!item)
            return false;


        if (item.inventoryInteraction == InventoryInteraction.Select)
            return true;

        return false;
    }
    public void ItemInventoryInteract(int ID)
        => ItemInventoryInteract(inventory[ID]);
    public void ItemInventoryInteract(ObjectSO item) 
        => item.UseObject();
}
