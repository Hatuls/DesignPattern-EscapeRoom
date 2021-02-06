
using System;
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
    Button lastViewButtonSelected;
    [SerializeField] Button LeftArrow, RightArrow , ForwardArrow , BackwardArrow;
    ButtonSlot[] inventoryButtonsSlots;
    ObjectSO[] InventroyArray;
   public static UIManager GetInstance => _instance;
    private void Awake() {
        _instance = this;
        Init();
    }
    private void Init()
    {
        inventoryScript = Inventory.GetInstance;
        InventroyArray = inventoryScript.GetInventory;
        cmra = CameraController._instance;
        cmra.ViewChanged += SetActiveView;

        if (inventoryPF == null || inventoryPF.Length == 0 || cmra == null)
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
    bool inTransition = false;
    public void SetActiveView(View view)
    {
        if(lastViewButtonSelected != null)
        HighLightArrow(lastViewButtonSelected, false);

        SetVisabilityViewAllButtons(true);

        currentView = view;

        inTransition = false;
    }
    public void LookLeft(Button buttonGO) {
        if (inTransition == true)
            return ;

        inTransition = true;

        HideEveryThingExcept(buttonGO);
        cmra.SetView(currentView.LeftView);
    }
    public void LookForward(Button buttonGO) {
        if (inTransition == true)
            return;

        inTransition = false;

        HideEveryThingExcept(buttonGO);
        cmra.SetView(currentView.ForwardView);
    }
    public void LookBackward(Button buttonGO) {
        if (inTransition == true)
            return;

        inTransition = false;


        HideEveryThingExcept(buttonGO);
        cmra.SetView(currentView.BackwardsView);
    }
    public void LookRight(Button buttonGO) {
        if (inTransition == true)
            return;

        inTransition = false;

        cmra.SetView(currentView.RightView);
        HideEveryThingExcept(buttonGO);
    }

    void HideEveryThingExcept(Button dontHideMe) {
        if (ForwardArrow != dontHideMe && ForwardArrow.gameObject.activeSelf != false)
            ForwardArrow.gameObject.SetActive(false);

        if (BackwardArrow!= dontHideMe && BackwardArrow.gameObject.activeSelf != false)
            BackwardArrow.gameObject.SetActive(false);

        if (RightArrow!= dontHideMe && RightArrow.gameObject.activeSelf != false)
            RightArrow.gameObject.SetActive(false);

        if (LeftArrow != dontHideMe && LeftArrow.gameObject.activeSelf != false)
            LeftArrow.gameObject.SetActive(false);

        HighLightArrow(dontHideMe , true);
    }

  
    private void HighLightArrow(Button HighlightMeButton , bool toHighlight)
    {
        HighlightMeButton.gameObject.GetComponent<Image>().color= toHighlight? Color.yellow: Color.white;
     
        lastViewButtonSelected = HighlightMeButton;
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
