using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, MaskListener
{
    [SerializeField] UIInventoryBlock[] inventoryBlocks;
    private int currentEquippedIndex = 0;
    private void Start()
    {
        MaskChanger.Instance.AddListener(this);
    }

    public void OnMaskChange(Mask mask)
    {
        inventoryBlocks[currentEquippedIndex].Equipped(false);
        inventoryBlocks[(int)mask].Equipped(true);
        currentEquippedIndex = (int)mask;
    }
}
