
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    [SerializeField] GameObject[] inventoryPF;
    Inventory inventoryScript;
    CameraController cmra;
    View currentView;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Button LeftArrow, RightArrow , ForwardArrow , BackwardArrow;
    ButtonSlot[] inventoryButtonsSlots;
    ObjectSO[] InventroyArray;
    public void SetActiveView(View view) { currentView = view;
        SetVisabilityViewAllButtons(true);
    }
    public static UIManager GetInstance => _instance;
    private void Awake() {
        _instance = this;
        Init();
    }
    private void Init() {
        inventoryScript = Inventory.GetInstance;
        InventroyArray = inventoryScript.GetInventory;
        cmra = CameraController._instance;

        if (inventoryPF == null || inventoryPF.Length == 0|| cmra == null)
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







    #region Ui Inventory
    public void UpdateUIInventory() {

        AssignImagesToButtons();
        ResetButtons();
    }

    void AssignImagesToButtons() {
        for (int i = 0; i < InventroyArray.Length; i++) {
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

    public bool GetObjectFromInventory(int buttonID) {
        if (buttonID < 0 || buttonID >= InventroyArray.Length || InventroyArray[buttonID] == null)
            return false;
        ObjectSO item = InventroyArray[buttonID];
        if (inventoryScript.CheckIfItemtIsSelectable(item)) 
            InputManager._instance.SetSelectedObject(item);
        else
        inventoryScript.ItemInventoryInteract(item);

        return item.inventoryInteraction != InventoryInteraction.ActivateQuest;

    }
    #endregion


















    #region View UI
    
    public void LookLeft() {
        cmra.SetView(currentView.LeftView);
    }
    public void LookForward() {
        cmra.SetView(currentView.ForwardView);
    }
    public void LookBackward() {

        cmra.SetView(currentView.BackwardsView);
    }
    public void LookRight() {
        cmra.SetView(currentView.RightView);
    }

    void HideEveryThingExcept() { 
    
    
    }
    void SetVisabilityViewAllButtons(bool ToActivate) {


        if (ForwardArrow.gameObject.activeSelf != ToActivate)
        ForwardArrow.gameObject.SetActive(ToActivate);

        if (BackwardArrow.gameObject.activeSelf != ToActivate)
            BackwardArrow.gameObject.SetActive(ToActivate);

        if (RightArrow.gameObject.activeSelf != ToActivate)
            RightArrow.gameObject.SetActive(ToActivate);

        if (LeftArrow.gameObject.activeSelf != ToActivate)
            LeftArrow.gameObject.SetActive(ToActivate);
    }
    #endregion
}
