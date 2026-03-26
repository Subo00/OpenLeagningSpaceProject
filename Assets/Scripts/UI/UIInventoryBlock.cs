using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryBlock : MonoBehaviour
{
    private Image image;
    private Color equippedColor;
    private Color unequippedColor;
    private Color disabledColor;
    void Awake()
    {
        //gameObject.SetActive(false);
        
        image = GetComponent<Image>();
        
        equippedColor = image.color;
        unequippedColor = image.color;
        unequippedColor.a = 0.5f;
        disabledColor = Color.black;
        disabledColor.a = 0.5f;

        image.color = disabledColor;
    }

    
    public void Equipped(bool isEquipped)
    {
        image.color = isEquipped ? equippedColor : unequippedColor;
    }
}
