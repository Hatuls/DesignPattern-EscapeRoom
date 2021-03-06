﻿using UnityEngine;
using UnityEngine.EventSystems;
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
    [SerializeField] Button LeftArrow, RightArrow, ForwardArrow, BackwardArrow;
    ButtonSlot[] inventoryButtonsSlots;
    ObjectSO[] InventroyArray;
    [SerializeField] Image inspectPanelImage;
    Sprite spriteToInspect;
   
    public static UIManager GetInstance => _instance;
    private void Awake() {
        _instance = this;
        Init();
    }
    private void Init() {
        inventoryScript = Inventory.GetInstance;
        InventroyArray = inventoryScript.GetInventory;
        cmra = CameraController._instance;
        cmra.ViewChanged += SetActiveView;
        cmra.StartedTransition += StartTransition;
      
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


    void CloseBlackPanel()
    {
        if (inspectPanelImage.gameObject.activeSelf)
        {
            inspectPanelImage.gameObject.SetActive(false);
            spriteToInspect = null;
        }
    }
    public void InspectItem(Sprite toInspect) {
        if (!toInspect)
            return;
        if (spriteToInspect == toInspect)
         {
            CloseBlackPanel();
            return;
         }
        spriteToInspect = toInspect;
        inspectPanelImage.gameObject.SetActive(true);
        inspectPanelImage.sprite = toInspect;
       
    }

    private void Update()
    {
        if (spriteToInspect && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
             ResetButtons();
        
       
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
    void StartTransition() {
        if (!inTransition) {
            inTransition = true;
            HideEveryThingExcept(null);
        }
    }
   

    public void ResetButtonHighLight() {

        InputManager._instance.SetSelectedObject(null);
    
        ResetButtons();
    }
    public void ResetButtons() {
        for (int i = 0; i < inventoryButtonsSlots.Length; i++)
            inventoryButtonsSlots[i].ResetButton();

        CloseBlackPanel();
    }

    public bool GetObjectFromInventory(int buttonID) {
        if (buttonID < 0 || buttonID >= InventroyArray.Length || InventroyArray[buttonID] == null)
            return false;

        ObjectSO item = InventroyArray[buttonID];
        if (inventoryScript.CheckIfItemtIsSelectable(item))
        {
            InputManager._instance.SetSelectedObject(item);
            CloseBlackPanel();
        }
        else {
            if (spriteToInspect  || item.inventoryInteraction != InventoryInteraction.Inspect || spriteToInspect != item.GetInspectImage)
            inventoryScript.ItemInventoryInteract(item);
        }
       
            ResetButtons(buttonID);
        return item.inventoryInteraction != InventoryInteraction.ActivateQuest;

    }


    void ResetButtons(int TheOneToNotInclude) {
        for (int i = 0; i < inventoryButtonsSlots.Length; i++) {
            if (i == TheOneToNotInclude)
                continue;
            inventoryButtonsSlots[i].ResetButton();
        }


    }
    #endregion


















    #region View UI
    bool inTransition = false;
    public void SetActiveView(View view) {
        if (lastViewButtonSelected != null)
            HighLightArrow(lastViewButtonSelected, false);

        SetButtonsVisabilityByView(view);

        currentView = view;

        inTransition = false;
    }
    public void LookLeft(Button buttonGO) {
        if (inTransition == true)
            return;

        inTransition = true;

        HideEveryThingExcept(buttonGO);
        cmra.SetView(currentView.LeftView);
    }
    public void LookForward(Button buttonGO) {
        if (inTransition == true)
            return;

        inTransition = true;

        HideEveryThingExcept(buttonGO);
        cmra.SetView(currentView.ForwardView);
    }
    public void LookBackward(Button buttonGO) {
        if (inTransition == true)
            return;

        inTransition = true;


        HideEveryThingExcept(buttonGO);
        cmra.SetView(currentView.BackwardsView);
    }
    public void LookRight(Button buttonGO) {
        if (inTransition == true)
            return;

        inTransition = true;

        HideEveryThingExcept(buttonGO);
        cmra.SetView(currentView.RightView);
    }

    void HideEveryThingExcept(Button dontHideMe) {
        if (ForwardArrow != dontHideMe && ForwardArrow.gameObject.activeSelf != false)
            ForwardArrow.gameObject.SetActive(false);

        if (BackwardArrow != dontHideMe && BackwardArrow.gameObject.activeSelf != false)
            BackwardArrow.gameObject.SetActive(false);

        if (RightArrow != dontHideMe && RightArrow.gameObject.activeSelf != false)
            RightArrow.gameObject.SetActive(false);

        if (LeftArrow != dontHideMe && LeftArrow.gameObject.activeSelf != false)
            LeftArrow.gameObject.SetActive(false);
        if (dontHideMe != null)
            HighLightArrow(dontHideMe, true);
    }


    private void HighLightArrow(Button HighlightMeButton, bool toHighlight) {
        HighlightMeButton.gameObject.GetComponent<Image>().color = toHighlight ? Color.yellow : Color.white;

        lastViewButtonSelected = HighlightMeButton;
    }

    void SetButtonsVisabilityByView(View view) {


        if (ForwardArrow.gameObject.activeSelf != (view.ForwardView != null))
            ForwardArrow.gameObject.SetActive(view.ForwardView != null);

        if (BackwardArrow.gameObject.activeSelf != (view.BackwardsView != null))
            BackwardArrow.gameObject.SetActive((view.BackwardsView != null));

        if (RightArrow.gameObject.activeSelf != (view.RightView != null))
            RightArrow.gameObject.SetActive((view.RightView != null));

        if (LeftArrow.gameObject.activeSelf != (view.LeftView != null))
            LeftArrow.gameObject.SetActive((view.LeftView != null));




    }
    #endregion
}
