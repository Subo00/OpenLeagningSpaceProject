using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMaskListener : MonoBehaviour, MaskListener
{
    public void OnMaskChange(Mask mask)
    {
        if(mask == Mask.BLUE)
        {
            gameObject.SetActive(true);
        } 
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        MaskChanger.Instance.AddListener(this);
        gameObject.SetActive(false);
    }
}
