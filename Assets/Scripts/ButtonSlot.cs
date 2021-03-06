﻿
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlot : MonoBehaviour
{

    Button btn;
    Image img;
    ColorBlock clrblk;
    Color[] colorParams;
    bool isHighlighted = false;
    public void Init()
    {
        btn = GetComponent<Button>();
        img = transform.GetChild(0).GetComponent<Image>();
        clrblk = btn.colors;
        colorParams = new Color[4];


        colorParams[0] = clrblk.normalColor;
        colorParams[1] = clrblk.pressedColor;
        colorParams[2] = clrblk.selectedColor;
        colorParams[3] = clrblk.highlightedColor;
        
    }

    public void ResetButton()
    {
        if (clrblk.normalColor != colorParams[0])
            clrblk.normalColor = colorParams[0];

        if (clrblk.pressedColor != colorParams[1])
            clrblk.pressedColor = colorParams[1];

        if (clrblk.selectedColor != colorParams[2])
            clrblk.selectedColor = colorParams[2];

        if (clrblk.highlightedColor != colorParams[3])
            clrblk.highlightedColor = colorParams[3];

        btn.colors = clrblk;
        isHighlighted = false;
    }

    public void AssignAlpha(bool doAlpha) => img.color = doAlpha ? Color.clear : Color.white;

    public void AssignImage(Sprite sprite)
    {
        AssignAlpha(false);
        img.sprite = sprite;
    }
    public void ButtonGotClicked(int buttonID) {

        if (!isHighlighted )
        {
            if (UIManager.GetInstance.GetObjectFromInventory(buttonID))
            {
                clrblk.normalColor = colorParams[1];
                btn.colors = clrblk;  
                isHighlighted = true;
            }
         
        }
        else
        {

            ResetButton();
            UIManager.GetInstance.ResetButtonHighLight();
        }

    }

}
