using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsRed : MonoBehaviour, MaskListener
{
    private SpriteRenderer spr;
    public void OnMaskChange(Mask mask)
    {
        if(mask == Mask.RED)
        {
            spr.enabled = true;
        }else
        {
            spr.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        MaskChanger.Instance.AddListener(this);
    }
}
