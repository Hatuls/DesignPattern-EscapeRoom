
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    [SerializeField] GameObject[] inventoryPF;
  
    [SerializeField] Button LeftArrows, RightArrows;
    [SerializeField] Sprite defaultSprite;
    ButtonSlot[] inventoryButtonsSlots;
    ObjectAbst[] inventory;
    public static UIManager GetInstance => _instance;
    private void Awake()
    {
        _instance = this;
        Init();
    }
    private void Init()
    {
        inventory = Inventory.GetInstance.GetInventory;
       

        if (inventoryPF == null || inventoryPF.Length == 0)
            return;

        if (!AssignComponenets())
            return;


        UpdateUIInventory();
    }
    private bool AssignComponenets() {
        inventoryButtonsSlots = GetComponentsInChildren<ButtonSlot>();


        if (inventoryButtonsSlots == null || inventoryButtonsSlots.Length == 0)
            return false;


        for (int i = 0; i < inventoryButtonsSlots.Length; i++)
            inventoryButtonsSlots[i].Init();
        return true;
    }  
    public void UpdateUIInventory() {

        AssignImagesToButtons();
        ResetButtons();
    }

    void AssignImagesToButtons()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null || inventory[i].GetObjectSprite() == null)
                inventoryButtonsSlots[i].AssignImage(defaultSprite);
            else
                inventoryButtonsSlots[i].AssignImage(inventory[i].GetObjectSprite());
        }
    }


    public void ResetButtons() {
        for (int i = 0; i < inventoryButtonsSlots.Length; i++)
            inventoryButtonsSlots[i].ResetButton();
    }

    public bool GetObjectFromItem(int buttonID) {
        if (buttonID < 0 || buttonID >= inventory.Length || inventory[buttonID] == null || !inventory[buttonID].canInteract)
            return false;

        Debug.Log("Now Selecting : " +inventory[buttonID].objName);

        InputManager._instance.SetUseObject(inventory[buttonID]);
        return true;
    }



}
