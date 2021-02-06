
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlot : MonoBehaviour
{

    Button btn;
    Image img;
    ColorBlock clrblk;
    Color[] colorParams;

    public void Init()
    {
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
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
    }
    public void AssignImage(Sprite sprite) {

        img.sprite = sprite;
    }

    public void ButtonGotClicked(int buttonID) {

        clrblk.normalColor = UIManager.GetInstance.GetObjectFromItem(buttonID) ? colorParams[1] : colorParams[0];
       
        btn.colors = clrblk;
    }

}
