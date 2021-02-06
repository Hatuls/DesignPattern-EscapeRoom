
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    [SerializeField] GameObject[] inventoryPF;
    Inventory inventoryScript;
    [SerializeField] Button LeftArrows, RightArrows;
    [SerializeField] Sprite defaultSprite;
    ButtonSlot[] inventoryButtonsSlots;
    ObjectAbst[] InventroyArray;
    public static UIManager GetInstance => _instance;
    private void Awake()
    {
        _instance = this;
        Init();
    }
    private void Init()
    {
        inventoryScript = Inventory.GetInstance;
        InventroyArray = inventoryScript.GetInventory;
       

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
        for (int i = 0; i < InventroyArray.Length; i++)
        {
            if (InventroyArray[i] == null || InventroyArray[i].GetObjectSprite() == null)
                inventoryButtonsSlots[i].AssignAlpha(true);
            else
                inventoryButtonsSlots[i].AssignImage(InventroyArray[i].GetObjectSprite());
        }
    }


    public void ResetButtons() {
        for (int i = 0; i < inventoryButtonsSlots.Length; i++)
            inventoryButtonsSlots[i].ResetButton();
    }

    public bool GetObjectFromItem(int buttonID) {
        if (buttonID < 0 || buttonID >= InventroyArray.Length || InventroyArray[buttonID] == null || !InventroyArray[buttonID].canInteract)
            return false;

        if (inventoryScript.CheckIfObjectIsSelectable(buttonID))
        return true;

        
       
            ResetButtons();
            return false;
        
    }



}
