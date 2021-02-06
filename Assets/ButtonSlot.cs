
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlot : MonoBehaviour
{

    Button btn;
    Image img;


    public void Init()
    {
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
    }


    public void AssignImage(Sprite sprite) {

        img.sprite = sprite;
    }

    public void ButtonGotClicked(int buttonID) { 
    
    
    }

}
